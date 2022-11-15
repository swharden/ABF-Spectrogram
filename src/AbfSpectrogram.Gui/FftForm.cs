using ScottPlot.Plottable;
using System.Text;

namespace AbfSpectrogram.Gui
{
    public partial class FftForm : Form
    {
        AbfRecording? ABF = null;

        public FftForm()
        {
            InitializeComponent();
            formsPlot1.PlottableDragged += (s, e) => UpdateFFT();
        }

        private void FftForm_Load(object sender, EventArgs e)
        {
        }

        private void BtnLoad_Click(object? sender, EventArgs e)
        {
            OpenFileDialog diag = new()
            {
                Title = "Select ABF File",
                Filter = "ABF files (*.abf)|*.abf",
            };

            if (diag.ShowDialog() == DialogResult.OK)
            {
                LoadAbf(diag.FileName);
            }
        }

        private void LoadAbf(string abfFilePath)
        {
            ABF = new AbfRecording(abfFilePath);

            formsPlot1.Plot.Clear();
            formsPlot1.Plot.AddSignal(ABF.Values, ABF.SampleRate);
            var vline = formsPlot1.Plot.AddVerticalLine(ABF.LengthSeconds / 2, width: 2);
            vline.DragEnabled = true;
            vline.DragLimitMin = 0;
            vline.DragLimitMax = ABF.LengthSeconds;

            formsPlot1.Plot.Title(Path.GetFileNameWithoutExtension(ABF.Path));
            formsPlot1.Plot.XLabel("Time (seconds)");
            formsPlot1.Plot.AxisAuto();
            formsPlot1.Refresh();

            UpdateFFT();
        }

        private void UpdateFFT()
        {
            if (ABF is null)
                return;

            var vlines = formsPlot1.Plot.GetPlottables().OfType<ScottPlot.Plottable.VLine>();
            if (!vlines.Any())
                return;

            ScottPlot.Plottable.VLine vline = vlines.First();
            int powerOfTwo = (int)nudFftSize.Value;
            int fftSamples = 1 << powerOfTwo;
            int firstSampleIndex = (int)(ABF.SampleRate * vline.X);
            int lastSampleIndex = firstSampleIndex + fftSamples;
            if (lastSampleIndex >= ABF.Values.Length)
            {
                formsPlot2.Plot.Clear();
                formsPlot2.Refresh();
                return;
            }

            var oldLimits = formsPlot2.Plot.GetAxisLimits();

            FftWaveform fft = ABF.GetFft(startTimeSec: vline.X, powerOfTwo: powerOfTwo, maxFreq: 100);

            double fftTimeSec = (double)fftSamples / ABF.SampleRate;
            lblFftSize.Text = $"{fftTimeSec:N3} sec ({fft.Resolution:N2} Hz resolution)";

            formsPlot2.Plot.Clear();
            formsPlot2.Plot.AddSignal(fft.Values, 1.0 / fft.Resolution);
            if (cbAutoScale.Checked)
                formsPlot2.Plot.AxisAuto(horizontalMargin: 0);
            else
                formsPlot2.Plot.SetAxisLimits(oldLimits);
            formsPlot2.Plot.Title($"FFT at {vline.X:N2} sec ({vline.X / 60:N2} min)");
            formsPlot2.Plot.YLabel("Power (RMS²)");
            formsPlot2.Plot.XLabel("Frequency (Hz)");
            formsPlot2.Refresh();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            var vlines = formsPlot1.Plot.GetPlottables().OfType<ScottPlot.Plottable.VLine>();
            if (!vlines.Any())
                return;
            ScottPlot.Plottable.VLine vline = vlines.First();

            var signals = formsPlot2.Plot.GetPlottables().OfType<ScottPlot.Plottable.SignalPlot>();
            if (!signals.Any())
                return;
            ScottPlot.Plottable.SignalPlot fftSignal = signals.First();

            double[] powers = fftSignal.Ys;
            double[] frequencies = Enumerable.Range(0, powers.Length)
                .Select(x => x * fftSignal.SamplePeriod)
                .ToArray();

            StringBuilder sb = new();
            sb.AppendLine("Frequency (Hz), Power (RMS²)");
            for (int i = 0; i < powers.Length; i++)
            {
                sb.AppendLine($"{frequencies[i]}, {powers[i]}");
            }

            SaveFileDialog savefile = new();
            savefile.FileName = $"{Path.GetFileNameWithoutExtension(ABF?.Path)}" +
                $"-FFT-{Math.Round(vline.X, 2)}sec.csv";
            savefile.Filter = "CSV Files (*.csv)|*.csv";
            if (savefile.ShowDialog() == DialogResult.OK)
            {
                string saveFilePath = savefile.FileName;
                File.WriteAllText(saveFilePath, sb.ToString());
            }
        }

        private void nudFftSize_ValueChanged(object sender, EventArgs e)
        {
            UpdateFFT();
        }
    }
}