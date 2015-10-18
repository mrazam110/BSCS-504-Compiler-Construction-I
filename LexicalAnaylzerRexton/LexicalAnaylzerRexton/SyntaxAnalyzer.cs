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
            //FIRST(<Class_ Member >) = { access_modifier , static , DT ,void ,ID , class }
            if (tokenList[index].classStr == Singleton.SingletonEnums._Access_Modifier.ToString() ||
                tokenList[index].classStr == Singleton.SingletonEnums._static.ToString() ||
                tokenList[index].classStr == Singleton.SingletonEnums._DT.ToString() ||
                tokenList[index].classStr == Singleton.SingletonEnums._void.ToString() ||
                tokenList[index].classStr == Singleton.nonKeywords.IDENTIFIER.ToString() ||
                tokenList[index].classStr == Singleton.SingletonEnums._class.ToString())
            {
                //<Class_Member>  <Access_Modifier><Member_Link>
                if (Access_Modifier())
                {
                    if (Member_Link())
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private bool Member_Link()
        {
            //FIRST(<Member_Link>) = { static , DT ,void ,ID , class }
            if (tokenList[index].classStr == Singleton.SingletonEnums._static.ToString() ||
                tokenList[index].classStr == Singleton.SingletonEnums._DT.ToString() ||
                tokenList[index].classStr == Singleton.SingletonEnums._void.ToString() ||
                tokenList[index].classStr == Singleton.nonKeywords.IDENTIFIER.ToString() ||
                tokenList[index].classStr == Singleton.SingletonEnums._class.ToString())
            {
                //<Member_Link>  <Static><SS_A>| void ID <Method_Link 3> | DT <DT_2> |<Constructor_DEC> | <Class_Link>
                if (Static())
                {
                    if (SS_A())
                    {
                        return true;
                    }
                }

                else if (tokenList[index].classStr == Singleton.SingletonEnums._void.ToString())
                {
                    index++;
                    if (tokenList[index].classStr == Singleton.nonKeywords.IDENTIFIER.ToString())
                    {
                        index++;
                        if (Method_Link3())
                        {
                            return true;
                        }
                    }
                }

                else if (tokenList[index].classStr == Singleton.SingletonEnums._DT.ToString())
                {
                    index++;
                    if (DT_2())
                    {
                        return true;
                    }
                }

                else if (Constructor_DEC())
                {
                    return true;
                }

                else if (Class_Link())
                {
                    return true;
                }
            }
            return false;
        }

        private bool Static()
        {
            //FIRST(<Static>) = {Static}
            if (tokenList[index].classStr == Singleton.SingletonEnums._static.ToString())
            {
                //<Static>   Static
                index++;
            }
            return false;
        }

        private bool SS_A()
        {
            //FIRST(<SS_A>) = {DT , ID , void}
            if (tokenList[index].classStr == Singleton.SingletonEnums._DT.ToString() ||
                tokenList[index].classStr == Singleton.nonKeywords.IDENTIFIER.ToString() ||
                tokenList[index].classStr == Singleton.SingletonEnums._void.ToString())
            {
                //<SS_A>   DT <DT_1> |ID <Id_OArray> |void ID<Method_Link3> 
                if (tokenList[index].classStr == Singleton.SingletonEnums._DT.ToString())
                {
                    index++;
                    if (DT_1())
                    {
                        return true;
                    }
                }

                else if (tokenList[index].classStr == Singleton.nonKeywords.IDENTIFIER.ToString())
                {
                    index++;
                    if (Id_OArray())
                    {
                        return true;
                    }
                }

                else if (tokenList[index].classStr == Singleton.SingletonEnums._void.ToString())
                {
                    index++;
                    if (Method_Link3())
                    {
                        return true;
                    }
                }
            }
            
            return false;
        }

        private bool Method_Link3()
        {
            //FIRST(<Method_Link 3>) = { ( }
            if (tokenList[index].classStr == "(")
            {
                //<Method_Link 3>   (<List_Param>) {<M_St>} 
                if (tokenList[index].classStr == "(")
                {
                    index++;
                    if (List_Param())
                    {
                        if (tokenList[index].classStr == ")")
                        {
                            index++;
                            if (tokenList[index].classStr == "{")
                            {
                                index++;
                                if (M_ST())
                                {
                                    if (tokenList[index].classStr == "}")
                                    {
                                        return true;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return false;
        }

        private bool DT_2()
        {
            //FIRST(<DT_2>) = {ID , [}
            if (tokenList[index].classStr == Singleton.nonKeywords.IDENTIFIER.ToString() ||
                tokenList[index].classStr == "[")
            {
                //<DT_2> ID <ID_1>|< Array_DEC>
                if (tokenList[index].classStr == Singleton.nonKeywords.IDENTIFIER.ToString())
                {
                    index++;
                    if (ID_1())
                    {
                        return true;
                    }
                }

                else if (Array_DEC())
                {
                    return true;
                }
            }
            return false;
        }

        private bool Constructor_DEC()
        {
            //FIRST(<Constructor_DEC>) = {ID}
            if (tokenList[index].classStr == Singleton.nonKeywords.IDENTIFIER.ToString())
            {
                //<Constructor_DEC>   ID (<List_Param>) {<M-St>}
                if (tokenList[index].classStr == Singleton.nonKeywords.IDENTIFIER.ToString())
                {
                    index++;
                    if (tokenList[index].classStr == "(")
                    {
                        index++;
                        if (List_Param())
                        {
                            if (tokenList[index].classStr == ")")
                            {
                                index++;
                                if (tokenList[index].classStr == "{")
                                {
                                    index++;
                                    if (M_ST())
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
                }
                
            }
            return false;
        }

        private bool ID_1()
        {
            //FIRST(<ID_1>) = {( , =} //TEMP
            if (tokenList[index].classStr == "(" ||
                tokenList[index].classStr == "=")
            {
                //<ID_1><Varaiable_Link2> | <Method_Link 3>
                if (Varaiable_Link2())
                {
                    if (Method_Link3())
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private bool Varaiable_Link2()
        {
            //FIRST(<Variable_Link2>  ) = {=, , , ;}
            if (tokenList[index].classStr == "=" ||
                tokenList[index].classStr == "," ||
                tokenList[index].classStr == ";")
            {
                //<Variable_Link2>   =  <Variable_Value>| <LIST> //TEMP
                if (tokenList[index].classStr == "=")
                {
                    index++;
                    if (Variable_Value())
                    {
                        return true;
                    }
                }

                else if (LIST())
                {
                    return true;
                }
            }
            return false;
        }

        private bool Variable_Value()
        {
            //FIRST(<Variable_Value>) = { ID, INT_CONST , FLOAT_CONST , STRING_CONST , CHAR_CONST , BOOL_CONST }
            if (tokenList[index].classStr == Singleton.nonKeywords.IDENTIFIER.ToString() ||
                tokenList[index].classStr == Singleton.nonKeywords.INT_CONSTANT.ToString() ||
                tokenList[index].classStr == Singleton.nonKeywords.FLOAT_CONSTANT.ToString() ||
                tokenList[index].classStr == Singleton.nonKeywords.STRING_CONSTANT.ToString() ||
                tokenList[index].classStr == Singleton.nonKeywords.CHAR_CONSTANT.ToString() ||
                tokenList[index].classStr == Singleton.nonKeywords.BOOL_CONSTANT.ToString())
            {
                //<Variable_Value>   <Exp><LIST>  	
                if (Exp())
                {
                    if (LIST())
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private bool Exp()
        {
            //FIRST(<Exp>) = { ID, INT_CONST , FLOAT_CONST , STRING_CONST , CHAR_CONST , BOOL_CONST  }
            if (tokenList[index].classStr == Singleton.nonKeywords.IDENTIFIER.ToString() ||
                tokenList[index].classStr == Singleton.nonKeywords.INT_CONSTANT.ToString() ||
                tokenList[index].classStr == Singleton.nonKeywords.FLOAT_CONSTANT.ToString() ||
                tokenList[index].classStr == Singleton.nonKeywords.STRING_CONSTANT.ToString() ||
                tokenList[index].classStr == Singleton.nonKeywords.CHAR_CONSTANT.ToString() ||
                tokenList[index].classStr == Singleton.nonKeywords.BOOL_CONSTANT.ToString())
            {
                //<Exp>  <OR_Exp>
                if (OR_Exp())
                {
                    return true;
                }
            }
            return false;
        }

        private bool OR_Exp()
        {
            //FIRST(<OR_Exp>) = { ID, INT_CONST , FLOAT_CONST , STRING_CONST , CHAR_CONST , BOOL_CONST  }
            if (tokenList[index].classStr == Singleton.nonKeywords.IDENTIFIER.ToString() ||
                tokenList[index].classStr == Singleton.nonKeywords.INT_CONSTANT.ToString() ||
                tokenList[index].classStr == Singleton.nonKeywords.FLOAT_CONSTANT.ToString() ||
                tokenList[index].classStr == Singleton.nonKeywords.STRING_CONSTANT.ToString() ||
                tokenList[index].classStr == Singleton.nonKeywords.CHAR_CONSTANT.ToString() ||
                tokenList[index].classStr == Singleton.nonKeywords.BOOL_CONSTANT.ToString())
            {
                //<OR_Exp>  <AND_Exp> <OR_Exp2>
                if (AND_Exp())
                {
                    if (OR_Exp2())
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private bool OR_Exp2()
        {
            //FIRST(<OR_Exp2>) = {|| , Null}
            if (tokenList[index].classStr == Singleton.SingletonEnums.OrOp.ToString())
            {
                //<OR_Exp2>  || <AND_Exp> <OR_Exp2> | Null
                if (tokenList[index].classStr == Singleton.SingletonEnums.OrOp.ToString())
                {
                    index++;
                    if (AND_Exp())
                    {
                        if (OR_Exp2())
                        {
                            return true;
                        }
                    }
                }
            }

            //FOLLOW(<OR_Exp2>) = { , ,  ; , )}
            if(tokenList[index].classStr == "," ||
                tokenList[index].classStr == ";" ||
                tokenList[index].classStr == ")")
            {
                return true;
            }
            return false;
        }

        private bool AND_Exp()
        {
            return false;
        }

        private bool Array_DEC()
        {
            return false;
        }

        private bool LIST()
        {
            return false;
        }

        private bool List_Param()
        {
            return false;
        }

        private bool M_ST()
        {
            return false;
        }

        private bool DT_1()
        {
            return false;
        }

        private bool Id_OArray()
        {
            return false;
        }
    }
}
