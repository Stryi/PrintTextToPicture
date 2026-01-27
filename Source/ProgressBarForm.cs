using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Tools.ExecuteWorkerBase;

namespace PrintTextToPicture.Source
{
    public partial class ProgressBarForm : Form
    {
        internal Program executeWorker;

        public ProgressBarForm()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            this.labelProgress.ResetText();
            this.backgroundWorker.RunWorkerAsync();
        }

        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            this.executeWorker = new Program();
            this.executeWorker.BackgroundWorker = this.backgroundWorker;

            this.executeWorker.Execute();
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

            this.Close();
        }

        private void buttonAbort_Click(object sender, EventArgs e)
        {
            Program.Abort = true;
        }
    }
}
