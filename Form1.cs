using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace hxf180007Asg4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Btn_browse_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog
            {
                Title = "Browse Text Files",

                CheckFileExists = true,
                CheckPathExists = true,

                DefaultExt = "txt",
                Filter = "txt files (*.txt)|*.txt",
                Multiselect = false,
            };

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string fileName = openFileDialog1.FileName;
                txtBox_fileName.Text = fileName;
            }
        }

        private void TxtBox_search_TextChanged(object sender, EventArgs e)
        {
            // Enable the search button if there is something to search for
            if (txtBox_search.TextLength > 0)
            {
                btn_search.Enabled = true;
            }
        }

        // Search file for what is in search textbox
        private void Btn_search_Click(object sender, EventArgs e)
        {
            string searchPhrase = txtBox_search.Text;
        }
    }
}
