﻿using System;
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

            int count = (int)(RecordingLengthSec / StepSizeSec);
            int maxIndex = ABF.Values.Length;
            int[] indexes = Enumerable.Range(0, count)
                .Select(x => x * StepSizePoints)
                //.Where(x => x < maxIndex)
                .ToArray();

            if (!indexes.Any())
                throw new InvalidOperationException();

            return indexes;
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            int[] indexes = GetWindowIndexes();
            progressBar1.Value = 0;
            progressBar1.Maximum = indexes.Length;
            progressBar1.Visible = true;

            double[,] data = new double[SpectrogramRowCount, indexes.Length];

            for (int i = 0; i < indexes.Length; i++)
            {
                progressBar1.Value = i;
                double[] segment = new double[WindowPoints];
                Array.Copy(ABF!.Values, indexes[i], segment, 0, segment.Length);
                WindowFunction.ApplyInPlace(segment);
                double[] fft = FftSharp.Transform.FFTmagnitude(segment);
                for (int j = 0; j < SpectrogramRowCount; j++)
                {
                    data[SpectrogramRowCount - 1 - j, i] = Math.Log10(fft[j]);
                    //data[SpectrogramRowCount - 1 - j, i] = fft[j];
                }
            }

            progressBar1.Visible = false;

            formsPlot2.Plot.Clear();
            var hm = formsPlot2.Plot.AddHeatmap(data, lockScales: false);
            hm.XMax = ABF!.LengthMinutes;
            hm.YMax = (double)nudMaxFreq.Value;
            formsPlot2.Plot.XLabel("Time (minutes)");
            formsPlot2.Plot.YLabel("Frequency (Hz)");

            formsPlot2.Refresh();
        }
    }
}