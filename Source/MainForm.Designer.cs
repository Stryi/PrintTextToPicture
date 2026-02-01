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
            this.textBoxDestinationDir = new System.Windows.Forms.TextBox();
            this.buttonSelectDestinationDir = new System.Windows.Forms.Button();
            this.labelDescription = new System.Windows.Forms.Label();
            this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.buttonStart = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonSelectSourceDir = new System.Windows.Forms.Button();
            this.textBoxSourceDir = new System.Windows.Forms.TextBox();
            this.checkBoxOverrideDestination = new System.Windows.Forms.CheckBox();
            this.groupBoxAddText = new System.Windows.Forms.GroupBox();
            this.checkBoxAddText = new System.Windows.Forms.CheckBox();
            this.pictureBoxAddText = new System.Windows.Forms.PictureBox();
            this.groupBoxCompress = new System.Windows.Forms.GroupBox();
            this.numericUpPictureQuality = new System.Windows.Forms.NumericUpDown();
            this.labelPictureQuality = new System.Windows.Forms.Label();
            this.numericUpDownHieght = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownWidth = new System.Windows.Forms.NumericUpDown();
            this.labelPictureSize = new System.Windows.Forms.Label();
            this.checkBoxCompress = new System.Windows.Forms.CheckBox();
            this.pictureBoxCompress = new System.Windows.Forms.PictureBox();
            this.groupBoxAddText.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAddText)).BeginInit();
            this.groupBoxCompress.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpPictureQuality)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownHieght)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCompress)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxDestinationDir
            // 
            this.textBoxDestinationDir.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxDestinationDir.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxDestinationDir.Location = new System.Drawing.Point(33, 121);
            this.textBoxDestinationDir.Name = "textBoxDestinationDir";
            this.textBoxDestinationDir.Size = new System.Drawing.Size(835, 26);
            this.textBoxDestinationDir.TabIndex = 5;
            // 
            // buttonSelectDestinationDir
            // 
            this.buttonSelectDestinationDir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSelectDestinationDir.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSelectDestinationDir.Location = new System.Drawing.Point(874, 115);
            this.buttonSelectDestinationDir.Name = "buttonSelectDestinationDir";
            this.buttonSelectDestinationDir.Size = new System.Drawing.Size(43, 32);
            this.buttonSelectDestinationDir.TabIndex = 6;
            this.buttonSelectDestinationDir.Text = "...";
            this.buttonSelectDestinationDir.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.buttonSelectDestinationDir.UseVisualStyleBackColor = true;
            this.buttonSelectDestinationDir.Click += new System.EventHandler(this.buttonSelectDestinationDir_Click);
            // 
            // labelDescription
            // 
            this.labelDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDescription.Location = new System.Drawing.Point(29, 90);
            this.labelDescription.Name = "labelDescription";
            this.labelDescription.Size = new System.Drawing.Size(823, 23);
            this.labelDescription.TabIndex = 4;
            this.labelDescription.Text = "Ziel-Verzeichnis, wo die Bildern komprimiert und beschriftet kopiert werden solle" +
    "n:";
            // 
            // backgroundWorker
            // 
            this.backgroundWorker.WorkerReportsProgress = true;
            // 
            // buttonStart
            // 
            this.buttonStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonStart.Location = new System.Drawing.Point(937, 23);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(122, 41);
            this.buttonStart.TabIndex = 0;
            this.buttonStart.Text = "Starten";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(29, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(823, 23);
            this.label1.TabIndex = 1;
            this.label1.Text = "Quell-Verzeichnis mit den ORIGINAL Bildern:";
            // 
            // buttonSelectSourceDir
            // 
            this.buttonSelectSourceDir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSelectSourceDir.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSelectSourceDir.Location = new System.Drawing.Point(874, 32);
            this.buttonSelectSourceDir.Name = "buttonSelectSourceDir";
            this.buttonSelectSourceDir.Size = new System.Drawing.Size(43, 32);
            this.buttonSelectSourceDir.TabIndex = 3;
            this.buttonSelectSourceDir.Text = "...";
            this.buttonSelectSourceDir.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.buttonSelectSourceDir.UseVisualStyleBackColor = true;
            this.buttonSelectSourceDir.Click += new System.EventHandler(this.buttonSelectSourceDir_Click);
            // 
            // textBoxSourceDir
            // 
            this.textBoxSourceDir.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxSourceDir.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxSourceDir.Location = new System.Drawing.Point(33, 38);
            this.textBoxSourceDir.Name = "textBoxSourceDir";
            this.textBoxSourceDir.Size = new System.Drawing.Size(835, 26);
            this.textBoxSourceDir.TabIndex = 2;
            // 
            // checkBoxOverrideDestination
            // 
            this.checkBoxOverrideDestination.AutoSize = true;
            this.checkBoxOverrideDestination.Checked = true;
            this.checkBoxOverrideDestination.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxOverrideDestination.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxOverrideDestination.Location = new System.Drawing.Point(33, 153);
            this.checkBoxOverrideDestination.Name = "checkBoxOverrideDestination";
            this.checkBoxOverrideDestination.Size = new System.Drawing.Size(319, 24);
            this.checkBoxOverrideDestination.TabIndex = 7;
            this.checkBoxOverrideDestination.Text = "Überschreibe Dateien im Ziel-Verzeichnis";
            this.checkBoxOverrideDestination.UseVisualStyleBackColor = true;
            // 
            // groupBoxAddText
            // 
            this.groupBoxAddText.Controls.Add(this.checkBoxAddText);
            this.groupBoxAddText.Controls.Add(this.pictureBoxAddText);
            this.groupBoxAddText.Location = new System.Drawing.Point(492, 242);
            this.groupBoxAddText.Name = "groupBoxAddText";
            this.groupBoxAddText.Size = new System.Drawing.Size(435, 351);
            this.groupBoxAddText.TabIndex = 16;
            this.groupBoxAddText.TabStop = false;
            this.groupBoxAddText.Text = "Bilder beschriften";
            // 
            // checkBoxAddText
            // 
            this.checkBoxAddText.AutoSize = true;
            this.checkBoxAddText.Checked = true;
            this.checkBoxAddText.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxAddText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxAddText.Location = new System.Drawing.Point(10, 22);
            this.checkBoxAddText.Name = "checkBoxAddText";
            this.checkBoxAddText.Size = new System.Drawing.Size(156, 24);
            this.checkBoxAddText.TabIndex = 11;
            this.checkBoxAddText.Text = "Text hinzufügen";
            this.checkBoxAddText.UseVisualStyleBackColor = true;
            this.checkBoxAddText.CheckedChanged += new System.EventHandler(this.checkBoxAddText_CheckedChanged);
            // 
            // pictureBoxAddText
            // 
            this.pictureBoxAddText.Image = global::PrintTextToPicture.Properties.Resources.addText;
            this.pictureBoxAddText.Location = new System.Drawing.Point(21, 79);
            this.pictureBoxAddText.Name = "pictureBoxAddText";
            this.pictureBoxAddText.Size = new System.Drawing.Size(408, 250);
            this.pictureBoxAddText.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxAddText.TabIndex = 10;
            this.pictureBoxAddText.TabStop = false;
            // 
            // groupBoxCompress
            // 
            this.groupBoxCompress.Controls.Add(this.numericUpDownHieght);
            this.groupBoxCompress.Controls.Add(this.numericUpDownWidth);
            this.groupBoxCompress.Controls.Add(this.labelPictureSize);
            this.groupBoxCompress.Controls.Add(this.checkBoxCompress);
            this.groupBoxCompress.Controls.Add(this.pictureBoxCompress);
            this.groupBoxCompress.Location = new System.Drawing.Point(33, 242);
            this.groupBoxCompress.Name = "groupBoxCompress";
            this.groupBoxCompress.Size = new System.Drawing.Size(435, 351);
            this.groupBoxCompress.TabIndex = 17;
            this.groupBoxCompress.TabStop = false;
            this.groupBoxCompress.Text = "Bilder verkleinern";
            // 
            // numericUpPictureQuality
            // 
            this.numericUpPictureQuality.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.numericUpPictureQuality.Location = new System.Drawing.Point(474, 191);
            this.numericUpPictureQuality.Name = "numericUpPictureQuality";
            this.numericUpPictureQuality.Size = new System.Drawing.Size(53, 26);
            this.numericUpPictureQuality.TabIndex = 22;
            this.numericUpPictureQuality.Value = new decimal(new int[] {
            75,
            0,
            0,
            0});
            // 
            // labelPictureQuality
            // 
            this.labelPictureQuality.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPictureQuality.Location = new System.Drawing.Point(29, 191);
            this.labelPictureQuality.Name = "labelPictureQuality";
            this.labelPictureQuality.Size = new System.Drawing.Size(439, 23);
            this.labelPictureQuality.TabIndex = 21;
            this.labelPictureQuality.Text = "Bildqualität in % beim Komprimieren oder Text hinzufügen";
            // 
            // numericUpDownHieght
            // 
            this.numericUpDownHieght.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.numericUpDownHieght.Location = new System.Drawing.Point(340, 47);
            this.numericUpDownHieght.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numericUpDownHieght.Name = "numericUpDownHieght";
            this.numericUpDownHieght.Size = new System.Drawing.Size(72, 26);
            this.numericUpDownHieght.TabIndex = 20;
            this.numericUpDownHieght.Value = new decimal(new int[] {
            1080,
            0,
            0,
            0});
            // 
            // numericUpDownWidth
            // 
            this.numericUpDownWidth.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.numericUpDownWidth.Location = new System.Drawing.Point(262, 47);
            this.numericUpDownWidth.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numericUpDownWidth.Name = "numericUpDownWidth";
            this.numericUpDownWidth.Size = new System.Drawing.Size(72, 26);
            this.numericUpDownWidth.TabIndex = 19;
            this.numericUpDownWidth.Value = new decimal(new int[] {
            1920,
            0,
            0,
            0});
            // 
            // labelPictureSize
            // 
            this.labelPictureSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPictureSize.Location = new System.Drawing.Point(17, 50);
            this.labelPictureSize.Name = "labelPictureSize";
            this.labelPictureSize.Size = new System.Drawing.Size(230, 23);
            this.labelPictureSize.TabIndex = 18;
            this.labelPictureSize.Text = "Maximale Bildgröße (B x H)";
            // 
            // checkBoxCompress
            // 
            this.checkBoxCompress.AutoSize = true;
            this.checkBoxCompress.Checked = true;
            this.checkBoxCompress.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxCompress.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxCompress.Location = new System.Drawing.Point(10, 22);
            this.checkBoxCompress.Name = "checkBoxCompress";
            this.checkBoxCompress.Size = new System.Drawing.Size(186, 24);
            this.checkBoxCompress.TabIndex = 16;
            this.checkBoxCompress.Text = "Bilder komprimieren";
            this.checkBoxCompress.UseVisualStyleBackColor = true;
            this.checkBoxCompress.CheckedChanged += new System.EventHandler(this.checkBoxCompress_CheckedChanged);
            // 
            // pictureBoxCompress
            // 
            this.pictureBoxCompress.Image = global::PrintTextToPicture.Properties.Resources.compress;
            this.pictureBoxCompress.Location = new System.Drawing.Point(21, 79);
            this.pictureBoxCompress.Name = "pictureBoxCompress";
            this.pictureBoxCompress.Size = new System.Drawing.Size(408, 250);
            this.pictureBoxCompress.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxCompress.TabIndex = 17;
            this.pictureBoxCompress.TabStop = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(1071, 614);
            this.Controls.Add(this.numericUpPictureQuality);
            this.Controls.Add(this.groupBoxCompress);
            this.Controls.Add(this.labelPictureQuality);
            this.Controls.Add(this.groupBoxAddText);
            this.Controls.Add(this.checkBoxOverrideDestination);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonSelectSourceDir);
            this.Controls.Add(this.textBoxSourceDir);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.labelDescription);
            this.Controls.Add(this.buttonSelectDestinationDir);
            this.Controls.Add(this.textBoxDestinationDir);
            this.MinimumSize = new System.Drawing.Size(660, 485);
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Beschriftung in die Bilder integrieren";
            this.groupBoxAddText.ResumeLayout(false);
            this.groupBoxAddText.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAddText)).EndInit();
            this.groupBoxCompress.ResumeLayout(false);
            this.groupBoxCompress.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpPictureQuality)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownHieght)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCompress)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox textBoxDestinationDir;
        private System.Windows.Forms.Button buttonSelectDestinationDir;
        private System.Windows.Forms.Label labelDescription;
        private System.ComponentModel.BackgroundWorker backgroundWorker;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonSelectSourceDir;
        private System.Windows.Forms.TextBox textBoxSourceDir;
        private System.Windows.Forms.CheckBox checkBoxOverrideDestination;
        private System.Windows.Forms.GroupBox groupBoxAddText;
        private System.Windows.Forms.CheckBox checkBoxAddText;
        private System.Windows.Forms.PictureBox pictureBoxAddText;
        private System.Windows.Forms.GroupBox groupBoxCompress;
        private System.Windows.Forms.NumericUpDown numericUpPictureQuality;
        private System.Windows.Forms.Label labelPictureQuality;
        private System.Windows.Forms.NumericUpDown numericUpDownHieght;
        private System.Windows.Forms.NumericUpDown numericUpDownWidth;
        private System.Windows.Forms.Label labelPictureSize;
        private System.Windows.Forms.CheckBox checkBoxCompress;
        private System.Windows.Forms.PictureBox pictureBoxCompress;
    }
}