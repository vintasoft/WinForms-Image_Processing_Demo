using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

using Vintasoft.Imaging;
using Vintasoft.Imaging.ImageProcessing;
using Vintasoft.Imaging.Metadata;
using Vintasoft.Imaging.UI;
using Vintasoft.Imaging.UI.VisualTools;

using DemosCommonCode;
using DemosCommonCode.Imaging;
using DemosCommonCode.Imaging.Codecs;
using ImageProcessingDemo.Dialogs;
using Vintasoft.Imaging.Drawing.Gdi;
using Vintasoft.Imaging.Drawing;

namespace ImageProcessingDemo
{
    /// <summary>
    /// The main form of Image Processing Demo application.
    /// </summary>
    public partial class MainForm : Form
    {

        #region Fields

        /// <summary>
        /// The template of the application's title.
        /// </summary>
        string _formTitle = "VintaSoft Image Processing Demo v" + ImagingGlobalSettings.ProductVersion;

        /// <summary>
        /// A value indicating whether the Open File Dialog is opened.
        /// </summary>
        bool _isFileDialogOpened = false;

        /// <summary>
        /// The selected "View - Image scale mode" menu item.
        /// </summary>
        ToolStripMenuItem _imageViewer_imageScaleSelectedMenuItem;

        /// <summary>
        /// The image compare operator.
        /// </summary>
        ImageCompareOperator _compareOperator = ImageCompareOperator.Difference;

        /// <summary>
        /// The processed image.
        /// </summary>
        VintasoftImage _processedImage;

        /// <summary>
        /// A form that allows to change palette settings of processed image.
        /// </summary>
        DifferencesPaletteForm _paletteSettingsForm;

        #endregion



        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="MainForm"/> class.
        /// </summary>
        public MainForm()
        {
            // register the evaluation license for VintaSoft Imaging .NET SDK
            Vintasoft.Imaging.ImagingGlobalSettings.Register("REG_USER", "REG_EMAIL", "EXPIRATION_DATE", "REG_CODE");

            InitializeComponent();

            Jbig2AssemblyLoader.Load();
            Jpeg2000AssemblyLoader.Load();
            RawAssemblyLoader.Load();
            DicomAssemblyLoader.Load();
            PdfAssemblyLoader.Load();
            DocxAssemblyLoader.Load();

            ImagingTypeEditorRegistrator.Register();

            SelectionVisualToolActionFactory.CreateActions(visualToolsToolStrip1);

            this.Text = _formTitle;

            // init file dialogs
            CodecsFileFilters.SetOpenFileDialogFilter(openImageFileDialog);
            CodecsFileFilters.SetSaveFileDialogFilter(saveImageFileDialog, false, false);
            openImageFileDialog.FileName = "";
            saveImageFileDialog.FileName = "";
            DemosTools.SetTestFilesFolder(openImageFileDialog);

            viewerToolStrip.ImageViewer = imageProcessingControl1.ImageViewer;
            visualToolsToolStrip1.ImageViewer = imageProcessingControl1.ImageViewer;
            imageProcessingControl1.ImageViewer.ZoomChanged += new EventHandler<ZoomChangedEventArgs>(SourceImageViewer_ZoomChanged);

            // init "View -> Image Scale Mode" menu 
            InitImageScaleMenu();

            // init "View -> Processing Viewer" menu
            InitProcessingViewerMenu();

            // init available processing commands
            InitAvailableProcessingCommands();

            DocumentPasswordForm.EnableAuthentication(imageProcessingControl1.ImageViewer);

            // init palette settings form
            _paletteSettingsForm = new DifferencesPaletteForm();
            _paletteSettingsForm.FormClosing += new FormClosingEventHandler(paletteSettingsForm_FormClosing);

            UpdateUI();
        }

        #endregion



        #region Properties

        bool _isImageProcessing = false;
        /// <summary>
        /// Gets or sets a value indicating whether image is processing.
        /// </summary>
        internal bool IsImageProcessing
        {
            get
            {
                return _isImageProcessing;
            }
            set
            {
                _isImageProcessing = value;
                UpdateUI();
            }
        }

        bool _isImageSaving = false;
        /// <summary>
        /// Gets or sets a value indicating whether image is saving.
        /// </summary>
        internal bool IsImageSaving
        {
            get
            {
                return _isImageSaving;
            }
            set
            {
                _isImageSaving = value;
                UpdateUI();
            }
        }

        /// <summary>
        /// Indicates whether "View -> Differece by Source" is enabled.
        /// </summary>
        private bool DifferenceBySourceEnabled
        {
            get
            {
                return differenceBySourceToolStripMenuItem.Checked;
            }
        }

        #endregion



        #region Methods

        #region UI

        #region 'File' menu

        /// <summary>
        /// Handles the Click event of OpenToolStripMenuItem object.
        /// </summary>
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_isFileDialogOpened)
                return;

            _isFileDialogOpened = true;

            // if image file is selected
            if (openImageFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                // clear image collection of the viewer of the source image 
                imageProcessingControl1.ImageViewer.Images.ClearAndDisposeItems();

                try
                {
                    this.Text = _formTitle;

                    // add image file to image collection of the image viewer
                    imageProcessingControl1.ImageViewer.Images.Add(openImageFileDialog.FileName);

                    this.Text = string.Format("{0} - {1}", _formTitle, openImageFileDialog.FileName);
                }
                catch (Exception ex)
                {
                    DemosTools.ShowErrorMessage(ex);
                }
            }

            _isFileDialogOpened = false;

            UpdateUI();
        }

        /// <summary>
        /// Handles the Click event of SaveAsToolStripMenuItem object.
        /// </summary>
        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.IsImageSaving = true;

            try
            {
                if (saveImageFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // save the processed image to a file
                    imageProcessingControl1.ProcessedImage.Save(saveImageFileDialog.FileName);
                }
            }
            catch (Exception ex)
            {
                DemosTools.ShowErrorMessage(ex);
            }

            this.IsImageSaving = false;
        }

        /// <summary>
        /// Handles the Click event of CloseToolStripMenuItem object.
        /// </summary>
        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // close the current image file
            imageProcessingControl1.ImageViewer.Images.ClearAndDisposeItems();

            UpdateUI();
        }

        /// <summary>
        /// Handles the Click event of ExitToolStripMenuItem object.
        /// </summary>
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        #endregion


        #region 'View' menu

        /// <summary>
        /// Handles the Click event of ImageScale property of ImageViewer object.
        /// </summary>
        private void imageViewer_ImageScale_Click(object sender, EventArgs e)
        {
            _imageViewer_imageScaleSelectedMenuItem.Checked = false;
            _imageViewer_imageScaleSelectedMenuItem = (ToolStripMenuItem)sender;

            // if menu item sets ImageSizeMode
            if (_imageViewer_imageScaleSelectedMenuItem.Tag is ImageSizeMode)
            {
                _imageViewer_imageScaleSelectedMenuItem.Checked = true;
                // set size mode
                imageProcessingControl1.ImageViewer.SizeMode = (ImageSizeMode)_imageViewer_imageScaleSelectedMenuItem.Tag;
            }
            // if menu item sets zoom
            else
            {
                // get zoom value
                int zoomValue = (int)_imageViewer_imageScaleSelectedMenuItem.Tag;
                // set ImageSizeMode as Zoom
                imageProcessingControl1.ImageViewer.SizeMode = ImageSizeMode.Zoom;
                // set zoom value
                imageProcessingControl1.ImageViewer.Zoom = zoomValue;
            }
        }

        /// <summary>
        /// Handles the Click event of ImageViewerSettingsToolStripMenuItem object.
        /// </summary>
        private void imageViewerSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (ImageViewerSettingsForm viewerSettingsDialog =
                new ImageViewerSettingsForm(imageProcessingControl1.ImageViewer))
            {
                viewerSettingsDialog.CanEditMultipageSettings = false;
                viewerSettingsDialog.ShowDialog();
            }

            imageProcessingControl1.SynchronizeViewerSettings();
        }

        /// <summary>
        /// Handles the Click event of ProcessingViewerSubMenuItem object.
        /// </summary>
        private void processingViewerSubMenuItem_Click(object sender, EventArgs e)
        {
            processedImageToolStripMenuItem.Checked = false;
            differenceBySourceToolStripMenuItem.Checked = false;
            differenceToolStripMenuItem.Checked = false;
            averageDifferenceToolStripMenuItem.Checked = false;
            maxDifferenceToolStripMenuItem.Checked = false;
            minDifferenceToolStripMenuItem.Checked = false;

            ToolStripMenuItem processingViewerMenuItem = (ToolStripMenuItem)sender;

            // if "View -> Processing Viewer -> Processed Image" clicked
            if (processingViewerMenuItem.Tag == null)
            {
                // if processedImage is not empty
                if (_processedImage != null)
                {
                    // set processed image to the processed image viewer
                    imageProcessingControl1.ProcessedImage.SetImage(_processedImage);
                    _processedImage = null;
                }
            }
            // if one of "View -> Processing Viewer -> Difference by Source" menu item clicked
            else
            {
                // if processed image viewer is not empty
                if (imageProcessingControl1.ProcessedImage != null)
                {
                    if (_processedImage == null)
                        _processedImage = (VintasoftImage)imageProcessingControl1.ProcessedImage.Clone();

                    // choose compare operator
                    _compareOperator = (ImageCompareOperator)processingViewerMenuItem.Tag;

                    // compare images
                    VintasoftImage differences = CompareImages(_processedImage, imageProcessingControl1.ImageViewer.Image);

                    imageProcessingControl1.ProcessedImage.SetImage(differences);
                }
                differenceBySourceToolStripMenuItem.Checked = true;
            }

            processingViewerMenuItem.Checked = true;
        }

        /// <summary>
        /// Handles the Click event of SettingsToolStripMenuItem object.
        /// </summary>
        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!_paletteSettingsForm.Visible)
            {
                // if processed image viewer is not empty
                if (imageProcessingControl1.ProcessedImage != null)
                    // get the palette of the image
                    _paletteSettingsForm.SourcePalette = imageProcessingControl1.ProcessedImage.Palette;
                _paletteSettingsForm.Show();
            }
            else
            {
                _paletteSettingsForm.Hide();
            }
        }

        /// <summary>
        /// Handles the FormClosing event of PaletteSettingsForm object.
        /// </summary>
        private void paletteSettingsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            _paletteSettingsForm.Hide();
        }

        #endregion


        #region 'Image processing' menu

        /// <summary>
        /// Handles the CheckedChanged event of UseMultithreadingToolStripMenuItem object.
        /// </summary>
        private void useMultithreadingToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            imageProcessingControl1.UseMultithreading = useMultithreadingToolStripMenuItem.Checked;
        }

        /// <summary>
        /// Handles the Click event of LoadPathsFromMetadataToolStripMenuItem object.
        /// </summary>
        private void loadPathsFromMetadataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.imageProcessingControl1.ImageViewer.Image != null)
            {
                // get image metadata tree
                MetadataNode metadata = this.imageProcessingControl1.ImageViewer.Image.Metadata.MetadataTree;

                PhotoshopResourcesMetadata photoshopMetadata = metadata.FindChildNode<PhotoshopResourcesMetadata>();

                bool pathsAreLoaded = false;
                if (photoshopMetadata != null)
                {
                    int width = this.imageProcessingControl1.ImageViewer.Image.Width;
                    int height = this.imageProcessingControl1.ImageViewer.Image.Height;

                    GdiGraphicsPath paths = new GdiGraphicsPath();

                    // find image path resources
                    foreach (PhotoshopResource resource in photoshopMetadata.Resources)
                    {
                        if (resource is PhotoshopImagePathResource)
                        {
                            IGraphicsPath path = ((PhotoshopImagePathResource)resource).GetPath(width, height);
                            if (path.PointCount > 0)
                                paths.AddPath(path);
                        }
                    }

                    if (paths.PointCount > 0)
                    {                        
                        // create selection tool with loaded paths
                        PathSelectionRegion selection = new PathSelectionRegion(paths.Source);
                        selection.InteractionController = selection.TransformInteractionController;
                        CustomSelectionTool tool = new CustomSelectionTool();
                        tool.Selection = selection;

                        this.imageProcessingControl1.ImageViewer.VisualTool = tool;
                        pathsAreLoaded = true;
                    }
                }

                if (!pathsAreLoaded)
                    DemosTools.ShowInfoMessage("No clipping paths found in metadata.");
            }
        }

        #endregion


        #region 'Help' menu

        /// <summary>
        /// Handles the Click event of AboutToolStripMenuItem object.
        /// </summary>
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (AboutBoxForm dlg = new AboutBoxForm())
            {
                dlg.ShowDialog();
            }
        }

        #endregion


        #region Image Processing control

        /// <summary>
        /// Handles the ExecuteCommandStarted event of ImageProcessingControl1 object.
        /// </summary>
        private void imageProcessingControl1_ExecuteCommandStarted(object sender, EventArgs e)
        {
            imageProcessingToolStripProgressBar.Visible = true;
            IsImageProcessing = true;
        }

        /// <summary>
        /// Handles the ExecuteCommandProgress event of ImageProcessingControl1 object.
        /// </summary>
        private void imageProcessingControl1_ExecuteCommandProgress(object sender, ImageProcessingProgressEventArgs e)
        {
            // update progress bar value
            imageProcessingToolStripProgressBar.Value = e.Progress;
            Application.DoEvents();
        }

        /// <summary>
        /// Handles the ExecuteCommandFinished event of ImageProcessingControl1 object.
        /// </summary>
        private void imageProcessingControl1_ExecuteCommandFinished(object sender, EventArgs e)
        {
            imageProcessingToolStripProgressBar.Visible = false;
            IsImageProcessing = false;
        }

        /// <summary>
        /// Handles the ProcessedImageReceived event of ImageProcessingControl1 object.
        /// </summary>
        private void imageProcessingControl1_ProcessedImageReceived(object sender, ImageEventArgs e)
        {
            if (_processedImage != null)
                _processedImage.Dispose();

            // save processed image
            _processedImage = (VintasoftImage)e.Image.Clone();

            // if processed image must be compared with source image
            if (DifferenceBySourceEnabled)
            {
                // compare images
                VintasoftImage differences = CompareImages(e.Image, imageProcessingControl1.ImageViewer.Image);
                e.Image.SetImage(differences);
            }
        }

        /// <summary>
        /// Handles the ZoomChanged event of SourceImageViewer object.
        /// </summary>
        private void SourceImageViewer_ZoomChanged(object sender, ZoomChangedEventArgs e)
        {
            _imageViewer_imageScaleSelectedMenuItem.Checked = false;
            switch (imageProcessingControl1.ImageViewer.SizeMode)
            {
                case ImageSizeMode.BestFit:
                    _imageViewer_imageScaleSelectedMenuItem = imageViewer_bestFitToolStripMenuItem;
                    break;
                case ImageSizeMode.FitToHeight:
                    _imageViewer_imageScaleSelectedMenuItem = imageViewer_fitToHeightToolStripMenuItem;
                    break;
                case ImageSizeMode.FitToWidth:
                    _imageViewer_imageScaleSelectedMenuItem = imageViewer_fitToWidthToolStripMenuItem;
                    break;
                case ImageSizeMode.Normal:
                    _imageViewer_imageScaleSelectedMenuItem = imageViewer_normalImageToolStripMenuItem;
                    break;
                case ImageSizeMode.PixelToPixel:
                    _imageViewer_imageScaleSelectedMenuItem = imageViewer_pixelToPixelToolStripMenuItem;
                    break;
                case ImageSizeMode.Zoom:
                    _imageViewer_imageScaleSelectedMenuItem = imageViewer_scaleToolStripMenuItem;
                    break;
            }
            _imageViewer_imageScaleSelectedMenuItem.Checked = true;
        }

        #endregion

        #endregion


        /// <summary>
        /// Updates the user interface of this form.
        /// </summary>
        private void UpdateUI()
        {
            bool isImageLoaded = imageProcessingControl1.ImageViewer.Images.Count > 0;
            bool isImageProcessing = this.IsImageProcessing;
            bool isImageProcessed = imageProcessingControl1.ProcessedImage != null;
            bool isImageSaving = this.IsImageSaving;

            // main menu
            saveAsToolStripMenuItem.Enabled = isImageLoaded && !isImageProcessing && isImageProcessed && !isImageSaving;
            closeToolStripMenuItem.Enabled = isImageLoaded && !isImageProcessing && !isImageSaving;

            // toolstip
            viewerToolStrip.CanSaveFile = saveAsToolStripMenuItem.Enabled;
            viewerToolStrip.CanOpenFile = !isImageProcessing;

            openToolStripMenuItem.Enabled = !isImageProcessing;
        }

        /// <summary>
        /// Initializes the available processing commands.
        /// </summary>
        private void InitAvailableProcessingCommands()
        {
            Dictionary<string, ProcessingCommandBase[]> availableProcessingCommandGroups =
                new Dictionary<string, ProcessingCommandBase[]>();

            // base commands
            ProcessingCommandBase[] baseCommands = new ProcessingCommandBase[] {
                new Vintasoft.Imaging.ImageProcessing.ChangePixelFormatCommand(),
                new Vintasoft.Imaging.ImageProcessing.ChangePixelFormatToBgrCommand(),
                new Vintasoft.Imaging.ImageProcessing.ChangePixelFormatToBlackWhiteCommand(),
                new Vintasoft.Imaging.ImageProcessing.ChangePixelFormatToGrayscaleCommand(),
                new Vintasoft.Imaging.ImageProcessing.ChangePixelFormatToPaletteCommand(),
                new Vintasoft.Imaging.ImageProcessing.ClearImageCommand(),
                new Vintasoft.Imaging.ImageProcessing.CropCommand(),
                new Vintasoft.Imaging.ImageProcessing.ResampleCommand(),
                new Vintasoft.Imaging.ImageProcessing.ResizeCommand(),
                new Vintasoft.Imaging.ImageProcessing.ResizeCanvasCommand(),
                new Vintasoft.Imaging.ImageProcessing.DrawImageCommand(),
                new Vintasoft.Imaging.ImageProcessing.OverlayCommand(),
                new Vintasoft.Imaging.ImageProcessing.OverlayBinaryCommand(),
                new Vintasoft.Imaging.ImageProcessing.OverlayMaskedCommand(),
                new Vintasoft.Imaging.ImageProcessing.OverlayWithBlendingCommand(),
                new Vintasoft.Imaging.ImageProcessing.ImageComparisonCommand(),
                new Vintasoft.Imaging.ImageProcessing.CopyColorChannelCommand()};
            availableProcessingCommandGroups.Add("Base", baseCommands);

            // info commands
            ProcessingCommandBase[] infoCommands = new ProcessingCommandBase[] {
                new Vintasoft.Imaging.ImageProcessing.Info.GetBackgroundColorCommand(),
                new Vintasoft.Imaging.ImageProcessing.Info.GetBorderColorCommand(),
                new Vintasoft.Imaging.ImageProcessing.Info.GetColorCountCommand(),
                new Vintasoft.Imaging.ImageProcessing.Info.GetHistogramCommand(),
                new Vintasoft.Imaging.ImageProcessing.Info.GetThresholdCommand(),
                new Vintasoft.Imaging.ImageProcessing.Info.IsImageBlankCommand(),
                new Vintasoft.Imaging.ImageProcessing.Info.HasCertainColorCommand(),
                new Vintasoft.Imaging.ImageProcessing.Info.GetUniqueColorCommand(),
                new Vintasoft.Imaging.ImageProcessing.Info.IsImageBlackWhiteCommand(),
                new Vintasoft.Imaging.ImageProcessing.Info.IsImageGrayscaleCommand(),
                new Vintasoft.Imaging.ImageProcessing.Info.GetImageColorDepthCommand(),
                new Vintasoft.Imaging.ImageProcessing.Info.GetBorderRectCommand()
                };
            availableProcessingCommandGroups.Add("Info", infoCommands);

            // transforms commands
            ProcessingCommandBase[] transformCommands = new ProcessingCommandBase[] {
                new Vintasoft.Imaging.ImageProcessing.Transforms.FlipCommand(),
                new Vintasoft.Imaging.ImageProcessing.Transforms.RotateCommand(),
                new Vintasoft.Imaging.ImageProcessing.Transforms.ImageScalingCommand(),
                new Vintasoft.Imaging.ImageProcessing.Transforms.SkewCommand(),
                new Vintasoft.Imaging.ImageProcessing.Transforms.QuadrilateralWarpCommand(),
                new Vintasoft.Imaging.ImageProcessing.Transforms.MatrixTransformCommand() };
            availableProcessingCommandGroups.Add("Transforms", transformCommands);

            // color commands
            ProcessingCommandBase[] colorCommands = new ProcessingCommandBase[] {
                new Vintasoft.Imaging.ImageProcessing.Color.BinarizeCommand(),
                new Vintasoft.Imaging.ImageProcessing.Color.ChangeBrightnessCommand(),
                new Vintasoft.Imaging.ImageProcessing.Color.ChangeBrightnessContrastCommand(),
                new Vintasoft.Imaging.ImageProcessing.Color.ChangeContrastCommand(),
                new Vintasoft.Imaging.ImageProcessing.Color.ChangeGammaCommand(),
                new Vintasoft.Imaging.ImageProcessing.Color.ChangeHueSaturationLuminanceCommand(),
                new Vintasoft.Imaging.ImageProcessing.Color.ColorBlendCommand(),
                new Vintasoft.Imaging.ImageProcessing.Color.ColorBlend16Command(),
                new Vintasoft.Imaging.ImageProcessing.Color.CurvesCommand(),
                new Vintasoft.Imaging.ImageProcessing.Color.DesaturateCommand(),
                new Vintasoft.Imaging.ImageProcessing.Color.GetAlphaChannelMaskCommand(),
                new Vintasoft.Imaging.ImageProcessing.Color.HalftoneCommand(),
                new Vintasoft.Imaging.ImageProcessing.Color.InvertCommand(),
                new Vintasoft.Imaging.ImageProcessing.Color.LevelsCommand(),
                new Vintasoft.Imaging.ImageProcessing.Color.PosterizeCommand(),
                new Vintasoft.Imaging.ImageProcessing.Color.RemapColorsCommand(),
                new Vintasoft.Imaging.ImageProcessing.Color.ReplaceColorCommand(),
                new Vintasoft.Imaging.ImageProcessing.Color.SetAlphaChannelMaskCommand(),
                new Vintasoft.Imaging.ImageProcessing.Color.SetAlphaChannelValueCommand()};
            availableProcessingCommandGroups.Add("Color", colorCommands);

            // filters commands
            ProcessingCommandBase[] filterCommands = new ProcessingCommandBase[] {
                new Vintasoft.Imaging.ImageProcessing.Filters.MinimumCommand(),
                new Vintasoft.Imaging.ImageProcessing.Filters.MaximumCommand(),
                new Vintasoft.Imaging.ImageProcessing.Filters.MidpointCommand(),
                new Vintasoft.Imaging.ImageProcessing.Filters.MeanCommand(),
                new Vintasoft.Imaging.ImageProcessing.Filters.MedianCommand(),
                new Vintasoft.Imaging.ImageProcessing.Filters.DilateCommand(),
                new Vintasoft.Imaging.ImageProcessing.Filters.ErodeCommand(),
                new Vintasoft.Imaging.ImageProcessing.Filters.BlurCommand(),
                new Vintasoft.Imaging.ImageProcessing.Filters.GaussianBlurCommand(),
                new Vintasoft.Imaging.ImageProcessing.Filters.EdgeDetectionCommand(),
                new Vintasoft.Imaging.ImageProcessing.Filters.EmbossCommand(),
                new Vintasoft.Imaging.ImageProcessing.Filters.SharpenCommand(),
                new Vintasoft.Imaging.ImageProcessing.Filters.AddNoiseCommand(),
                new Vintasoft.Imaging.ImageProcessing.Filters.CannyEdgeDetectorCommand() };
            availableProcessingCommandGroups.Add("Filters", filterCommands);

            // FFT commands
            ProcessingCommandBase[] fftCommands = new ProcessingCommandBase[] {
                new Vintasoft.Imaging.ImageProcessing.Fft.Filtering.Lowpass.IdealLowpassCommand(),
                new Vintasoft.Imaging.ImageProcessing.Fft.Filtering.Lowpass.ButterworthLowpassCommand(),
                new Vintasoft.Imaging.ImageProcessing.Fft.Filtering.Lowpass.GaussianLowpassCommand(),
                new Vintasoft.Imaging.ImageProcessing.Fft.Filtering.Highpass.IdealHighpassCommand(),
                new Vintasoft.Imaging.ImageProcessing.Fft.Filtering.Highpass.ButterworthHighpassCommand(),
                new Vintasoft.Imaging.ImageProcessing.Fft.Filtering.Highpass.GaussianHighpassCommand(),
                new Vintasoft.Imaging.ImageProcessing.Fft.Filters.ImageSmoothingCommand(),
                new Vintasoft.Imaging.ImageProcessing.Fft.Filters.ImageSharpeningCommand(),
                new Vintasoft.Imaging.ImageProcessing.Fft.FrequencySpectrumVisualizerCommand()};
            availableProcessingCommandGroups.Add("FFT", fftCommands);

            // document cleanup info commands
            ProcessingCommandBase[] documentCleanupInfoCommands = new ProcessingCommandBase[] {
#if !REMOVE_DOCCLEANUP_PLUGIN
                new Vintasoft.Imaging.ImageProcessing.Info.IsDocumentImageCommand(),
#endif
                new Vintasoft.Imaging.ImageProcessing.Info.GetRotationAngleCommand(),
#if !REMOVE_DOCCLEANUP_PLUGIN
                new Vintasoft.Imaging.ImageProcessing.Info.HalftoneRecognitionCommand(),
                new Vintasoft.Imaging.ImageProcessing.Info.DocumentSegmentationCommand(),
                new Vintasoft.Imaging.ImageProcessing.Info.ImageSegmentationCommand(),
                new Vintasoft.Imaging.ImageProcessing.Info.GetTextOrientationCommand(),
                new Vintasoft.Imaging.ImageProcessing.Info.GetDocumentImageRotationAngleCommand()
#endif
            };

            availableProcessingCommandGroups.Add("Document Cleanup, Info", documentCleanupInfoCommands);

#if !REMOVE_DOCCLEANUP_PLUGIN
            // document cleanup commands
            ProcessingCommandBase[] documentCleanupCommands = new ProcessingCommandBase[] {
                new Vintasoft.Imaging.ImageProcessing.Document.AutoInvertCommand(),
                new Vintasoft.Imaging.ImageProcessing.Document.BorderClearCommand(),
                new Vintasoft.Imaging.ImageProcessing.Document.HalftoneRemovalCommand(),
                new Vintasoft.Imaging.ImageProcessing.Document.RestoreTextFromHalftoneCommand(),
                new Vintasoft.Imaging.ImageProcessing.Document.DeskewCommand(),
                new Vintasoft.Imaging.ImageProcessing.Document.DeskewDocumentImageCommand(),
                new Vintasoft.Imaging.ImageProcessing.Document.DocumentPerspectiveCorrectionCommand(),
                new Vintasoft.Imaging.ImageProcessing.Document.SmoothingCommand(),
                new Vintasoft.Imaging.ImageProcessing.Document.HolePunchFillingCommand(),
                new Vintasoft.Imaging.ImageProcessing.Document.HolePunchRemovalCommand(),
                new Vintasoft.Imaging.ImageProcessing.Document.LineRemovalCommand(),
                new Vintasoft.Imaging.ImageProcessing.Document.ShapeRemovalCommand(),
                new Vintasoft.Imaging.ImageProcessing.Document.AutoTextInvertCommand(),
                new Vintasoft.Imaging.ImageProcessing.Document.DespeckleCommand(),
                new Vintasoft.Imaging.ImageProcessing.Document.BorderRemovalCommand(),
                new Vintasoft.Imaging.ImageProcessing.Document.AutoTextOrientationCommand(),
                new Vintasoft.Imaging.ImageProcessing.Document.AdvancedReplaceColorCommand(),
                new Vintasoft.Imaging.ImageProcessing.Document.ColorNoiseClearCommand()};
            availableProcessingCommandGroups.Add("Document Cleanup", documentCleanupCommands);
#endif

            // effects commands
            ProcessingCommandBase[] effectCommands = new ProcessingCommandBase[] {
                new Vintasoft.Imaging.ImageProcessing.Effects.AutoColorsCommand(),
                new Vintasoft.Imaging.ImageProcessing.Effects.AutoContrastCommand(),
                new Vintasoft.Imaging.ImageProcessing.Effects.AutoLevelsCommand(),
                new Vintasoft.Imaging.ImageProcessing.Effects.BevelEdgeCommand(),
                new Vintasoft.Imaging.ImageProcessing.Effects.DropShadowCommand(),
                new Vintasoft.Imaging.ImageProcessing.Effects.MotionBlurCommand(),
                new Vintasoft.Imaging.ImageProcessing.Effects.MosaicCommand(),
                new Vintasoft.Imaging.ImageProcessing.Effects.OilPaintingCommand(),
                new Vintasoft.Imaging.ImageProcessing.Effects.PixelateCommand(),
                new Vintasoft.Imaging.ImageProcessing.Effects.RedEyeRemovalCommand(),
                new Vintasoft.Imaging.ImageProcessing.Effects.SepiaCommand(),
                new Vintasoft.Imaging.ImageProcessing.Effects.SolarizeCommand(),
                new Vintasoft.Imaging.ImageProcessing.Effects.TileReflectionCommand() };
            availableProcessingCommandGroups.Add("Effects", effectCommands);

#if !REMOVE_FORMSPROCESSING_PLUGIN
            // forms processing
            Vintasoft.Imaging.FormsProcessing.TemplateMatching.ImageImprintComparerCommand imprintComparerCommand =
                new Vintasoft.Imaging.FormsProcessing.TemplateMatching.ImageImprintComparerCommand();
            imprintComparerCommand.ImageImprintGenerator = new Vintasoft.Imaging.FormsProcessing.TemplateMatching.ImageImprintGeneratorCommand();
            ProcessingCommandBase[] formsProcessingCommands = new ProcessingCommandBase[] {
                imprintComparerCommand,
                new Vintasoft.Imaging.FormsProcessing.TemplateMatching.TemplateAligningCommand() };
            availableProcessingCommandGroups.Add("Forms Processing", formsProcessingCommands);
#endif

            imageProcessingControl1.AvailableProcessingCommands = availableProcessingCommandGroups;
        }

        /// <summary>
        /// Initializes the processing viewer menu.
        /// </summary>
        private void InitProcessingViewerMenu()
        {
            processedImageToolStripMenuItem.Tag = null;
            differenceToolStripMenuItem.Tag = ImageCompareOperator.Difference;
            averageDifferenceToolStripMenuItem.Tag = ImageCompareOperator.AvgDifference;
            maxDifferenceToolStripMenuItem.Tag = ImageCompareOperator.MaxDifference;
            minDifferenceToolStripMenuItem.Tag = ImageCompareOperator.MinDifference;
        }

        /// <summary>
        /// Initializes the image scale menu.
        /// </summary>
        private void InitImageScaleMenu()
        {
            imageViewer_normalImageToolStripMenuItem.Tag = ImageSizeMode.Normal;
            imageViewer_bestFitToolStripMenuItem.Tag = ImageSizeMode.BestFit;
            imageViewer_fitToWidthToolStripMenuItem.Tag = ImageSizeMode.FitToWidth;
            imageViewer_fitToHeightToolStripMenuItem.Tag = ImageSizeMode.FitToHeight;
            imageViewer_pixelToPixelToolStripMenuItem.Tag = ImageSizeMode.PixelToPixel;
            imageViewer_scaleToolStripMenuItem.Tag = ImageSizeMode.Zoom;
            imageViewer_scale25ToolStripMenuItem.Tag = 25;
            imageViewer_scale50ToolStripMenuItem.Tag = 50;
            imageViewer_scale100ToolStripMenuItem.Tag = 100;
            imageViewer_scale200ToolStripMenuItem.Tag = 200;
            imageViewer_scale400ToolStripMenuItem.Tag = 400;

            _imageViewer_imageScaleSelectedMenuItem = imageViewer_normalImageToolStripMenuItem;
            _imageViewer_imageScaleSelectedMenuItem.Checked = true;
        }

        /// <summary>
        /// Returns the result of comparing two <see cref="VintasoftImage"/>.
        /// </summary>
        /// <param name="firstImage">The first image.</param>
        /// <param name="secondImage">The second image.</param>
        /// <returns><see cref="VintasoftImage"/> that is a result of comparing two images.</returns>
        private VintasoftImage CompareImages(VintasoftImage firstImage, VintasoftImage secondImage)
        {
            // compare images
            ImageComparisonCommand command = new ImageComparisonCommand();
            command.CompareOperator = _compareOperator;
            command.Image = secondImage;
            VintasoftImage result = command.Execute(firstImage);

            // convert processed image pixel format; it allows to change the palette of processed image
            ChangePixelFormatToPaletteCommand convertProcessedImage = new ChangePixelFormatToPaletteCommand(PixelFormat.Indexed8);
            convertProcessedImage.ExecuteInPlace(result);

            // set current palette
            _paletteSettingsForm.SetColors(result.Palette);

            return result;
        }

        #endregion

    }
}
