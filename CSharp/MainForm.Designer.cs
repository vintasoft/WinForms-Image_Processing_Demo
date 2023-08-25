namespace ImageProcessingDemo
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.mainMenu = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.visualToolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.imageViewerScaleModeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageViewer_normalImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageViewer_bestFitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageViewer_fitToWidthToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageViewer_fitToHeightToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageViewer_scaleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageViewer_pixelToPixelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageViewer_toolStripSeparatorZoomModes = new System.Windows.Forms.ToolStripSeparator();
            this.imageViewer_scale25ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageViewer_scale50ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageViewer_scale100ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageViewer_scale200ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageViewer_scale400ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageViewerSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.processingViewerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.processedImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.differenceBySourceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.differenceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.averageDifferenceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.maxDifferenceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.minDifferenceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageProcessingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.useMultithreadingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadPathsFromMetadataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.imageProcessingToolStripProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.openImageFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveImageFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.toolStripPanel1 = new System.Windows.Forms.ToolStripPanel();
            this.viewerToolStrip = new DemosCommonCode.Imaging.ImageViewerToolStrip();
            this.visualToolsToolStrip1 = new DemosCommonCode.Imaging.VisualToolsToolStrip();
            this.imageProcessingControl1 = new DemosCommonCode.ImageProcessingControl();
            this.panel1 = new System.Windows.Forms.Panel();
            this.mainMenu.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.toolStripPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMenu
            // 
            this.mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.imageProcessingToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.mainMenu.Location = new System.Drawing.Point(0, 0);
            this.mainMenu.Name = "mainMenu";
            this.mainMenu.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.mainMenu.Size = new System.Drawing.Size(970, 24);
            this.mainMenu.TabIndex = 0;
            this.mainMenu.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.closeToolStripMenuItem,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.openToolStripMenuItem.Text = "Open...";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.saveAsToolStripMenuItem.Text = "Save As...";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.W)));
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.closeToolStripMenuItem.Text = "Close";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(160, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.X)));
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.visualToolsToolStripMenuItem,
            this.toolStripSeparator3,
            this.imageViewerScaleModeToolStripMenuItem,
            this.imageViewerSettings,
            this.processingViewerToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // visualToolsToolStripMenuItem
            // 
            this.visualToolsToolStripMenuItem.Name = "visualToolsToolStripMenuItem";
            this.visualToolsToolStripMenuItem.Size = new System.Drawing.Size(209, 22);
            this.visualToolsToolStripMenuItem.Text = "Visual Tools";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(206, 6);
            // 
            // imageViewerScaleModeToolStripMenuItem
            // 
            this.imageViewerScaleModeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.imageViewer_normalImageToolStripMenuItem,
            this.imageViewer_bestFitToolStripMenuItem,
            this.imageViewer_fitToWidthToolStripMenuItem,
            this.imageViewer_fitToHeightToolStripMenuItem,
            this.imageViewer_scaleToolStripMenuItem,
            this.imageViewer_pixelToPixelToolStripMenuItem,
            this.imageViewer_toolStripSeparatorZoomModes,
            this.imageViewer_scale25ToolStripMenuItem,
            this.imageViewer_scale50ToolStripMenuItem,
            this.imageViewer_scale100ToolStripMenuItem,
            this.imageViewer_scale200ToolStripMenuItem,
            this.imageViewer_scale400ToolStripMenuItem});
            this.imageViewerScaleModeToolStripMenuItem.Name = "imageViewerScaleModeToolStripMenuItem";
            this.imageViewerScaleModeToolStripMenuItem.Size = new System.Drawing.Size(209, 22);
            this.imageViewerScaleModeToolStripMenuItem.Text = "Image Viewer Scale Mode";
            // 
            // imageViewer_normalImageToolStripMenuItem
            // 
            this.imageViewer_normalImageToolStripMenuItem.Name = "imageViewer_normalImageToolStripMenuItem";
            this.imageViewer_normalImageToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.imageViewer_normalImageToolStripMenuItem.Text = "Normal";
            this.imageViewer_normalImageToolStripMenuItem.Click += new System.EventHandler(this.imageViewer_ImageScale_Click);
            // 
            // imageViewer_bestFitToolStripMenuItem
            // 
            this.imageViewer_bestFitToolStripMenuItem.Name = "imageViewer_bestFitToolStripMenuItem";
            this.imageViewer_bestFitToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.imageViewer_bestFitToolStripMenuItem.Text = "Best fit";
            this.imageViewer_bestFitToolStripMenuItem.Click += new System.EventHandler(this.imageViewer_ImageScale_Click);
            // 
            // imageViewer_fitToWidthToolStripMenuItem
            // 
            this.imageViewer_fitToWidthToolStripMenuItem.Name = "imageViewer_fitToWidthToolStripMenuItem";
            this.imageViewer_fitToWidthToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.imageViewer_fitToWidthToolStripMenuItem.Text = "Fit to width";
            this.imageViewer_fitToWidthToolStripMenuItem.Click += new System.EventHandler(this.imageViewer_ImageScale_Click);
            // 
            // imageViewer_fitToHeightToolStripMenuItem
            // 
            this.imageViewer_fitToHeightToolStripMenuItem.Name = "imageViewer_fitToHeightToolStripMenuItem";
            this.imageViewer_fitToHeightToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.imageViewer_fitToHeightToolStripMenuItem.Text = "Fit to height";
            this.imageViewer_fitToHeightToolStripMenuItem.Click += new System.EventHandler(this.imageViewer_ImageScale_Click);
            // 
            // imageViewer_scaleToolStripMenuItem
            // 
            this.imageViewer_scaleToolStripMenuItem.Name = "imageViewer_scaleToolStripMenuItem";
            this.imageViewer_scaleToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.imageViewer_scaleToolStripMenuItem.Text = "Scale";
            this.imageViewer_scaleToolStripMenuItem.Click += new System.EventHandler(this.imageViewer_ImageScale_Click);
            // 
            // imageViewer_pixelToPixelToolStripMenuItem
            // 
            this.imageViewer_pixelToPixelToolStripMenuItem.Name = "imageViewer_pixelToPixelToolStripMenuItem";
            this.imageViewer_pixelToPixelToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.imageViewer_pixelToPixelToolStripMenuItem.Text = "Pixel to pixel";
            this.imageViewer_pixelToPixelToolStripMenuItem.Click += new System.EventHandler(this.imageViewer_ImageScale_Click);
            // 
            // imageViewer_toolStripSeparatorZoomModes
            // 
            this.imageViewer_toolStripSeparatorZoomModes.Name = "imageViewer_toolStripSeparatorZoomModes";
            this.imageViewer_toolStripSeparatorZoomModes.Size = new System.Drawing.Size(138, 6);
            // 
            // imageViewer_scale25ToolStripMenuItem
            // 
            this.imageViewer_scale25ToolStripMenuItem.Name = "imageViewer_scale25ToolStripMenuItem";
            this.imageViewer_scale25ToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.imageViewer_scale25ToolStripMenuItem.Text = "25%";
            this.imageViewer_scale25ToolStripMenuItem.Click += new System.EventHandler(this.imageViewer_ImageScale_Click);
            // 
            // imageViewer_scale50ToolStripMenuItem
            // 
            this.imageViewer_scale50ToolStripMenuItem.Name = "imageViewer_scale50ToolStripMenuItem";
            this.imageViewer_scale50ToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.imageViewer_scale50ToolStripMenuItem.Text = "50%";
            this.imageViewer_scale50ToolStripMenuItem.Click += new System.EventHandler(this.imageViewer_ImageScale_Click);
            // 
            // imageViewer_scale100ToolStripMenuItem
            // 
            this.imageViewer_scale100ToolStripMenuItem.Name = "imageViewer_scale100ToolStripMenuItem";
            this.imageViewer_scale100ToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.imageViewer_scale100ToolStripMenuItem.Text = "100%";
            this.imageViewer_scale100ToolStripMenuItem.Click += new System.EventHandler(this.imageViewer_ImageScale_Click);
            // 
            // imageViewer_scale200ToolStripMenuItem
            // 
            this.imageViewer_scale200ToolStripMenuItem.Name = "imageViewer_scale200ToolStripMenuItem";
            this.imageViewer_scale200ToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.imageViewer_scale200ToolStripMenuItem.Text = "200%";
            this.imageViewer_scale200ToolStripMenuItem.Click += new System.EventHandler(this.imageViewer_ImageScale_Click);
            // 
            // imageViewer_scale400ToolStripMenuItem
            // 
            this.imageViewer_scale400ToolStripMenuItem.Name = "imageViewer_scale400ToolStripMenuItem";
            this.imageViewer_scale400ToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.imageViewer_scale400ToolStripMenuItem.Text = "400%";
            this.imageViewer_scale400ToolStripMenuItem.Click += new System.EventHandler(this.imageViewer_ImageScale_Click);
            // 
            // imageViewerSettings
            // 
            this.imageViewerSettings.Name = "imageViewerSettings";
            this.imageViewerSettings.Size = new System.Drawing.Size(209, 22);
            this.imageViewerSettings.Text = "Image Viewer Settings...";
            this.imageViewerSettings.Click += new System.EventHandler(this.imageViewerSettingsToolStripMenuItem_Click);
            // 
            // processingViewerToolStripMenuItem
            // 
            this.processingViewerToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.processedImageToolStripMenuItem,
            this.differenceBySourceToolStripMenuItem});
            this.processingViewerToolStripMenuItem.Name = "processingViewerToolStripMenuItem";
            this.processingViewerToolStripMenuItem.Size = new System.Drawing.Size(209, 22);
            this.processingViewerToolStripMenuItem.Text = "Processing Viewer";
            // 
            // processedImageToolStripMenuItem
            // 
            this.processedImageToolStripMenuItem.Checked = true;
            this.processedImageToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.processedImageToolStripMenuItem.Name = "processedImageToolStripMenuItem";
            this.processedImageToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.processedImageToolStripMenuItem.Text = "Processed Image";
            this.processedImageToolStripMenuItem.Click += new System.EventHandler(this.processingViewerSubMenuItem_Click);
            // 
            // differenceBySourceToolStripMenuItem
            // 
            this.differenceBySourceToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.differenceToolStripMenuItem,
            this.averageDifferenceToolStripMenuItem,
            this.maxDifferenceToolStripMenuItem,
            this.minDifferenceToolStripMenuItem,
            this.toolStripSeparator2,
            this.settingsToolStripMenuItem});
            this.differenceBySourceToolStripMenuItem.Name = "differenceBySourceToolStripMenuItem";
            this.differenceBySourceToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.differenceBySourceToolStripMenuItem.Text = "Difference by Source";
            // 
            // differenceToolStripMenuItem
            // 
            this.differenceToolStripMenuItem.Name = "differenceToolStripMenuItem";
            this.differenceToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.differenceToolStripMenuItem.Text = "Difference";
            this.differenceToolStripMenuItem.Click += new System.EventHandler(this.processingViewerSubMenuItem_Click);
            // 
            // averageDifferenceToolStripMenuItem
            // 
            this.averageDifferenceToolStripMenuItem.Name = "averageDifferenceToolStripMenuItem";
            this.averageDifferenceToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.averageDifferenceToolStripMenuItem.Text = "Average Difference";
            this.averageDifferenceToolStripMenuItem.Click += new System.EventHandler(this.processingViewerSubMenuItem_Click);
            // 
            // maxDifferenceToolStripMenuItem
            // 
            this.maxDifferenceToolStripMenuItem.Name = "maxDifferenceToolStripMenuItem";
            this.maxDifferenceToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.maxDifferenceToolStripMenuItem.Text = "Max Difference";
            this.maxDifferenceToolStripMenuItem.Click += new System.EventHandler(this.processingViewerSubMenuItem_Click);
            // 
            // minDifferenceToolStripMenuItem
            // 
            this.minDifferenceToolStripMenuItem.Name = "minDifferenceToolStripMenuItem";
            this.minDifferenceToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.minDifferenceToolStripMenuItem.Text = "Min Difference";
            this.minDifferenceToolStripMenuItem.Click += new System.EventHandler(this.processingViewerSubMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(171, 6);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.settingsToolStripMenuItem.Text = "Settings...";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // imageProcessingToolStripMenuItem
            // 
            this.imageProcessingToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.useMultithreadingToolStripMenuItem,
            this.loadPathsFromMetadataToolStripMenuItem});
            this.imageProcessingToolStripMenuItem.Name = "imageProcessingToolStripMenuItem";
            this.imageProcessingToolStripMenuItem.Size = new System.Drawing.Size(112, 20);
            this.imageProcessingToolStripMenuItem.Text = "Image processing";
            // 
            // useMultithreadingToolStripMenuItem
            // 
            this.useMultithreadingToolStripMenuItem.CheckOnClick = true;
            this.useMultithreadingToolStripMenuItem.Name = "useMultithreadingToolStripMenuItem";
            this.useMultithreadingToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.useMultithreadingToolStripMenuItem.Text = "Use Multithreading";
            this.useMultithreadingToolStripMenuItem.CheckedChanged += new System.EventHandler(this.useMultithreadingToolStripMenuItem_CheckedChanged);
            // 
            // loadPathsFromMetadataToolStripMenuItem
            // 
            this.loadPathsFromMetadataToolStripMenuItem.Name = "loadPathsFromMetadataToolStripMenuItem";
            this.loadPathsFromMetadataToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.loadPathsFromMetadataToolStripMenuItem.Text = "Load paths from metadata";
            this.loadPathsFromMetadataToolStripMenuItem.Click += new System.EventHandler(this.loadPathsFromMetadataToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.aboutToolStripMenuItem.Text = "About...";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.imageProcessingToolStripProgressBar});
            this.statusStrip1.Location = new System.Drawing.Point(0, 614);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 12, 0);
            this.statusStrip1.Size = new System.Drawing.Size(970, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // imageProcessingToolStripProgressBar
            // 
            this.imageProcessingToolStripProgressBar.Name = "imageProcessingToolStripProgressBar";
            this.imageProcessingToolStripProgressBar.Size = new System.Drawing.Size(86, 16);
            this.imageProcessingToolStripProgressBar.Visible = false;
            // 
            // openImageFileDialog
            // 
            this.openImageFileDialog.FileName = "openFileDialog1";
            // 
            // saveImageFileDialog
            // 
            this.saveImageFileDialog.Filter = "TIFF files|*.tif";
            // 
            // toolStripPanel1
            // 
            this.toolStripPanel1.Controls.Add(this.viewerToolStrip);
            this.toolStripPanel1.Controls.Add(this.visualToolsToolStrip1);
            this.toolStripPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.toolStripPanel1.Location = new System.Drawing.Point(0, 24);
            this.toolStripPanel1.Name = "toolStripPanel1";
            this.toolStripPanel1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.toolStripPanel1.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.toolStripPanel1.Size = new System.Drawing.Size(970, 25);
            // 
            // viewerToolStrip
            // 
            this.viewerToolStrip.AssociatedZoomTrackBar = null;
            this.viewerToolStrip.CanPrint = false;
            this.viewerToolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.viewerToolStrip.ImageViewer = null;
            this.viewerToolStrip.ScanButtonEnabled = true;
            this.viewerToolStrip.Location = new System.Drawing.Point(3, 0);
            this.viewerToolStrip.Name = "viewerToolStrip";
            this.viewerToolStrip.PageCount = 0;
            this.viewerToolStrip.PrintButtonEnabled = true;
            this.viewerToolStrip.SaveButtonEnabled = true;
            this.viewerToolStrip.Size = new System.Drawing.Size(333, 25);
            this.viewerToolStrip.TabIndex = 2;
            this.viewerToolStrip.Text = "toolStrip1";
            this.viewerToolStrip.UseImageViewerImages = true;
            this.viewerToolStrip.OpenFile += new System.EventHandler(this.openToolStripMenuItem_Click);
            this.viewerToolStrip.SaveFile += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // visualToolsToolStrip1
            // 
            this.visualToolsToolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.visualToolsToolStrip1.Enabled = false;
            this.visualToolsToolStrip1.ImageViewer = null;
            this.visualToolsToolStrip1.Location = new System.Drawing.Point(336, 0);
            this.visualToolsToolStrip1.MandatoryVisualTool = null;
            this.visualToolsToolStrip1.Name = "visualToolsToolStrip1";
            this.visualToolsToolStrip1.Size = new System.Drawing.Size(35, 25);
            this.visualToolsToolStrip1.TabIndex = 3;
            this.visualToolsToolStrip1.VisualToolsMenuItem = this.visualToolsToolStripMenuItem;
            // 
            // imageProcessingControl1
            // 
            this.imageProcessingControl1.AvailableProcessingCommands = null;
            this.imageProcessingControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.imageProcessingControl1.Location = new System.Drawing.Point(0, 0);
            this.imageProcessingControl1.MinimumSize = new System.Drawing.Size(366, 313);
            this.imageProcessingControl1.Name = "imageProcessingControl1";
            this.imageProcessingControl1.SelectedCommands = null;
            this.imageProcessingControl1.Size = new System.Drawing.Size(970, 565);
            this.imageProcessingControl1.TabIndex = 3;
            this.imageProcessingControl1.UseMultithreading = false;
            this.imageProcessingControl1.ExecuteCommandStarted += new System.EventHandler(this.imageProcessingControl1_ExecuteCommandStarted);
            this.imageProcessingControl1.ExecuteCommandProgress += new System.EventHandler<Vintasoft.Imaging.ImageProcessing.ImageProcessingProgressEventArgs>(this.imageProcessingControl1_ExecuteCommandProgress);
            this.imageProcessingControl1.ProcessedImageReceived += new System.EventHandler<Vintasoft.Imaging.ImageEventArgs>(this.imageProcessingControl1_ProcessedImageReceived);
            this.imageProcessingControl1.ExecuteCommandFinished += new System.EventHandler(this.imageProcessingControl1_ExecuteCommandFinished);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.imageProcessingControl1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 49);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(970, 565);
            this.panel1.TabIndex = 4;
            // 
            // MainForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(970, 636);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStripPanel1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.mainMenu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.mainMenu;
            this.MinimumSize = new System.Drawing.Size(602, 482);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VintaSoft Image Processing Demo";
            this.mainMenu.ResumeLayout(false);
            this.mainMenu.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.toolStripPanel1.ResumeLayout(false);
            this.toolStripPanel1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mainMenu;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private DemosCommonCode.Imaging.ImageViewerToolStrip viewerToolStrip;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem imageViewerScaleModeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem imageViewer_normalImageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem imageViewer_bestFitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem imageViewer_fitToWidthToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem imageViewer_fitToHeightToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem imageViewer_scaleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem imageViewer_pixelToPixelToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator imageViewer_toolStripSeparatorZoomModes;
        private System.Windows.Forms.ToolStripMenuItem imageViewer_scale25ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem imageViewer_scale50ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem imageViewer_scale100ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem imageViewer_scale200ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem imageViewer_scale400ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem imageViewerSettings;
        private System.Windows.Forms.OpenFileDialog openImageFileDialog;
        private System.Windows.Forms.ToolStripProgressBar imageProcessingToolStripProgressBar;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveImageFileDialog;
        private System.Windows.Forms.ToolStripMenuItem imageProcessingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem useMultithreadingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadPathsFromMetadataToolStripMenuItem;
        private DemosCommonCode.ImageProcessingControl imageProcessingControl1;
        private System.Windows.Forms.ToolStripMenuItem processingViewerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem processedImageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem differenceBySourceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem differenceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem averageDifferenceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem maxDifferenceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem minDifferenceToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripPanel toolStripPanel1;
        private DemosCommonCode.Imaging.VisualToolsToolStrip visualToolsToolStrip1;
        private System.Windows.Forms.ToolStripMenuItem visualToolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.Panel panel1;
    }
}