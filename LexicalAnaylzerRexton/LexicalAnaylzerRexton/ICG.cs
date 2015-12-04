using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LexicalAnaylzerRexton
{
    class ICG
    {
        int labelCount = 1;
        int tempCount = 1;
        List<string> icgCode = new List<string>();

        public string CreateLabel()
        {
            return "L" + labelCount++;
        }

        public string CreateTemp()
        {
            return "T" + tempCount++;
        }

        public void GenerateCode(string line)
        {
            icgCode.Add(line + "\n");
            Program.compiler.ICG_text.Text += icgCode.Last();
        }

        public string getLastLabel()
        {
            return "L" + (labelCount - 1);
        }
        public string getLastTemp()
        {
            return "T" + (tempCount - 1);
        }

        public void reset()
        {
            labelCount = 1;
            tempCount = 1;
            icgCode = new List<string>();
        }
    }
}
