namespace ImageProcessingDemo.Dialogs
{
    partial class DifferencesPaletteForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DifferencesPaletteForm));
            this.mainGroupBox = new System.Windows.Forms.GroupBox();
            this.differenceColorsImageViewer = new Vintasoft.Imaging.UI.ImageViewer();
            this.maxPointLabel = new System.Windows.Forms.Label();
            this.minPointLabel = new System.Windows.Forms.Label();
            this.paletteGammaComboBox = new System.Windows.Forms.ComboBox();
            this.criticalLevelTrackBar = new System.Windows.Forms.TrackBar();
            this.criticalLevelLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.mainGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.criticalLevelTrackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // mainGroupBox
            // 
            this.mainGroupBox.Controls.Add(this.differenceColorsImageViewer);
            this.mainGroupBox.Controls.Add(this.maxPointLabel);
            this.mainGroupBox.Controls.Add(this.minPointLabel);
            this.mainGroupBox.Controls.Add(this.paletteGammaComboBox);
            this.mainGroupBox.Controls.Add(this.criticalLevelTrackBar);
            this.mainGroupBox.Controls.Add(this.criticalLevelLabel);
            this.mainGroupBox.Controls.Add(this.label2);
            this.mainGroupBox.Location = new System.Drawing.Point(12, 12);
            this.mainGroupBox.Name = "mainGroupBox";
            this.mainGroupBox.Size = new System.Drawing.Size(285, 174);
            this.mainGroupBox.TabIndex = 16;
            this.mainGroupBox.TabStop = false;
            this.mainGroupBox.Text = "Palette of differences";
            // 
            // differenceColorsImageViewer
            // 
            this.differenceColorsImageViewer.AutoScroll = true;
            this.differenceColorsImageViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.differenceColorsImageViewer.Location = new System.Drawing.Point(14, 43);
            this.differenceColorsImageViewer.Name = "differenceColorsImageViewer";
            this.differenceColorsImageViewer.Size = new System.Drawing.Size(258, 59);
            this.differenceColorsImageViewer.TabIndex = 17;
            this.differenceColorsImageViewer.Text = "differenceColorsImageViewer";
            this.differenceColorsImageViewer.ViewerBufferSize = 10F;
            // 
            // maxPointLabel
            // 
            this.maxPointLabel.AutoSize = true;
            this.maxPointLabel.Location = new System.Drawing.Point(254, 153);
            this.maxPointLabel.Name = "maxPointLabel";
            this.maxPointLabel.Size = new System.Drawing.Size(25, 13);
            this.maxPointLabel.TabIndex = 16;
            this.maxPointLabel.Text = "255";
            // 
            // minPointLabel
            // 
            this.minPointLabel.AutoSize = true;
            this.minPointLabel.Location = new System.Drawing.Point(7, 151);
            this.minPointLabel.Name = "minPointLabel";
            this.minPointLabel.Size = new System.Drawing.Size(13, 13);
            this.minPointLabel.TabIndex = 15;
            this.minPointLabel.Text = "0";
            // 
            // paletteGammaComboBox
            // 
            this.paletteGammaComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.paletteGammaComboBox.FormattingEnabled = true;
            this.paletteGammaComboBox.Items.AddRange(new object[] {
            "Green->Red",
            "Green->Yellow->Red",
            "Black->White"});
            this.paletteGammaComboBox.Location = new System.Drawing.Point(14, 15);
            this.paletteGammaComboBox.Name = "paletteGammaComboBox";
            this.paletteGammaComboBox.Size = new System.Drawing.Size(260, 21);
            this.paletteGammaComboBox.TabIndex = 14;
            this.paletteGammaComboBox.SelectedIndexChanged += new System.EventHandler(this.paletteGammaComboBox_SelectedIndexChanged);
            // 
            // criticalLevelTrackBar
            // 
            this.criticalLevelTrackBar.LargeChange = 50;
            this.criticalLevelTrackBar.Location = new System.Drawing.Point(1, 108);
            this.criticalLevelTrackBar.Maximum = 255;
            this.criticalLevelTrackBar.Name = "criticalLevelTrackBar";
            this.criticalLevelTrackBar.Size = new System.Drawing.Size(283, 45);
            this.criticalLevelTrackBar.TabIndex = 8;
            this.criticalLevelTrackBar.TickFrequency = 10;
            this.criticalLevelTrackBar.ValueChanged += new System.EventHandler(this.criticalLevelTrackBar_ValueChanged);
            // 
            // criticalLevelLabel
            // 
            this.criticalLevelLabel.AutoSize = true;
            this.criticalLevelLabel.Location = new System.Drawing.Point(167, 153);
            this.criticalLevelLabel.Name = "criticalLevelLabel";
            this.criticalLevelLabel.Size = new System.Drawing.Size(13, 13);
            this.criticalLevelLabel.TabIndex = 10;
            this.criticalLevelLabel.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(101, 153);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Critical level:";
            // 
            // DifferencesPaletteForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(309, 198);
            this.Controls.Add(this.mainGroupBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "DifferencesPaletteForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Palette of differences settings";
            this.mainGroupBox.ResumeLayout(false);
            this.mainGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.criticalLevelTrackBar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox mainGroupBox;
        private System.Windows.Forms.Label maxPointLabel;
        private System.Windows.Forms.Label minPointLabel;
        private System.Windows.Forms.ComboBox paletteGammaComboBox;
        private System.Windows.Forms.TrackBar criticalLevelTrackBar;
        private System.Windows.Forms.Label criticalLevelLabel;
        private System.Windows.Forms.Label label2;
        private Vintasoft.Imaging.UI.ImageViewer differenceColorsImageViewer;
    }
}