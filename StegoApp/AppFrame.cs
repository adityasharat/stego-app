using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Imaging;

namespace StegoApp {

    /// <summary>
    /// 
    /// </summary>
    public partial class AppFrame : Form {

        int width, height;
        int[,] pixels;
        string key;
        Boolean imgready = false, textReady = false;
        Bitmap outputImage;

        OpenFileDialog fileChooser;

        /// <summary>
        /// 
        /// </summary>
        public AppFrame(){
            InitializeComponent();
        }

        private void selectImageEmbedMenuItem_Click(object sender, EventArgs e)
        {

            this.fileChooser = new OpenFileDialog();
            fileChooser.Filter = "Image Files| *.jpg; *.jpeg; *.png; *.bmp;";
            fileChooser.Title = "Select Image";

            if (fileChooser.ShowDialog() == DialogResult.OK)
            {
                Cursor = Cursors.WaitCursor;

                // input image to be displayed in the picture box.
                Bitmap inputImageFile;
                try
                {
                    inputImageFile = new Bitmap(fileChooser.FileName);
                    this.width = inputImageFile.Width;
                    this.height = inputImageFile.Height;

                    // grab pixels of the image
                    this.pixels = StegoApp.Image.returnPixels(fileChooser.FileName);

                }
                catch (Exception ex)
                {
                    Cursor = Cursors.Default;
                    DialogResult result = MessageBox.Show(ex.Message
                        + " \nPress OK to Start Over or Cancel to continue.",
                        "Something went wrong",
                        MessageBoxButtons.OKCancel,
                        MessageBoxIcon.Error);

                    if (result == DialogResult.OK)
                    {
                        this.start_Over();
                        return;
                    }
                    else
                    {
                        pictureBox.Image = null;
                        return;
                    }
                }

                // scale and show the image inside the picture box
                if (inputImageFile != null && inputImageFile.Width <= 400 && inputImageFile.Height <= 300)
                    pictureBox.Image = inputImageFile;

                else if (inputImageFile != null)
                {
                    try
                    {
                        pictureBox.Image = StegoApp.Image.getScaledImage(400, 300, inputImageFile);
                    }
                    catch (Exception ex)
                    {
                        Cursor = Cursors.Default;
                        MessageBox.Show(ex.Message,
                            "something went wrong",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        return;
                    }
                }

                extract.Enabled = false;
                imgready = true;

                if (imgready && textReady)
                    EmbedButton.Enabled = true;
                Cursor = Cursors.Default;
            }
            else return;
        }

        private void selectTextEmbedMenuItem_Click(object sender, EventArgs e) {

            this.fileChooser = new OpenFileDialog();
            fileChooser.Filter = "Text Files| *.txt; *.c; *.cpp; *.java; *.php; *.html;";
            fileChooser.Title = "Select text";

            if (fileChooser.ShowDialog() == System.Windows.Forms.DialogResult.OK){
                Cursor = Cursors.WaitCursor;
                string text;
                try {
                    text = StegoApp.Text.readText(fileChooser.FileName);
                    inputTextBox.Text = text;
                }
                catch (Exception ex) {
                    Cursor = Cursors.Default;
                    MessageBox.Show(ex.Message,
                            "Something went wrong",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    return;
                }

                Cursor = Cursors.Default;

            } else
                return;
        }

        private void inputTextBox_TextChanged(object sender, EventArgs e) {
            
            if (inputTextBox.Text != null && !string.IsNullOrWhiteSpace(inputTextBox.Text)) {
                encryptButton.Enabled = true;
            }
            else {
                encryptButton.Enabled = false;
                textReady = false;
            }
        }

        private void encryptButton_Click(object sender, EventArgs e) {
            
            GetKeyForm keyForm = new GetKeyForm(key);
            keyForm.ShowDialog();

            this.key = keyForm.getKey();

            if (this.key == null) {
                textReady = false;
            }
            else {
                textReady = true;
                if (textReady && imgready)
                    EmbedButton.Enabled = true;
                else
                    EmbedButton.Enabled = false;
            }
            keyForm = null;
        }

        private void embedButton_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            string encryptedText=null;

            try
            {
                encryptedText = StegoApp.Text.Encrypt(inputTextBox.Text, key);
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                MessageBox.Show(ex.Message,
                     "Something went wrong.",
                     MessageBoxButtons.OK,
                     MessageBoxIcon.Error);
                return;
            }

            encryptedText = StegoApp.Stego.getHeader() + encryptedText;
            
            if (encryptedText.Length >= width * height)
            {
                Cursor = Cursors.Default;
                MessageBox.Show("Please use a larger image",
                            "Something is wrong",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Exclamation);
                return;
            }
            else {
                Cursor = Cursors.WaitCursor;
                this.outputImage = StegoApp.Stego.applyStego(pixels, width, height, encryptedText);
                Cursor = Cursors.Default;
                saveImage.Visible = true;
                saveImage.Enabled = true;
            }
            Cursor = Cursors.Default;
        }

        private void extract_Click(object sender, EventArgs e)
        {
            inputTextBox.Text = null;
            if (!StegoApp.DeStego.isEmbedded(pixels, width, height))
            {
                MessageBox.Show("This image has no embedded data.",
                    "Something went wrong.",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                return;
            }
            
            key = null;
            
            GetKeyForm keyForm = new GetKeyForm(key);
            keyForm.ShowDialog();

            this.key = keyForm.getKey();

            Cursor = Cursors.WaitCursor;
            if (key != null)
            {
                string text;
                try
                {
                    text = StegoApp.DeStego.extractData(pixels, width, height, key);
                    inputTextBox.Text = text;
                    Cursor = Cursors.Default;
                }
                catch (Exception ex)
                {
                    Cursor = Cursors.Default;
                    MessageBox.Show(ex.Message + "\nIncorrect de-crypryion key or corrupted image.",
                    "Something went wrong.",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
                }
            }
            else {
                Cursor = Cursors.Default;
                return;
            }

        }

        private void startOver_Click(object sender, EventArgs e)
        {
            this.start_Over();
        }

        private void selectImageExtractMenuItem_Click(object sender, EventArgs e) {
            
            this.fileChooser = new OpenFileDialog();
            fileChooser.Filter = "Image Files| *.jpg; *.jpeg; *.png; *.bmp;";
            fileChooser.Title = "Select Image";

            if (fileChooser.ShowDialog() == DialogResult.OK)
            {
                Cursor = Cursors.WaitCursor;
                // input image to be displayed in the picture box.
                Bitmap inputImageFile;
                try
                {
                    inputImageFile = new Bitmap(fileChooser.FileName);
                    this.width = inputImageFile.Width;
                    this.height = inputImageFile.Height;

                    // grab pixels of the image
                    this.pixels = StegoApp.Image.returnPixels(fileChooser.FileName);
                }
                catch (Exception ex)
                {
                    Cursor = Cursors.Default;
                    DialogResult result = MessageBox.Show(ex.Message
                        + " \nPress OK to Start Over or Cancel to continue.",
                        "Something went wrong",
                        MessageBoxButtons.OKCancel,
                        MessageBoxIcon.Error);

                    if (result == DialogResult.OK)
                    {
                        this.start_Over();
                        return;
                    }
                    else
                    {
                        pictureBox.Image = null;
                        return;
                    }
                }

                // scale and show the image inside the picture box
                if (inputImageFile != null && inputImageFile.Width <= 400 && inputImageFile.Height <= 300)
                    pictureBox.Image = inputImageFile;

                else if(inputImageFile!=null)
                {
                    try
                    {
                        pictureBox.Image = StegoApp.Image.getScaledImage(400, 300, inputImageFile);
                    }
                    catch (Exception ex)
                    {
                        Cursor = Cursors.Default;
                        MessageBox.Show(ex.Message,
                            "something went wrong",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        return;
                    }
                }

                encryptButton.Enabled = false;
                EmbedButton.Enabled = false;
                inputTextBox.Text = null;
                saveImage.Enabled = false;
                saveImage.Visible = false;
                extract.Enabled = true;

            }
            else
            {
                Cursor = Cursors.Default;
                extract.Enabled = true;
                return;
            }
            Cursor = Cursors.Default;

        }

        private void start_Over() {
            pixels = null;
            key = null;
            imgready = false;
            textReady = false;

            encryptButton.Enabled = false;
            EmbedButton.Enabled = false;
            extract.Enabled = false;

            inputTextBox.Text = "";
            pictureBox.Image = null;

            saveImage.Enabled = false;
            saveImage.Visible = false;

        }

        private void saveImage_Click(object sender, EventArgs e)
        {
            // Displays a SaveFileDialog so the user can save the Image
            // assigned to Button2.
            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "Image|*.png;";
            save.Title = "Save Image";
            save.ShowDialog();

            // If the file name is not an empty string open it for saving.
            if (save.FileName != "")
            {
                Cursor = Cursors.WaitCursor;
                // Saves the Image via a FileStream created by the OpenFile method.
                System.IO.FileStream fs = (System.IO.FileStream)save.OpenFile();
                this.outputImage.Save(fs, ImageFormat.Png);
                fs.Close();
                Cursor = Cursors.Default;
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutStegoApp abt = new AboutStegoApp();
            abt.ShowDialog();
        }

    }
}
