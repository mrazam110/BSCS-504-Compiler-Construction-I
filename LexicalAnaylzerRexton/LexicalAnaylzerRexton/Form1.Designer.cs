﻿namespace LexicalAnaylzerRexton
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.codebox1 = new System.Windows.Forms.RichTextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.button2 = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.LexTabPage = new System.Windows.Forms.TabPage();
            this.label6 = new System.Windows.Forms.Label();
            this.SyntaxTabPage = new System.Windows.Forms.TabPage();
            this.treeView = new System.Windows.Forms.TreeView();
            this.SemTabPage = new System.Windows.Forms.TabPage();
            this.ICGTabPage = new System.Windows.Forms.TabPage();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.NotificationTabPage = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.sementicErrorLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lexicalErrorLabel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.syntaxErrorLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.totLineLabel = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.totWordsLabel = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.totalTokenLabel = new System.Windows.Forms.Label();
            this.characterCountLabel = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ErrorTabPage = new System.Windows.Forms.TabPage();
            this.errorTextBox = new System.Windows.Forms.RichTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.classes_data = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.semanticTreeView = new System.Windows.Forms.TreeView();
            this.tabControl1.SuspendLayout();
            this.LexTabPage.SuspendLayout();
            this.SyntaxTabPage.SuspendLayout();
            this.SemTabPage.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.NotificationTabPage.SuspendLayout();
            this.panel1.SuspendLayout();
            this.ErrorTabPage.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // codebox1
            // 
            this.codebox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.codebox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.codebox1.DetectUrls = false;
            this.codebox1.Font = new System.Drawing.Font("Consolas", 12F);
            this.codebox1.ForeColor = System.Drawing.Color.DodgerBlue;
            this.codebox1.Location = new System.Drawing.Point(653, 40);
            this.codebox1.Name = "codebox1";
            this.codebox1.Size = new System.Drawing.Size(343, 376);
            this.codebox1.TabIndex = 1;
            this.codebox1.Text = "class program {\npublic static void main(){\naur_int a = 10;\naur_bool flag = false;" +
    "\nagar(a == 10 && !flag){\n++a;\na++;\n}\n}\n}\n\n";
            this.codebox1.TextChanged += new System.EventHandler(this.codebox1_TextChanged);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(653, 422);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(343, 49);
            this.button2.TabIndex = 3;
            this.button2.Text = "COMPILE";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.SystemColors.Control;
            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox1.BulletIndent = 1;
            this.richTextBox1.DetectUrls = false;
            this.richTextBox1.Font = new System.Drawing.Font("Consolas", 12F);
            this.richTextBox1.Location = new System.Drawing.Point(6, 20);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(615, 346);
            this.richTextBox1.TabIndex = 4;
            this.richTextBox1.Text = "";
            this.richTextBox1.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.LexTabPage);
            this.tabControl1.Controls.Add(this.SyntaxTabPage);
            this.tabControl1.Controls.Add(this.SemTabPage);
            this.tabControl1.Controls.Add(this.ICGTabPage);
            this.tabControl1.Location = new System.Drawing.Point(12, 51);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(635, 398);
            this.tabControl1.TabIndex = 7;
            // 
            // LexTabPage
            // 
            this.LexTabPage.BackColor = System.Drawing.Color.WhiteSmoke;
            this.LexTabPage.Controls.Add(this.label6);
            this.LexTabPage.Controls.Add(this.richTextBox1);
            this.LexTabPage.Location = new System.Drawing.Point(4, 22);
            this.LexTabPage.Name = "LexTabPage";
            this.LexTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.LexTabPage.Size = new System.Drawing.Size(627, 372);
            this.LexTabPage.TabIndex = 0;
            this.LexTabPage.Text = "Lexical Analyzer";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 4);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(46, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Tokens:";
            // 
            // SyntaxTabPage
            // 
            this.SyntaxTabPage.BackColor = System.Drawing.Color.WhiteSmoke;
            this.SyntaxTabPage.Controls.Add(this.treeView);
            this.SyntaxTabPage.Location = new System.Drawing.Point(4, 22);
            this.SyntaxTabPage.Name = "SyntaxTabPage";
            this.SyntaxTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.SyntaxTabPage.Size = new System.Drawing.Size(627, 372);
            this.SyntaxTabPage.TabIndex = 1;
            this.SyntaxTabPage.Text = "Syntax Analyzer";
            // 
            // treeView
            // 
            this.treeView.Location = new System.Drawing.Point(6, 6);
            this.treeView.Name = "treeView";
            this.treeView.Size = new System.Drawing.Size(615, 360);
            this.treeView.TabIndex = 0;
            // 
            // SemTabPage
            // 
            this.SemTabPage.BackColor = System.Drawing.Color.WhiteSmoke;
            this.SemTabPage.Controls.Add(this.semanticTreeView);
            this.SemTabPage.Controls.Add(this.groupBox2);
            this.SemTabPage.Controls.Add(this.groupBox1);
            this.SemTabPage.Controls.Add(this.groupBox8);
            this.SemTabPage.Location = new System.Drawing.Point(4, 22);
            this.SemTabPage.Name = "SemTabPage";
            this.SemTabPage.Size = new System.Drawing.Size(627, 372);
            this.SemTabPage.TabIndex = 2;
            this.SemTabPage.Text = "Sementic Analyzer";
            // 
            // ICGTabPage
            // 
            this.ICGTabPage.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ICGTabPage.Location = new System.Drawing.Point(4, 22);
            this.ICGTabPage.Name = "ICGTabPage";
            this.ICGTabPage.Size = new System.Drawing.Size(627, 372);
            this.ICGTabPage.TabIndex = 3;
            this.ICGTabPage.Text = "ICG";
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.NotificationTabPage);
            this.tabControl2.Controls.Add(this.ErrorTabPage);
            this.tabControl2.Location = new System.Drawing.Point(12, 455);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(984, 131);
            this.tabControl2.TabIndex = 8;
            // 
            // NotificationTabPage
            // 
            this.NotificationTabPage.Controls.Add(this.panel1);
            this.NotificationTabPage.Controls.Add(this.totLineLabel);
            this.NotificationTabPage.Controls.Add(this.label12);
            this.NotificationTabPage.Controls.Add(this.totWordsLabel);
            this.NotificationTabPage.Controls.Add(this.label10);
            this.NotificationTabPage.Controls.Add(this.totalTokenLabel);
            this.NotificationTabPage.Controls.Add(this.characterCountLabel);
            this.NotificationTabPage.Controls.Add(this.label7);
            this.NotificationTabPage.Controls.Add(this.label1);
            this.NotificationTabPage.Location = new System.Drawing.Point(4, 22);
            this.NotificationTabPage.Name = "NotificationTabPage";
            this.NotificationTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.NotificationTabPage.Size = new System.Drawing.Size(976, 105);
            this.NotificationTabPage.TabIndex = 0;
            this.NotificationTabPage.Text = "Notifications";
            this.NotificationTabPage.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.sementicErrorLabel);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.lexicalErrorLabel);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.syntaxErrorLabel);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(637, 33);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(339, 71);
            this.panel1.TabIndex = 14;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // sementicErrorLabel
            // 
            this.sementicErrorLabel.AutoSize = true;
            this.sementicErrorLabel.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sementicErrorLabel.ForeColor = System.Drawing.Color.Green;
            this.sementicErrorLabel.Location = new System.Drawing.Point(88, 44);
            this.sementicErrorLabel.Name = "sementicErrorLabel";
            this.sementicErrorLabel.Size = new System.Drawing.Size(53, 15);
            this.sementicErrorLabel.TabIndex = 13;
            this.sementicErrorLabel.Text = "No Error";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(8, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 15);
            this.label3.TabIndex = 9;
            this.label3.Text = "Syntax:";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // lexicalErrorLabel
            // 
            this.lexicalErrorLabel.AutoSize = true;
            this.lexicalErrorLabel.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lexicalErrorLabel.ForeColor = System.Drawing.Color.Green;
            this.lexicalErrorLabel.Location = new System.Drawing.Point(88, 8);
            this.lexicalErrorLabel.Name = "lexicalErrorLabel";
            this.lexicalErrorLabel.Size = new System.Drawing.Size(53, 15);
            this.lexicalErrorLabel.TabIndex = 11;
            this.lexicalErrorLabel.Text = "No Error";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(8, 44);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 15);
            this.label4.TabIndex = 10;
            this.label4.Text = "Sementic:";
            // 
            // syntaxErrorLabel
            // 
            this.syntaxErrorLabel.AutoSize = true;
            this.syntaxErrorLabel.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.syntaxErrorLabel.ForeColor = System.Drawing.Color.Green;
            this.syntaxErrorLabel.Location = new System.Drawing.Point(88, 26);
            this.syntaxErrorLabel.Name = "syntaxErrorLabel";
            this.syntaxErrorLabel.Size = new System.Drawing.Size(53, 15);
            this.syntaxErrorLabel.TabIndex = 12;
            this.syntaxErrorLabel.Text = "No Error";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(8, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 15);
            this.label2.TabIndex = 8;
            this.label2.Text = "Lexical:";
            // 
            // totLineLabel
            // 
            this.totLineLabel.AutoSize = true;
            this.totLineLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totLineLabel.Location = new System.Drawing.Point(116, 77);
            this.totLineLabel.Name = "totLineLabel";
            this.totLineLabel.Size = new System.Drawing.Size(15, 16);
            this.totLineLabel.TabIndex = 7;
            this.totLineLabel.Text = "0";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(3, 77);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(70, 16);
            this.label12.TabIndex = 6;
            this.label12.Text = "Total Line:";
            // 
            // totWordsLabel
            // 
            this.totWordsLabel.AutoSize = true;
            this.totWordsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totWordsLabel.Location = new System.Drawing.Point(116, 55);
            this.totWordsLabel.Name = "totWordsLabel";
            this.totWordsLabel.Size = new System.Drawing.Size(15, 16);
            this.totWordsLabel.TabIndex = 5;
            this.totWordsLabel.Text = "0";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(3, 55);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(85, 16);
            this.label10.TabIndex = 4;
            this.label10.Text = "Total Words:";
            // 
            // totalTokenLabel
            // 
            this.totalTokenLabel.AutoSize = true;
            this.totalTokenLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalTokenLabel.Location = new System.Drawing.Point(116, 33);
            this.totalTokenLabel.Name = "totalTokenLabel";
            this.totalTokenLabel.Size = new System.Drawing.Size(15, 16);
            this.totalTokenLabel.TabIndex = 3;
            this.totalTokenLabel.Text = "0";
            // 
            // characterCountLabel
            // 
            this.characterCountLabel.AutoSize = true;
            this.characterCountLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.characterCountLabel.Location = new System.Drawing.Point(115, 12);
            this.characterCountLabel.Name = "characterCountLabel";
            this.characterCountLabel.Size = new System.Drawing.Size(15, 16);
            this.characterCountLabel.TabIndex = 2;
            this.characterCountLabel.Text = "0";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(3, 33);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(107, 16);
            this.label7.TabIndex = 1;
            this.label7.Text = "Total Token Set:";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(2, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Characters Count:";
            // 
            // ErrorTabPage
            // 
            this.ErrorTabPage.BackColor = System.Drawing.Color.Black;
            this.ErrorTabPage.Controls.Add(this.errorTextBox);
            this.ErrorTabPage.ForeColor = System.Drawing.Color.Gold;
            this.ErrorTabPage.Location = new System.Drawing.Point(4, 22);
            this.ErrorTabPage.Name = "ErrorTabPage";
            this.ErrorTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.ErrorTabPage.Size = new System.Drawing.Size(976, 105);
            this.ErrorTabPage.TabIndex = 1;
            this.ErrorTabPage.Text = "Error";
            // 
            // errorTextBox
            // 
            this.errorTextBox.BackColor = System.Drawing.SystemColors.WindowText;
            this.errorTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.errorTextBox.ForeColor = System.Drawing.Color.Red;
            this.errorTextBox.Location = new System.Drawing.Point(0, 0);
            this.errorTextBox.Name = "errorTextBox";
            this.errorTextBox.Size = new System.Drawing.Size(976, 106);
            this.errorTextBox.TabIndex = 0;
            this.errorTextBox.Text = "Errors:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(650, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Source Code:";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(65, 12);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(42, 23);
            this.button3.TabIndex = 11;
            this.button3.Text = "Save Token";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(13, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(46, 23);
            this.button1.TabIndex = 10;
            this.button1.Text = "Open";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox1.Location = new System.Drawing.Point(550, 23);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(87, 22);
            this.checkBox1.TabIndex = 8;
            this.checkBox1.Text = "Live View";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.classes_data);
            this.groupBox8.Location = new System.Drawing.Point(6, 3);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(195, 52);
            this.groupBox8.TabIndex = 3;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Classes";
            // 
            // classes_data
            // 
            this.classes_data.FormattingEnabled = true;
            this.classes_data.Location = new System.Drawing.Point(6, 19);
            this.classes_data.Name = "classes_data";
            this.classes_data.Size = new System.Drawing.Size(183, 21);
            this.classes_data.TabIndex = 0;
            this.classes_data.Text = "Select a Class";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Location = new System.Drawing.Point(6, 61);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(195, 52);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Classes";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(6, 19);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(183, 21);
            this.comboBox1.TabIndex = 0;
            this.comboBox1.Text = "Select a Class";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.comboBox2);
            this.groupBox2.Location = new System.Drawing.Point(6, 119);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(195, 52);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Classes";
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(6, 19);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(183, 21);
            this.comboBox2.TabIndex = 0;
            this.comboBox2.Text = "Select a Class";
            // 
            // semanticTreeView
            // 
            this.semanticTreeView.Location = new System.Drawing.Point(207, 4);
            this.semanticTreeView.Name = "semanticTreeView";
            this.semanticTreeView.Size = new System.Drawing.Size(414, 183);
            this.semanticTreeView.TabIndex = 6;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 595);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tabControl2);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.codebox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.LexTabPage.ResumeLayout(false);
            this.LexTabPage.PerformLayout();
            this.SyntaxTabPage.ResumeLayout(false);
            this.SemTabPage.ResumeLayout(false);
            this.tabControl2.ResumeLayout(false);
            this.NotificationTabPage.ResumeLayout(false);
            this.NotificationTabPage.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ErrorTabPage.ResumeLayout(false);
            this.groupBox8.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox codebox1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage LexTabPage;
        private System.Windows.Forms.TabPage SyntaxTabPage;
        private System.Windows.Forms.TabPage SemTabPage;
        private System.Windows.Forms.TabPage ICGTabPage;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage NotificationTabPage;
        private System.Windows.Forms.TabPage ErrorTabPage;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label totalTokenLabel;
        private System.Windows.Forms.Label characterCountLabel;
        private System.Windows.Forms.Label totLineLabel;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label totWordsLabel;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label sementicErrorLabel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label syntaxErrorLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lexicalErrorLabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox errorTextBox;
        public System.Windows.Forms.TreeView treeView;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.ComboBox classes_data;
        public System.Windows.Forms.TreeView semanticTreeView;
    }
}

