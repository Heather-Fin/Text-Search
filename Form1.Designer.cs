﻿namespace hxf180007Asg4
{
    partial class Form1
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtBox_fileName = new System.Windows.Forms.TextBox();
            this.txtBox_search = new System.Windows.Forms.TextBox();
            this.btn_browse = new System.Windows.Forms.Button();
            this.btn_search = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.LineNumber = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.LineText = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 19);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "File Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 50);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Search For:";
            // 
            // txtBox_fileName
            // 
            this.txtBox_fileName.Location = new System.Drawing.Point(90, 17);
            this.txtBox_fileName.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtBox_fileName.Name = "txtBox_fileName";
            this.txtBox_fileName.Size = new System.Drawing.Size(627, 20);
            this.txtBox_fileName.TabIndex = 2;
            // 
            // txtBox_search
            // 
            this.txtBox_search.Location = new System.Drawing.Point(90, 48);
            this.txtBox_search.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtBox_search.Name = "txtBox_search";
            this.txtBox_search.Size = new System.Drawing.Size(627, 20);
            this.txtBox_search.TabIndex = 3;
            this.txtBox_search.TextChanged += new System.EventHandler(this.TxtBox_search_TextChanged);
            // 
            // btn_browse
            // 
            this.btn_browse.Location = new System.Drawing.Point(731, 17);
            this.btn_browse.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btn_browse.Name = "btn_browse";
            this.btn_browse.Size = new System.Drawing.Size(74, 20);
            this.btn_browse.TabIndex = 4;
            this.btn_browse.Text = "Browse";
            this.btn_browse.UseVisualStyleBackColor = true;
            this.btn_browse.Click += new System.EventHandler(this.Btn_browse_Click);
            // 
            // btn_search
            // 
            this.btn_search.Enabled = false;
            this.btn_search.Location = new System.Drawing.Point(731, 48);
            this.btn_search.Margin = new System.Windows.Forms.Padding(2);
            this.btn_search.Name = "btn_search";
            this.btn_search.Size = new System.Drawing.Size(74, 20);
            this.btn_search.TabIndex = 5;
            this.btn_search.Text = "Search";
            this.btn_search.UseVisualStyleBackColor = true;
            this.btn_search.Click += new System.EventHandler(this.Btn_search_Click);
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.LineNumber,
            this.LineText});
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(28, 96);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(777, 328);
            this.listView1.TabIndex = 6;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // LineNumber
            // 
            this.LineNumber.Text = "Line No.";
            // 
            // LineText
            // 
            this.LineText.Text = "Text";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // Form1
            // 
            this.AcceptButton = this.btn_browse;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(876, 476);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.btn_search);
            this.Controls.Add(this.btn_browse);
            this.Controls.Add(this.txtBox_search);
            this.Controls.Add(this.txtBox_fileName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form1";
            this.Text = "Text Search";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtBox_fileName;
        private System.Windows.Forms.TextBox txtBox_search;
        private System.Windows.Forms.Button btn_browse;
        private System.Windows.Forms.Button btn_search;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader LineNumber;
        private System.Windows.Forms.ColumnHeader LineText;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}
