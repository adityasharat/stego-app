namespace StegoApp
{
    partial class AppFrame
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AppFrame));
            this.mainMenu = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectTextToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deEncryptionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.inputTextBox = new System.Windows.Forms.RichTextBox();
            this.encryptButton = new System.Windows.Forms.Button();
            this.EmbedButton = new System.Windows.Forms.Button();
            this.extract = new System.Windows.Forms.Button();
            this.startOver = new System.Windows.Forms.Button();
            this.saveImage = new System.Windows.Forms.Button();
            this.mainMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // mainMenu
            // 
            this.mainMenu.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.deEncryptionToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.mainMenu.Location = new System.Drawing.Point(0, 0);
            this.mainMenu.Name = "mainMenu";
            this.mainMenu.Size = new System.Drawing.Size(784, 24);
            this.mainMenu.TabIndex = 0;
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openImageToolStripMenuItem,
            this.selectTextToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.fileToolStripMenuItem.Text = "Embed";
            // 
            // openImageToolStripMenuItem
            // 
            this.openImageToolStripMenuItem.Name = "openImageToolStripMenuItem";
            this.openImageToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.openImageToolStripMenuItem.Text = "Select Image";
            this.openImageToolStripMenuItem.Click += new System.EventHandler(this.selectImageEmbedMenuItem_Click);
            // 
            // selectTextToolStripMenuItem
            // 
            this.selectTextToolStripMenuItem.Name = "selectTextToolStripMenuItem";
            this.selectTextToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.selectTextToolStripMenuItem.Text = "Select Text";
            this.selectTextToolStripMenuItem.Click += new System.EventHandler(this.selectTextEmbedMenuItem_Click);
            // 
            // deEncryptionToolStripMenuItem
            // 
            this.deEncryptionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.selectImageToolStripMenuItem});
            this.deEncryptionToolStripMenuItem.Name = "deEncryptionToolStripMenuItem";
            this.deEncryptionToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.deEncryptionToolStripMenuItem.Text = "Extract";
            // 
            // selectImageToolStripMenuItem
            // 
            this.selectImageToolStripMenuItem.Name = "selectImageToolStripMenuItem";
            this.selectImageToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.selectImageToolStripMenuItem.Text = "Select Image";
            this.selectImageToolStripMenuItem.Click += new System.EventHandler(this.selectImageExtractMenuItem_Click);
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
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // pictureBox
            // 
            this.pictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.pictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox.Location = new System.Drawing.Point(372, 27);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(400, 300);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox.TabIndex = 1;
            this.pictureBox.TabStop = false;
            // 
            // inputTextBox
            // 
            this.inputTextBox.Location = new System.Drawing.Point(12, 27);
            this.inputTextBox.Name = "inputTextBox";
            this.inputTextBox.Size = new System.Drawing.Size(354, 300);
            this.inputTextBox.TabIndex = 2;
            this.inputTextBox.Text = "";
            this.inputTextBox.TextChanged += new System.EventHandler(this.inputTextBox_TextChanged);
            // 
            // encryptButton
            // 
            this.encryptButton.Enabled = false;
            this.encryptButton.Location = new System.Drawing.Point(150, 333);
            this.encryptButton.Name = "encryptButton";
            this.encryptButton.Size = new System.Drawing.Size(130, 25);
            this.encryptButton.TabIndex = 3;
            this.encryptButton.Text = "Encrypt Data";
            this.encryptButton.UseVisualStyleBackColor = true;
            this.encryptButton.Click += new System.EventHandler(this.encryptButton_Click);
            // 
            // EmbedButton
            // 
            this.EmbedButton.Enabled = false;
            this.EmbedButton.Location = new System.Drawing.Point(150, 364);
            this.EmbedButton.Name = "EmbedButton";
            this.EmbedButton.Size = new System.Drawing.Size(130, 25);
            this.EmbedButton.TabIndex = 4;
            this.EmbedButton.Text = "Embed Data";
            this.EmbedButton.UseVisualStyleBackColor = true;
            this.EmbedButton.Click += new System.EventHandler(this.embedButton_Click);
            // 
            // extract
            // 
            this.extract.Enabled = false;
            this.extract.Location = new System.Drawing.Point(642, 333);
            this.extract.Name = "extract";
            this.extract.Size = new System.Drawing.Size(130, 25);
            this.extract.TabIndex = 5;
            this.extract.Text = "Extract Data";
            this.extract.UseVisualStyleBackColor = true;
            this.extract.Click += new System.EventHandler(this.extract_Click);
            // 
            // startOver
            // 
            this.startOver.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startOver.Location = new System.Drawing.Point(12, 333);
            this.startOver.Name = "startOver";
            this.startOver.Size = new System.Drawing.Size(110, 56);
            this.startOver.TabIndex = 6;
            this.startOver.Text = "Start Over";
            this.startOver.UseVisualStyleBackColor = true;
            this.startOver.Click += new System.EventHandler(this.startOver_Click);
            // 
            // saveImage
            // 
            this.saveImage.AllowDrop = true;
            this.saveImage.Enabled = false;
            this.saveImage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveImage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.saveImage.Location = new System.Drawing.Point(286, 364);
            this.saveImage.Name = "saveImage";
            this.saveImage.Size = new System.Drawing.Size(115, 58);
            this.saveImage.TabIndex = 7;
            this.saveImage.Text = "Save Image";
            this.saveImage.UseVisualStyleBackColor = true;
            this.saveImage.Visible = false;
            this.saveImage.Click += new System.EventHandler(this.saveImage_Click);
            // 
            // AppFrame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 423);
            this.Controls.Add(this.saveImage);
            this.Controls.Add(this.startOver);
            this.Controls.Add(this.extract);
            this.Controls.Add(this.EmbedButton);
            this.Controls.Add(this.encryptButton);
            this.Controls.Add(this.inputTextBox);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.mainMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.mainMenu;
            this.MinimumSize = new System.Drawing.Size(800, 462);
            this.Name = "AppFrame";
            this.Text = "StegoApp";
            this.mainMenu.ResumeLayout(false);
            this.mainMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mainMenu;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openImageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem selectTextToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deEncryptionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem selectImageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.RichTextBox inputTextBox;
        private System.Windows.Forms.Button encryptButton;
        private System.Windows.Forms.Button EmbedButton;
        private System.Windows.Forms.Button extract;
        private System.Windows.Forms.Button startOver;
        private System.Windows.Forms.Button saveImage;
    }
}

