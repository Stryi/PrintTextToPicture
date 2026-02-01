using PrintTextToPicture.Properties;
using PrintTextToPicture.Source;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using System.Drawing.Imaging;
using static Tools.ExecuteWorkerBase;

namespace PrintTextToPicture
{
    public partial class MainForm : Form
    {

        public MainForm()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            this.textBoxSourceDir.Text      = Environment.ExpandEnvironmentVariables(Settings.Default.SourceDir);
            this.textBoxDestinationDir.Text = Environment.ExpandEnvironmentVariables(Settings.Default.ProcessDir);
            this.checkBoxOverrideDestination.Checked = Settings.Default.OverrideDestination;
            this.checkBoxCompress.Checked  = Settings.Default.Compress;
            this.numericUpDownWidth.Value  = Settings.Default.MaxPictureHeight;
            this.numericUpDownHieght.Value = Settings.Default.MaxPictureHeight;
            this.checkBoxAddText.Checked   = Settings.Default.AddText;
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            
            Settings.Default.SourceDir = this.textBoxSourceDir.Text;
            Settings.Default.ProcessDir = this.textBoxDestinationDir.Text;
            Settings.Default.OverrideDestination = checkBoxOverrideDestination.Checked;
            Settings.Default.Compress         = this.checkBoxCompress.Checked;
            Settings.Default.MaxPictureHeight = Convert.ToInt32(this.numericUpDownWidth.Value);
            Settings.Default.MaxPictureHeight = Convert.ToInt32(this.numericUpDownHieght.Value);
            Settings.Default.AddText          = this.checkBoxAddText.Checked;

            Settings.Default.Save();
        }

        private void buttonSelectSourceDir_Click(object sender, EventArgs e)
        {
            using (var folderBrowserDialog = new FolderBrowserDialog())
            {
                folderBrowserDialog.SelectedPath = this.textBoxSourceDir.Text;

                DialogResult result = folderBrowserDialog.ShowDialog();

                if (result == DialogResult.OK)
                {
                    this.textBoxSourceDir.Text = folderBrowserDialog.SelectedPath;
                }
            }
        }

        private void buttonSelectDestinationDir_Click(object sender, EventArgs e)
        {
            using (var folderBrowserDialog = new FolderBrowserDialog())
            {
                folderBrowserDialog.SelectedPath = this.textBoxDestinationDir.Text;

                DialogResult result = folderBrowserDialog.ShowDialog();

                if (result == DialogResult.OK)
                {
                    this.textBoxDestinationDir.Text = folderBrowserDialog.SelectedPath;
                }
            }
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            this.textBoxSourceDir.Enabled = false;
            this.textBoxDestinationDir.Enabled = false;
            this.buttonSelectSourceDir.Enabled = false;
            this.buttonSelectDestinationDir.Enabled = false;
            this.checkBoxOverrideDestination.Enabled = false;

            this.checkBoxCompress.Enabled   = false;
            this.checkBoxAddText.Enabled = false;

            this.buttonStart.Enabled = false;

            this.Visible = false;

            Program.SourceImageDirectory = this.textBoxSourceDir.Text;
            Program.DestinationImageDirectory = this.textBoxDestinationDir.Text;
            Program.Abort = false;

            PictureMaker.overrideDestination = this.checkBoxOverrideDestination.Checked;
            PictureMaker.resizeToFit =       this.checkBoxCompress.Checked;
            PictureMaker.addText             = this.checkBoxAddText.Checked;
            PictureMaker.maxHeight = Convert.ToInt32(this.numericUpDownHieght.Value);
            PictureMaker.maxWidth  = Convert.ToInt32(this.numericUpDownWidth.Value);
            PictureMaker.pictureQuality = Convert.ToInt32(this.numericUpPictureQuality.Value);

            var progressBar = new ProgressBarForm();
            progressBar.ShowDialog(this);

            this.Visible = true;

            this.textBoxSourceDir.Enabled = true;
            this.textBoxDestinationDir.Enabled = true;
            this.buttonSelectSourceDir.Enabled = true;
            this.buttonSelectDestinationDir.Enabled = true;
            this.checkBoxOverrideDestination.Enabled = true;

            this.checkBoxCompress.Enabled = true;
            this.checkBoxAddText.Enabled = true;
            this.buttonStart.Enabled = true;

            /*
            var executeParameter = new ExecutionParameter();

            executeParameter.SourceImageDirectory      = this.textBoxSourceDir.Text;
            executeParameter.DestinationImageDirectory = this.textBoxDestinationDir.Text;

            PictureMaker.overrideDestination = this.checkBoxOverrideDestination.Checked;
            PictureMaker.addText     = this.checkBoxAddText.Checked;
            PictureMaker.resizeToFit = this.checkBoxCompress.Checked;
            PictureMaker.maxHeight   = 1080;
            PictureMaker.maxWidth    = 1920;

            this.labelProgress.ResetText();
            this.labelProgress.ForeColor = SystemColors.WindowText;

            this.backgroundWorker.RunWorkerAsync(executeParameter);
            */
        }

        private void checkBoxCompress_CheckedChanged(object sender, EventArgs e)
        {
            bool compress = this.checkBoxCompress.Checked;
            bool addText = this.checkBoxAddText.Checked;

            this.numericUpDownHieght.Enabled = compress;
            this.numericUpDownWidth.Enabled  = compress;
            this.labelPictureSize.Enabled    = compress;

            this.labelPictureQuality.Enabled     = compress || addText;
            this.numericUpPictureQuality.Enabled = compress || addText;

            if (compress)
            {
                this.pictureBoxCompress.Image = Resources.compress;
            }
            else
            {
                this.pictureBoxCompress.Image = ToGrayscale(Resources.compress);
            }
        }

        private void checkBoxAddText_CheckedChanged(object sender, EventArgs e)
        {
            bool compress = this.checkBoxCompress.Checked;
            bool addText = this.checkBoxAddText.Checked;

            this.labelPictureQuality.Enabled = compress || addText;
            this.numericUpPictureQuality.Enabled = compress || addText;

            if (addText)
            {
                this.pictureBoxAddText.Image = Resources.addText;
            }
            else
            {
                this.pictureBoxAddText.Image = ToGrayscale(Resources.addText);
            }
        }


        public static Image ToGrayscale(Image original)
        {
            Bitmap grayBitmap = new Bitmap(original.Width, original.Height);

            using (Graphics g = Graphics.FromImage(grayBitmap))
            {
                ColorMatrix colorMatrix = new ColorMatrix(
                    new float[][]
                    {
                    new float[] {0.3f, 0.3f, 0.3f, 0, 0},
                    new float[] {0.59f, 0.59f, 0.59f, 0, 0},
                    new float[] {0.11f, 0.11f, 0.11f, 0, 0},
                    new float[] {0,    0,    0,    1, 0},
                    new float[] {0,    0,    0,    0, 1}
                    });

                using (ImageAttributes attributes = new ImageAttributes())
                {
                    attributes.SetColorMatrix(colorMatrix);
                    g.DrawImage(
                        original,
                        new Rectangle(0, 0, original.Width, original.Height),
                        0, 0, original.Width, original.Height,
                        GraphicsUnit.Pixel,
                        attributes);
                }
            }

            return grayBitmap;
        }
    }
}
