using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using Vintasoft.Imaging;

namespace ImageProcessingDemo.Dialogs
{
    /// <summary>
    /// A form that allows to view and change the palette for image that visualizes the differences between two images.
    /// </summary>
    public partial class DifferencesPaletteForm : Form
    {

        #region Fields

        /// <summary>
        /// The palette.
        /// </summary>
        int[] _colors = new int[256];

        /// <summary>
        /// The color that defines point 0 in a color range from 0 to 255.
        /// </summary>
        Color _backColor = Color.Black;

        /// <summary>
        /// The color that defines the first point in the first range in a color range from 0 to 255.
        /// </summary>
        Color _firstColorInFirstColorRange;

        /// <summary>
        /// The color that defines the second point in the first range in a color range from 0 to 255.
        /// </summary>
        Color _secondColorInFirstColorRange;

        /// <summary>
        /// The color that defines the first point in the second range in a color range from 0 to 255.
        /// </summary>
        Color _firstColorInSecondColorRange;

        /// <summary>
        /// The color that defines the second point in the second range in a color range from 0 to 255.
        /// </summary>
        Color _secondColorInSecondColorRange;

        #endregion



        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="DifferencesPaletteForm"/> class.
        /// </summary>
        public DifferencesPaletteForm()
        {
            InitializeComponent();

            paletteGammaComboBox.SelectedIndex = 2;
            criticalLevelTrackBar.Value = 255;
            _sourcePalette = new Vintasoft.Imaging.Palette(_colors);
        }

        #endregion



        #region Properties

        Vintasoft.Imaging.Palette _sourcePalette = null;
        /// <summary>
        /// Gets or sets the palette of the processed image.
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Vintasoft.Imaging.Palette SourcePalette
        {
            get
            {
                return _sourcePalette;
            }
            set
            {
                _sourcePalette = value;
            }
        }

        #endregion



        #region Methods

        #region PUBLIC

        /// <summary>
        /// Sets colors in image palette.
        /// </summary>
        /// <param name="palette">The palette in which the colors are set.</param>
        public void SetColors(Vintasoft.Imaging.Palette palette)
        {
            palette.SetColors(_colors);
        }

        #endregion


        #region PRIVATE

        #region UI

        /// <summary>
        /// Handles the SelectedIndexChanged event of paletteGammaComboBox object.
        /// </summary>
        private void paletteGammaComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (paletteGammaComboBox.SelectedIndex)
            {
                // green - red palette
                case 0:
                    _firstColorInFirstColorRange = System.Drawing.Color.FromArgb(0, 128, 0);
                    _secondColorInFirstColorRange = System.Drawing.Color.FromArgb(0, 255, 0);
                    _firstColorInSecondColorRange = System.Drawing.Color.FromArgb(255, 0, 0);
                    _secondColorInSecondColorRange = System.Drawing.Color.FromArgb(255, 0, 0);
                    break;

                // green - yellow - red palette
                case 1:
                    _firstColorInFirstColorRange = System.Drawing.Color.FromArgb(0, 128, 0);
                    _secondColorInFirstColorRange = Color.Yellow;
                    _firstColorInSecondColorRange = Color.Yellow;
                    _secondColorInSecondColorRange = System.Drawing.Color.FromArgb(255, 0, 0);
                    break;

                // black - white palette
                case 2:
                    _firstColorInFirstColorRange = Color.Black;
                    _secondColorInFirstColorRange = Color.White;
                    _firstColorInSecondColorRange = Color.White;
                    _secondColorInSecondColorRange = Color.White;
                    break;
            }

            // update palette
            UpdatePalette();

            // update image
            UpdateDisplay(true);
        }

        /// <summary>
        /// Handles the ValueChanged event of criticalLevelTrackBar object.
        /// </summary>
        private void criticalLevelTrackBar_ValueChanged(object sender, EventArgs e)
        {
            // update palette
            UpdatePalette();

            // update image
            UpdateDisplay(true);
        }

        #endregion


        /// <summary>
        /// Updates the palette.
        /// </summary>
        /// <param name="positions">The positions of colors.</param>
        /// <param name="colors">The colors.</param>
        private void UpdatePalette(byte[] positions, System.Drawing.Color[] colors)
        {
            if (positions == null || positions.Length == 0)
                throw new ArgumentException("positions");
            if (colors == null || colors.Length == 0)
                throw new ArgumentException("colors");
            if (positions.Length != colors.Length)
                throw new ArgumentException("positions.Length != colors.Length");


            // set the first color
            int firstColor = colors[0].ToArgb();
            for (int i = 0; i <= positions[0]; i++)
                _colors[i] = firstColor;

            // set given colors
            int startPos = positions[0];
            for (int i = 1; i < positions.Length; i++)
            {
                int len = positions[i] - startPos + 1;
                int R = colors[i - 1].R;
                int G = colors[i - 1].G;
                int B = colors[i - 1].B;
                float dR = (colors[i].R - R) / (float)len;
                float dG = (colors[i].G - G) / (float)len;
                float dB = (colors[i].B - B) / (float)len;
                for (int j = 0; j < len; j++)
                {
                    _colors[positions[i - 1] + j] = System.Drawing.Color.FromArgb((int)Math.Round(R + dR * j), (int)Math.Round(G + dG * j), (int)Math.Round(B + dB * j)).ToArgb();
                }
                startPos = (int)positions[i] + 1;
            }
            startPos--;

            // set the last color
            int lastColor = colors[colors.Length - 1].ToArgb();
            for (int i = startPos; i < 256; i++)
                _colors[i] = lastColor;
        }

        /// <summary>
        /// Returns the palette of differences as <see cref="Vintasoft.Imaging.VintasoftImage"/>.
        /// </summary>
        /// <param name="cellWidth">Single color cell width.</param>
        /// <param name="heigth">Result image height.</param>
        /// <returns><see cref="Vintasoft.Imaging.VintasoftImage"/> that is a palette of differences.</returns>
        private VintasoftImage GetAsImage(int cellWidth, int heigth)
        {
            VintasoftImage image = new VintasoftImage(cellWidth * 256, heigth, PixelFormat.Indexed8);

            PixelManipulator pixelManipulator = image.OpenPixelManipulator();
            pixelManipulator.LockPixels(new System.Drawing.Rectangle(0, 0, image.Width, image.Height), Vintasoft.Imaging.BitmapLockMode.ReadWrite);
            byte[] line = new byte[pixelManipulator.Stride];

            // prepare the line
            for (int cell = 0; cell < 256; cell++)
                for (int x = 0; x < cellWidth; x++)
                    line[cell * cellWidth + x] = (byte)cell;

            // write data
            for (int y = 0; y < heigth; y++)
                pixelManipulator.WriteRowDataUnsafe(y, line, 0, line.Length);

            pixelManipulator.UnlockPixels();
            image.ClosePixelManipulator(true);

            SetColors(image.Palette);
            return image;
        }

        /// <summary>
        /// Updates the palette.
        /// </summary>
        private void UpdatePalette()
        {
            byte criticalLevel = (byte)criticalLevelTrackBar.Value;

            criticalLevelLabel.Text = criticalLevel.ToString();

            if (criticalLevel == 0)
            {
                UpdatePalette(
                    new byte[] { 0, 1, 255 },
                    new Color[] { _backColor, _firstColorInSecondColorRange, _secondColorInSecondColorRange }
                    );
            }
            else if (criticalLevel == 255)
            {
                UpdatePalette(
                    new byte[] { 0, 1, 255 },
                    new Color[] { _backColor, _firstColorInFirstColorRange, _secondColorInFirstColorRange }
                    );
            }
            else
            {
                UpdatePalette(
                    new byte[] { 0, 1, criticalLevel, Math.Min((byte)255, (byte)(criticalLevel + 1)), 255 },
                    new Color[] { _backColor, _firstColorInFirstColorRange, _secondColorInFirstColorRange, _firstColorInSecondColorRange, _secondColorInSecondColorRange }
                    );
            }

            if (differenceColorsImageViewer.Image != null)
            {
                // change palette
                SetColors(differenceColorsImageViewer.Image.Palette);
            }
            else
            {
                // set new palette
                differenceColorsImageViewer.Image = GetAsImage(1, differenceColorsImageViewer.ClientSize.Height);
            }

            criticalLevelLabel.Refresh();
            differenceColorsImageViewer.Refresh();
        }

        /// <summary>
        /// Updates the image.
        /// </summary>
        /// <param name="paletteChanged">Indicates whether palette is changed.</param>
        private void UpdateDisplay(bool paletteChanged)
        {
            if (SourcePalette == null)
            {
                return;
            }
            else if (paletteChanged)
            {
                SetColors(SourcePalette);
            }
        }

        #endregion

        #endregion

    }
}
