﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace LexicalAnaylzerRexton
{
    class CFG
    {
        private int index = 0;
        private List<token> tokenList;

        public TreeNode currentNode;

        private string errors = "";

        //SEMACTIC DECLARATIONS
        SemanticAnalyzer semanticAnalyzer = new SemanticAnalyzer();
        private string Search_GetType(string  N, string e)
        {
            string T = "";
            if (semanticAnalyzer.Search(N))
            {
                T = semanticAnalyzer.getType(N);
                if (T == "invalid")
                {
                    //addError(e);
                    return "invalid";
                }
                return T;
            }
            else
            {
                //addError(e);
                return "invalid";
            }
        }

        private void addError(string  message)
        {
            semanticAnalyzer.errors.Add(message + " (" + tokenList[index] + " " + semanticAnalyzer.getCurrentClass() + ")");
            //new semanticError(Tokens[tokenIndex], message)
        }

        public string getSemanticErrors()
        {
            string error = "";
            foreach(string e in semanticAnalyzer.errors){
                error += e + "\n";
            }
            return error;
        }

        public string getErrors()
        {
            return errors;
        }

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

            errors += tokenList[index].lineNumber + " " + tokenList[index].wordStr + " " + tokenList[index].classStr + "\t";
            return false;
        }

        private bool CONST(ref string T)
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
                    if (tokenList[index].classStr == Singleton.nonKeywords.INT_CONSTANT.ToString())
                    {
                        T = "aur_int";
                        //currentNode = currentNode.Parent;
                    }
                    else if (tokenList[index].classStr == Singleton.nonKeywords.FLOAT_CONSTANT.ToString())
                    {
                        T = "aur_float";
                        //currentNode = currentNode.Parent;
                    }
                    else if (tokenList[index].classStr == Singleton.nonKeywords.STRING_CONSTANT.ToString())
                    {
                        T = "aur_string";
                        //currentNode = currentNode.Parent;
                    }
                    else if (tokenList[index].classStr == Singleton.nonKeywords.CHAR_CONSTANT.ToString())
                    {
                        T = "aur_char";
                        //currentNode = currentNode.Parent;
                    }
                    else if (tokenList[index].classStr == Singleton.nonKeywords.BOOL_CONSTANT.ToString())
                    {
                        T = "aur_bool";
                        //currentNode = currentNode.Parent;
                    }

                    index++;
                    return true;
                }
            }
            return false;
        }

        private bool Static(ref string TM)
        {
            //FIRST(<Static>) = {Static}
            if (tokenList[index].classStr == Singleton.SingletonEnums._static.ToString())
            {
                //<Static>   Static
                TM = tokenList[index].classStr;
                index++;
                return true;
            }
            return false;
        }

        private bool ID_CONST()
        {
            currentNode = currentNode.Nodes.Add("<" + System.Reflection.MethodBase.GetCurrentMethod().Name + ">", "< " + System.Reflection.MethodBase.GetCurrentMethod().Name + " >");

            string T = "";

            if (tokenList[index].classStr == Singleton.nonKeywords.IDENTIFIER.ToString() ||
                tokenList[index].classStr == Singleton.nonKeywords.INT_CONSTANT.ToString() ||
                tokenList[index].classStr == Singleton.nonKeywords.FLOAT_CONSTANT.ToString() ||
                tokenList[index].classStr == Singleton.nonKeywords.STRING_CONSTANT.ToString() ||
                tokenList[index].classStr == Singleton.nonKeywords.CHAR_CONSTANT.ToString() ||
                tokenList[index].classStr == Singleton.nonKeywords.BOOL_CONSTANT.ToString())
            {
                //<ID_CONST> ID|<CONST>
                if (tokenList[index].classStr == Singleton.nonKeywords.IDENTIFIER.ToString())
                {   
                    index++;
                    //T = tokenList[index - 1].wordStr;
                    return true;
                }
                else if (CONST(ref T))
                {
                    return true;
                }
            }
            return false;
        }

        private bool Access_Modifier(ref string AM)
        {
            //FIRST(<Access_Modifier>) = { access_modifier, Null}
            if (tokenList[index].classStr == Singleton.SingletonEnums._Access_Modifier.ToString())
            {
                //<Access_Modifier>  access_modifier | Null
                if (tokenList[index].classStr == Singleton.SingletonEnums._Access_Modifier.ToString())
                {
                    AM = tokenList[index].classStr;
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
                AM = Singleton.defaultAccessModifier;
                return true;
            }

            return false;
        }

        private bool Return_Type(ref string RT)
        {
            //FIRST(<Return_Type>) = { void, DT }
            if (tokenList[index].classStr == Singleton.SingletonEnums._void.ToString() ||
                tokenList[index].classStr == Singleton.SingletonEnums._DT.ToString())
            {
                //<Return_Type>  void | DT
                RT = tokenList[index].wordStr;
                index++;
                return true;
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
                String RT = "";
                if (S_ST(ref RT))
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
                String RT = "";
                //<Body>  ; | <S_ST> | {<M_ST>}
                if (tokenList[index].classStr == ";")
                {
                    index++;
                }

                else if (S_ST(ref RT))
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

        private bool List_Param(ref string AL, string PL)
        {
            //FIRST(<List_Param>) = {DT , Null}
            if (tokenList[index].classStr == Singleton.SingletonEnums._DT.ToString())
            {
                //<List_Param>  DT ID <List_Param1> | Null
                if (tokenList[index].classStr == Singleton.SingletonEnums._DT.ToString())
                {
                    String T = tokenList[index].wordStr;
                    PL += T;
                    index++;
                    if (tokenList[index].classStr == Singleton.nonKeywords.IDENTIFIER.ToString())
                    {
                        String N = tokenList[index].wordStr;
                        index++;
                        if (List_Param1(ref AL, PL))
                        {
                            return true;
                        }
                    }
                }
            }
            //FOLLOW(<List_Param>) = { ) }
            if (tokenList[index].classStr == ")")
            {
                AL = PL;
                return true;
            }
            return false;
        }

        private bool List_Param1(ref string AL, string PL)
        {
            //FIRST(<List_Param>) = {DT , Null}
            if (tokenList[index].classStr == ",")
            {
                //<List_Param> , DT ID <List_Param1> | Null
                if (tokenList[index].classStr == ",")
                {
                    index++;
                    if (tokenList[index].classStr == Singleton.SingletonEnums._DT.ToString())
                    {
                        String T = tokenList[index].wordStr;
                        PL += "," + T;
                        index++;
                        if (tokenList[index].classStr == Singleton.nonKeywords.IDENTIFIER.ToString())
                        {
                            String N = tokenList[index].wordStr;
                            index++;
                            if (List_Param1(ref AL, PL))
                            {
                                return true;
                            }
                        }
                    }
                }
            }
            //FOLLOW(<List_Param>) = { ) }
            if (tokenList[index].classStr == ")")
            {
                AL = PL;
                return true;
            }
            return false;
        }

        private bool Param(ref string AL, string PL)
        {
            string T = "";
            //FIRST(<Param>) = {ID , Null}
            if (tokenList[index].classStr == Singleton.nonKeywords.IDENTIFIER.ToString() ||
                tokenList[index].classStr == Singleton.nonKeywords.INT_CONSTANT.ToString() ||
                tokenList[index].classStr == Singleton.nonKeywords.FLOAT_CONSTANT.ToString() ||
                tokenList[index].classStr == Singleton.nonKeywords.STRING_CONSTANT.ToString() ||
                tokenList[index].classStr == Singleton.nonKeywords.CHAR_CONSTANT.ToString() ||
                tokenList[index].classStr == Singleton.nonKeywords.BOOL_CONSTANT.ToString())
            {
                //<Param>  ID <Param1> | Null
                //<Param> <Exp> <Param1> | Null
                
                if (Exp(ref T))
                {
                    PL += T;
                    if (Param1(ref AL, PL))
                    {
                        return true;
                    }
                }
            }

            ////FOLLOW(<Param>) = { ) }
            if (tokenList[index].classStr == ")")
            {
                AL = PL;
                return true;
            }
            return false;
        }

        private bool Param1(ref string AL, string PL)
        {
            string T = "";
            //FIRST(<Param1>) = {, , Null}
            if (tokenList[index].classStr == ",")
            {
                //<Param1>  ,  ID <Param1> | Null
                index++;
                if (Exp(ref T))
                {
                    PL += "," + T;
                    if (Param1(ref AL, PL))
                    {
                        return true;
                    }
                }
            }
            //FOLLOW(<Param1>) = { ) }
            if (tokenList[index].classStr == ")")
            {
                AL = PL;
                return true;
            }
            return false;
        }

        /*LEFT*/
        private bool Method_Call_1(ref string RT, string N)
        {
            //FIRST(<Method_Call_1>) = { ( }
            if (tokenList[index].classStr == "(")
            {
                //<Method_Call_1>  (<Param>) 
                if (tokenList[index].classStr == "(")
                {
                    string AL = "";
                    string PL = "";
                    index++;
                    if (Param(ref AL, PL))
                    {
                        if (tokenList[index].classStr == ")")
                        {
                            RT = Search_GetType(N, "Undeclared Method");
                            index++;
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        private bool S_ST(ref string RT)
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
                //<S_ST><Jab_Tak> | DT <S_St_DT> | <Bar_Bar> | <agar_warna> | <Return> | inc_dec  ID<inc_dec_list>;|ID <S_St_ID>| <break> | <continue> |<this>
                if (Jab_Tak())
                {
                    return true;
                }
                else if (tokenList[index].classStr == Singleton.SingletonEnums._DT.ToString())
                {
                    string T = tokenList[index].wordStr;
                    index++;
                    if (S_St_DT(T))
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
                else if (Return(ref RT))
                {
                    return true;
                }
                else if (tokenList[index].classStr == Singleton.SingletonEnums.IncDec.ToString())
                {
                    index++;
                    if (tokenList[index].classStr == Singleton.nonKeywords.IDENTIFIER.ToString())
                    {
                        string N = tokenList[index].wordStr;
                        string T = Search_GetType(N, "Undeclared Variable");
                        index++;
                        if (inc_dec_list(ref RT, N, T))
                        {
                            if (tokenList[index].classStr == ";")
                            {
                                return true;
                            }
                        }
                    }
                }
                else if (tokenList[index].classStr == Singleton.nonKeywords.IDENTIFIER.ToString())
                {
                    string N = tokenList[index].wordStr;
                    string T = Search_GetType(N, " ");
                    index++;
                    if (S_St_ID(N, T))
                    {
                        return true;
                    }
                }
                else if (BREAK())
                {
                    return true;
                }
                else if (CONTINUE())
                {
                    return true;
                }
                /*else if (THIS())
                {
                    return true;
                }*/
            }
            return false;
        }

        private bool S_St_ID(string  N, string T)
        {
            string RT = "";
            //FIRST(<S_St_ID>) = {inc_dec , = , ID ,  .  , (  }
            ////FIRST(<S_St_ID>) = {inc_dec , AOP , ID , [ ,  .  , (  }
            if (tokenList[index].classStr == Singleton.SingletonEnums.IncDec.ToString() ||
                tokenList[index].classStr == Singleton.SingletonEnums.AssignmentOp.ToString() ||
                tokenList[index].classStr == Singleton.nonKeywords.IDENTIFIER.ToString() ||
                tokenList[index].classStr == "." ||
                tokenList[index].classStr == "(" ||
                tokenList[index].classStr == "[" )
            {
                //<S_St_ID>  inc_dec | <Assign_Op> | <Object_link> | <Object_Call> | <Method_Call_1>7
                //inc_dec; | <Assign_Op>| <Object_link> | <Object_Call>; | <Method_Call_1>; | [<Exp>] <Assign_Op>	
                if (tokenList[index].classStr == Singleton.SingletonEnums.IncDec.ToString())
                {
                    //String N = tokenList[index].wordStr;
                    //String T = "";
                    T = Search_GetType(N, "Undeclared Variable");
                    index++;
                    if (tokenList[index].classStr == ";")
                    {
                        index++;
                        return true;
                    }
                }
                else if (Assign_Op(T))
                {
                    T = Search_GetType(N, "Undeclared Variable");
                    return true;
                }
                else if (Object_link(Singleton.defaultAccessModifier, N))
                {
                    T = Search_GetType(N, "Undeclared Class");
                    return true;
                }
                else if (Object_Call())
                {
                    T = Search_GetType(N, "Undeclared Object");
                    
                    if (tokenList[index].classStr == ";")
                    {
                        index++;
                        return true;
                    }
                }
                else if (Method_Call_1(ref RT, N))
                {
                    if (tokenList[index].classStr == ";")
                    {
                        index++;
                        return true;
                    }
                }
                else if (tokenList[index].classStr == "[")
                {
                    T = Search_GetType(N, "Undeclared Array");
                    
                    index++;
                    if (Exp(ref RT))
                    {
                        if (tokenList[index].classStr == "]")
                        {
                            index++;
                            if (Assign_Op(T))
                            {
                                return true;
                            }
                        }
                    }
                }
            }
            return false;
        }

        private bool S_St_DT(string  T)
        {
            string N = "";
            //FIRST(<S_St_DT>) = {ID , void , DT , [}
            if (tokenList[index].classStr == Singleton.nonKeywords.IDENTIFIER.ToString() ||
                tokenList[index].classStr == Singleton.SingletonEnums._void.ToString() ||
                tokenList[index].classStr == Singleton.SingletonEnums._DT.ToString() ||
                tokenList[index].classStr == "[")
            {
                //<S_St_DT>  ID <S_St_DT2> | <Method_DEC> | <Array_DEC>
                if (tokenList[index].classStr == Singleton.nonKeywords.IDENTIFIER.ToString())
                {
                    N = tokenList[index].wordStr;
                    semanticAnalyzer.insertVariables(N, T, semanticAnalyzer.currentScope());
                    index++;
                    if (S_St_DT2(T))
                    {
                        return true;
                    }
                }
                /*else if (Method_DEC())
                {
                    return true;
                }*/
                /*else if (Array_DEC(T))
                {
                    return true;
                }*/
            }
            return false;
        }

        private bool S_St_DT2(string  T)
        {
            //FIRST(<S_St_DT2>) = { = }
            ////FIRST(<S_St_DT2>) = { AOP , , , ; }
            if (tokenList[index].classStr == Singleton.SingletonEnums.AssignmentOp.ToString() ||
                tokenList[index].classStr == "," ||
                tokenList[index].classStr == ";")
            {
                //<S_St_DT2>  <Variable_Link2> 
                //<S_St_DT2><Variable_Link2>
                if (Variable_Link2(T))
                {
                    return true;
                }
            }
            return false;
        }

        private bool DEC()
        {
            string T = "";
            //FIRST(<DEC>) = { DT}
            if (tokenList[index].classStr == Singleton.SingletonEnums._DT.ToString())
            {
                //<DEC>  DT <Variable_Link>
                if (tokenList[index].classStr == Singleton.SingletonEnums._DT.ToString())
                {
                    T = tokenList[index].wordStr;
                    index++;
                    if (Variable_Link(T))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private bool Variable_Link(string  T)
        {
            string N = "";
            //FIRST(<Variable_Link>) = {ID} 
            if (tokenList[index].classStr == Singleton.nonKeywords.IDENTIFIER.ToString())
            {
                //<Variable_Link>  ID <Varaiable_Link2>
                if (tokenList[index].classStr == Singleton.nonKeywords.IDENTIFIER.ToString())
                {
                    N = tokenList[index].wordStr;
                    semanticAnalyzer.insertVariables(N, T, semanticAnalyzer.currentScope());
                    index++;
                    if (Variable_Link2(T))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private bool Variable_Link2(string  T)
        {
            string OP = "";
            //FIRST(<Variable_Link2>  ) = {=, , , ;}
            if (tokenList[index].classStr == "," ||
                tokenList[index].classStr == ";" ||
                tokenList[index].wordStr == Singleton.SingletonEnums.AssignmentOp.ToString())
            {
                //<Variable_Link2>   =  <Variable_Value>| <LIST>
                if (tokenList[index].wordStr == Singleton.SingletonEnums.AssignmentOp.ToString())
                {
                    OP = tokenList[index].wordStr;
                    index++;
                    if (Variable_Value(T, OP))
                    {
                        return true;
                    }
                }
                else if (LIST(T))
                {
                    return true;
                }
            }
            return false;
        }

        private bool Variable_Value(string  T, string OP)
        {
            string ET = "";
            //FIRST(<Variable_Value>) = { ID, INT_CONST , FLOAT_CONST , STRING_CONST , CHAR_CONST , BOOL_CONST }
            if (tokenList[index].classStr == Singleton.nonKeywords.IDENTIFIER.ToString() ||
                tokenList[index].classStr == Singleton.nonKeywords.INT_CONSTANT.ToString() ||
                tokenList[index].classStr == Singleton.nonKeywords.FLOAT_CONSTANT.ToString() ||
                tokenList[index].classStr == Singleton.nonKeywords.STRING_CONSTANT.ToString() ||
                tokenList[index].classStr == Singleton.nonKeywords.CHAR_CONSTANT.ToString() ||
                tokenList[index].classStr == Singleton.nonKeywords.BOOL_CONSTANT.ToString())
            {
                //<Variable_Value>   <Exp><LIST>  	
                if (Exp(ref ET))
                {
                    if (semanticAnalyzer.CC(ET, T, OP) == "invalid")
                    {
                        addError("Type Mismatch" + ET + " " + OP + " " + T);
                    }
                    if (LIST(T))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private bool LIST(string  T)
        {
            string N = "";
            //FIRST(<LIST >) = {, , ;}
            if (tokenList[index].classStr == "," ||
                tokenList[index].classStr == ";")
            {
                //<LIST >  , ID <Variable_Link2> | ;
                if (tokenList[index].classStr == ",") {
                    N = tokenList[index].wordStr;
                    semanticAnalyzer.insertVariables(N, T, semanticAnalyzer.currentScope());
                    index++;
                    if (tokenList[index].classStr == Singleton.nonKeywords.IDENTIFIER.ToString())
                    {
                        index++;
                        if (Variable_Link2(T))
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

        private bool Assign_Op(string  T)
        {
            string OP = "";
            //FIRST(<Assign_Op>) = { = }
            if (tokenList[index].classStr == Singleton.SingletonEnums.AssignmentOp.ToString())
            {
                //<Assign_Op>   = <Assign_Op2>      
                //<Assign_Op> AOP <Assign_Op2>	
                if (tokenList[index].classStr == Singleton.SingletonEnums.AssignmentOp.ToString())
                {
                    OP = tokenList[index].wordStr;

                    index++;
                    if (Assign_Op2(T, OP))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private bool Assign_Op2(string  T, string OP)
        {
            string ET = "";
            //FIRST(<Assign_Op2>) = { ID, INT_CONST , FLOAT_CONST , STRING_CONST , CHAR_CONST , BOOL_CONST }
            if (tokenList[index].classStr == Singleton.nonKeywords.INT_CONSTANT.ToString() ||
                tokenList[index].classStr == Singleton.nonKeywords.IDENTIFIER.ToString() ||
                tokenList[index].classStr == Singleton.nonKeywords.FLOAT_CONSTANT.ToString() ||
                tokenList[index].classStr == Singleton.nonKeywords.STRING_CONSTANT.ToString() ||
                tokenList[index].classStr == Singleton.nonKeywords.CHAR_CONSTANT.ToString() ||
                tokenList[index].classStr == Singleton.nonKeywords.BOOL_CONSTANT.ToString())
            {
                //<Assign_Op2>  <Exp>;
                if (Exp(ref ET))
                {
                    if (semanticAnalyzer.CC(ET, T, OP) == "invalid")
                    {
                        addError("Type Mismatch" + ET + " " + OP + " " + T);
                    }
                    if (tokenList[index].classStr == ";")
                    {
                        index++;
                        return true;
                    }
                }
            }
            return false;
        }

        private bool agar_warna()
        {
            string ET = "";
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
                        if (Exp(ref ET))
                        {
                            if (ET != "aur_bool")
                            {
                                addError(ET + " Type Error");
                            }
                            if (tokenList[index].classStr == ")")
                            {
                                index++;
                                if (tokenList[index].classStr == "{")
                                {
                                    semanticAnalyzer.createScope();
                                    index++;
                                    if (M_ST())
                                    {
                                        if (tokenList[index].classStr == "}")
                                        {
                                            index++;
                                            semanticAnalyzer.deleteScope();
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
                        semanticAnalyzer.createScope();
                        if (M_ST())
                        {
                            if (tokenList[index].classStr == "}")
                            {
                                index++;
                                semanticAnalyzer.deleteScope();
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

        private bool Jab_Tak()
        {
            string ET = "";
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
                        if (Exp(ref ET))
                        {
                            if (ET != "aur_bool")
                            {
                                addError(ET + " Type Error");
                            }
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
            return false;
        }

        private bool Return(ref string RT)
        {
            //FIRST(<Return>) = {return}
            if (tokenList[index].classStr == Singleton.SingletonEnums._return.ToString())
            {
                //<Return>  return <Exp> ;
                //<Return> return <Return2> 
                if (tokenList[index].classStr == Singleton.SingletonEnums._return.ToString())
                {
                    index++;
                    if (return2(ref RT))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private bool return2(ref string RT)
        {
            //string T = "";
            //FIRST(<Return2>) = { ; , ID, INT_CONST , FLOAT_CONST , STRING_CONST , CHAR_CONST , BOOL_CONST , ! , ( , inc_dec }
            if (tokenList[index].classStr == ";" ||
                tokenList[index].classStr == Singleton.nonKeywords.INT_CONSTANT.ToString() ||
                tokenList[index].classStr == Singleton.nonKeywords.IDENTIFIER.ToString() ||
                tokenList[index].classStr == Singleton.nonKeywords.FLOAT_CONSTANT.ToString() ||
                tokenList[index].classStr == Singleton.nonKeywords.STRING_CONSTANT.ToString() ||
                tokenList[index].classStr == Singleton.nonKeywords.CHAR_CONSTANT.ToString() ||
                tokenList[index].classStr == Singleton.nonKeywords.BOOL_CONSTANT.ToString() ||
                tokenList[index].classStr == "!" ||
                tokenList[index].classStr == "(" ||
                tokenList[index].classStr == Singleton.SingletonEnums.IncDec.ToString())
            {
                //<Return2>  ; | <Exp>;
                if (tokenList[index].classStr == ";")
                {
                    RT = "NULL";
                    index++;
                    return true;
                }
                else if(Exp(ref RT))
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

        private bool BREAK()
        {
            //FIRST(<Break>) = {break}
            if (tokenList[index].classStr == Singleton.SingletonEnums._break.ToString())
            {
                //<Break>  break ;
                if (tokenList[index].classStr == Singleton.SingletonEnums._break.ToString())
                {
                    index++;
                    if (tokenList[index].classStr == ";")
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private bool CONTINUE()
        {
            //FIRST(<Break>) = {break}
            if (tokenList[index].classStr == Singleton.SingletonEnums._continue.ToString())
            {
                //<Break>  break ;
                if (tokenList[index].classStr == Singleton.SingletonEnums._continue.ToString())
                {
                    index++;
                    if (tokenList[index].classStr == ";")
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private bool S()
        {
            string AM = "";
            //FIRST(<Class_Dec>) = { access_modifier, class}
            if (tokenList[index].classStr == Singleton.SingletonEnums._Access_Modifier.ToString() ||
                tokenList[index].classStr == Singleton.SingletonEnums._class.ToString())
            {

                //<Class_Dec>   <Access_Modifier><Class_Link>
                if (Access_Modifier(ref AM))
                {
                    if (Class_Link(AM))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        

        private bool Class_Link(string  AM)
        {
            
            //FIRST(<Class_Link>) = {class}
            if (tokenList[index].classStr == Singleton.SingletonEnums._class.ToString())
            {
                //<Class_Link>  class ID <Class_Base> {<Class_Body>}
                index++;
                if (tokenList[index].classStr == Singleton.nonKeywords.IDENTIFIER.ToString())
                {
                    string PN = "";
                    string N = tokenList[index].wordStr;
                    index++;
                    if (Class_Base(ref PN))
                    {
                        semanticAnalyzer.insertClass(N, AM, PN);
                        if (tokenList[index].classStr == "{")
                        {
                            index++;
                            semanticAnalyzer.createScope();
                            if (Class_Body())
                            {
                                if (tokenList[index].classStr == "}")
                                {
                                    index++;
                                    semanticAnalyzer.deleteScope();
                                    if (Second_Class())
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

        private bool Second_Class()
        {
            if (tokenList[index].classStr == Singleton.SingletonEnums._Access_Modifier.ToString() ||
                tokenList[index].classStr == Singleton.SingletonEnums._class.ToString())
            {
                if (S())
                {
                    return true;
                }
            }

            if (tokenList[index].classStr == "$")
            {
                return true;
            }
            return false;
        }

        private bool Class_Base(ref string N)
        {
            //FIRST(<Class_Base>) = {Null , :}
            if (tokenList[index].classStr == ":")
            {
                //<Class_Base>  Null | : ID
                index++;
                if (tokenList[index].classStr == Singleton.nonKeywords.IDENTIFIER.ToString())
                {
                    N = tokenList[index].wordStr;
                    if (semanticAnalyzer.LookUpClass(N))
                    {
                        
                    }
                    else
                    {
                        addError("Class Undeclared " + N);
                    }
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
                string AM = "";
                //<Class_Member>  <Access_Modifier><Member_Link>
                if (Access_Modifier(ref AM))
                {
                    if (Member_Link(AM))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private bool Member_Link(string AM)
        {
            
            //FIRST(<Member_Link>) = { static , DT ,void ,ID , class }
            if (tokenList[index].classStr == Singleton.SingletonEnums._static.ToString() ||
                tokenList[index].classStr == Singleton.SingletonEnums._DT.ToString() ||
                tokenList[index].classStr == Singleton.SingletonEnums._void.ToString() ||
                tokenList[index].classStr == Singleton.nonKeywords.IDENTIFIER.ToString() ||
                tokenList[index].classStr == Singleton.SingletonEnums._class.ToString())
            {
                //<Member_Link>  <Static><SS_A>| void ID <Method_Link 3> | DT <DT_2> |<Constructor_DEC> | <Class_Link>
                //<Member_Link>  <Static><SS_A>| void ID <Method_Link 3> | DT<DT_2> |ID <Object_Constructor_DEC> | <Class_Link>
                string TM = "";
                if (Static(ref TM))
                {
                    if (SS_A(AM, TM))
                    {
                        return true;
                    }
                }

                else if (tokenList[index].classStr == Singleton.SingletonEnums._void.ToString())
                {
                    string RT = tokenList[index].wordStr;
                    index++;
                    if (tokenList[index].classStr == Singleton.nonKeywords.IDENTIFIER.ToString())
                    {
                        string N = tokenList[index].wordStr;
                        index++;
                        if (Method_Link3(AM, TM, RT, N))
                        {
                            return true;
                        }
                    }
                }

                else if (tokenList[index].classStr == Singleton.SingletonEnums._DT.ToString())
                {
                    string T = tokenList[index].wordStr;
                    index++;
                    if (DT_2(T, AM))
                    {
                        return true;
                    }
                }

                else if (tokenList[index].classStr == Singleton.nonKeywords.IDENTIFIER.ToString())
                {
                    string N = tokenList[index].wordStr;
                    if (!semanticAnalyzer.LookUpClass(N))
                    {
                        addError(N + "Class does not exists");
                    }
                    index++;
                    if (Object_Constructor_Dec(AM, N))
                    {
                        return true;
                    }
                }

                /*else if (Class_Link())
                {
                    return true;
                }*/
            }
            return false;
        }

        private bool Object_Constructor_Dec(string  AM, string N)
        {
            ////FIRST(<Object_Constructor_DEC>) = { ID, [ , (}
            if (tokenList[index].classStr == Singleton.nonKeywords.IDENTIFIER.ToString() ||
                tokenList[index].classStr == "[" ||
                tokenList[index].classStr == "(")
            {
                //<Object_Constructor_DEC>  <object_link> | <Constructor_DEC>
                if (Object_link(AM, N))
                {
                    return true;
                }
                else if(Constructor_DEC(AM, N))
                {
                    return true;
                }
            }
            return false;
        }

        private bool DT_2(string  T, string AM)
        {
            //FIRST(<DT_2>) = {ID , [}
            if (tokenList[index].classStr == Singleton.nonKeywords.IDENTIFIER.ToString() ||
                tokenList[index].classStr == "[")
            {
                //<DT_2> ID <ID_1>|< Array_DEC>
                if (tokenList[index].classStr == Singleton.nonKeywords.IDENTIFIER.ToString())
                {
                    string N = tokenList[index].wordStr;
                    index++;
                    if (ID_1(AM, T, N))
                    {
                        return true;
                    }
                }

                else if (Array_DEC(AM , "", T))
                {
                    return true;
                }
            }
            return false;
        }

        private bool ID_1(string  AM, string RT, string N)
        {
            //FIRST(<ID_1>) = {( , =} //TEMP
            //FIRST(<ID_1>) = {( , AOP , , , ; }
            if (tokenList[index].classStr == "(" ||
                tokenList[index].classStr == Singleton.SingletonEnums.AssignmentOp.ToString() ||
                tokenList[index].classStr == "," ||
                tokenList[index].classStr == ";")
            {
                //<ID_1><Varaiable_Link2> | <Method_Link 3>
                if (Variable_Link2(RT))
                {
                    return true;
                }
                else if (Method_Link3(AM, "", RT, N))
                {
                    return true;
                }
            }
            return false;
        }

        private bool SS_A(string  AM, string TM)
        {
            //FIRST(<SS_A>) = {DT , ID , void}
            if (tokenList[index].classStr == Singleton.SingletonEnums._DT.ToString() ||
                tokenList[index].classStr == Singleton.nonKeywords.IDENTIFIER.ToString() ||
                tokenList[index].classStr == Singleton.SingletonEnums._void.ToString())
            {
                //<SS_A>   DT <DT_1> |ID <Id_OArray> |void ID<Method_Link3> 
                if (tokenList[index].classStr == Singleton.SingletonEnums._DT.ToString())
                {
                    string RT = tokenList[index].wordStr;
                    index++;
                    if (DT_1(AM, TM, RT))
                    {
                        return true;
                    }
                }

                /*else if (tokenList[index].classStr == Singleton.nonKeywords.IDENTIFIER.ToString())
                {
                    index++;
                    if (Id_OArray())
                    {
                        return true;
                    }
                }*/

                else if (tokenList[index].classStr == Singleton.SingletonEnums._void.ToString())
                {
                    string RT = tokenList[index].wordStr;
                    index++;
                    if (tokenList[index].classStr == Singleton.nonKeywords.IDENTIFIER.ToString())
                    {
                        string N = tokenList[index].wordStr;
                        index++;
                        if (Method_Link3(AM, TM, RT, N))
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
        }

        private bool DT_1(string  AM, string TM, string RT)
        {
            //FIRST(<DT_1>) = {ID , [}
            if (tokenList[index].classStr == Singleton.nonKeywords.IDENTIFIER.ToString() ||
                tokenList[index].classStr == "[")
            {
                //<DT_1>  ID <ID_2>| <Array_DEC>
                if (tokenList[index].classStr == Singleton.nonKeywords.IDENTIFIER.ToString())
                {
                    string N = tokenList[index].wordStr;
                    index++;
                    if (ID_2(AM, TM, RT, N))
                    {
                        return true;
                    }
                }
                else if (Array_DEC(AM, TM, RT))
                {
                    return true;
                }
            }
            return false;
        }

        private bool ID_2(string  AM, string TM, string RT, string N)
        {
            //FIRST(<ID_2>) = {( , =}
            //FIRST(<ID_2>) = {( , AOP , , , ; }
            if (tokenList[index].classStr == "(" ||
                tokenList[index].classStr == Singleton.SingletonEnums.AssignmentOp.ToString() ||
                tokenList[index].classStr == "," ||
                tokenList[index].classStr == ";")
            {
                //<ID_2>  <Method_Link3> | <Variable_Link2>
                if (Method_Link3(AM, TM, RT, N))
                {
                    return true;
                }
                else if (Variable_Link2(RT))
                {
                    return true;
                }
            }
            return false;
        }

        /*private bool Id_OArray()
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
        }*/

        /*private bool Id_A()
        {
            //FIRST(<Id_A>) = {= , (}
            //FIRST(<Id_A>) = {( , = , ;}
            if (tokenList[index].wordStr == "=" ||
                tokenList[index].classStr == "(" ||
                tokenList[index].classStr == ";")
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
        }*/

        private bool Constructor_DEC(string  AM, string N)
        {
            //FIRST(<Constructor_DEC>) = {ID}
            //FIRST(<Constructor_DEC>) = { ( }
            if (tokenList[index].classStr == "(")
            {
                //<Constructor_DEC>   ID (<List_Param>) {<M-St>}
                //<Constructor_DEC> (<List_Param>) {<M-St>}
                if (tokenList[index].classStr == "(")
                {
                    string AL = "", PL = "";
                    index++;
                    if (List_Param(ref AL, PL))
                    {
                        if (tokenList[index].classStr == ")")
                        {
                            string TM = "";
                            CLASSMEMBER cons = new CLASSMEMBER();
                            cons.name = N;
                            cons.type = semanticAnalyzer.getCurrentClass();
                            cons.param = AL;
                            cons.isMethod = false;
                            semanticAnalyzer.insertConstructor(cons);
                            index++;
                            if (tokenList[index].classStr == "{")
                            {
                                index++;
                                semanticAnalyzer.createScope();
                                if (M_ST())
                                {
                                    if (tokenList[index].classStr == "}")
                                    {
                                        index++;
                                        semanticAnalyzer.deleteScope();
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

        private bool Array_DEC(string  AM, string TM, string RT)
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
                        RT += "[]";
                        if (tokenList[index].classStr == Singleton.nonKeywords.IDENTIFIER.ToString())
                        {
                            string N = tokenList[index].wordStr;
                            semanticAnalyzer.insertVariables(N, RT, semanticAnalyzer.currentScope());
                            index++;
                            if (INIT_Array(RT))
                            {
                                return true;
                            }
                        }
                    }
                }
            }
            return false;
        }

        private bool INIT_Array(string T)
        {
            //FIRST(<INIT_Array>) = {; , =}
            if (tokenList[index].classStr == ";" ||
                tokenList[index].wordStr == "=")
            {
                //<INIT_Array>  ; | = new DT [<ID_Const>]<Array_const>
                if (tokenList[index].classStr == ";")
                {
                    index++;
                    return true;
                }
                else if (tokenList[index].wordStr == "=")
                {
                    index++;
                    if (tokenList[index].classStr == Singleton.SingletonEnums._new.ToString())
                    {
                        index++;
                        if (tokenList[index].classStr == Singleton.SingletonEnums._DT.ToString())
                        {
                            string T2 = tokenList[index].wordStr;
                            index++;
                            if (tokenList[index].classStr == "[")
                            {
                                index++;
                                string ET = "";
                                if (Exp(ref ET))
                                {
                                    if (tokenList[index].classStr == "]")
                                    {
                                        T2 += "[]";
                                        if (T != T2)
                                        {
                                            addError("Array type mismatch " + T + " " + T2);
                                        }
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
                //<Array_C>{ <Exp><Array_C2>
                if (tokenList[index].classStr == "{")
                {
                    index++;
                    string ET = "";
                    if (Exp(ref ET))
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
            if (tokenList[index].classStr == "}" ||
                tokenList[index].classStr == ",")
            {
                //<Array_C2>  , <Const> | } ;
                //<Array_C2> , <Exp> | } ;
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
                    string ET = "";
                    if (Exp(ref ET))
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


        /*private bool Method_DEC()
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
        }*/

        private bool Method_Link3(string AM, string TM, string RT, string N)
        {
            //FIRST(<Method_Link 3>) = { ( }
            if (tokenList[index].classStr == "(")
            {
                //<Method_Link 3>   (<List_Param>) {<M_St>} 
                if (tokenList[index].classStr == "(")
                {
                    index++;
                    string PL = "";
                    string AL = "";
                    if (List_Param(ref AL, PL))
                    {
                        if (tokenList[index].classStr == ")")
                        {
                            index++;
                            CLASSMEMBER mem = new CLASSMEMBER();
                            mem.isMethod = true;
                            mem.name = N;
                            mem.type = RT;
                            mem.param = AL;
                            semanticAnalyzer.insertMember(mem);
                            if (tokenList[index].classStr == "{")
                            {
                                index++;
                                semanticAnalyzer.createScope();
                                if (M_ST())
                                {
                                    if (tokenList[index].classStr == "}")
                                    {
                                        semanticAnalyzer.deleteScope();
                                        index++;
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

        private bool Object_link(string  AM, string N)
        {
            //FIRST(<Object_Link>) = {ID}
            //FIRST(<Object_Link>) = {ID , [}
            if (tokenList[index].classStr == Singleton.nonKeywords.IDENTIFIER.ToString() ||
                tokenList[index].classStr == "[")
            {
                //<Object_Link> ID <Object_Creation_Exp>
                //<Object_Link> ID <Object_Creation_Exp>| [] ID <object_array_dec>
                if (tokenList[index].classStr == Singleton.nonKeywords.IDENTIFIER.ToString())
                {
                    string N1 = tokenList[index].wordStr;
                    if (semanticAnalyzer.LookUpVariable(N1, semanticAnalyzer.currentScope()))
                    {
                        addError("Redeclaration Error");
                    }
                    index++;
                    if (Object_Creation_Exp(N, N1, AM))
                    {
                        return true;
                    }
                }
                else if (tokenList[index].classStr == "[")
                {
                    index++;
                    if (tokenList[index].classStr == "]")
                    {
                        index++;
                        if (tokenList[index].classStr == Singleton.nonKeywords.IDENTIFIER.ToString())
                        {
                            string N1 = tokenList[index].wordStr;
                            index++;
                            if (object_array_dec(N,N1,AM))
                            {
                                return true;
                            }
                        }
                    }
                }
            }
            return false;
        }

        private bool object_array_dec(string  N, string N1, string AM)
        {
            //FIRST(<object_array_dec>) = { = }
            if (tokenList[index].wordStr == "=")
            {
                //<object_array_dec>  = new ID[<Exp>]<obj_arr_dec1>
                if (tokenList[index].wordStr == "=")
                {
                    index++;
                    if (tokenList[index].classStr == Singleton.SingletonEnums._new.ToString())
                    {
                        index++;
                        if (tokenList[index].classStr == Singleton.nonKeywords.IDENTIFIER.ToString())
                        {
                            string N2 = tokenList[index].wordStr;
                            if (!semanticAnalyzer.LookUpClass(N2))
                            {
                                addError("Class unspecified");
                            }
                            index++;
                            if (tokenList[index].classStr == "[")
                            {
                                index++;
                                string ET = "";
                                if (Exp(ref ET))
                                {
                                    if (tokenList[index].classStr == "]")
                                    {
                                        index++;
                                        semanticAnalyzer.insertVariables(N, N1, semanticAnalyzer.currentScope(), AM, "");
                                        if (obj_arr_dec1())
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

        private bool obj_arr_dec1()
        {
            //FIRST(<obj_arr_dec1>) = { ; , { }
            if(tokenList[index].classStr == "{" ||
                //tokenList[index].classStr == "," ||
                tokenList[index].classStr == ";")
            {
                //<obj_arr_dec1>  ;| {<obj_arr_dec2>
                if (tokenList[index].classStr == ";")
                {
                    index++;
                    return true;
                }
                else if (obj_arr_dec2())
                {
                    return true;
                }
            }
            return false;
        }

        private bool obj_arr_dec2()
        {
            //FIRST(<obj_arr_dec2>) = { new , Null}
            if (tokenList[index].classStr == Singleton.SingletonEnums._new.ToString())
            {
                //<obj_arr_dec2>  new ID  (<Param>)<obj_arr_dec3>
                if (tokenList[index].classStr == Singleton.SingletonEnums._new.ToString())
                {
                    index++;
                    if (tokenList[index].classStr == Singleton.nonKeywords.IDENTIFIER.ToString())
                    {
                        string N = tokenList[index].wordStr;
                        if (!semanticAnalyzer.LookUpClass(N))
                        {
                            addError("Class unspecified");
                        }
                        index++;
                        if (tokenList[index].classStr == "(")
                        {
                            string PL = "", AL = "";
                            index++;
                            if (Param(ref AL, PL))
                            {
                                if (tokenList[index].classStr == ")")
                                {
                                    index++;

                                    if (obj_arr_dec3())
                                    {
                                        return true;
                                    }
                                }
                            }
                        }
                    }
                }
            } 

            /*///FOLLOW(<obj_arr_dec2>) = { access_modifier , static, DT , void , ID , class  , jabtak , barbar , agar , return , inc_dec ,
            ///break , continue , this ,} }
            else if (tokenList[index].classStr == Singleton.SingletonEnums._Access_Modifier.ToString() ||
                tokenList[index].classStr == Singleton.SingletonEnums._static.ToString() ||
                tokenList[index].classStr == Singleton.SingletonEnums._DT.ToString() ||
                tokenList[index].classStr == Singleton.SingletonEnums._void.ToString() ||
                tokenList[index].classStr == Singleton.SingletonEnums._class.ToString() ||
                tokenList[index].classStr == Singleton.SingletonEnums._jabtak.ToString() ||
                tokenList[index].classStr == Singleton.SingletonEnums._barbar.ToString() ||
                tokenList[index].classStr == Singleton.SingletonEnums._agar.ToString() ||
                tokenList[index].classStr == Singleton.SingletonEnums._return.ToString() ||
                tokenList[index].classStr == Singleton.SingletonEnums._break.ToString() ||
                tokenList[index].classStr == Singleton.SingletonEnums.IncDec.ToString() ||
                tokenList[index].classStr == Singleton.SingletonEnums._continue.ToString() ||
                tokenList[index].classStr == Singleton.SingletonEnums._this.ToString())
            {
                return true;
            }*/
            return false;
        }

        private bool obj_arr_dec3()
        {
            ////FIRST(<obj_arr_dec3>) = { , , }}
            if (tokenList[index].classStr == "," ||
                tokenList[index].classStr == "}")
            {
                //<obj_arr_dec3>  , <obj_arr_dec2>|}; 
                if (tokenList[index].classStr == ",")
                {
                    index++;
                    if (obj_arr_dec2())
                    {
                        return true;
                    }
                }
                else if (tokenList[index].classStr == "}")
                {
                    index++;
                    return true;
                }
            }

            return false;
        }

        private bool Object_Creation_Exp(string  N, string N1, string AM)
        {
            //FIRST(<Object_Creation_Exp>) = {= , , , ;}
            //FIRST(<Object_Creation_Exp>) = {=  , ;}
            if (tokenList[index].wordStr == "=" ||
                tokenList[index].classStr == ";")
            {
                //<Object_Creation_Exp>  = new ID  (<List_Const>) <Object_List>  |<Object_List>
                //<Object_Creation_Exp> = new ID  (<Param>) <Object_List>  |;
                if (tokenList[index].wordStr == "=")
                {
                    index++;
                    if (tokenList[index].classStr == Singleton.SingletonEnums._new.ToString())
                    {
                        index++;
                        if (tokenList[index].classStr == Singleton.nonKeywords.IDENTIFIER.ToString())
                        {
                            string N2 = tokenList[index].wordStr;
                            if (!semanticAnalyzer.LookUpClass(N2))
                            {
                                addError("Class unspecified");
                            }
                            index++;
                            if (tokenList[index].classStr == "(")
                            {
                                index++;
                                string PL = "", AL = "";
                                if (Param(ref AL, PL))
                                {
                                    if (tokenList[index].classStr == ")")
                                    {
                                        index++;
                                        semanticAnalyzer.insertVariables(N1, N, semanticAnalyzer.currentScope(), AM, "");
                                        if (Object_List(N, AM))
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

        private bool Object_List(string  N, string AM)
        {
            //FIRST(<Object_List>) = {,, ;}
            //FIRST(<Object_List>) = { , }
            if (tokenList[index].classStr == "," ||
                tokenList[index].classStr == ";")
            {
                //<Object_List>  , ID<Object_Creation_Exp>|;
                //<Object_List> , ID<Object_Creation_Exp>
                if (tokenList[index].classStr == ",")
                {
                    index++;
                    if (tokenList[index].classStr == Singleton.nonKeywords.IDENTIFIER.ToString())
                    {
                        string N1 = tokenList[index].wordStr;
                        Search_GetType(N1, "Redeclaration Error");
                        index++;
                        if (Object_Creation_Exp(N,N1,AM))
                        {
                            return true;
                        }
                    }
                }
                else if (tokenList[index].wordStr == ";")
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
            //FIRST(<Object_Call>) = {. , [}
            if (tokenList[index].classStr == "." ||
                tokenList[index].classStr == "[")
            {
                //<Object_Call>  . ID <Object_Call>| <Method_Call_1> 
                //<Object_Call> . <Exp> | [<Exp>].<Exp>
                if (tokenList[index].classStr == ".")
                {
                    index++;
                    string ET = "";
                    if (Exp(ref ET))
                    {
                        return true;
                    }
                }
                else if (tokenList[index].classStr == "[")
                {
                    index++;
                    string ET = "";
                    if (Exp(ref ET))
                    {
                        if (tokenList[index].classStr == "]")
                        {
                            index++;
                            if (tokenList[index].classStr == ".")
                            {
                                index++;
                                string ET2 = "";
                                if (Exp(ref ET2))
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

        

        private bool Exp(ref string T)
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
                if (OR_Exp(ref T))
                {
                    return true;
                }
            }
            return false;
        }

        private bool OR_Exp(ref string T2)
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
                string T = "";
                if (AND_Exp(ref T))
                {
                    if (OR_Exp2(ref T2, T))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private bool OR_Exp2(ref string T3, string T)
        {
            //FIRST(<OR_Exp2>) = {|| , Null}
            if (tokenList[index].classStr == Singleton.SingletonEnums.OrOp.ToString())
            {
                //<OR_Exp2>  || <AND_Exp> <OR_Exp2> | Null
                if (tokenList[index].classStr == Singleton.SingletonEnums.OrOp.ToString())
                {
                    string OP = tokenList[index].wordStr;
                    index++;
                    string RT = "";
                    if (AND_Exp(ref RT))
                    {
                        string T2 = semanticAnalyzer.CC(T, RT, OP);
                        if (T2 == "invalid")
                        {
                            addError("Type Mismatch" + RT + " " + OP + " " + T);
                        }
                        if (OR_Exp2(ref T3, T2))
                        {
                            return true;
                        }
                    }
                }
            }

            //FOLLOW(<OR_Exp2>) = { ,  , ) , } , ] , ;}
            else if (tokenList[index].classStr == "," ||
                tokenList[index].classStr == "}" ||
                tokenList[index].classStr == "]" ||
                tokenList[index].classStr == ";" ||
                tokenList[index].classStr == ")")
            {
                T3 = T;
                return true;
            }
            return false;
        }

        private bool AND_Exp(ref string T2)
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
                string T = "";
                if (ROP(ref T))
                {
                    if (AND_Exp2(ref T2, T))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private bool AND_Exp2(ref string T3, string T)
        {
            //FIRST(<AND_Exp2>) = {&& , Null}
            if (tokenList[index].classStr == Singleton.SingletonEnums.AndOp.ToString())
            {
                //<AND_Exp2>  && <ROP> <AND_Exp2> | Null
                if (tokenList[index].classStr == Singleton.SingletonEnums.AndOp.ToString())
                {
                    string OP = tokenList[index].wordStr;
                    index++;
                    string RT = "";
                    if (ROP(ref RT))
                    {
                        string T2 = semanticAnalyzer.CC(T, RT, OP);
                        if (T2 == "invalid")
                        {
                            addError("Type Mismatch" + RT + " " + OP + " " + T);
                        }
                        if (AND_Exp2(ref T3, T2))
                        {
                            return true;
                        }
                    }
                }
            }
            ///FOLLOW(<AND_Exp2>) = {||, ,  , ) , } , ] , ;}
            
            else if (tokenList[index].classStr == Singleton.SingletonEnums.OrOp.ToString() ||
                tokenList[index].classStr == "," ||
                tokenList[index].classStr == ";" ||
                tokenList[index].classStr == "}" ||
                tokenList[index].classStr == "]" ||
                tokenList[index].classStr == ")")
            {
                T3 = T;
                return true;
            }
            return false;
        }


        private bool ROP(ref string T2)
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
                string T = "";
                if (E(ref T))
                {
                    if (ROP2(ref T2, T))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private bool ROP2(ref string T3, string T)
        {
            //FIRST(<ROP2>) = {ROP , Null}
            if (tokenList[index].classStr == Singleton.SingletonEnums.RelationalOp.ToString()) //can be '=' TEMP
            {
                //<ROP2>  ROP <E> <ROP2> | Null
                if (tokenList[index].classStr == Singleton.SingletonEnums.RelationalOp.ToString())
                {
                    string OP = tokenList[index].wordStr;
                    index++;
                    string RT = "";
                    if (E(ref RT))
                    {
                        string T2 = semanticAnalyzer.CC(T, RT, OP);
                        if (T2 == "invalid")
                        {
                            addError("Type Mismatch" + RT + " " + OP + " " + T);
                        }
                        if (ROP2(ref T3, T2))
                        {
                            return true;
                        }
                    }
                }
            }

            ////FOLLOW(<ROP2>) = {&& ,||, ,  , ) , } , ] , ;}
            else if (tokenList[index].classStr == Singleton.SingletonEnums.AndOp.ToString() ||
                    tokenList[index].classStr == Singleton.SingletonEnums.OrOp.ToString() ||
                    tokenList[index].classStr == "," ||
                    tokenList[index].classStr == ")" ||
                    tokenList[index].classStr == "}" ||
                    tokenList[index].classStr == "]" ||
                    tokenList[index].classStr == ";")
            {
                T3 = T;
                return true;
            }
            return false;
        }

        private bool E(ref string T2)
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
                string T = "";
                if (this.T(ref T))
                {
                    if (E2(ref T2, T))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private bool E2(ref string T3, string T)
        {
            //FIRST(<E2 >) = {Plus_Minus , Null}
            if (tokenList[index].classStr == Singleton.SingletonEnums.PlusMinus.ToString())
            {
                //<E2 >  Plus_Minus <T > <E2> | Null
                if (tokenList[index].classStr == Singleton.SingletonEnums.PlusMinus.ToString())
                {
                    string OP = tokenList[index].wordStr;
                    index++;
                    string RT = "";
                    if (this.T(ref RT))
                    {
                        string T2 = semanticAnalyzer.CC(T, RT, OP);
                        if (T2 == "invalid")
                        {
                            addError("Type Mismatch" + RT + " " + OP + " " + T);
                        }
                        if (E2(ref T3, T2))
                        {
                            return true;
                        }
                    }
                }
            }
            //FOLLOW(<E2>) = {ROP , && ,||, ,  , ) , } , ] , ;}}
            else if (tokenList[index].classStr == Singleton.SingletonEnums.RelationalOp.ToString() ||
                    tokenList[index].classStr == Singleton.SingletonEnums.AndOp.ToString() ||
                    tokenList[index].classStr == Singleton.SingletonEnums.OrOp.ToString() ||
                    tokenList[index].classStr == "," ||
                    tokenList[index].classStr == ")" ||
                    tokenList[index].classStr == "}" ||
                    tokenList[index].classStr == "]" ||
                    tokenList[index].classStr == ";")
            {
                T3 = T;
                return true;
            }
            return false;
        }

        private bool T(ref string T2)
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
                string T = "";
                if (F(ref T))
                {
                    if (this.T2(ref T2, T))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private bool T2(ref string T3, string T)
        {
            //FIRST(<T2>) = { M_D_M , Null}
            if (tokenList[index].classStr == Singleton.SingletonEnums.MultiDivideMode.ToString())
            {
                //<T2>  M_D_M <F> <T2> | Nulll
                if (tokenList[index].classStr == Singleton.SingletonEnums.MultiDivideMode.ToString())
                {
                    string OP = tokenList[index].wordStr;
                    index++;
                    string RT = "";
                    if (F(ref RT))
                    {
                        string T2 = semanticAnalyzer.CC(T, RT, OP);
                        if (T2 == "invalid")
                        {
                            addError("Type Mismatch" + RT + " " + OP + " " + T);
                        }
                        if (this.T2(ref T3, T2))
                        {
                            return true;
                        }
                    }
                }
            }
            //FOLLOW(<T2>) = { Plus_Minus , ROP , && ,||, ,  , ) , } , ] , ;}

            else if (tokenList[index].classStr == Singleton.SingletonEnums.PlusMinus.ToString() ||
                    tokenList[index].classStr == Singleton.SingletonEnums.RelationalOp.ToString() ||
                    tokenList[index].classStr == Singleton.SingletonEnums.AndOp.ToString() ||
                    tokenList[index].classStr == Singleton.SingletonEnums.OrOp.ToString() ||
                    tokenList[index].classStr == "," ||
                    tokenList[index].classStr == ")" ||
                    tokenList[index].classStr == "}" ||
                    tokenList[index].classStr == "]" ||
                    tokenList[index].classStr == ";")
            {
                T3 = T;
                return true;
            }
            return false;
        }

        private bool F(ref string RT)
        {
            //FIRST(<F>) = { ID, INT_CONST , FLOAT_CONST , STRING_CONST , CHAR_CONST , BOOL_CONST  }
            //FIRST(<F>) = { ID, INT_CONST , FLOAT_CONST , STRING_CONST , CHAR_CONST , BOOL_CONST , ! , ( , inc_dec }
            if (tokenList[index].classStr == Singleton.nonKeywords.IDENTIFIER.ToString() ||
                tokenList[index].classStr == Singleton.nonKeywords.INT_CONSTANT.ToString() ||
                tokenList[index].classStr == Singleton.nonKeywords.FLOAT_CONSTANT.ToString() ||
                tokenList[index].classStr == Singleton.nonKeywords.STRING_CONSTANT.ToString() ||
                tokenList[index].classStr == Singleton.nonKeywords.CHAR_CONSTANT.ToString() ||
                tokenList[index].classStr == Singleton.nonKeywords.BOOL_CONSTANT.ToString() ||
                tokenList[index].classStr == "!" ||
                tokenList[index].classStr == "(" ||
                tokenList[index].classStr == Singleton.SingletonEnums.IncDec.ToString())
            {
                string constT = "";
                //<F>  ID | <CONST>
                //<F> ID <id_op>  |<Const> |!<F> | (<Exp>) | Inc_Dec  ID<inc_dec_list>
                if (tokenList[index].classStr == Singleton.nonKeywords.IDENTIFIER.ToString())
                {
                    string N = tokenList[index].wordStr;
                    string T = Search_GetType(N, "Undeclared Variable");
                    index++;
                    if (id_op(ref RT, N, T))
                    {
                        return true;
                    }
                }
                else if (CONST(ref constT))
                {
                    RT = constT;
                    return true;
                }
                else if (tokenList[index].classStr == "!")
                {
                    string OP = tokenList[index].wordStr;
                    string T = "";
                    index++;
                    if (F(ref T))
                    {
                        if (T != "aur_bool")
                        {
                            addError("Type Mismatch !" + T);
                        }
                        RT = T;
                        return true;
                    }
                }
                else if (tokenList[index].classStr == "(")
                {
                    string T = "";
                    index++;
                    if (Exp(ref T))
                    {
                        if (tokenList[index].classStr == ")")
                        {
                            index++;
                            RT = T;
                            return true;
                        }
                    }
                }
                else if (tokenList[index].classStr == Singleton.SingletonEnums.IncDec.ToString())
                {
                    index++;
                    if (tokenList[index].classStr == Singleton.nonKeywords.IDENTIFIER.ToString())
                    {
                        string N = tokenList[index].wordStr;
                        string T = Search_GetType(N, "Undeclared");
                        string T2 = "";
                        index++;
                        if (inc_dec_list(ref T2, N, T))
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        private bool inc_dec_list(ref string RT, string N, string T1)
        {
            //FIRST(<inc_dec_list>) = { [ , . , Null}
            if (tokenList[index].classStr == "[" ||
                tokenList[index].classStr == ".")
            {
                //<inc_dec_list>  [<Exp>] | .ID[<Exp>] |Null 
                if(tokenList[index].classStr == "["){
                    index++;
                    string ET = "";
                    if(Exp(ref ET))
                    {
                        if(tokenList[index].classStr == "]")
                        {
                            if (Search_GetType(N, "Undeclared Array") != "invalid")
                            {
                                RT = T1;
                            }
                            return true;
                        }
                    }
                }else if(tokenList[index].classStr == ".")
                {
                    if (Search_GetType(N, "Undeclared Object") != "invalid")
                    {
                        RT = T1;
                    }
                    index++;
                    if (tokenList[index].classStr == Singleton.nonKeywords.IDENTIFIER.ToString())
                    {
                        string N1 = tokenList[index].wordStr;
                        index++;
                        if(tokenList[index].classStr == "["){
                            index++;
                            string ET = "";
                            if(Exp(ref ET))
                            {
                                if(tokenList[index].classStr == "]")
                                {
                                    if (Search_GetType(N1, "Undeclared Array") != "invalid")
                                    {
                                        RT = T1;
                                    }
                                    return true;
                                }
                            }
                        }
                    }
                }
            }
            //FOLLOW(<inc_dec_list>) = {M_D_M , Plus_Minus , ROP , && ,||, ,  , ) , } , ] , ;}
            else if(tokenList[index].classStr == Singleton.SingletonEnums.MultiDivideMode.ToString() ||
                    tokenList[index].classStr == Singleton.SingletonEnums.PlusMinus.ToString() ||
                    tokenList[index].classStr == Singleton.SingletonEnums.RelationalOp.ToString() ||
                    tokenList[index].classStr == Singleton.SingletonEnums.AndOp.ToString() ||
                    tokenList[index].classStr == Singleton.SingletonEnums.OrOp.ToString() ||
                    tokenList[index].classStr == "," ||
                    tokenList[index].classStr == ")" ||
                    tokenList[index].classStr == "}" ||
                    tokenList[index].classStr == "]" ||
                    tokenList[index].classStr == ";")
            {
                if (Search_GetType(N, "Undeclared variable") != "invalid")
                {
                    RT = T1;
                }
                return true;
            }
            return false;
        }

        private bool id_op(ref string RT, string N, string T)
        {
            //FIRST(<id_op>) = { Null , ( , [ , . , inc_dec}
            if (tokenList[index].classStr == "(" ||
                tokenList[index].classStr == "[" ||
                tokenList[index].classStr == "." ||
                tokenList[index].classStr == Singleton.SingletonEnums.IncDec.ToString())
            {
                //<id_op>  Null | <Method_Call_1> | [ <Exp> ] |<Member_exp> |  Inc_Dec 

                if (Method_Call_1(ref RT, N))
                {
                    return true;
                }
                else if (tokenList[index].classStr == "[")
                {
                    index++;
                    string ET = "";
                    if (Exp(ref ET))
                    {
                        if (tokenList[index].classStr == "]")
                        {
                            if (Search_GetType(N, "Undeclared Array") != "invalid")
                            {
                            }
                            RT = T;
                            index++;
                            return true;
                        }
                    }
                }
                else if (Member_exp(ref RT, N))
                {
                    return true;
                }
                else if (tokenList[index].classStr == Singleton.SingletonEnums.IncDec.ToString())
                {
                    if (Search_GetType(N, "Undeclared variable") != "invalid")
                    {
                    }
                    index++;
                    RT = T;
                    return false;
                }
            }

            ////FOLLOW(<id_op>) = {M_D_M , Plus_Minus , ROP , && ,||, ,  , ) , } , ] , ;}
            else if (tokenList[index].classStr == Singleton.SingletonEnums.MultiDivideMode.ToString() ||
                    tokenList[index].classStr == Singleton.SingletonEnums.PlusMinus.ToString() ||
                    tokenList[index].classStr == Singleton.SingletonEnums.RelationalOp.ToString() ||
                    tokenList[index].classStr == Singleton.SingletonEnums.AndOp.ToString() ||
                    tokenList[index].classStr == Singleton.SingletonEnums.OrOp.ToString() ||
                    tokenList[index].classStr == "," ||
                    tokenList[index].classStr == ")" ||
                    tokenList[index].classStr == "}" ||
                    tokenList[index].classStr == "]" ||
                    tokenList[index].classStr == ";")
            {
                if (Search_GetType(N, "Undeclared variable") != "invalid")
                {
                    
                }
                RT = T;
                return true;
            }
            return false;
        }

        private bool Member_exp(ref string RT, string N)
        {
            //FIRST(<Member_exp>) = { . }
            if (tokenList[index].classStr == ".")
            {
                //<Member_exp> -> .ID < Member_exp_2>
                if (tokenList[index].classStr == ".")
                {
                    Search_GetType(N, "Undeclared Object");
                    index++;
                    if (tokenList[index].classStr == Singleton.nonKeywords.IDENTIFIER.ToString())
                    {
                        string N1 = tokenList[index].wordStr;
                        string T1 = Search_GetType(N1, "Undeclared variable");

                        index++;
                        if (Member_exp_2(ref RT, N1, T1))
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        private bool Member_exp_2(ref string RT, string N, string T)
        {
            //FIRST(< Member_exp_2>) = {Null , ( , [}
            if (tokenList[index].classStr == "(" ||
                tokenList[index].classStr == "[")
            {
                //< Member_exp_2> -> Null | <Method_Call_1> | [<Exp>]
                if (Method_Call_1(ref RT, N))
                {
                    return true;
                }
                else if (tokenList[index].classStr == "[")
                {
                    index++;
                    string ET = "";
                    if (Exp(ref ET))
                    {
                        if (tokenList[index].classStr == "]")
                        {
                            RT = T;
                            Search_GetType(N, "Undeclared Array");
                            index++;
                            return true;
                        }
                    }
                }
            }

            //FOLLOW(<Member_exp2>) = {M_D_M , Plus_Minus , ROP , && ,||, ,  , ) , } , ] , ;}
            else if (tokenList[index].classStr == Singleton.SingletonEnums.MultiDivideMode.ToString() ||
                    tokenList[index].classStr == Singleton.SingletonEnums.PlusMinus.ToString() ||
                    tokenList[index].classStr == Singleton.SingletonEnums.RelationalOp.ToString() ||
                    tokenList[index].classStr == Singleton.SingletonEnums.AndOp.ToString() ||
                    tokenList[index].classStr == Singleton.SingletonEnums.OrOp.ToString() ||
                    tokenList[index].classStr == "," ||
                    tokenList[index].classStr == ")" ||
                    tokenList[index].classStr == "}" ||
                    tokenList[index].classStr == "]" ||
                    tokenList[index].classStr == ";")
            {

                RT = T;
                Search_GetType(N, "Undeclared Variable");

                return true;
            }
            return false;
        }

        /*private bool THIS()
        {
            //FIRST(<This>)  = {this}
            if (tokenList[index].classStr == Singleton.SingletonEnums._this.ToString())
            {
                //<this>  this.ID < LISTAOP >
                if (tokenList[index].classStr == Singleton.SingletonEnums._this.ToString())
                {
                    index++;
                    if (tokenList[index].classStr == ".")
                    {
                        index++;
                        if (tokenList[index].classStr == Singleton.nonKeywords.IDENTIFIER.ToString())
                        {
                            index++;
                            if (LISTAOP())
                            {
                                return true;
                            }
                        }
                    }
                }

            }

            return false;
        }

        private bool LISTAOP()
        {
            //FIRST(<LISTAOP >) = {; , AOP}

            if (tokenList[index].classStr == Singleton.SingletonEnums.AssignmentOp.ToString() ||
                tokenList[index].classStr == ";")
            {
                //<LISTAOP>  ; | AOP < LIST2AOP>
                if (tokenList[index].classStr == ";")
                {
                    index++;
                    return true;
                }
                else if (tokenList[index].classStr == Singleton.SingletonEnums.AssignmentOp.ToString())
                {
                    index++;
                    if (LIST2AOP())
                    {
                        return true;
                    }
                }
            }
            
            return false;
        }

        private bool LIST2AOP()
        {
            //FIRST(<LIST2AOP >) = { ID, INT_CONST , FLOAT_CONST , STRING_CONST , CHAR_CONST , BOOL_CONST }
            if (tokenList[index].classStr == Singleton.nonKeywords.IDENTIFIER.ToString() ||
                tokenList[index].classStr == Singleton.nonKeywords.INT_CONSTANT.ToString() ||
                tokenList[index].classStr == Singleton.nonKeywords.FLOAT_CONSTANT.ToString() ||
                tokenList[index].classStr == Singleton.nonKeywords.STRING_CONSTANT.ToString() ||
                tokenList[index].classStr == Singleton.nonKeywords.CHAR_CONSTANT.ToString() ||
                tokenList[index].classStr == Singleton.nonKeywords.BOOL_CONSTANT.ToString())
            {
                //< LIST2AOP >  ID <INIT> ; | <CONST> ;
                if (CONST())
                {
                    return true;
                }
                else if (tokenList[index].classStr == Singleton.nonKeywords.IDENTIFIER.ToString())
                {
                    index++;
                   // if(INIT_Array)
                }
            }
            

            return false;
        }*/

        

        

        

        

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
                    string N = tokenList[index].wordStr;
                    string T = Search_GetType(N, "Undeclared Variable");
                    index++;
                    if (Assign_Op(T))
                    {
                        return true;
                    }
                }
            }
            //FOLLOW(<F1>) = { ; }
            else if (tokenList[index].classStr == ";")
            {
                index++;
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
                string ET = "";
                if (Exp(ref ET))
                {
                    if (ET != "aur_bool")
                    {
                        addError("type mismatch");
                    }
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
                        string N = tokenList[index].wordStr;
                        Search_GetType(N, "Undeclared Variable");
                        index++;
                        return true;
                    }
                }
                else if (tokenList[index].classStr == Singleton.nonKeywords.IDENTIFIER.ToString())
                {
                    string N = tokenList[index].wordStr;
                    string T = Search_GetType(N, "Undeclared Variable");
                    index++;
                    if (F4(T))
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

        private bool F4(string  T)
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
                    string OP = tokenList[index].wordStr;
                    index++;
                    string ET = "";
                    if (Exp(ref ET))
                    {
                        if (semanticAnalyzer.CC(T, ET, OP) == "invalid")
                        {
                            addError("Type Mismatch" + ET + " " + OP + " " + T);
                        }
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
                string ET = "";
                if (Exp(ref ET))
                {
                    if (ET != "aur_bool")
                    {
                        addError("type mismatch");
                    }
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

        
    }
}
