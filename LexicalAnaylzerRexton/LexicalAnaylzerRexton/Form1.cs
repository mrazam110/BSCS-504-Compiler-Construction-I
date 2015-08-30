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
        
        public Form1()
        {
            InitializeComponent();


        }

        private void button1_Click(object sender, EventArgs e)
        {
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

        private void button2_Click(object sender, EventArgs e)
        {
            if (codebox1.Text.Length > 0) { 
                
            }
        }
    }
}
