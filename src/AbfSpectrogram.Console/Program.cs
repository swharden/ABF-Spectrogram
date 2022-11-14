using AbfSpectrogram;
using FftSharp;

string abfPath = @"C:\Users\swharden\Documents\temp\2022_10_28_DIC3_0000.abf";
Console.WriteLine($"Reading: {abfPath}");

AbfRecording abf = new(abfPath);
//MakeFfts(abf);
MakeSpectrogram(abf);

static void MakeFfts(AbfRecording abf)
{
    FftWaveform baseline = abf.GetFft(startTimeSec: 10 * 60);
    Console.WriteLine(baseline);

    FftWaveform drug = abf.GetFft(startTimeSec: 15 * 60);
    Console.WriteLine(drug);

    ScottPlot.Plot plt = new();
    plt.AddSignal(baseline.Values, baseline.RR, label: "10 min");
    plt.AddSignal(drug.Values, drug.RR, label: "15 min");

    plt.SetAxisLimitsX(-5, 100);
    plt.YLabel("Power (RMS²)");
    plt.XLabel("Frequency (Hz)");
    plt.Legend(true, ScottPlot.Alignment.UpperRight);

    ScottPlot.FormsPlotViewer viewer = new(plt);
    viewer.ShowDialog();
}

static void MakeSpectrogram(AbfRecording abf)
{
    int fftSize = 1 << 16;
    double fftStepSeconds = 5;
    int fftStep = (int)(abf.SampleRate * fftStepSeconds);
    Spectrogram.SpectrogramGenerator sp = new(abf.SampleRate, fftSize, fftStep, maxFreq: 100);
    sp.Add(abf.Values);
    sp.SaveImage("spectrogram.png", intensity: 30_000);

    double[] totalFftPower  = sp.GetFFTs().Select(x => x.Sum()).ToArray();
    ScottPlot.Plot plt = new();
    plt.AddSignal(totalFftPower, 1.0 / (fftStepSeconds / 60));
    ScottPlot.FormsPlotViewer viewer = new(plt);
    plt.YLabel("Total Spectral Power (RMS²)");
    plt.XLabel("Time (minutes)");
    viewer.ShowDialog();
}