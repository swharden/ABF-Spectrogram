using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AbfSpectrogram.Gui
{
    public partial class SpectrogramForm : Form
    {
        AbfRecording? ABF;
        double RecordingLengthSec => ABF?.LengthSeconds ?? 0;
        double SampleRate => ABF?.SampleRate ?? 0;
        double WindowLengthSec => ABF?.LengthSeconds ?? 0;
        int WindowPoints => FftSize;
        double StepSizeSec => (double)nudStep.Value;
        int StepSizePoints => (int)(StepSizeSec * SampleRate);
        int FftSize => (int)Math.Pow(2, (double)nudFftSize.Value);
        double FftSizeSec => FftSize / SampleRate;
        double FftResolution => (double)SampleRate / FftSize;
        double[,]? FftData = null;

        int SpectrogramRowCount => (int)((double)nudMaxFreq.Value / FftResolution);
        FftSharp.Windows.Hanning WindowFunction = new();

        public SpectrogramForm()
        {
            InitializeComponent();
            progressBar1.Visible = false;
        }

        private void SpectrogramForm_Load(object sender, EventArgs e)
        {
            lblFft.Text = string.Empty;
            lblStep.Text = string.Empty;
            lblFreq.Text = string.Empty;
        }

        private void btnLoadABF_Click(object sender, EventArgs e)
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
            UpdateLabels();
            formsPlot1.Plot.Clear();
            formsPlot1.Plot.AddSignal(ABF.Values, ABF.SampleRate * 60);
            formsPlot1.Plot.XLabel("Time (minutes)");
            formsPlot1.Plot.AxisAuto(horizontalMargin: 0);
            formsPlot1.Refresh();
        }

        private void nudFftSize_ValueChanged(object sender, EventArgs e) => UpdateLabels();
        private void nudMaxFreq_ValueChanged(object sender, EventArgs e) => UpdateLabels();
        private void nudStep_ValueChanged(object sender, EventArgs e) => UpdateLabels();
        private void UpdateLabels()
        {
            lblFft.Text = $"{FftSizeSec:N2} sec ({FftResolution:N2} Hz resolution)";
            lblStep.Text = $"{StepSizeSec:N2} sec ({GetWindowIndexes().Length} FFTs)";
            lblFreq.Text = $"{SpectrogramRowCount} frequency points";
        }

        int[] GetWindowIndexes()
        {
            if (ABF is null)
                return Array.Empty<int>();

            List<int> indexes = new();
            int i = 0;
            while (i < ABF.Values.Length - 1 - FftSize)
            {
                indexes.Add(i);
                i += StepSizePoints;
            }
            return indexes.ToArray();
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            int[] indexes = GetWindowIndexes();
            progressBar1.Value = 0;
            progressBar1.Maximum = indexes.Length;
            progressBar1.Visible = true;

            FftData = new double[SpectrogramRowCount, indexes.Length];

            for (int i = 0; i < indexes.Length; i++)
            {
                progressBar1.Value = i;
                double[] segment = new double[WindowPoints];
                Array.Copy(ABF!.Values, indexes[i], segment, 0, segment.Length);
                WindowFunction.ApplyInPlace(segment);
                double[] fft = FftSharp.Transform.FFTmagnitude(segment);
                for (int j = 0; j < SpectrogramRowCount; j++)
                {
                    FftData[SpectrogramRowCount - 1 - j, i] = fft[j];
                }
            }

            ScaleToMean(FftData, 5);

            progressBar1.Visible = false;

            formsPlot2.Plot.Clear();
            var hm = formsPlot2.Plot.AddHeatmap(FftData, lockScales: false);
            hm.XMax = ABF!.LengthMinutes;
            hm.YMax = (double)nudMaxFreq.Value;
            formsPlot2.Plot.AxisAuto(0, 0);
            formsPlot2.Plot.XLabel("Time (minutes)");
            formsPlot2.Plot.YLabel("Frequency (Hz)");

            UpdateIntensity();
        }

        private void ScaleToMean(double[,] data, double newMean = 100)
        {
            double sum = 0;

            for (int i = 0; i < data.GetLength(0); i++)
                for (int j = 0; j < data.GetLength(1); j++)
                    sum += data[i, j];

            double oldMean = sum / (data.GetLength(0) * data.GetLength(1));

            for (int i = 0; i < data.GetLength(0); i++)
                for (int j = 0; j < data.GetLength(1); j++)
                    data[i, j] = data[i, j] / oldMean * newMean;
        }

        private void nudIntensity_ValueChanged(object sender, EventArgs e) => UpdateIntensity();

        private void UpdateIntensity()
        {
            ScottPlot.Plottable.Heatmap hm = (ScottPlot.Plottable.Heatmap)formsPlot2.Plot.GetPlottables().First();
            hm.Update(FftData, min: 0, max: (double)nudIntensity.Value);
            formsPlot2.Refresh();
        }
    }
}
