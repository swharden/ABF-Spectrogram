﻿using FftSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbfSpectrogram;

public class AbfRecording
{
    public readonly string Path;
    public readonly double[] Values;
    public readonly int SampleRate;
    public double LengthSeconds => Values.Length / SampleRate;
    public double LengthMinutes => LengthSeconds / 60;

    public AbfRecording(string path)
    {
        Path = System.IO.Path.GetFullPath(path);

        AbfSharp.ABF abf = new(path, true);

        bool isGapFree = abf.Header.nOperationMode == 3;
        float[] values = isGapFree
            ? abf.GetSweep(0)
            : Enumerable.Range(0, abf.Header.SweepCount).SelectMany(x => abf.GetSweep(x)).ToArray();

        Values = Array.ConvertAll(values, x => (double)x);

        SampleRate = abf.Header.SampleRate;
    }

    public override string ToString()
    {
        return $"Samples: {Values.Length:N0}" +
            $"Sample Rate: {SampleRate:N0} Hz" +
            $"Length: {LengthMinutes:N2} min";
    }

    private int GetIndex(double timeSec) => (int)(timeSec * SampleRate);

    public FftWaveform GetFft(double startTimeSec, bool dB = false, int powerOfTwo = 16, bool zeroDC = true, double maxFreq = double.PositiveInfinity)
    {
        int firstIndex = GetIndex(startTimeSec);
        int fftLength = 1 << powerOfTwo;

        FftSharp.Window hanningWindow = new FftSharp.Windows.Hanning();
        double[] window = hanningWindow.Create(fftLength, true);

        // isolate real values for this window
        double[] windowValues = new double[fftLength];
        for (int i = 0; i < fftLength; i++)
            windowValues[i] = Values[firstIndex + i];

        // remove DC
        double sum = 0;
        for (int i = 0; i < fftLength; i++)
            sum += windowValues[i];
        double mean = sum / fftLength;
        for (int i = 0; i < fftLength; i++)
            sum -= mean;

        // apply window
        for (int i = 0; i < fftLength; i++)
            windowValues[i] = windowValues[i] * window[i];

        // create complex buffer
        Complex[] buffer = new Complex[fftLength];
        for (int i = 0; i < fftLength; i++)
            buffer[i] = new(Values[firstIndex + i] * window[i], 0);

        // perform FFT
        Transform.FFT(buffer);

        // get the real result
        double[] real = new double[buffer.Length / 2];
        for (int i = 0; i < real.Length; i++)
            real[i] = buffer[i].Magnitude;

        if (dB)
        {
            for (int i = 0; i < real.Length; i++)
                real[i] = 20 * Math.Log10(real[i]);
        }

        if (zeroDC)
        {
            real[0] = 0;
            real[1] = 0;
        }

        return new FftWaveform(real, SampleRate, true, maxFreq);
    }
}
