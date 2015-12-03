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

        private List<token> tokenSet;
        
        public Form1()
        {
            InitializeComponent();
            characterCountLabel.Text = "" + codebox1.Text.Length;
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
            Compile();
        }

        private void Compile()
        {
            richTextBox1.Text = "";
            errorTextBox.Text = "";

            String errorText = "";
            LexAnalyzer lex = new LexAnalyzer();
            if (codebox1.Text.Length > 0)
            {
                wordBreaker = new breakWork();

                wordBreakerOutput = new List<token>();
                TokenOutput = new List<token>();

                wordBreakerOutput = wordBreaker.breakString(codebox1.Text);

                List<token> tokensList = lex.getTokensList(wordBreakerOutput);

                tokenSet = new List<token>();
                String lexError = "";
                foreach (token s in tokensList)
                {
                    if (s.wordStr != " " && s.wordStr != "\n" && s.wordStr != "\t" && s.wordStr != "\r")
                    {
                        //richTextBox1.Text += "(" + s.lineNumber + ") " + s.wordStr + "\n";
                        richTextBox1.Text += "(" + s.wordStr + ", " + s.classStr + ", " + s.lineNumber + ")\n";

                        token temp = new token(s.lineNumber, s.wordStr, s.classStr);
                        tokenSet.Add(temp);

                        if (s.classStr == Singleton.nonKeywords._INVALID.ToString())
                        {
                            lexError += s.wordStr + "\n";
                            lexicalErrorLabel.Text = lexError;
                            lexicalErrorLabel.ForeColor = System.Drawing.Color.Maroon;

                            errorText += "Lexical Error on Line Number " + s.lineNumber + ": " + s.wordStr + "\n";
                        }
                    }

                    if (lexError == "")
                    {
                        lexicalErrorLabel.Text = "No Error";
                        lexicalErrorLabel.ForeColor = System.Drawing.Color.Green;
                    }
                }

                SyntaxAnalyzer syntaxAnalysis = new SyntaxAnalyzer(tokenSet);
                if (syntaxAnalysis.validateCfg())
                {
                    syntaxErrorLabel.Text = "No Error";
                    syntaxErrorLabel.ForeColor = System.Drawing.Color.Green;

                    TreeNode tree = new TreeNode("<S>");
                    treeView.Nodes.Clear();
                    treeView.Nodes.Add(tree);
                }
                else
                {
                    syntaxErrorLabel.Text = "" + syntaxAnalysis.getErrors();
                    syntaxErrorLabel.ForeColor = System.Drawing.Color.Maroon;

                    errorText += "Syntax Error: " + syntaxAnalysis.getErrors();

                    
                }
                errorText += "\n" + syntaxAnalysis.getSemanticError();
                if (checkBox1.Checked)
                {
                    totalTokenLabel.Text = "" + (tokenSet.Count - 1);
                    totWordsLabel.Text = "" + (tokenSet.Count - 1);
                    totLineLabel.Text = "" + wordBreakerOutput[wordBreakerOutput.Count - 1].lineNumber;
                }

                if (errorText != "")
                {
                    errorTextBox.Text = errorText;
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

        private void button4_Click(object sender, EventArgs e)
        {
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void codebox1_TextChanged(object sender, EventArgs e)
        {
            characterCountLabel.Text = "" + codebox1.Text.Length;
            Compile();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                Compile();
            }
        }

        private void sementicErrorLabel_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
