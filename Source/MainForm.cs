using PrintTextToPicture.Source;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
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

            this.textBoxSourceDir.Text      = Configuration.SourceDir;
            this.textBoxDestinationDir.Text = Configuration.ProcessDir;
            this.checkBoxOverrideDestination.Checked = Configuration.OverrideDestination;
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            
            Configuration.SourceDir  = this.textBoxSourceDir.Text;
            Configuration.ProcessDir = this.textBoxDestinationDir.Text;
            Configuration.OverrideDestination = this.checkBoxOverrideDestination.Checked;

            Configuration.SaveConfig();
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

            PictureMaker.addText             = this.checkBoxAddText.Checked;
            PictureMaker.resizeToFit         = this.checkBoxCompress.Checked;
            PictureMaker.overrideDestination = this.checkBoxOverrideDestination.Checked;
            PictureMaker.maxHeight = 1080;
            PictureMaker.maxWidth  = 1920;

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
    }
}
