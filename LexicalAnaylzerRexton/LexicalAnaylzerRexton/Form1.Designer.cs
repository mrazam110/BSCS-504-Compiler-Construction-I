namespace LexicalAnaylzerRexton
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
            this.sementicErrorLabel = new System.Windows.Forms.Label();
            this.syntaxErrorLabel = new System.Windows.Forms.Label();
            this.lexicalErrorLabel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.LexTabPage = new System.Windows.Forms.TabPage();
            this.label6 = new System.Windows.Forms.Label();
            this.SyntaxTabPage = new System.Windows.Forms.TabPage();
            this.SemTabPage = new System.Windows.Forms.TabPage();
            this.ICGTabPage = new System.Windows.Forms.TabPage();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.NotificationTabPage = new System.Windows.Forms.TabPage();
            this.ErrorTabPage = new System.Windows.Forms.TabPage();
            this.label5 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.treeView = new System.Windows.Forms.TreeView();
            this.tabControl1.SuspendLayout();
            this.LexTabPage.SuspendLayout();
            this.SyntaxTabPage.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.ErrorTabPage.SuspendLayout();
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
            this.codebox1.Text = "class a {}";
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
            // sementicErrorLabel
            // 
            this.sementicErrorLabel.AutoSize = true;
            this.sementicErrorLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sementicErrorLabel.Location = new System.Drawing.Point(674, 33);
            this.sementicErrorLabel.Name = "sementicErrorLabel";
            this.sementicErrorLabel.Size = new System.Drawing.Size(66, 18);
            this.sementicErrorLabel.TabIndex = 6;
            this.sementicErrorLabel.Text = "No Error";
            // 
            // syntaxErrorLabel
            // 
            this.syntaxErrorLabel.AutoSize = true;
            this.syntaxErrorLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.syntaxErrorLabel.Location = new System.Drawing.Point(288, 33);
            this.syntaxErrorLabel.Name = "syntaxErrorLabel";
            this.syntaxErrorLabel.Size = new System.Drawing.Size(66, 18);
            this.syntaxErrorLabel.TabIndex = 5;
            this.syntaxErrorLabel.Text = "No Error";
            // 
            // lexicalErrorLabel
            // 
            this.lexicalErrorLabel.AutoSize = true;
            this.lexicalErrorLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lexicalErrorLabel.Location = new System.Drawing.Point(6, 33);
            this.lexicalErrorLabel.Name = "lexicalErrorLabel";
            this.lexicalErrorLabel.Size = new System.Drawing.Size(66, 18);
            this.lexicalErrorLabel.TabIndex = 4;
            this.lexicalErrorLabel.Text = "No Error";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(674, 6);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 18);
            this.label4.TabIndex = 3;
            this.label4.Text = "Sementic:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(288, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 18);
            this.label3.TabIndex = 2;
            this.label3.Text = "Syntax:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 18);
            this.label2.TabIndex = 1;
            this.label2.Text = "Lexical:";
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
            this.LexTabPage.BackColor = System.Drawing.Color.White;
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
            this.SyntaxTabPage.Controls.Add(this.treeView);
            this.SyntaxTabPage.Location = new System.Drawing.Point(4, 22);
            this.SyntaxTabPage.Name = "SyntaxTabPage";
            this.SyntaxTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.SyntaxTabPage.Size = new System.Drawing.Size(627, 372);
            this.SyntaxTabPage.TabIndex = 1;
            this.SyntaxTabPage.Text = "Syntax Analyzer";
            this.SyntaxTabPage.UseVisualStyleBackColor = true;
            // 
            // SemTabPage
            // 
            this.SemTabPage.Location = new System.Drawing.Point(4, 22);
            this.SemTabPage.Name = "SemTabPage";
            this.SemTabPage.Size = new System.Drawing.Size(627, 372);
            this.SemTabPage.TabIndex = 2;
            this.SemTabPage.Text = "Sementic Analyzer";
            this.SemTabPage.UseVisualStyleBackColor = true;
            // 
            // ICGTabPage
            // 
            this.ICGTabPage.Location = new System.Drawing.Point(4, 22);
            this.ICGTabPage.Name = "ICGTabPage";
            this.ICGTabPage.Size = new System.Drawing.Size(627, 372);
            this.ICGTabPage.TabIndex = 3;
            this.ICGTabPage.Text = "ICG";
            this.ICGTabPage.UseVisualStyleBackColor = true;
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
            this.NotificationTabPage.Location = new System.Drawing.Point(4, 22);
            this.NotificationTabPage.Name = "NotificationTabPage";
            this.NotificationTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.NotificationTabPage.Size = new System.Drawing.Size(976, 105);
            this.NotificationTabPage.TabIndex = 0;
            this.NotificationTabPage.Text = "Notifications";
            this.NotificationTabPage.UseVisualStyleBackColor = true;
            // 
            // ErrorTabPage
            // 
            this.ErrorTabPage.BackColor = System.Drawing.Color.DimGray;
            this.ErrorTabPage.Controls.Add(this.sementicErrorLabel);
            this.ErrorTabPage.Controls.Add(this.label4);
            this.ErrorTabPage.Controls.Add(this.syntaxErrorLabel);
            this.ErrorTabPage.Controls.Add(this.label2);
            this.ErrorTabPage.Controls.Add(this.lexicalErrorLabel);
            this.ErrorTabPage.Controls.Add(this.label3);
            this.ErrorTabPage.ForeColor = System.Drawing.Color.Gold;
            this.ErrorTabPage.Location = new System.Drawing.Point(4, 22);
            this.ErrorTabPage.Name = "ErrorTabPage";
            this.ErrorTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.ErrorTabPage.Size = new System.Drawing.Size(976, 105);
            this.ErrorTabPage.TabIndex = 1;
            this.ErrorTabPage.Text = "Error";
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
            // treeView
            // 
            this.treeView.Location = new System.Drawing.Point(6, 6);
            this.treeView.Name = "treeView";
            this.treeView.Size = new System.Drawing.Size(338, 360);
            this.treeView.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 595);
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
            this.tabControl2.ResumeLayout(false);
            this.ErrorTabPage.ResumeLayout(false);
            this.ErrorTabPage.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox codebox1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Label sementicErrorLabel;
        private System.Windows.Forms.Label syntaxErrorLabel;
        private System.Windows.Forms.Label lexicalErrorLabel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
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
        private System.Windows.Forms.TreeView treeView;
    }
}

