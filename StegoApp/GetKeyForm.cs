using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace StegoApp
{
    /// <summary>
    /// 
    /// </summary>
    public partial class GetKeyForm : Form
    {
        string key; 

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        public GetKeyForm(string key)
        {
            InitializeComponent();
            reKeyBox.Text = keyBox.Text = this.key = key;
        }

        private void confirm_Click(object sender, EventArgs e)
        {
         
            if ((keyBox.Text == null && string.IsNullOrWhiteSpace(keyBox.Text))
                    || (reKeyBox.Text == null && string.IsNullOrWhiteSpace(reKeyBox.Text)))
            {
                MessageBox.Show("Key cannot be empty.", "Something is Wrong", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            else if (keyBox.Text != reKeyBox.Text)
            {
                MessageBox.Show("Key miss-match.", "Something is Wrong", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            else
            {
                this.key = keyBox.Text;
                this.Visible = false;
            }
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string getKey() {
            return key;
        }
    }
}
