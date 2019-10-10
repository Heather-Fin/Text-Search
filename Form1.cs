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
        string fileName;
        string searchPhrase;
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

        private void TxtBox_fileName_TextChanged(object sender, EventArgs e)
        {
            // Enable the search button if there is something to search for and a file to search
            if (txtBox_search.TextLength > 0 && txtBox_fileName.TextLength > 0)
            {
                btn_search.Enabled = true;
            }
            else
            {
                btn_search.Enabled = false;
            }
        }

        private void TxtBox_search_TextChanged(object sender, EventArgs e)
        {
            // Enable the search button if there is something to search for and a file to search
            if (txtBox_search.TextLength > 0 && txtBox_fileName.TextLength > 0)
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
                if (string.IsNullOrWhiteSpace(txtBox_fileName.Text)) { 
                    MessageBox.Show("Please choose a text file first.");
                };
                toolStripStatusLabel1.Text = "Analyzing file: " + fileName + " for phrase: " + searchPhrase;
                listView1.Items.Clear();
                backgroundWorker1.RunWorkerAsync();
                btn_search.Text = "Cancel";
            }

            // If user clicks on cancel button, cancel search
            else if (backgroundWorker1.IsBusy && btn_search.Text == "Cancel")
            {
                toolStripStatusLabel1.Text = "Analysis of file: " + fileName + " canceled.";
                backgroundWorker1.CancelAsync();
                btn_search.Text = "Search";
            }
        }

        // Ensures the file path exists before attempting to read
        private StreamReader CheckFileExists(string fileName)
        {

            try
            {
                using (StreamReader file = File.OpenText(fileName))
                {
                    return (new StreamReader(fileName));
                }
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine($"The file was not found: '{e}'");
                return null;
            }
            catch (DirectoryNotFoundException e)
            {
                Console.WriteLine($"The directory was not found: '{e}'");
                return null;
            }
            catch (IOException e)
            {
                Console.WriteLine($"The file could not be opened: '{e}'");
                return null;
            }
        }

        private void BackgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            backgroundWorker1.ReportProgress(0);
            string line;
            int counter = 0;
            float currentSpot = 0;
            int results = 0;
            searchPhrase = txtBox_search.Text;
            fileName = txtBox_fileName.Text;

            // Set pause for 1 milisecond
            Thread.Sleep(1);

            var file = CheckFileExists(fileName);
            if(file is null)
            {
                MessageBox.Show("Please enter a valid file path.");
                return;
            }

            float fileSize = (new FileInfo(fileName)).Length;

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
                    // Update results count
                    if (lbl_results.InvokeRequired)
                    {
                        lbl_results.Invoke((MethodInvoker)delegate ()
                        {
                            results++;
                            lbl_results.Text = results + " matches found.";
                        });
                    }
                }

                // Set progress bar value by multiplying by size of each line and 
                // dividing by total file size.
                currentSpot += line.Length;
                backgroundWorker1.ReportProgress((int)((currentSpot / fileSize) * 100));

                // Check if user cancels search
                if (backgroundWorker1.CancellationPending)
                {
                    backgroundWorker1.ReportProgress(0);
                    e.Cancel = true;
                    return;
                }
            }

            backgroundWorker1.ReportProgress(100);
            file.Close();
        }

        private void backgroundWorker1_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            this.progressBar1.Value = e.ProgressPercentage;
        }


        private void backgroundWorker1_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            // Search was canceled
            if (e.Cancelled)
            {
        
            }
            // Error during search
            else if (e.Error != null)
            {
                toolStripStatusLabel1.Text = "There was an error: " + e.Error.Message;
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
