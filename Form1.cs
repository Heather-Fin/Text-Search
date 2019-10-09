using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;

// Multi-threaded Text Search (Assignment 4)
// Author: Heather Finnegan
// Course: CS6326 - Human Computer Interaction
// Date Created: 10/09/2019

namespace hxf180007Asg4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            toolStripStatusLabel1.Text = "Select a file and phrase to analyze.";
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
            else
            {
                btn_search.Enabled = false;
            }
        }

        // Search file for what is in search textbox
        private void Btn_search_Click(object sender, EventArgs e)
        {
            // If user clicks on search button, begin search
            if (!backgroundWorker1.IsBusy && btn_search.Text == "Search")
            {
                listView1.Items.Clear();
                backgroundWorker1.RunWorkerAsync();
                btn_search.Text = "Cancel";
            }

            // If user clicks on cancel button, cancel search
            else if (backgroundWorker1.IsBusy && btn_search.Text == "Cancel")
            {
                backgroundWorker1.CancelAsync();
                btn_search.Text = "Search";
            }
        }

        private void BackgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            string line;
            int counter = 0;
            string searchPhrase = txtBox_search.Text;
            StreamReader file = new StreamReader(txtBox_fileName.Text);

            toolStripStatusLabel1.Text = "Analyzing file: " + file + "for phrase: " + searchPhrase;

            // Read the source file
            while ((line = file.ReadLine()) != null)
            {
                counter++;

                // Check for matches here, ignoring casing
                bool match = Regex.IsMatch(line, searchPhrase, RegexOptions.IgnoreCase);
                if (match)
                {
                    // Add item to list view
                    if (listView1.InvokeRequired)
                    {
                        listView1.Invoke((MethodInvoker)delegate ()
                        {
                            ListViewItem item = new ListViewItem(counter.ToString());
                            item.SubItems.Add(line.Trim());
                            listView1.Items.Add(item);
                        });
                    }
                }

                // Check if user cancels search
                if (backgroundWorker1.CancellationPending)
                {
                    e.Cancel = true;
                    toolStripStatusLabel1.Text = "Analysis of file: " + file + " canceled.";
                    return;
                }
            }
            file.Close();
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            btn_search.Text = "Search";

            if (e.Cancelled)
            {
                // search canceled
            }
            else if (e.Error != null)
            {
                // error
            }
            // Search completed
            else
            {
                toolStripStatusLabel1.Text = "Analysis of file completed.";
                btn_search.Text = "Search";
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
