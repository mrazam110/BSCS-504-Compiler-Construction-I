using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LexicalAnaylzerRexton
{
    class LexAnalyzer
    {

        public List<token> TokensList(List<token> words) { 
            
        }

        public string checkKeyword(string word)
        {
            for (int i = 0; i < SingletonClass.keywords.Length / 2; i++)
            {
                if (word == SingletonClass.keywords[i, 0])
                {
                    return SingletonClass.keywords[i, 1];
                }
            }
            return "";
        }

        public string checkPunctuators(string word)
        {
            Console.WriteLine(word);
            for (int i = 0; i < SingletonClass.punctuators.Length / 2; i++)
            {
                if (word == SingletonClass.punctuators[i, 0])
                {
                    return SingletonClass.punctuators[i, 1];
                }
            }
            return "";
        }

    }
}
