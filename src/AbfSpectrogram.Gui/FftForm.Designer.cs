namespace AbfSpectrogram.Gui
{
    partial class FftForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.formsPlot1 = new ScottPlot.FormsPlot();
            this.formsPlot2 = new ScottPlot.FormsPlot();
            this.btnLoad = new System.Windows.Forms.Button();
            this.cbAutoScale = new System.Windows.Forms.CheckBox();
            this.btnExport = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.nudFftSize = new System.Windows.Forms.NumericUpDown();
            this.lblFftSize = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudFftSize)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.formsPlot1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.formsPlot2, 0, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 52);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1189, 864);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // formsPlot1
            // 
            this.formsPlot1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.formsPlot1.Location = new System.Drawing.Point(6, 5);
            this.formsPlot1.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.formsPlot1.Name = "formsPlot1";
            this.formsPlot1.Size = new System.Drawing.Size(1177, 422);
            this.formsPlot1.TabIndex = 0;
            // 
            // formsPlot2
            // 
            this.formsPlot2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.formsPlot2.Location = new System.Drawing.Point(6, 437);
            this.formsPlot2.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.formsPlot2.Name = "formsPlot2";
            this.formsPlot2.Size = new System.Drawing.Size(1177, 422);
            this.formsPlot2.TabIndex = 1;
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(12, 12);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(112, 34);
            this.btnLoad.TabIndex = 1;
            this.btnLoad.Text = "Load ABF";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.BtnLoad_Click);
            // 
            // cbAutoScale
            // 
            this.cbAutoScale.AutoSize = true;
            this.cbAutoScale.Checked = true;
            this.cbAutoScale.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbAutoScale.Location = new System.Drawing.Point(130, 16);
            this.cbAutoScale.Name = "cbAutoScale";
            this.cbAutoScale.Size = new System.Drawing.Size(117, 29);
            this.cbAutoScale.TabIndex = 2;
            this.cbAutoScale.Text = "AutoScale";
            this.cbAutoScale.UseVisualStyleBackColor = true;
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(253, 12);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(176, 34);
            this.btnExport.TabIndex = 3;
            this.btnExport.Text = "Export FFT Data";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(435, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 25);
            this.label1.TabIndex = 5;
            this.label1.Text = "FFT Size (2^x):";
            // 
            // nudFftSize
            // 
            this.nudFftSize.Location = new System.Drawing.Point(565, 14);
            this.nudFftSize.Maximum = new decimal(new int[] {
            24,
            0,
            0,
            0});
            this.nudFftSize.Minimum = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.nudFftSize.Name = "nudFftSize";
            this.nudFftSize.Size = new System.Drawing.Size(78, 31);
            this.nudFftSize.TabIndex = 6;
            this.nudFftSize.Value = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.nudFftSize.ValueChanged += new System.EventHandler(this.nudFftSize_ValueChanged);
            // 
            // lblFftSize
            // 
            this.lblFftSize.AutoSize = true;
            this.lblFftSize.Location = new System.Drawing.Point(649, 16);
            this.lblFftSize.Name = "lblFftSize";
            this.lblFftSize.Size = new System.Drawing.Size(176, 25);
            this.lblFftSize.TabIndex = 7;
            this.lblFftSize.Text = "ABF not yet loaded...";
            // 
            // FftForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1213, 928);
            this.Controls.Add(this.lblFftSize);
            this.Controls.Add(this.nudFftSize);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.cbAutoScale);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "FftForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ABF Frequency Analysis";
            this.Load += new System.EventHandler(this.FftForm_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudFftSize)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private ScottPlot.FormsPlot formsPlot1;
        private ScottPlot.FormsPlot formsPlot2;
        private Button btnLoad;
        private CheckBox cbAutoScale;
        private Button btnExport;
        private Label label1;
        private NumericUpDown nudFftSize;
        private Label lblFftSize;
    }
}