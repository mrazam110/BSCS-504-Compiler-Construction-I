using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LexicalAnaylzerRexton
{
    class token
    {
        public int lineNumber = 1;
        public string wordStr;
        public string classStr;

        public token(int lineNum, string word)
        {
            lineNumber = lineNum;
            wordStr  = word;
        }
        public token(ushort line, string word, string classs)
        {
            lineNumber = line;
            wordStr = word;
            classStr = classs;
        }
    }
}
