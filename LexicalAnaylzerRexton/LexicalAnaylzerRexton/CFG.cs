using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LexicalAnaylzerRexton
{
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
            if (tokenList[index].classStr == Singleton.SingletonEnums._Access_Modifier.ToString() ||
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
                                        index++;
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
                if (Variable_Link2())
                {
                    return true;
                }
                else if (Method_Link3())
                {
                    return true;
                }
            }
            return false;
        }

        /*private bool Varaiable_Link2()
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
        }*/

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
            if (tokenList[index].classStr == "," ||
                tokenList[index].classStr == ";" ||
                tokenList[index].classStr == ")")
            {
                return true;
            }
            return false;
        }

        private bool AND_Exp()
        {
            //FIRST(<AND_Exp>) = { ID, INT_CONST , FLOAT_CONST , STRING_CONST , CHAR_CONST , BOOL_CONST  }
            if (tokenList[index].classStr == Singleton.nonKeywords.IDENTIFIER.ToString() ||
                tokenList[index].classStr == Singleton.nonKeywords.INT_CONSTANT.ToString() ||
                tokenList[index].classStr == Singleton.nonKeywords.FLOAT_CONSTANT.ToString() ||
                tokenList[index].classStr == Singleton.nonKeywords.STRING_CONSTANT.ToString() ||
                tokenList[index].classStr == Singleton.nonKeywords.CHAR_CONSTANT.ToString() ||
                tokenList[index].classStr == Singleton.nonKeywords.BOOL_CONSTANT.ToString())
            {
                //<AND_Exp>  <ROP> <AND_Exp2>
                if (ROP())
                {
                    if (AND_Exp2())
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private bool AND_Exp2()
        {
            //FIRST(<AND_Exp2>) = {&& , Null}
            if (tokenList[index].classStr == Singleton.SingletonEnums.AndOp.ToString())
            {
                //<AND_Exp2>  && <ROP> <AND_Exp2> | Null
                if (tokenList[index].classStr == Singleton.SingletonEnums.AndOp.ToString())
                {
                    index++;
                    if (ROP())
                    {
                        if (AND_Exp2())
                        {
                            return true;
                        }
                    }
                }
            }
            ////FOLLOW(<AND_Exp2>) = {||, , ,  ; , )}
            
            if (tokenList[index].classStr == Singleton.SingletonEnums.OrOp.ToString() ||
                tokenList[index].classStr == "," ||
                tokenList[index].classStr == ";" ||
                tokenList[index].classStr == ")")
            {
                return true;
            }
            return false;
        }


        private bool ROP()
        {
            //FIRST(<ROP>) = { ID, INT_CONST , FLOAT_CONST , STRING_CONST , CHAR_CONST , BOOL_CONST  }
            if (tokenList[index].classStr == Singleton.nonKeywords.IDENTIFIER.ToString() ||
                tokenList[index].classStr == Singleton.nonKeywords.INT_CONSTANT.ToString() ||
                tokenList[index].classStr == Singleton.nonKeywords.FLOAT_CONSTANT.ToString() ||
                tokenList[index].classStr == Singleton.nonKeywords.STRING_CONSTANT.ToString() ||
                tokenList[index].classStr == Singleton.nonKeywords.CHAR_CONSTANT.ToString() ||
                tokenList[index].classStr == Singleton.nonKeywords.BOOL_CONSTANT.ToString())
            {
                //<ROP>  <E> <ROP2>
                if (E())
                {
                    if (ROP2())
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private bool ROP2()
        {
            //FIRST(<ROP2>) = {ROP , Null}
            if (tokenList[index].classStr == Singleton.SingletonEnums.RelationalOp.ToString()) //can be '=' TEMP
            {
                //<ROP2>  ROP <E> <ROP2> | Null
                if (tokenList[index].classStr == Singleton.SingletonEnums.RelationalOp.ToString())
                {
                    index++;
                    if (E())
                    {
                        if (ROP2())
                        {
                            return true;
                        }
                    }
                }
            }

            ////FOLLOW(<ROP2>) = {&& ,||, , ,  ; , )}
            if (tokenList[index].classStr == Singleton.SingletonEnums.AndOp.ToString() ||
                tokenList[index].classStr == Singleton.SingletonEnums.OrOp.ToString() ||
                tokenList[index].classStr == "," ||
                tokenList[index].classStr == ";" ||
                tokenList[index].classStr == ")")
            {
                return true;
            }
            return false;
        }

        private bool E()
        {
            //FIRST(<E>) = { ID, INT_CONST , FLOAT_CONST , STRING_CONST , CHAR_CONST , BOOL_CONST  }
            if (tokenList[index].classStr == Singleton.nonKeywords.IDENTIFIER.ToString() ||
                tokenList[index].classStr == Singleton.nonKeywords.INT_CONSTANT.ToString() ||
                tokenList[index].classStr == Singleton.nonKeywords.FLOAT_CONSTANT.ToString() ||
                tokenList[index].classStr == Singleton.nonKeywords.STRING_CONSTANT.ToString() ||
                tokenList[index].classStr == Singleton.nonKeywords.CHAR_CONSTANT.ToString() ||
                tokenList[index].classStr == Singleton.nonKeywords.BOOL_CONSTANT.ToString())
            {
                //<E>  <T> <E2>
                if (T())
                {
                    if (E2())
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private bool E2()
        {
            //FIRST(<E2 >) = {Plus_Minus , Null}
            if (tokenList[index].classStr == Singleton.SingletonEnums.PlusMinus.ToString())
            {
                //<E2 >  Plus_Minus <T > <E2> | Null
                if (tokenList[index].classStr == Singleton.SingletonEnums.PlusMinus.ToString())
                {
                    index++;
                    if (T())
                    {
                        if (E2())
                        {
                            return true;
                        }
                    }
                }
            }
            ////FOLLOW(<E2>) = {ROP , && ,||, , ,  ; , )}
            if (tokenList[index].classStr == Singleton.SingletonEnums.RelationalOp.ToString() || // maybe '=' TEMP
                tokenList[index].classStr == Singleton.SingletonEnums.OrOp.ToString() ||
                tokenList[index].classStr == Singleton.SingletonEnums.AndOp.ToString() ||
                tokenList[index].classStr == "," ||
                tokenList[index].classStr == ";" ||
                tokenList[index].classStr == ")")
            {
                return true;
            }
            return false;
        }

        private bool T()
        {
            //FIRST(<T>) = { ID, INT_CONST , FLOAT_CONST , STRING_CONST , CHAR_CONST , BOOL_CONST  }
            if (tokenList[index].classStr == Singleton.nonKeywords.IDENTIFIER.ToString() ||
                tokenList[index].classStr == Singleton.nonKeywords.INT_CONSTANT.ToString() ||
                tokenList[index].classStr == Singleton.nonKeywords.FLOAT_CONSTANT.ToString() ||
                tokenList[index].classStr == Singleton.nonKeywords.STRING_CONSTANT.ToString() ||
                tokenList[index].classStr == Singleton.nonKeywords.CHAR_CONSTANT.ToString() ||
                tokenList[index].classStr == Singleton.nonKeywords.BOOL_CONSTANT.ToString())
            {
                //<T>  <F> <T2>
                if (F())
                {
                    if (T2())
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private bool T2()
        {
            //FIRST(<T2>) = { M_D_M , Null}
            if (tokenList[index].classStr == Singleton.SingletonEnums.MultiDivideMode.ToString())
            {
                //<T2>  M_D_M <F> <T2> | Nulll
                if (tokenList[index].classStr == Singleton.SingletonEnums.MultiDivideMode.ToString())
                {
                    if (F())
                    {
                        if (T2())
                        {
                            return true;
                        }
                    }
                }
            }
            ////FOLLOW(<T2>) = { Plus_Minus , ROP , && ,||, , ,  ; , )}
            
            if (tokenList[index].classStr == Singleton.SingletonEnums.RelationalOp.ToString() || // maybe '=' TEMP
                tokenList[index].classStr == Singleton.SingletonEnums.OrOp.ToString() ||
                tokenList[index].classStr == Singleton.SingletonEnums.AndOp.ToString() ||
                tokenList[index].classStr == "," ||
                tokenList[index].classStr == ";" ||
                tokenList[index].classStr == ")")
            {
                return true;
            }
            return false;
        }

        private bool F()
        {
            //FIRST(<F>) = { ID, INT_CONST , FLOAT_CONST , STRING_CONST , CHAR_CONST , BOOL_CONST  }
            if (tokenList[index].classStr == Singleton.nonKeywords.IDENTIFIER.ToString() ||
                tokenList[index].classStr == Singleton.nonKeywords.INT_CONSTANT.ToString() ||
                tokenList[index].classStr == Singleton.nonKeywords.FLOAT_CONSTANT.ToString() ||
                tokenList[index].classStr == Singleton.nonKeywords.STRING_CONSTANT.ToString() ||
                tokenList[index].classStr == Singleton.nonKeywords.CHAR_CONSTANT.ToString() ||
                tokenList[index].classStr == Singleton.nonKeywords.BOOL_CONSTANT.ToString())
            {
                //<F>  ID | <CONST>
                if (tokenList[index].classStr == Singleton.nonKeywords.IDENTIFIER.ToString())
                {
                    index++;
                    return true;
                }
                else if (CONST())
                {
                    return true;
                }
            }
            return false;
        }

        private bool CONST()
        {
            //FIRST(<CONST>) = { INT_CONST, FLOAT_CONST , STRING_CONST , CHAR_CONST ,BOOL_CONST }
            if (tokenList[index].classStr == Singleton.nonKeywords.INT_CONSTANT.ToString() ||
                tokenList[index].classStr == Singleton.nonKeywords.FLOAT_CONSTANT.ToString() ||
                tokenList[index].classStr == Singleton.nonKeywords.STRING_CONSTANT.ToString() ||
                tokenList[index].classStr == Singleton.nonKeywords.CHAR_CONSTANT.ToString() ||
                tokenList[index].classStr == Singleton.nonKeywords.BOOL_CONSTANT.ToString())
            {
                //<CONST>   INT_CONST| FLOAT_CONST | STRING_CONST | CHAR_CONST | BOOL_CONST
                if (tokenList[index].classStr == Singleton.nonKeywords.INT_CONSTANT.ToString() ||
                tokenList[index].classStr == Singleton.nonKeywords.FLOAT_CONSTANT.ToString() ||
                tokenList[index].classStr == Singleton.nonKeywords.STRING_CONSTANT.ToString() ||
                tokenList[index].classStr == Singleton.nonKeywords.CHAR_CONSTANT.ToString() ||
                tokenList[index].classStr == Singleton.nonKeywords.BOOL_CONSTANT.ToString())
                {
                    index++;
                    return true;
                }
            }
            return false;
        }

        private bool LIST()
        {
            //FIRST(<LIST >) = {, , ;}
            if (tokenList[index].classStr == "," ||
                tokenList[index].classStr == ";")
            {
                //<LIST >  , ID <Variable_Link2> | ;
                if (tokenList[index].classStr == Singleton.nonKeywords.IDENTIFIER.ToString())
                {
                    index++;
                    if (Variable_Link2())
                    {
                        return true;
                    }
                }
                else if (tokenList[index].classStr == ";")
                {
                    index++;
                    return true;
                }
            }
            return false;
        }

        private bool Param()
        {
            //FIRST(<Param>) = {ID , Null}
            if (tokenList[index].classStr == Singleton.nonKeywords.IDENTIFIER.ToString())
            {
                //<Param>  ID <Param1> | Null
                if (tokenList[index].classStr == Singleton.nonKeywords.IDENTIFIER.ToString())
                {
                    index++;
                    if (Param1())
                    {
                        return true;
                    }
                }
            }

            ////FOLLOW(<Param>) = { ) }
            if (tokenList[index].classStr == ")")
            {
                return true;
            }
            return false;
        }

        private bool Param1()
        {
            //FIRST(<Param1>) = {, , Null}
            if (tokenList[index].classStr == ",")
            {
                //<Param1>  ,  ID <Param1> | Null
                if (tokenList[index].classStr == Singleton.nonKeywords.IDENTIFIER.ToString())
                {
                    index++;
                    if (Param1())
                    {
                        return true;
                    }
                }
            }
            //FOLLOW(<Param1>) = { ) }
            if (tokenList[index].classStr == ")")
            {
                return true;
            }
            return false;
        }

        private bool List_Param()
        {
            //FIRST(<List_Param>) = {DT , Null}
            if (tokenList[index].classStr == Singleton.SingletonEnums._DT.ToString())
            {
                //<List_Param>  DT ID <List_Param1> | Null
                if (tokenList[index].classStr == Singleton.SingletonEnums._DT.ToString())
                {
                    index++;
                    if (tokenList[index].classStr == Singleton.nonKeywords.IDENTIFIER.ToString())
                    {
                        index++;
                        if (List_Param())
                        {
                            return true;
                        }
                    }
                }
            }
            //FOLLOW(<List_Param>) = { ) }
            if (tokenList[index].classStr == ")")
            {
                return true;
            }
            return false;
        }

        private bool Variable_Link2()
        {
            //FIRST(<Variable_Link2>  ) = {=, , , ;}
            if(tokenList[index].classStr == "=" ||
                tokenList[index].classStr == "," ||
                tokenList[index].classStr == ";")
            {
                //<Variable_Link2>   =  <Variable_Value>| <LIST>
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

        private bool M_ST()
        {
            //FIRST(<M_ST>) = { jabtak , DT , Barbar , agar , return ,  inc_dec , ID , break , continue, this , Null}
            if (tokenList[index].classStr == Singleton.SingletonEnums._jabtak.ToString() ||
                tokenList[index].classStr == Singleton.SingletonEnums._DT.ToString() ||
                tokenList[index].classStr == Singleton.SingletonEnums._barbar.ToString() ||
                tokenList[index].classStr == Singleton.SingletonEnums._agar.ToString() ||
                tokenList[index].classStr == Singleton.SingletonEnums._return.ToString() ||
                tokenList[index].classStr == Singleton.SingletonEnums.IncDec.ToString() ||
                tokenList[index].classStr == Singleton.nonKeywords.IDENTIFIER.ToString() ||
                tokenList[index].classStr == Singleton.SingletonEnums._break.ToString() ||
                tokenList[index].classStr == Singleton.SingletonEnums._continue.ToString() ||
                tokenList[index].classStr == Singleton.SingletonEnums._this.ToString())
            {
                //<M_ST>   <S_ST><M_ST> | Null
                if (S_ST())
                {
                    if (M_ST())
                    {
                        return true;
                    }
                }
            }
            ////FOLLOW(<M_ST>) = { } }
            if (tokenList[index].classStr == "}")
            {
                return true;
            }
            return false;
        }

        private bool S_ST()
        {
            //FIRST(S_ST) = {jabtak , DT , Barbar , agar , return ,  inc_dec , ID , break , continue , this}
            if (tokenList[index].classStr == Singleton.SingletonEnums._jabtak.ToString() ||
                tokenList[index].classStr == Singleton.SingletonEnums._DT.ToString() ||
                tokenList[index].classStr == Singleton.SingletonEnums._barbar.ToString() ||
                tokenList[index].classStr == Singleton.SingletonEnums._agar.ToString() ||
                tokenList[index].classStr == Singleton.SingletonEnums._return.ToString() ||
                tokenList[index].classStr == Singleton.SingletonEnums.IncDec.ToString() ||
                tokenList[index].classStr == Singleton.nonKeywords.IDENTIFIER.ToString() ||
                tokenList[index].classStr == Singleton.SingletonEnums._break.ToString() ||
                tokenList[index].classStr == Singleton.SingletonEnums._continue.ToString() ||
                tokenList[index].classStr == Singleton.SingletonEnums._this.ToString())
            {
                //<S_ST>  <Jab_Tak> | DT <S_St_DT> | <Bar_Bar> | <agar_warna> | <Return> | inc_dec  ID|ID 
                if (Jab_Tak())
                {
                    return true;
                }
                else if (tokenList[index].classStr == Singleton.SingletonEnums._DT.ToString())
                {
                    index++;
                    if (S_St_DT())
                    {
                        return true;
                    }
                }
                else if (Bar_Bar())
                {
                    return true;
                }
                else if (agar_warna())
                {
                    return true;
                }
                else if (Return())
                {
                    return true;
                }
                else if (tokenList[index].classStr == Singleton.SingletonEnums.IncDec.ToString())
                {
                    index++;
                    if (tokenList[index].classStr == Singleton.nonKeywords.IDENTIFIER.ToString())
                    {
                        index++;
                        return true;
                    }
                }
                else if (tokenList[index].classStr == Singleton.nonKeywords.IDENTIFIER.ToString())
                {
                    index++;
                    return true;
                }
            }
            return false;
        }

        private bool Return()
        {
            //FIRST(<Return>) = {return}
            if (tokenList[index].classStr == Singleton.SingletonEnums._return.ToString())
            {
                //<Return>  return <Exp> ;
                if (tokenList[index].classStr == Singleton.SingletonEnums._return.ToString())
                {
                    index++;
                    if (Exp())
                    {
                        if (tokenList[index].classStr == ";")
                        {
                            index++;
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        private bool agar_warna()
        {
            //FIRST(<agar_warna>) = {agar}
            if (tokenList[index].classStr == Singleton.SingletonEnums._agar.ToString())
            {
                //<agar_warna>  agar (<Exp>) {<M_ST>} <O_Else>
                if (tokenList[index].classStr == Singleton.SingletonEnums._agar.ToString())
                {
                    index++;
                    if (tokenList[index].classStr == "(")
                    {
                        index++;
                        if (Exp())
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
                                            if (O_Else())
                                            {
                                                return true;
                                            }
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

        private bool O_Else()
        {
            //FIRST(<O_Else>) = {warna , Null}
            if (tokenList[index].classStr == Singleton.SingletonEnums._warna.ToString())
            {
                //<O_Else>  warna {<M_ST>} | Null
                if (tokenList[index].classStr == Singleton.SingletonEnums._warna.ToString())
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
                            }

                        }
                    }
                }
            }
            //FOLLOW(<O_Else>) = { jabtak , DT , Barbar , agar , return ,  inc_dec , ID , break , continue, this , }}
            if (tokenList[index].classStr == Singleton.SingletonEnums._jabtak.ToString() ||
                tokenList[index].classStr == Singleton.SingletonEnums._DT.ToString() ||
                tokenList[index].classStr == Singleton.SingletonEnums._barbar.ToString() ||
                tokenList[index].classStr == Singleton.SingletonEnums._agar.ToString() ||
                tokenList[index].classStr == Singleton.SingletonEnums._return.ToString() ||
                tokenList[index].classStr == Singleton.SingletonEnums.IncDec.ToString() ||
                tokenList[index].classStr == Singleton.nonKeywords.IDENTIFIER.ToString() ||
                tokenList[index].classStr == Singleton.SingletonEnums._break.ToString() ||
                tokenList[index].classStr == Singleton.SingletonEnums._continue.ToString() ||
                tokenList[index].classStr == Singleton.SingletonEnums._this.ToString())
            {
                return true;
            }
            return false;
        }

        private bool S_St_DT()
        {
            //FIRST(<S_St_DT>) = {ID , void , DT , [}
            if (tokenList[index].classStr == Singleton.nonKeywords.IDENTIFIER.ToString() ||
                tokenList[index].classStr == Singleton.SingletonEnums._void.ToString() ||
                tokenList[index].classStr == Singleton.SingletonEnums._DT.ToString() ||
                tokenList[index].classStr == "[")
            {
                //<S_St_DT>  ID <S_St_DT2> | <Method_DEC> | <Array_DEC>
                if (tokenList[index].classStr == Singleton.nonKeywords.IDENTIFIER.ToString())
                {
                    index++;
                    if (S_St_DT2())
                    {
                        return true;
                    }
                }
                else if (Method_DEC())
                {
                    return true;
                }
                else if (Array_DEC())
                {
                    return true;
                }
            }
            return false;
        }

        private bool Array_DEC()
        {
            //FIRST(<Array_DEC>) = {[}
            if (tokenList[index].classStr == "[")
            {
                //<Array_DEC>   [] ID <INIT_Array>
                if (tokenList[index].classStr == "[")
                {
                    index++;
                    if (tokenList[index].classStr == "]")
                    {
                        index++;
                        if (tokenList[index].classStr == Singleton.nonKeywords.IDENTIFIER.ToString())
                        {
                            index++;
                            if (INIT_Array())
                            {
                                return true;
                            }
                        }
                    }
                }
            }
            return false;
        }

        private bool INIT_Array()
        {
            //FIRST(<INIT_Array>) = {; , =}
            if (tokenList[index].classStr == ";" ||
                tokenList[index].classStr == "=")
            {
                //<INIT_Array>  ; | = new DT [<ID_Const>]<Array_const>
                if (tokenList[index].classStr == ";")
                {
                    index++;
                    return true;
                }
                else if (tokenList[index].classStr == "=")
                {
                    index++;
                    if (tokenList[index].classStr == Singleton.SingletonEnums._new.ToString())
                    {
                        index++;
                        if (tokenList[index].classStr == Singleton.SingletonEnums._DT.ToString())
                        {
                            index++;
                            if (tokenList[index].classStr == "[")
                            {
                                index++;
                                if (ID_Const())
                                {
                                    if (tokenList[index].classStr == "]")
                                    {
                                        index++;
                                        if (Array_const())
                                        {
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

        private bool Array_const()
        {
            //FIRST(<Array_const>) = {{ , ;}
            if (tokenList[index].classStr == "{" ||
                tokenList[index].classStr == ";")
            {
                //<Array_const>  <Array_C> | ;
                if (tokenList[index].classStr == ";")
                {
                    index++;
                    return true;
                }
                else if (Array_C())
                {
                    return true;
                }
            }
            return false;
        }

        private bool Array_C()
        {
           // FIRST(<Array_C>) = { { }
            if (tokenList[index].classStr == "{")
            {
                //<Array_C>  { <Const> <Array_C2>
                if (tokenList[index].classStr == "{")
                {
                    index++;
                    if (CONST())
                    {
                        if (Array_C2())
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        private bool Array_C2()
        {
            //FIRST(<Array_C2>) = {, , } }
            if (tokenList[index].classStr == "{" ||
                tokenList[index].classStr == ",")
            {
                //<Array_C2>  , <Const> | } ;
                if (tokenList[index].classStr == "}")
                {
                    index++;
                    if (tokenList[index].classStr == ";")
                    {
                        index++;
                        return true;
                    }
                }
                else if (tokenList[index].classStr == ",")
                {
                    index++;
                    if (CONST())
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private bool ID_Const()
        {
            //FIRST(<ID_Const>) = { ID, INT_CONST , FLOAT_CONST , STRING_CONST , CHAR_CONST , BOOL_CONST }
            if (tokenList[index].classStr == Singleton.nonKeywords.INT_CONSTANT.ToString() ||
                tokenList[index].classStr == Singleton.nonKeywords.IDENTIFIER.ToString() ||
                tokenList[index].classStr == Singleton.nonKeywords.FLOAT_CONSTANT.ToString() ||
                tokenList[index].classStr == Singleton.nonKeywords.STRING_CONSTANT.ToString() ||
                tokenList[index].classStr == Singleton.nonKeywords.CHAR_CONSTANT.ToString() ||
                tokenList[index].classStr == Singleton.nonKeywords.BOOL_CONSTANT.ToString())
            {
                index++;
                return true;
            }
            return false;
        }

        private bool Method_DEC()
        {
            //FIRST(<Method_DEC>) = {DT , void}
            if (tokenList[index].classStr == Singleton.SingletonEnums._DT.ToString() ||
                tokenList[index].classStr == Singleton.SingletonEnums._void.ToString())
            {
                //<Method_DEC>   <Return_Type>  ID <Method_Link 3>
                if (Return_Type())
                {
                    if (tokenList[index].classStr == Singleton.nonKeywords.IDENTIFIER.ToString())
                    {
                        index++;
                        if (Method_Link3())
                        {
                            return true;
                        }
                    }
                }

            }

            return false;
        }

        private bool Return_Type()
        {
            //FIRST(<Return_Type>) = { void, DT }
            if (tokenList[index].classStr == Singleton.SingletonEnums._void.ToString() ||
                tokenList[index].classStr == Singleton.SingletonEnums._DT.ToString())
            {
                //<Return_Type>  void | DT
                index++;
                return true;
            }
            return false;
        }

        private bool S_St_DT2()
        {
            //FIRST(<S_St_DT2>) = { = }
            if (tokenList[index].classStr == "=")
            {
                //<S_St_DT2>  <Variable_Link2> 
                if (Variable_Link2())
                {
                    return true;
                }
            }
            return false;
        }


        private bool Bar_Bar()
        {
            //FIRST(<Bar_Bar>) = {barbar}
            if (tokenList[index].classStr == Singleton.SingletonEnums._barbar.ToString())
            {
                //<Bar_Bar>  barbar(<F1>; <F2>; <F3>) <Body>
                if (tokenList[index].classStr == Singleton.SingletonEnums._barbar.ToString())
                {
                    index++;
                    if (tokenList[index].classStr == "(")
                    {
                        index++;
                        if (F1())
                        {
                            if (tokenList[index].classStr == ";")
                            {
                                index++;
                                if (F2())
                                {
                                    if (tokenList[index].classStr == ";")
                                    {
                                        index++;
                                        if (F3())
                                        {
                                            if (tokenList[index].classStr == ")")
                                            {
                                                index++;
                                                if (Body())
                                                {
                                                    return true;
                                                }
                                            }
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

        private bool Jab_Tak()
        {
            //FIRST(<Jab_tak>) = {jabtak}
            if (tokenList[index].classStr == Singleton.SingletonEnums._jabtak.ToString())
            {
                //<Jab_tak>  jabtak (<Exp>) <Body>
                if (tokenList[index].classStr == Singleton.SingletonEnums._jabtak.ToString())
                {
                    index++;
                    if (tokenList[index].classStr == "(")
                    {
                        index++;
                        if (Exp())
                        {
                            if (tokenList[index].classStr == ")")
                            {
                                if (Body())
                                {
                                    return true;
                                }
                            }
                        }
                    }
                }
            }
            return false;
        }

        private bool F1()
        {
            //FIRST(<F1>) = {DT , ID , Null}
            if (tokenList[index].classStr == Singleton.nonKeywords.IDENTIFIER.ToString() ||
                tokenList[index].classStr == Singleton.SingletonEnums._DT.ToString())
            {
                //<F1>  <DEC> |ID <Assign_Op> | Null
                if (DEC())
                {
                    return true;
                }
                else if (tokenList[index].classStr == Singleton.nonKeywords.IDENTIFIER.ToString())
                {
                    index++;
                    if (Assign_Op())
                    {
                        return true;
                    }
                }
            }
            //FOLLOW(<F1>) = { ; }
            if (tokenList[index].classStr == ";")
            {
                return true;
            }
            return false;
        }

        private bool F2()
        {
            //FIRST(<F2>) = { ID, INT_CONST , FLOAT_CONST , STRING_CONST , CHAR_CONST , BOOL_CONST , Null }
            if (tokenList[index].classStr == Singleton.nonKeywords.INT_CONSTANT.ToString() ||
                tokenList[index].classStr == Singleton.nonKeywords.IDENTIFIER.ToString() ||
                tokenList[index].classStr == Singleton.nonKeywords.FLOAT_CONSTANT.ToString() ||
                tokenList[index].classStr == Singleton.nonKeywords.STRING_CONSTANT.ToString() ||
                tokenList[index].classStr == Singleton.nonKeywords.CHAR_CONSTANT.ToString() ||
                tokenList[index].classStr == Singleton.nonKeywords.BOOL_CONSTANT.ToString())
            {
                //<F2>  <Exp> <X> | Null
                if (Exp())
                {
                    if (X())
                    {
                        return true;
                    }
                }
            }
                ////FOLLOW(<F2>) = { ; }
            
            if (tokenList[index].classStr == ";")
            {
                return true;
            }
            return false;
        }

        private bool F3()
        {
            //FIRST(<F3>) = {inc_dec , ID , Null}
            if (tokenList[index].classStr == Singleton.SingletonEnums.IncDec.ToString() ||
                tokenList[index].classStr == Singleton.nonKeywords.IDENTIFIER.ToString())
            {
                //<F3>  inc_dec ID | ID <F4>| Null
                if (tokenList[index].classStr == Singleton.SingletonEnums.IncDec.ToString())
                {
                    index++;
                    if (tokenList[index].classStr == Singleton.nonKeywords.IDENTIFIER.ToString())
                    {
                        index++;
                        return true;
                    }
                }
                else if (tokenList[index].classStr == Singleton.nonKeywords.IDENTIFIER.ToString())
                {
                    index++;
                    if (F4())
                    {
                        return true;
                    }
                }
            }
            ////FOLLOW(<F3>) = { ) }
            
            if (tokenList[index].classStr == ")")
            {
                return true;
            }
            return false;
        }

        private bool F4()
        {
            //FIRST(<F4>) = {inc_dec , AOP}
            if (tokenList[index].classStr == Singleton.SingletonEnums.IncDec.ToString() ||
                tokenList[index].classStr == Singleton.SingletonEnums.AssignmentOp.ToString()) 
            {
                //<F4>  inc_dec | AOP <Exp>
                if (tokenList[index].classStr == Singleton.SingletonEnums.IncDec.ToString())
                {
                    index++;
                }
                else if (tokenList[index].classStr == Singleton.SingletonEnums.AssignmentOp.ToString())
                {
                    index++;
                    if (Exp())
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private bool X()
        {
            //FIRST(<X>) = { , , Null}
            if (tokenList[index].classStr == ",")
            {
                //<X>  , <Exp> <X> | Null
                if (Exp())
                {
                    if (X())
                    {
                        return true;
                    }
                }
            }

            ////FOLLOW(<X>) = { ; }
            
            if (tokenList[index].classStr == ";")
            {
                return true;
            }
            return false;
        }

        private bool Body()
        {
            //FIRST(<Body>) = {; , { , jabtak , DT , Barbar , agar , return ,  inc_dec , ID , break , continue , this }
            if (tokenList[index].classStr == Singleton.SingletonEnums._jabtak.ToString() ||
                tokenList[index].classStr == Singleton.SingletonEnums._DT.ToString() ||
                tokenList[index].classStr == Singleton.SingletonEnums._barbar.ToString() ||
                tokenList[index].classStr == Singleton.SingletonEnums._agar.ToString() ||
                tokenList[index].classStr == Singleton.SingletonEnums._return.ToString() ||
                tokenList[index].classStr == Singleton.SingletonEnums.IncDec.ToString() ||
                tokenList[index].classStr == Singleton.nonKeywords.IDENTIFIER.ToString() ||
                tokenList[index].classStr == Singleton.SingletonEnums._break.ToString() ||
                tokenList[index].classStr == Singleton.SingletonEnums._continue.ToString() ||
                tokenList[index].classStr == Singleton.SingletonEnums._this.ToString() ||
                tokenList[index].classStr == "," ||
                tokenList[index].classStr == ";" ||
                tokenList[index].classStr == "{")
            {
                //<Body>  ; | <S_ST> | {<M_ST>}
                if (tokenList[index].classStr == ";")
                {
                    index++;
                }

                else if (S_ST())
                {
                    return true;
                }
                else if (tokenList[index].classStr == "{")
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

            return false;
        }

        private bool DEC()
        {
            //FIRST(<DEC>) = { DT}
            if (tokenList[index].classStr == Singleton.SingletonEnums._DT.ToString())
            {
                //<DEC>  DT <Variable_Link>
                if (tokenList[index].classStr == Singleton.SingletonEnums._DT.ToString())
                {
                    index++;
                    if (Variable_Link())
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private bool Variable_Link()
        {
            //FIRST(<Variable_Link>) = {ID} 
            if (tokenList[index].classStr == Singleton.nonKeywords.IDENTIFIER.ToString())
            {
                //<Variable_Link>  ID <Varaiable_Link2>
                if (tokenList[index].classStr == Singleton.nonKeywords.IDENTIFIER.ToString())
                {
                    index++;
                    if (Variable_Link2())
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private bool Assign_Op()
        {
            //FIRST(<Assign_Op>) = { = }
            if (tokenList[index].classStr == "=")
            {
                //<Assign_Op>   = <Assign_Op2>      	
                if (tokenList[index].classStr == "=")
                {
                    index++;
                    if (Assign_Op2())
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private bool Assign_Op2()
        {
            //FIRST(<Assign_Op2>) = { ID, INT_CONST , FLOAT_CONST , STRING_CONST , CHAR_CONST , BOOL_CONST }
            if (tokenList[index].classStr == Singleton.nonKeywords.INT_CONSTANT.ToString() ||
                tokenList[index].classStr == Singleton.nonKeywords.IDENTIFIER.ToString() ||
                tokenList[index].classStr == Singleton.nonKeywords.FLOAT_CONSTANT.ToString() ||
                tokenList[index].classStr == Singleton.nonKeywords.STRING_CONSTANT.ToString() ||
                tokenList[index].classStr == Singleton.nonKeywords.CHAR_CONSTANT.ToString() ||
                tokenList[index].classStr == Singleton.nonKeywords.BOOL_CONSTANT.ToString())
            {
                //<Assign_Op2>  <Exp>;
                if (Exp())
                {
                    if (tokenList[index].classStr == ";")
                    {
                        index++;
                        return true;
                    }
                }
            }
            return false;
        }

        private bool DT_1()
        {
            //FIRST(<DT_1>) = {ID , [}
            if(tokenList[index].classStr == Singleton.nonKeywords.IDENTIFIER.ToString() ||
                tokenList[index].classStr == "[")
            {
                //<DT_1>  ID <ID_2>| <Array_DEC>
                if (tokenList[index].classStr == Singleton.nonKeywords.IDENTIFIER.ToString())
                {
                    index++;
                    if (ID_2())
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

        private bool ID_2()
        {
            //FIRST(<ID_2>) = {( , =}
            if (tokenList[index].classStr == "(" ||
                tokenList[index].classStr == "=")
            {
                //<ID_2>  <Method_Link3> | <Variable_Link2>
                if (Method_Link3())
                {
                    return true;
                }
                else if (Variable_Link2())
                {
                    return true;
                }
            }
            return false;
        }

        private bool Id_OArray()
        {
            //FIRST(<Id_OArray>) = {ID , [}
            if (tokenList[index].classStr == Singleton.nonKeywords.IDENTIFIER.ToString() ||
                tokenList[index].classStr == "[") 
            {
                //<Id_OArray>  ID <Id_A> | <Array_DEC>
                if (tokenList[index].classStr == Singleton.nonKeywords.IDENTIFIER.ToString())
                {
                    index++;
                    if (Id_A())
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

        private bool Id_A()
        {
            //FIRST(<Id_A>) = {= , (}
            if (tokenList[index].classStr == "=" ||
                tokenList[index].classStr == "(")
            {
                //<Id_A>  <Method_Link3> | <Object_Creation_Exp>
                if (Method_Link3())
                {
                    return true;
                }
                else if (Object_Creation_Exp())
                {
                    return true;
                }
            }
           
            return false;
        }

        private bool Object_Creation_Exp()
        {
            //FIRST(<Object_Creation_Exp>) = {= , , , ;}
            if (tokenList[index].classStr == "=" ||
                tokenList[index].classStr == "," ||
                tokenList[index].classStr == ";")
            {
                //<Object_Creation_Exp>  = new ID  (<List_Const>) <Object_List>  |<Object_List>
                if (tokenList[index].classStr == "=")
                {
                    index++;
                    if (tokenList[index].classStr == Singleton.SingletonEnums._new.ToString())
                    {
                        index++;
                        if (tokenList[index].classStr == Singleton.nonKeywords.IDENTIFIER.ToString())
                        {
                            index++;
                            if (tokenList[index].classStr == "(")
                            {
                                index++;
                                if (CONST())
                                {
                                    if (tokenList[index].classStr == ")")
                                    {
                                        index++;
                                        if (Object_List())
                                        {
                                            return true;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                else if (Object_List())
                {
                    return true;
                }
            }
            return false;
        }

        private bool Object_List()
        {
            //FIRST(<Object_List>) = {,, ;}
            if (tokenList[index].classStr == "," || tokenList[index].classStr == ";")
            {
                //<Object_List>  , ID<Object_Creation_Exp>|;
                if (tokenList[index].classStr == ",")
                {
                    index++;
                    if (tokenList[index].classStr == Singleton.nonKeywords.IDENTIFIER.ToString())
                    {
                        index++;
                        if (Object_Creation_Exp())
                        {
                            return true;
                        }
                    }
                }
                else if (tokenList[index].classStr == ";")
                {
                    index++;
                    return true;
                }
            }
            return false;
        }

        private bool Object_Call()
        {
            //FIRST(<Object_Call>) = {. , (}
            if (tokenList[index].classStr == "." ||
                tokenList[index].classStr == "(")
            {
                //<Object_Call>  . ID <Object_Call>| <Method_Call_1> 
                if (tokenList[index].classStr == ".")
                {
                    index++;
                    if (tokenList[index].classStr == Singleton.nonKeywords.IDENTIFIER.ToString())
                    {
                        index++;
                        if (Object_Call())
                        {
                            return true;
                        }
                    }
                }
                else if (Method_Call_1())
                {
                    return true;
                }
            }
            return false;
        }

        private bool Method_Call_1()
        {
            //FIRST(<Method_Call_1>) = { ( }
            if (tokenList[index].classStr == "(")
            {
                //<Method_Call_1>  (<Param>) ;
                if (tokenList[index].classStr == "(")
                {
                    index++;
                    if (Param())
                    {
                        if (tokenList[index].classStr == ")")
                        {
                            index++;
                            if (tokenList[index].classStr == ";")
                            {
                                index++;
                                return true;
                            }
                        }
                    }
                }
            }
            return false;
        }
    }
}
