using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LexicalAnaylzerRexton
{
    class LexAnalyzer
    {

        public List<token> getTokensList(List<token> words) {
        
            for (int i = 0; i < words.Count; i++) {
                if (isInt(words[i].wordStr))
                {
                    words[i].classStr = SingletonClass.nonKeywords.INT_CONSTANT.ToString();
                }
                else if (checkOperator(words[i].wordStr) != "")
                {
                    words[i].classStr = checkOperator(words[i].wordStr);
                }
                else if (checkPunctuators(words[i].wordStr) != "")
                {
                    words[i].classStr = checkPunctuators(words[i].wordStr);
                }
                else if (checkKeyword(words[i].wordStr) != "")
                {
                    words[i].classStr = checkKeyword(words[i].wordStr);
                }
            }

            return words;
        }

        public bool isInt(string word) {
            /*
             STATE  +   -   D
             * 1    1   1   2
             * 2    3   3   2
             * 3    3   3   3
             */
            int currentState = 0;
            int finalState = 1;

            for (int i = 0; i < word.Length && currentState != 3; i++) {
                switch (currentState)
                {
                    case 0:
                        if (Regex.IsMatch(word[i].ToString(), RegularExpression.digits)) {
                            currentState = 1;
                        }
                        else if (Regex.IsMatch(word[i].ToString(), RegularExpression.signs)) {
                            currentState = 0;
                        }
                        break;
                    case 1:
                        if (Regex.IsMatch(word[i].ToString(), RegularExpression.digits))
                        {
                            currentState = 1;
                        }
                        else if (Regex.IsMatch(word[i].ToString(), RegularExpression.signs))
                        {
                            currentState = 2;
                        }
                        break;
                    case 2:
                        if (Regex.IsMatch(word[i].ToString(), RegularExpression.digits))
                        {
                            currentState = 2;
                        }
                        else if (Regex.IsMatch(word[i].ToString(), RegularExpression.signs))
                        {
                            currentState = 2;
                        }
                        break;
                }
            }

            if (currentState == finalState) {
                return true;
            }

            return false;
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
