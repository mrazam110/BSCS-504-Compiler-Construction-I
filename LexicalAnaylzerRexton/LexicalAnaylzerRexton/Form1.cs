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

namespace LexicalAnaylzerRexton
{
    public partial class Form1 : Form
    {

        breakWork wordBreaker;
        List<token> wordBreakerOutput;
        List<token> TokenOutput;
        
        public Form1()
        {
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            codebox1.Text = "";
            DialogResult result = openFileDialog1.ShowDialog(); // Show the dialog.
            if (result == DialogResult.OK) // Test result.
            {
                string file = openFileDialog1.FileName;
                try
                {
                    string text = File.ReadAllText(file);
                    codebox1.Text = text;
                }
                catch (IOException)
                {
                    MessageBox.Show("Can not read from file");
                }
            }
            //codebox1.Text = "@abc 'a' \t \n@";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
            LexAnalyzer lex = new LexAnalyzer();
            if (codebox1.Text.Length > 0) {
                wordBreaker = new breakWork();

                wordBreakerOutput = new List<token>();
                TokenOutput = new List<token>();

                wordBreakerOutput = wordBreaker.breakString(codebox1.Text);

                List<token> tokensList = lex.getTokensList(wordBreakerOutput);

                foreach (token s in tokensList)
                {
                    if (s.wordStr != " " && s.wordStr != "\n" && s.wordStr != "\t" && s.wordStr != "\r")
                    {
                        //richTextBox1.Text += "(" + s.lineNumber + ") " + s.wordStr + "\n";
                        richTextBox1.Text += "(" + s.wordStr + ", " + s.classStr + ", " + s.lineNumber + ")\n";
                    }
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult result = saveFileDialog1.ShowDialog(); // Show the dialog.
            if (result == DialogResult.OK) // Test result.
            {
                string file = saveFileDialog1.FileName;
                try
                {
                    System.IO.StreamWriter writer = new System.IO.StreamWriter(file + ".txt", false); //open the file for writing.
                    writer.Write(richTextBox1.Text); //write the current date to the file. change this with your date or something.
                    writer.Close(); //remember to close the file again.
                    writer.Dispose();

                }
                catch (IOException)
                {
                    MessageBox.Show("Can not read from file");
                }
            }
        }
    }
}
