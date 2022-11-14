using System.Text;

namespace AbfSpectrogram;

public class FftWaveform
{
    public readonly double[] Values;
    public readonly double SampleRate;
    public readonly double Resolution;
    public readonly double RR;
    public readonly double[] Frequencies;

    public FftWaveform(double[] values, double sampleRate, bool fftIsHalf = true, double maxFreq = double.PositiveInfinity)
    {
        Values = values;
        SampleRate = sampleRate;

        double nyquestFrequency = SampleRate / 2;
        Resolution = nyquestFrequency / values.Length;
        if (!fftIsHalf)
            Resolution /= 2;

        RR = 1.0 / Resolution;

        Frequencies = Enumerable.Range(0, values.Length)
            .Select(x => x * Resolution)
            .ToArray();

        if (Frequencies.Last() > maxFreq)
        {
            int count = Frequencies.Where(x => x <= maxFreq).Count();
            Values = Values.Take(count).ToArray();
            Frequencies = Frequencies.Take(count).ToArray();
        }
    }

    public override string ToString()
    {
        return $"FFT with {Values.Length} samples " +
            $"({Values.Length / SampleRate} sec) " +
            $"{Resolution} Hz resolution";
    }
}
