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
                if(words[i].wordStr == " "){
                    
                }
                else if (isInt(words[i].wordStr))
                {
                    words[i].classStr = Singleton.nonKeywords.INT_CONSTANT.ToString();
                }
                else if (isChar(words[i].wordStr))
                {
                    words[i].classStr = Singleton.nonKeywords.CHAR_CONSTANT.ToString();
                }
                else if (isFloat(words[i].wordStr))
                {
                    words[i].classStr = Singleton.nonKeywords.FLOAT_CONSTANT.ToString();
                }
                else if (isString(words[i].wordStr))
                {
                    words[i].wordStr = words[i].wordStr.Remove(0, 1);
                    words[i].wordStr = words[i].wordStr.Remove(words[i].wordStr.Length - 1, 1);
                    words[i].classStr = Singleton.nonKeywords.STRING_CONSTANT.ToString();
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
                else if (isIdentifier(words[i].wordStr))
                {
                        words[i].classStr = Singleton.nonKeywords.IDENTIFIER.ToString();
                }
                else
                {
                    words[i].classStr = Singleton.nonKeywords._INVALID.ToString();
                }
            }

            return words;
        }

        private bool isIdentifier(string word)
        {
            int currentState = 0;
            int finalState = 2;

            /*STATE A   D   $
             * 1    3   4   2
             * 2    3   3   4
             * 3    3   3   3
             * 4    4   4   4
             */
            for (int i = 0; i < word.Length; i++)
            {
                switch (currentState)
                {
                    case 0:
                        if(Regex.IsMatch(word[i].ToString(), RegularExpression.alphabet))
                        {
                            currentState = 2;
                        }
                        else if (Regex.IsMatch(word[i].ToString(), RegularExpression.digits))
                        {
                            currentState = 3;
                        }
                        else if (word[i] == '$')
                        {
                            currentState = 1;
                        }
                        else
                        {
                            currentState = 3;
                        }
                        break;

                    case 1:
                        if (Regex.IsMatch(word[i].ToString(), RegularExpression.alphabet) ||
                            Regex.IsMatch(word[i].ToString(), RegularExpression.digits))
                        {
                            currentState = 2;
                        }
                        else {
                            currentState = 3;
                        }
                        break;

                    case 2:
                        if (Regex.IsMatch(word[i].ToString(), RegularExpression.alphabet) ||
                            Regex.IsMatch(word[i].ToString(), RegularExpression.digits) ||
                            word[i] == '$')
                        {
                            currentState = 2;
                        }
                        else 
                        {
                            currentState = 2;
                        }
                        break;

                    case 3:
                        if (Regex.IsMatch(word[i].ToString(), RegularExpression.alphabet) ||
                            Regex.IsMatch(word[i].ToString(), RegularExpression.digits) ||
                            word[i] == '$')
                        {
                            currentState = 3;
                        }
                        else
                        {
                            currentState = 3;
                        }
                        break;
                }
            }

            if (currentState == finalState)
            {
                return true;
            }

            return false;
        }

        private bool isString(string word)
        {
            int currentState = 0;
            int finalState = 3;

            for (int i = 0; i < word.Length && currentState != 6; i++)
            {
                switch (currentState)
                {
                    case 0:
                        if (word[i] == '@')
                        {
                            currentState = 1;
                        }
                        else
                        {
                            currentState = 4;
                        }
                        break;
                    case 1:
                        if (word[i] == '\\')
                        {
                            currentState = 2;
                        }
                        else if (word[i] == '@')
                        {
                            currentState = 3;
                        }
                        else
                        {
                            currentState = 1;
                        }
                        break;
                    case 2:
                        if (Regex.IsMatch(word[i].ToString(), RegularExpression.escapeCharacters) ||
                            Regex.IsMatch(word[i].ToString(), RegularExpression.sc))
                        {
                            currentState = 1;
                        }
                        else
                        {
                            currentState = 4;
                        }
                        break;
                    case 3:
                        if (i <= word.Length - 1)
                        {
                            currentState = 4;
                        }
                        break;
                    case 4:
                        //valid = false;
                        break;
                }
            }

            if(currentState == finalState){
                return true;
            }

            return false;
        }

        private bool isFloat(string word)
        {
            /*STATE +   -   .   D
             * 1    2   2   3   2
             * 2    5   5   3   2
             * 3    5   5   5   4
             * 4    5   5   5   4
             * 5    5   5   5   5
             */

            int currentState = 0;
            int finalState = 3;

            for (int i = 0; i < word.Length && currentState != 5; i++)
            {
                switch (currentState)
                {
                    case 0:
                        if (word[i] == '.')
                        {
                            currentState = 2;
                        }
                        else
                        {
                            currentState = 1;
                        }
                        break;

                    case 1:
                        if (word[i] == '.')
                        {
                            currentState = 2;
                        }
                        else if (Regex.IsMatch(word[i].ToString(), RegularExpression.digits))
                        {
                            currentState = 1;
                        }
                        else
                        {
                            currentState = 4;
                        }
                        break;

                    case 2:
                        if (Regex.IsMatch(word[i].ToString(), RegularExpression.digits))
                        {
                            currentState = 3;
                        }
                        else
                        {
                            currentState = 4;
                        }
                        break;

                    case 3:
                        if (Regex.IsMatch(word[i].ToString(), RegularExpression.digits))
                        {
                            currentState = 3;

                        }
                        else
                        {
                            currentState = 4;
                        }
                        break;
                        
                    case 4:
                        break;
                }
            }

            if (currentState == finalState)
            {
                return true;
            }

            return false;
        }

        private bool isChar(string word)
        { 
             /*STATE    '   \   ec  sc  ch  '
              * 1       2   6   6   6   6   6
              * 2       6   3   6   6   4   6
              * 3       4   4   4   4   6   4
              * 4       6   6   6   6   6   5
              * 5       6   6   6   6   6   6
              * 6       6   6   6   6   6   6
              */
            int currentState = 0;
            int finalState = 4;

            for (int i = 0; i < word.Length && currentState != 6; i++) {
                switch (currentState)
                {
                    case 0:
                        if (word[i] == '\'') {
                            currentState = 1;
                        }
                        else {
                            currentState = 5;
                        }
                        break;
                        
                    case 1:
                        if (word[i] == '\\') {
                            currentState = 2;
                        }
                        else {
                            currentState = 3; //characters
                        }
                        break;

                    case 2:
                        if (Regex.IsMatch(word[i].ToString(), RegularExpression.escapeCharacters) ||
                            Regex.IsMatch(word[i].ToString(), RegularExpression.sc)) {
                            currentState = 3;
                        }
                        else {
                            currentState = 5;
                        }
                        break;

                    case 3:
                        if (word[i] == '\'') {
                            currentState = 4;
                        }
                        else {
                            currentState = 5;
                        }
                        break;

                    case 4:
                        if (i <= word.Length - 1) {
                            currentState = 5;
                        }
                        break;

                    case 5:
                        break;
                }

                if (currentState == finalState) {
                    return true;
                }
            }

            return false;
        }

        private bool isInt(string word)
        {
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
                        else if (Regex.IsMatch(word[i].ToString(), RegularExpression.signs))
                        {
                            currentState = 0;
                        }
                        else {
                            currentState = 2;
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
                        else
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

        private string checkOperator(string word)
        {
            for (int i = 0; i < Singleton.Operators.Length / 2; i++)
            {
                if (word == Singleton.Operators[i, 0])
                {
                    return Singleton.Operators[i, 1];
                }
            }
            return "";
        }

        private string checkKeyword(string word)
        {
            for (int i = 0; i < Singleton.keywords.Length / 2; i++)
            {
                if (word == Singleton.keywords[i, 0])
                {
                    return Singleton.keywords[i, 1];
                }
            }
            return "";
        }

        private string checkPunctuators(string word)
        {
            Console.WriteLine(word);
            for (int i = 0; i < Singleton.punctuators.Length / 2; i++)
            {
                if (word == Singleton.punctuators[i, 0])
                {
                    return Singleton.punctuators[i, 1];
                }
            }
            return "";
        }

    }
}
