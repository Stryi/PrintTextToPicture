namespace PrintTextToPicture
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
            this.buttonMake = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.labelProgress = new System.Windows.Forms.Label();
            this.textBoxPath = new System.Windows.Forms.TextBox();
            this.buttonSelectDirectory = new System.Windows.Forms.Button();
            this.labelDescription = new System.Windows.Forms.Label();
            this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.checkBoxProcessSubFolder = new System.Windows.Forms.CheckBox();
            this.buttonCompress = new System.Windows.Forms.Button();
            this.pictureBoxCompress = new System.Windows.Forms.PictureBox();
            this.pictureBoxMake = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCompress)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMake)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonMake
            // 
            this.buttonMake.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonMake.Location = new System.Drawing.Point(467, 382);
            this.buttonMake.Name = "buttonMake";
            this.buttonMake.Size = new System.Drawing.Size(252, 49);
            this.buttonMake.TabIndex = 5;
            this.buttonMake.Text = "Text hinzufügen";
            this.buttonMake.UseVisualStyleBackColor = true;
            this.buttonMake.Click += new System.EventHandler(this.button_Click);
            // 
            // progressBar
            // 
            this.progressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar.Location = new System.Drawing.Point(33, 519);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(863, 23);
            this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar.TabIndex = 9;
            // 
            // labelProgress
            // 
            this.labelProgress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelProgress.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelProgress.Location = new System.Drawing.Point(29, 452);
            this.labelProgress.Name = "labelProgress";
            this.labelProgress.Size = new System.Drawing.Size(867, 64);
            this.labelProgress.TabIndex = 8;
            this.labelProgress.Text = "Progress text";
            // 
            // textBoxPath
            // 
            this.textBoxPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxPath.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxPath.Location = new System.Drawing.Point(33, 49);
            this.textBoxPath.Name = "textBoxPath";
            this.textBoxPath.Size = new System.Drawing.Size(811, 26);
            this.textBoxPath.TabIndex = 1;
            // 
            // buttonSelectDirectory
            // 
            this.buttonSelectDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSelectDirectory.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSelectDirectory.Location = new System.Drawing.Point(853, 49);
            this.buttonSelectDirectory.Name = "buttonSelectDirectory";
            this.buttonSelectDirectory.Size = new System.Drawing.Size(43, 32);
            this.buttonSelectDirectory.TabIndex = 2;
            this.buttonSelectDirectory.Text = "...";
            this.buttonSelectDirectory.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.buttonSelectDirectory.UseVisualStyleBackColor = true;
            this.buttonSelectDirectory.Click += new System.EventHandler(this.buttonSelectDirectory_Click);
            // 
            // labelDescription
            // 
            this.labelDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDescription.Location = new System.Drawing.Point(29, 23);
            this.labelDescription.Name = "labelDescription";
            this.labelDescription.Size = new System.Drawing.Size(867, 23);
            this.labelDescription.TabIndex = 0;
            this.labelDescription.Text = "Stammverzeichnis der Bilder die GEÄNDERT werden sollen:";
            // 
            // backgroundWorker
            // 
            this.backgroundWorker.WorkerReportsProgress = true;
            this.backgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker_DoWork);
            this.backgroundWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker_ProgressChanged);
            this.backgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker_RunWorkerCompleted);
            // 
            // checkBoxProcessSubFolder
            // 
            this.checkBoxProcessSubFolder.AutoSize = true;
            this.checkBoxProcessSubFolder.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxProcessSubFolder.Location = new System.Drawing.Point(33, 85);
            this.checkBoxProcessSubFolder.Name = "checkBoxProcessSubFolder";
            this.checkBoxProcessSubFolder.Size = new System.Drawing.Size(202, 24);
            this.checkBoxProcessSubFolder.TabIndex = 3;
            this.checkBoxProcessSubFolder.Text = "auch Unterverzeichnisse";
            this.checkBoxProcessSubFolder.UseVisualStyleBackColor = true;
            // 
            // buttonCompress
            // 
            this.buttonCompress.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCompress.Location = new System.Drawing.Point(33, 382);
            this.buttonCompress.Name = "buttonCompress";
            this.buttonCompress.Size = new System.Drawing.Size(252, 49);
            this.buttonCompress.TabIndex = 4;
            this.buttonCompress.Text = "Compress";
            this.buttonCompress.UseVisualStyleBackColor = true;
            this.buttonCompress.Click += new System.EventHandler(this.button_Click);
            // 
            // pictureBoxCompress
            // 
            this.pictureBoxCompress.Image = global::PrintTextToPicture.Properties.Resources.compress;
            this.pictureBoxCompress.Location = new System.Drawing.Point(33, 126);
            this.pictureBoxCompress.Name = "pictureBoxCompress";
            this.pictureBoxCompress.Size = new System.Drawing.Size(408, 250);
            this.pictureBoxCompress.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxCompress.TabIndex = 9;
            this.pictureBoxCompress.TabStop = false;
            // 
            // pictureBoxMake
            // 
            this.pictureBoxMake.Image = global::PrintTextToPicture.Properties.Resources.text;
            this.pictureBoxMake.Location = new System.Drawing.Point(467, 126);
            this.pictureBoxMake.Name = "pictureBoxMake";
            this.pictureBoxMake.Size = new System.Drawing.Size(408, 250);
            this.pictureBoxMake.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxMake.TabIndex = 1;
            this.pictureBoxMake.TabStop = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(937, 564);
            this.Controls.Add(this.buttonCompress);
            this.Controls.Add(this.pictureBoxCompress);
            this.Controls.Add(this.checkBoxProcessSubFolder);
            this.Controls.Add(this.labelDescription);
            this.Controls.Add(this.buttonSelectDirectory);
            this.Controls.Add(this.textBoxPath);
            this.Controls.Add(this.labelProgress);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.buttonMake);
            this.Controls.Add(this.pictureBoxMake);
            this.MinimumSize = new System.Drawing.Size(660, 485);
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Beschriftung in die Bilder integrieren";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCompress)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMake)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBoxMake;
        private System.Windows.Forms.Button buttonMake;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label labelProgress;
        private System.Windows.Forms.TextBox textBoxPath;
        private System.Windows.Forms.Button buttonSelectDirectory;
        private System.Windows.Forms.Label labelDescription;
        private System.ComponentModel.BackgroundWorker backgroundWorker;
        private System.Windows.Forms.CheckBox checkBoxProcessSubFolder;
        private System.Windows.Forms.Button buttonCompress;
        private System.Windows.Forms.PictureBox pictureBoxCompress;
    }
}