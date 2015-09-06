using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LexicalAnaylzerRexton
{
    class breakWork
    {
        public List<string> distinctBreaker = new List<string>();
        public List<string> totalBreaker = new List<string>();

        public List<token> breakString(string myString)
        {
            List<token> output = new List<token>();

            string temp = "";

            bool breaker = false;
            bool addNext = false;
            bool isFloat = false;
            bool isString = false;
            bool newLine = false;
            bool exit = false;
            bool isMultiComment = false;

            int dump = 0;
            int line = 1;

            for (int i = 0; i < myString.Length; i++)
            {

                //check new line
                if (newLine)
                {
                    line++;
                    newLine = false;
                }

                //--START char ch in breakers
                foreach (char ch in SingletonClass.breakers)
                {
                    //--START myString[i] == ch
                    if (myString[i] == ch)
                    {
                        breaker = true;
                        //START i != myString.Length - 1
                        if (i != myString.Length - 1)
                        {
                            //--START SWITCH--
                            switch (myString[i])
                            {
                                case ' ':
                                    break;
                                //if \t
                                case '\t':
                                    break;
                                //if next line
                                case '\n':
                                    newLine = true;
                                    break;
                                //IF OPERATORS
                                case '+':
                                    //if not plus minus operator
                                    if (myString[i + 1] == '+' || myString[i + 1] == '=')
                                    {
                                        addNext = true;
                                    }
                                    else
                                    {
                                        //means plus minus operator
                                        addNext = false;
                                    }
                                    break;
                                case '-':
                                    //if not plus minus operator
                                    if (myString[i + 1] == '-' || myString[i + 1] == '=')
                                    {
                                        addNext = true;
                                    }
                                    else
                                    {
                                        //means plus minus operator
                                        addNext = false;
                                    }
                                    break;
                                case '*':
                                    //if not multiply operator
                                    if (myString[i + 1] == '=')
                                    {
                                        addNext = true;
                                    }
                                    else
                                    {
                                        //means multiply operator
                                        addNext = false;
                                    }
                                    break;
                                case '/':
                                    //if not divide operator
                                    if (myString[i + 1] == '=')
                                    {
                                        addNext = true;
                                    }
                                    else
                                    {
                                        //means divide operator
                                        addNext = false;
                                    }
                                    break;
                                case '%':
                                    //if not mode operator
                                    if (myString[i + 1] == '=')
                                    {
                                        addNext = true;
                                    }
                                    else
                                    {
                                        //means mode operator
                                        addNext = false;
                                    }
                                    break;
                                //END OPERATOR
                                case '>':
                                    //if >= sign
                                    if (myString[i + 1] == '=')
                                    {
                                        addNext = true;
                                    }
                                    else
                                    {
                                        //if > sign
                                        addNext = false;
                                    }
                                    break;
                                case '<':
                                    if (myString[i + 1] == '=')
                                    {
                                        //if <= sign
                                        addNext = true;
                                    }
                                    else
                                    {
                                        //if < sign
                                        addNext = false;
                                    }
                                    break;
                                case '=':
                                    if (myString[i + 1] == '=')
                                    {
                                        //if == sign
                                        addNext = true;
                                    }
                                    else
                                    {
                                        //if = sign
                                        addNext = false;
                                    }
                                    break;
                                case '&':
                                    if (myString[i + 1] == '&')
                                    {
                                        //if && sign
                                        addNext = true;
                                    }
                                    else
                                    {
                                        //if & sign
                                        addNext = false;
                                    }
                                    break;
                                case '|':
                                    if (myString[i + 1] == '|')
                                    {
                                        //if || sign
                                        addNext = true;
                                    }
                                    else if (myString[i + 1] == '-')
                                    {
                                        //Multi line comments
                                        string tempComment = "|-";
                                        bool commentNOtComplete = true;
                                        isMultiComment = true;
                                        i += 2;
                                        while (i < myString.Length)
                                        {
                                            tempComment += myString[i];
                                            if (myString[i] == '\n')
                                            {
                                                line++;
                                            }

                                            if (i + 1 < myString.Length && myString[i] == '-' && myString[i + 1] == '|')
                                            {
                                                commentNOtComplete = false;
                                                i += 1;
                                                break;
                                            }
                                            else
                                            {
                                                i++;
                                            }
                                        }
                                        if (i < myString.Length && myString[i] == '\n')
                                        {
                                            line++;
                                        }

                                        if (commentNOtComplete)
                                        {
                                            output.Add(new token(line, tempComment));
                                        }
                                    }
                                    else
                                    {
                                        //if | sign
                                        addNext = false;
                                    }
                                    break;
                                case '!':
                                    if (myString[i + 1] == '=')
                                    {
                                        //if != sign
                                        addNext = true;
                                    }
                                    else
                                    {
                                        //if ! sign
                                        addNext = false;
                                    }
                                    break;
                                case '#':
                                    if (myString[i + 1] == '#')
                                    {
                                        while (true)
                                        {
                                            if (i >= myString.Length)
                                            {
                                                exit = true;
                                                break;
                                            }
                                            if (myString[i] == '\n')
                                            {
                                                addNext = false;
                                                newLine = true;
                                                break;
                                            }
                                            i++;
                                        }
                                    }
                                    else
                                    {
                                        //if ! sign
                                        addNext = false;
                                    }
                                    break;
                                case '.':
                                    if (int.TryParse(temp, out dump) && int.TryParse(myString[i + 1].ToString(), out dump))
                                    {
                                        breaker = false;
                                    }
                                    else if (int.TryParse(myString[i + 1].ToString(), out dump))
                                    {
                                        isFloat = true;
                                    }
                                    break;
                                case '@':
                                    if (temp != "")
                                    {
                                        output.Add(new token(line, temp));
                                        temp = "";
                                    }
                                    temp += myString[i];
                                    i++;
                                    while (i < myString.Length)// && myString[i] != '\n'
                                    {
                                        if (myString[i] == '\\')
                                        {
                                            temp += myString[i];
                                            if (i + 1 < myString.Length - 1)
                                            {
                                                temp += myString[i + 1];
                                            }
                                            i++;

                                        }
                                        else if (myString[i] == '@')
                                        {
                                            temp += myString[i];

                                            break;
                                        }
                                        else
                                        {
                                            temp += myString[i];
                                        }
                                        i++;
                                    }
                                    if (i < myString.Length && myString[i] == '\n')
                                    {
                                        newLine = true;
                                    }
                                    isString = true;
                                    break;
                                case '\'':
                                    if (temp != "")
                                    {
                                        isString = true;
                                        i--;
                                        break;

                                    }
                                    short length = 0;
                                    while (true)
                                    {

                                        temp += myString[i];
                                        i++;
                                        if (length >= 2 && myString[i - 2] != '\\')
                                        {
                                            i--;
                                            isString = true;
                                            break;
                                        }
                                        if (length >= 3 && myString[i - 2] == '\\' && myString[i - 3] == '\\')
                                        {
                                            i--;
                                            isString = true;
                                            break;
                                        }
                                        if ((myString[i] == '\'' && myString[i - 1] != '\\') || (myString[i] == '\n') || (i == myString.Length - 1))
                                        {
                                            temp += myString[i];
                                            isString = true;
                                            if (myString[i] == '\n')
                                            {
                                                newLine = true;
                                                temp = temp.Remove(temp.Length - 1);
                                            }
                                            break;
                                        }
                                        length++;
                                    }
                                    break;
                                default:
                                    break;
                            }
                            //--END SWITCH--
                        }
                        //--END i != myString.Length - 1
                    }
                    //--END myString[i] == ch

                    if (breaker)
                    {
                        break;
                    }
                }
                //--END char ch in breakers

                if (exit)
                {
                    exit = false;
                    break;
                }
                if (!breaker)
                {
                    temp += myString[i];
                }
                else if (breaker && !isString && !isMultiComment)
                {
                    if (temp != "")
                    {
                        output.Add(new token(line, temp));
                    }
                    temp = myString[i].ToString();
                    if (isFloat)
                    {
                        breaker = false;
                        isFloat = false;
                        continue;
                    }
                    else if (addNext)
                    {
                        i++;
                        temp += myString[i];
                        addNext = false;
                    }
                    output.Add(new token(line, temp));
                    temp = "";
                    breaker = false;
                }
                else if (isString)
                {
                    output.Add(new token(line, temp));
                    temp = "";
                    isString = false;
                    breaker = false;
                    if (newLine)
                    {
                        output.Add(new token(line, "\n"));
                    }
                    //close multi line comment
                    if (isMultiComment)
                    {
                        breaker = false;
                        isMultiComment = false;
                    }
                }
            }

            if (temp != "")
            {
                output.Add(new token(line, temp));
                temp = "";
            }

            return output;
        }


    }
}
