using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tools;
using static Tools.ExecuteWorkerBase;

namespace PrintTextToPicture
{
    public partial class MainForm : Form
    {
        internal Program executeWorker;

        public MainForm()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            this.labelProgress.ResetText();

            this.textBoxPath.Text                 = Configuration.SourceDir;
            this.checkBoxProcessSubFolder.Checked = Configuration.ProcessSubFolder;
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            
            Configuration.SourceDir        = this.textBoxPath.Text;
            Configuration.ProcessSubFolder = this.checkBoxProcessSubFolder.Checked;

            Configuration.SaveConfig();
        }

        private void button_Click(object sender, EventArgs e)
        {
            string command = string.Empty;

            this.textBoxPath.Enabled = false;
            this.buttonSelectDirectory.Enabled = false;
            this.checkBoxProcessSubFolder.Enabled = false;

            this.buttonMake.Enabled = false;
            this.buttonCompress.Enabled = false;

            this.buttonMake.Visible = false;
            this.buttonCompress.Visible = false;

            this.pictureBoxMake.Visible = false;
            this.pictureBoxCompress.Visible = false;

            if (sender == this.buttonMake)
            {
                this.buttonMake.Visible = true;
                this.pictureBoxMake.Visible = true;

                command = "MAKE";
            }

            if (sender == this.buttonCompress)
            {
                this.buttonCompress.Visible = true;
                this.pictureBoxCompress.Visible = true;

                command = "COMPRESS";
            }

            this.labelProgress.ResetText();
            this.labelProgress.ForeColor = SystemColors.WindowText;

            this.backgroundWorker.RunWorkerAsync(command);
        }


        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            this.executeWorker = new Program();
            this.executeWorker.BackgroundWorker = this.backgroundWorker;
            this.executeWorker.PictureRootPath  = this.textBoxPath.Text;
            this.executeWorker.ProcessSubFolder = this.checkBoxProcessSubFolder.Checked;

            this.executeWorker.Execute(e.Argument.ToString());
        }

        private void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (e.UserState is ProgressInformation)
            {
                this.labelProgress.Text = ((ProgressInformation)e.UserState).Message;
            }
            this.progressBar.Value = e.ProgressPercentage;
        }

        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.buttonSelectDirectory.Enabled = true;
            this.textBoxPath.Enabled = true;
            this.pictureBoxMake.Visible = true;
            this.pictureBoxCompress.Visible = true;
            this.buttonMake.Visible = true;
            this.buttonCompress.Visible = true;

            this.buttonMake.Enabled = true;
            this.buttonCompress.Enabled = true;

            this.textBoxPath.Enabled = true;

            this.checkBoxProcessSubFolder.Enabled = true;

            if (e.Error != null)
            {
                MessageBox.Show(this, e.Error.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.labelProgress.Text = e.Error.Message;
                this.labelProgress.ForeColor = Color.Red;
                //this.progressBar.Value = 0;
                return;
            }

            this.labelProgress.ResetText();

            string completedMessage = "Bearbeitung abgeschlossen";
            if (e.Result is ProgressInformation)
            {

                completedMessage = ((ProgressInformation)e.Result).Message;
            }

            MessageBox.Show(this, completedMessage, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.progressBar.Value = 0;
        }

        private void buttonSelectDirectory_Click(object sender, EventArgs e)
        {
            using (var folderBrowserDialog = new FolderBrowserDialog())
            {
                folderBrowserDialog.SelectedPath = this.textBoxPath.Text;

                // Zeige den Dialog an
                DialogResult result = folderBrowserDialog.ShowDialog();

                // Überprüfe, ob der Benutzer auf "OK" geklickt hat
                if (result == DialogResult.OK)
                {
                    this.textBoxPath.Text = folderBrowserDialog.SelectedPath;
                }
            }
        }
    }
}
