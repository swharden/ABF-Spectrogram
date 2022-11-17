namespace AbfSpectrogram.Gui
{
    partial class SpectrogramForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblFft = new System.Windows.Forms.Label();
            this.btnLoadABF = new System.Windows.Forms.Button();
            this.nudFftSize = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.nudMaxFreq = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.lblFreq = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.formsPlot1 = new ScottPlot.FormsPlot();
            this.formsPlot2 = new ScottPlot.FormsPlot();
            this.label1 = new System.Windows.Forms.Label();
            this.nudStep = new System.Windows.Forms.NumericUpDown();
            this.lblStep = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nudFftSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaxFreq)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudStep)).BeginInit();
            this.SuspendLayout();
            // 
            // lblFft
            // 
            this.lblFft.AutoSize = true;
            this.lblFft.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.lblFft.Location = new System.Drawing.Point(185, 49);
            this.lblFft.Name = "lblFft";
            this.lblFft.Size = new System.Drawing.Size(245, 25);
            this.lblFft.TabIndex = 3;
            this.lblFft.Text = "1.234 sec (0.34 Hz resolution)";
            // 
            // btnLoadABF
            // 
            this.btnLoadABF.Location = new System.Drawing.Point(12, 12);
            this.btnLoadABF.Name = "btnLoadABF";
            this.btnLoadABF.Size = new System.Drawing.Size(112, 64);
            this.btnLoadABF.TabIndex = 14;
            this.btnLoadABF.Text = "Load ABF";
            this.btnLoadABF.UseVisualStyleBackColor = true;
            this.btnLoadABF.Click += new System.EventHandler(this.btnLoadABF_Click);
            // 
            // nudFftSize
            // 
            this.nudFftSize.Location = new System.Drawing.Point(266, 15);
            this.nudFftSize.Maximum = new decimal(new int[] {
            25,
            0,
            0,
            0});
            this.nudFftSize.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudFftSize.Name = "nudFftSize";
            this.nudFftSize.Size = new System.Drawing.Size(112, 31);
            this.nudFftSize.TabIndex = 15;
            this.nudFftSize.Value = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.nudFftSize.ValueChanged += new System.EventHandler(this.nudFftSize_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(185, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 25);
            this.label4.TabIndex = 16;
            this.label4.Text = "FFT Size";
            // 
            // nudMaxFreq
            // 
            this.nudMaxFreq.Location = new System.Drawing.Point(953, 17);
            this.nudMaxFreq.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.nudMaxFreq.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudMaxFreq.Name = "nudMaxFreq";
            this.nudMaxFreq.Size = new System.Drawing.Size(112, 31);
            this.nudMaxFreq.TabIndex = 18;
            this.nudMaxFreq.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.nudMaxFreq.ValueChanged += new System.EventHandler(this.nudMaxFreq_ValueChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(780, 17);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(167, 25);
            this.label7.TabIndex = 19;
            this.label7.Text = "Max Frequency (Hz)";
            // 
            // btnGenerate
            // 
            this.btnGenerate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGenerate.Location = new System.Drawing.Point(1225, 17);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(138, 59);
            this.btnGenerate.TabIndex = 20;
            this.btnGenerate.Text = "Generate Spectrogram";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // lblFreq
            // 
            this.lblFreq.AutoSize = true;
            this.lblFreq.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.lblFreq.Location = new System.Drawing.Point(780, 51);
            this.lblFreq.Name = "lblFreq";
            this.lblFreq.Size = new System.Drawing.Size(180, 25);
            this.lblFreq.TabIndex = 21;
            this.lblFreq.Text = "123 frequency points";
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar1.Location = new System.Drawing.Point(12, 96);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(1351, 34);
            this.progressBar1.TabIndex = 22;
            // 
            // formsPlot1
            // 
            this.formsPlot1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.formsPlot1.Location = new System.Drawing.Point(12, 138);
            this.formsPlot1.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.formsPlot1.Name = "formsPlot1";
            this.formsPlot1.Size = new System.Drawing.Size(1351, 225);
            this.formsPlot1.TabIndex = 23;
            // 
            // formsPlot2
            // 
            this.formsPlot2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.formsPlot2.Location = new System.Drawing.Point(15, 373);
            this.formsPlot2.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.formsPlot2.Name = "formsPlot2";
            this.formsPlot2.Size = new System.Drawing.Size(1352, 483);
            this.formsPlot2.TabIndex = 24;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(471, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 25);
            this.label1.TabIndex = 25;
            this.label1.Text = "Step Size (sec):";
            // 
            // nudStep
            // 
            this.nudStep.Location = new System.Drawing.Point(604, 15);
            this.nudStep.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.nudStep.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudStep.Name = "nudStep";
            this.nudStep.Size = new System.Drawing.Size(112, 31);
            this.nudStep.TabIndex = 26;
            this.nudStep.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.nudStep.ValueChanged += new System.EventHandler(this.nudStep_ValueChanged);
            // 
            // lblStep
            // 
            this.lblStep.AutoSize = true;
            this.lblStep.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.lblStep.Location = new System.Drawing.Point(471, 49);
            this.lblStep.Name = "lblStep";
            this.lblStep.Size = new System.Drawing.Size(170, 25);
            this.lblStep.TabIndex = 27;
            this.lblStep.Text = "12.34 sec (123 FFTs)";
            // 
            // SpectrogramForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1382, 870);
            this.Controls.Add(this.lblStep);
            this.Controls.Add(this.nudStep);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.formsPlot2);
            this.Controls.Add(this.formsPlot1);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.lblFreq);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.nudMaxFreq);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.nudFftSize);
            this.Controls.Add(this.btnLoadABF);
            this.Controls.Add(this.lblFft);
            this.Name = "SpectrogramForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ABF Spectrogram Generator";
            this.Load += new System.EventHandler(this.SpectrogramForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudFftSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaxFreq)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudStep)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Label lblFft;
        private Button btnLoadABF;
        private NumericUpDown nudFftSize;
        private Label label4;
        private NumericUpDown nudMaxFreq;
        private Label label7;
        private Button btnGenerate;
        private Label lblFreq;
        private ProgressBar progressBar1;
        private ScottPlot.FormsPlot formsPlot1;
        private ScottPlot.FormsPlot formsPlot2;
        private Label label1;
        private NumericUpDown nudStep;
        private Label lblStep;
    }
}