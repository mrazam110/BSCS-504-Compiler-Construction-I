using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LexicalAnaylzerRexton
{
    class LexAnalyzer
    {

        public List<token> getTokensList(List<token> words) {
        
            for (int i = 0; i < words.Count; i++) {
                if (checkKeyword(words[i].wordStr) != "")
                {
                    words[i].classStr = checkKeyword(words[i].wordStr);
                }
                else if (checkOperator(words[i].wordStr) != "")
                {
                    words[i].classStr = checkOperator(words[i].wordStr);
                }
                else if (checkPunctuators(words[i].wordStr) != "")
                {
                    words[i].classStr = checkPunctuators(words[i].wordStr);
                }
            }

            return words;
        }

        public string checkOperator(string word)
        {
            for (int i = 0; i < SingletonClass.Operators.Length / 2; i++)
            {
                if (word == SingletonClass.Operators[i, 0])
                {
                    return SingletonClass.Operators[i, 1];
                }
            }
            return "";
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
