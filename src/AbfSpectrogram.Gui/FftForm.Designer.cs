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
            this.tableLayoutPanel1.SuspendLayout();
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
            this.tableLayoutPanel1.Size = new System.Drawing.Size(928, 604);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // formsPlot1
            // 
            this.formsPlot1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.formsPlot1.Location = new System.Drawing.Point(6, 5);
            this.formsPlot1.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.formsPlot1.Name = "formsPlot1";
            this.formsPlot1.Size = new System.Drawing.Size(916, 292);
            this.formsPlot1.TabIndex = 0;
            // 
            // formsPlot2
            // 
            this.formsPlot2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.formsPlot2.Location = new System.Drawing.Point(6, 307);
            this.formsPlot2.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.formsPlot2.Name = "formsPlot2";
            this.formsPlot2.Size = new System.Drawing.Size(916, 292);
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
            this.btnExport.Size = new System.Drawing.Size(127, 34);
            this.btnExport.TabIndex = 3;
            this.btnExport.Text = "Export Data";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // FftForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(952, 668);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.cbAutoScale);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "FftForm";
            this.Text = "ABF FFT";
            this.Load += new System.EventHandler(this.FftForm_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
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
    }
}