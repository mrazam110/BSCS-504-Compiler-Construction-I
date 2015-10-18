using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LexicalAnaylzerRexton
{
    class SyntaxAnalyzer
    {
        private List<token> tokenList;

        public SyntaxAnalyzer(List<token> tokenList)
        {
            this.tokenList = tokenList;
            addDollarToken();
        }

        private void addDollarToken(){
            token temp = new token(-1, "$", "$");
            tokenList.Add(temp);
        }

        public bool validateCfg()
        {
            CFG cfg = new CFG(tokenList);
            return cfg.validate();
        }

    }

    class CFG
    {
        private int index = 0;
        private List<token> tokenList;

        public CFG(List<token> tokenList)
        {
            this.tokenList = tokenList;
        }

        public bool validate()
        {
            if (S())
            {
                if (tokenList[index].classStr == "$")
                {
                    return true;
                }
            }
            return false;
        }

        private bool S()
        {
            //FIRST(<Class_Dec>) = { access_modifier, class}
            if (tokenList[index].classStr == Singleton.SingletonEnums._Access_Modifier.ToString() || 
                tokenList[index].classStr == Singleton.SingletonEnums._class.ToString())
            {

                //<Class_Dec>   <Access_Modifier><Class_Link>
                if (Access_Modifier())
                {
                    if (Class_Link())
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private bool Access_Modifier()
        {
            //FIRST(<Access_Modifier>) = { access_modifier, Null}
            if (tokenList[index].classStr == Singleton.SingletonEnums._Access_Modifier.ToString())
            {

                //<Access_Modifier>  access_modifier | Null
                if (tokenList[index].classStr == Singleton.SingletonEnums._Access_Modifier.ToString())
                {
                    index++;
                    return true;
                }
            }

            //FOLLOW(<Access_Modifier>) = { class , static , DT ,void ,ID  }
            if (tokenList[index].classStr == Singleton.SingletonEnums._class.ToString() ||
                tokenList[index].classStr == Singleton.SingletonEnums._static.ToString() ||
                tokenList[index].classStr == Singleton.SingletonEnums._DT.ToString() ||
                tokenList[index].classStr == Singleton.SingletonEnums._void.ToString() ||
                tokenList[index].classStr == Singleton.nonKeywords.IDENTIFIER.ToString())
            {
                return true;
            }

            return false;
        }

        private bool Class_Link()
        {
            //FIRST(<Class_Link>) = {class}
            if (tokenList[index].classStr == Singleton.SingletonEnums._class.ToString())
            {
                //<Class_Link>  class ID <Class_Base> {<Class_Body>}
                index++;
                if (tokenList[index].classStr == Singleton.nonKeywords.IDENTIFIER.ToString())
                {
                    index++;
                    if (Class_Base())
                    {
                        if (tokenList[index].classStr == "{")
                        {
                            index++;
                            if (Class_Body())
                            {
                                if (tokenList[index].classStr == "}")
                                {
                                    index++;
                                    return true;
                                }
                            }
                        }
                    }
                }
            }

            return false;
        }

        private bool Class_Base()
        {
            //FIRST(<Class_Base>) = {Null , :}
            if (tokenList[index].classStr == ":")
            {
                //<Class_Base>  Null | : ID
                index++;
                if (tokenList[index].classStr == Singleton.nonKeywords.IDENTIFIER.ToString())
                {
                    index++;
                    return true;
                }
            }

            //FOLLOW(<Class_Base>) = { { }
            if (tokenList[index].classStr == "{")
            {
                return true;
            }

            return false;
        }

        private bool Class_Body()
        {
            //FIRST(<Class_Body>) = { access_modifier , static , DT ,void ,ID , class  , Null
            if(tokenList[index].classStr == Singleton.SingletonEnums._Access_Modifier.ToString() ||
                tokenList[index].classStr == Singleton.SingletonEnums._static.ToString() ||
                tokenList[index].classStr == Singleton.SingletonEnums._DT.ToString() ||
                tokenList[index].classStr == Singleton.SingletonEnums._void.ToString() ||
                tokenList[index].classStr == Singleton.nonKeywords.IDENTIFIER.ToString() ||
                tokenList[index].classStr == Singleton.SingletonEnums._class.ToString())
            {
                //<Class_Body>  <Class_Member> <Class_Body> | Null
                if (Class_Member())
                {
                    if (Class_Body())
                    {
                        return true;
                    }
                }
            }

            //FOLLOW(<Class_Body>) = { } }
            if (tokenList[index].classStr == "}")
            {
                return true;
            }

            return false;
        }

        private bool Class_Member()
        {
            return true;
        }

    }
}
