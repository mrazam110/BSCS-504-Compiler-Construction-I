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
            mainLabel.Text = "No Main Found";
            mainLabel.ForeColor = System.Drawing.Color.Maroon;
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
        }

        private void loadSemanticTree() 
        {
            z_class_access.Text = "";
            z_class_access.Text = "";
            z_class_parent.Text = "";
            z_class_totalmembers.Text = "";

            z_member_access.Text = "";
            z_member_category.Text = "";
            z_member_name.Text = "";
            z_member_totalvar.Text = "";
            z_member_type.Text = "";
            z_members_params.Text = "";

            z_var_name.Text = "";
            z_var_scope.Text = "";
            z_var_type.Text = "";

            TreeNode currentNode;
            semanticTreeView.Nodes.Clear();

            currentNode = semanticTreeView.Nodes.Add("Global: " + SemanticAnalyzer.globalSymbolTable[0].name);
            for (int b = 0; b < SemanticAnalyzer.globalSymbolTable[0].classes.Count; b++)
            {
                currentNode = currentNode.Nodes.Add("Class: " + SemanticAnalyzer.globalSymbolTable[0].classes[b].name);
                classes_data.Items.Add(SemanticAnalyzer.globalSymbolTable[0].classes[b].name);
                for (int k = 0; k < SemanticAnalyzer.globalSymbolTable[0].classes[b].members.Count; k++)
                {
                    string memberType;
                    if (SemanticAnalyzer.globalSymbolTable[0].classes[b].members[k].isMethod)
                    {
                        memberType = "Method: ";
                    }
                    else
                    {
                        memberType = "Field: ";
                    }
                    currentNode = currentNode.Nodes.Add(memberType + SemanticAnalyzer.globalSymbolTable[0].classes[b].members[k].type + " " + SemanticAnalyzer.globalSymbolTable[0].classes[b].members[k].name);

                    for (int l = 0; l < SemanticAnalyzer.globalSymbolTable[0].classes[b].members[k].variables.Count; l++)
                    {
                        currentNode.Nodes.Add(SemanticAnalyzer.globalSymbolTable[0].classes[b].members[k].variables[l].type + ": " + SemanticAnalyzer.globalSymbolTable[0].classes[b].members[k].variables[l].name);
                    }
                    currentNode = currentNode.Parent;
                }
                currentNode = currentNode.Parent;
            }
            currentNode = currentNode.Parent;
            semanticTreeView.ExpandAll();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Compile();
            loadSemanticTree();
            checkMain();
        }

        private void checkMain()
        {
            mainLabel.Text = "No Main Found";
            mainLabel.ForeColor = System.Drawing.Color.Maroon;
            List<CLASS> classesTable = SemanticAnalyzer.globalSymbolTable[0].classes;

            for (int i = 0; i < classesTable.Count; i++)
            {
                for (int j = 0; j < classesTable[i].members.Count; j++)
                {
                    for (int k = 0; k < classesTable[i].members[j].variables.Count; k++)
                    {
                        if (classesTable[i].members[j].name == "main" && classesTable[i].members[j].isMethod == true)
                        {
                            mainLabel.Text = "Main Found";
                            mainLabel.ForeColor = System.Drawing.Color.Green;
                        }
                    }
                }
            }
            
        }

        private void Compile()
        {
            ICG_text.Text = "";
            richTextBox1.Text = "";
            errorTextBox.Text = ""; 
            treeView.Nodes.Clear();
            SemanticAnalyzer.globalSymbolTable = new List<GLOBAL>();
            SemanticAnalyzer.ClassSymbolTable = new List<CLASS>();
            SemanticAnalyzer.errors = new List<string>();
            classes_data.Text = "Select a Class";
            member_data.Text = "Select a Member";
            variables_data.Text = "Select a variable";
            classes_data.Items.Clear();
            member_data.Items.Clear();
            variables_data.Items.Clear();

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

                    //TreeNode tree = new TreeNode("<S>");
                    
                    //treeView.Nodes.Add(tree);
                }
                else
                {
                    syntaxErrorLabel.Text = "" + syntaxAnalysis.getErrors();
                    syntaxErrorLabel.ForeColor = System.Drawing.Color.Maroon;

                    errorText += "Syntax Error: " + syntaxAnalysis.getErrors();

                    
                }
                if (syntaxAnalysis.getSemanticError() != "")
                {
                    errorText += "\n" + syntaxAnalysis.getSemanticError(); 
                    sementicErrorLabel.Text = "Errors";
                    sementicErrorLabel.ForeColor = System.Drawing.Color.Maroon;
                }
                else
                {
                    sementicErrorLabel.Text = "No Error";
                    sementicErrorLabel.ForeColor = System.Drawing.Color.Green;
                }
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
                treeView.ExpandAll();
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
            if (checkBox1.Checked)
            {
                SemanticAnalyzer.errors = new List<string>();
                Compile();

            }
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

        private void classes_data_SelectedIndexChanged(object sender, EventArgs e)
        {
            z_member_access.Text = "";
            z_member_category.Text = "";
            z_member_name.Text = "";
            z_member_totalvar.Text = "";
            z_member_type.Text = "";
            z_members_params.Text = "";

            z_var_name.Text = "";
            z_var_scope.Text = "";
            z_var_type.Text = "";

            member_data.Items.Clear();
            variables_data.Items.Clear();

            List<CLASS> classesTable = SemanticAnalyzer.globalSymbolTable[0].classes;
            string selectedclass = classes_data.SelectedItem.ToString();

            for (int i = 0; i < classesTable.Count; i++)
            {
                if (selectedclass == classesTable[i].name)
                {
                    z_class_name.Text = classesTable[i].name;
                    z_class_access.Text = classesTable[i].accessModifier;
                    z_class_parent.Text = classesTable[i].parent;
                    z_class_totalmembers.Text = classesTable[i].members.Count.ToString();
                    for (int j = 0; j < classesTable[i].members.Count; j++)
                    {
                        member_data.Items.Add(classesTable[i].members[j].name);
                    }
                }
            }
        }

        private void member_data_SelectedIndexChanged(object sender, EventArgs e)
        {
            variables_data.Items.Clear();

            List<CLASS> classesTable = SemanticAnalyzer.globalSymbolTable[0].classes;
            string selectedclass = classes_data.SelectedItem.ToString();
            string selectedMember = member_data.SelectedItem.ToString();

            for (int i = 0; i < classesTable.Count; i++)
            {
                if (selectedclass == classesTable[i].name)
                {
                    z_class_name.Text = classesTable[i].name;
                    z_class_access.Text = classesTable[i].accessModifier;
                    z_class_parent.Text = classesTable[i].parent;
                    z_class_totalmembers.Text = classesTable[i].members.Count.ToString();
                    for (int j = 0; j < classesTable[i].members.Count; j++)
                    {
                        if (selectedMember == classesTable[i].members[j].name)
                        {
                            z_member_name.Text = classesTable[i].members[j].name;
                            z_member_access.Text = classesTable[i].members[j].accessModifier;
                            z_member_category.Text = classesTable[i].members[j].category;
                            z_member_totalvar.Text = classesTable[i].members[j].variables.Count.ToString();
                            z_member_type.Text = classesTable[i].members[j].type;
                            z_members_params.Text = classesTable[i].members[j].param;
                            for (int k = 0; k < classesTable[i].members[j].variables.Count; k++)
                            {
                                variables_data.Items.Add(classesTable[i].members[j].variables[k].name);
                            }
                        }

                    }
                }
            }
        }

        private void variables_data_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<CLASS> classesTable = SemanticAnalyzer.globalSymbolTable[0].classes;
            string selectedclass = classes_data.SelectedItem.ToString();
            string selectedMember = member_data.SelectedItem.ToString();
            string selectedVariable = variables_data.SelectedItem.ToString();

            for (int i = 0; i < classesTable.Count; i++)
            {
                if (selectedclass == classesTable[i].name)
                {
                    z_class_name.Text = classesTable[i].name;
                    z_class_access.Text = classesTable[i].accessModifier;
                    z_class_parent.Text = classesTable[i].parent;
                    z_class_totalmembers.Text = classesTable[i].members.Count.ToString();
                    for (int j = 0; j < classesTable[i].members.Count; j++)
                    {
                        if (selectedMember == classesTable[i].members[j].name)
                        {
                            z_member_name.Text = classesTable[i].members[j].name;
                            z_member_access.Text = classesTable[i].members[j].accessModifier;
                            z_member_category.Text = classesTable[i].members[j].category;
                            z_member_totalvar.Text = classesTable[i].members[j].variables.Count.ToString();
                            z_member_type.Text = classesTable[i].members[j].type;
                            z_members_params.Text = classesTable[i].members[j].param;
                            for (int k = 0; k < classesTable[i].members[j].variables.Count; k++)
                            {
                                if (selectedVariable == classesTable[i].members[j].variables[k].name)
                                {
                                    z_var_name.Text = classesTable[i].members[j].variables[k].name;
                                    z_var_scope.Text = classesTable[i].members[j].variables[k].scope.ToString();
                                    z_var_type.Text = classesTable[i].members[j].variables[k].type;
                                }
                            }
                        }

                    }
                }
            }
        }
    }
}
