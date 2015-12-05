using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LexicalAnaylzerRexton
{
    class SemanticAnalyzer
    {
        public static List<String> errors = new List<string>();

        public static List<CLASS> ClassSymbolTable = new List<CLASS>();
        public static  List<GLOBAL> globalSymbolTable = new List<GLOBAL>();

        Stack<int> Scope = new Stack<int>();
        int scopeToAdd = 0;

        public SemanticAnalyzer()
        {
            //Adding Global
            SemanticAnalyzer.globalSymbolTable.Add(new GLOBAL());
        }

        //Scope Functions
        public void createScope()
        {
            Scope.Push(scopeToAdd++);
        }

        public void deleteScope()
        {
            Scope.Pop();
        }

        public int currentScope()
        {
            return Scope.Peek();
        }

        public string getCurrentClass()
        {
            return globalSymbolTable.Last().classes.Last().name;
        }

        //Insert
        public bool insertVariables(string N, string T, int S)
        {
            VARIABLE currentVariable = new VARIABLE(N,T,S);
            if (LookUpVariable(currentVariable.name, currentVariable.scope))
            {
                variableRedeclarationError(N, T, S);
                //currentVariable.name = "ERROR-" + currentVariable.name;
                //globalSymbolTable.Last().classes.Last().members.Last().variables.Add(currentVariable);
                return false;

            }
            else
            {
                globalSymbolTable.Last().classes.Last().members.Last().variables.Add(currentVariable);
                return true;
            }
        }

        public bool insertMember(CLASSMEMBER obj)
        {
            CLASSMEMBER currentMember = (CLASSMEMBER)obj.ShallowCopy();
            if (LookUpMember(currentMember))
            {
                errors.Add("Method Redeclaration Error " + currentMember.name + " " + currentMember.param + " " + currentMember.type);
                //currentMember.name = "ERROR-" + currentMember.name;
                //globalSymbolTable.Last().classes.Last().members.Add(currentMember);
                return false;
            }
            else
            {
                globalSymbolTable.Last().classes.Last().members.Add(currentMember);
                return true;
            }

        }

        public bool insertConstructor(CLASSMEMBER obj)
        {
            if (obj.name == globalSymbolTable.Last().classes.Last().name)
            {
                bool RT = insertMember(obj);
                return RT;
            }
            else
            {
                errors.Add("Constructor Redeclaration " + obj.name + " " + obj.param + " " + obj.type);
                //obj.name = "ERROR-" + obj.name;
                //insertMember(obj);
                return false;
            }


        }

        public bool insertClass(string N, string AM, string P)
        {
            CLASS currentClass = new CLASS(N, AM, P);

            if (!LookUpClass(currentClass.name))
            {
                globalSymbolTable[globalSymbolTable.Count - 1].classes.Add(currentClass);
                return true;
            }
            else
            {
                errors.Add("Class Redeclaration Error " + N + " " + AM);
            }
            return false;
        }

        private void variableRedeclarationError(string N, string T, int S)
        {
            errors.Add("Variable Redeclaration " + N + " " + T + " " + S);
        }

        //Look ups
        public bool LookUpClass(String N)
        {
            for (int i = 0; i < globalSymbolTable[globalSymbolTable.Count - 1].classes.Count; i++)
            {
                if (globalSymbolTable.Last().classes[i].name == N)
                {
                    return true;
                }
            }
            return false;
        }

        public bool LookUpGlobal(String N)
        {
            for (int i = 0; i < globalSymbolTable.Count - 1; i++)
            {
                if (globalSymbolTable[i].name == N)
                {
                    return true;
                }
            }
            return false;
        }

        public bool LookUpVariable(String N, int S)
        {
            if (globalSymbolTable.Last().classes.Last().members.Count > 0)
            {

                for (int i = 0; i < globalSymbolTable.Last().classes.Last().members.Last().variables.Count; i++)
                {
                    if (globalSymbolTable.Last().classes.Last().members.Last().variables[i].scope == S &&
                        globalSymbolTable.Last().classes.Last().members.Last().variables[i].name == N)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool LookUpMember(CLASSMEMBER obj)
        {
            bool paramNotMatch = false;
            if (obj.isMethod)
            {
                for (int i = 0; i < globalSymbolTable.Last().classes.Last().members.Count; i++)
                {
                    if (globalSymbolTable.Last().classes.Last().members[i].isMethod &&
                        globalSymbolTable.Last().classes.Last().members[i].name == obj.name)
                    {
                        string memberParam = globalSymbolTable.Last().classes.Last().members[i].param;
                        string objParam = obj.param;
                        if (objParam == memberParam)
                        {
                            paramNotMatch = true;
                        }
                        else
                        {
                            paramNotMatch = false;
                            break;
                        }
                    }
                }

                if (paramNotMatch)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                for (int i = 0; i < globalSymbolTable.Last().classes.Last().members.Count; i++)
                {
                    if (!globalSymbolTable.Last().classes.Last().members[i].isMethod &&
                        globalSymbolTable.Last().classes.Last().members[i].name == obj.name)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public bool LookUpContructor(CLASSMEMBER obj)
        {
            for (int j = 0; j < globalSymbolTable[globalSymbolTable.Count - 1].classes.Count; j++)
            {
                if (globalSymbolTable.Last().classes[j].name == obj.type)
                {
                    foreach (CLASSMEMBER i in globalSymbolTable.Last().classes[j].members)
                    {
                        if (obj.type == i.name)
                        {
                            string memberParam = i.param;
                            string objParam = obj.param;
                            if (objParam == memberParam)
                            {
                                return true;
                            }
                        }
                    }
                }
            }
            return false;
        }

        //
        public string getType(string name)
        {
            int[] scopeArray = Scope.ToArray();
            for (int j = scopeArray.Count() - 1; j >= 0; j--)
            {
                if (globalSymbolTable.Last().classes.Last().members.Count > 0)
                {

                    for (int i = 0; i < globalSymbolTable.Last().classes.Last().members.Last().variables.Count; i++)
                    {
                        if (globalSymbolTable.Last().classes.Last().members.Last().variables[i].name == name)
                        {
                            return globalSymbolTable.Last().classes.Last().members.Last().variables[i].type;
                        }
                    }
                    //return "invalid";
                }
                //else
                //{
                //    return "invalid";
                //}
            }

            for (int i = 0; i < globalSymbolTable.Last().classes.Last().members.Count; i++)
            {
                if (!globalSymbolTable.Last().classes.Last().members[i].isMethod &&
                    globalSymbolTable.Last().classes.Last().members[i].name == name)
                {
                    return globalSymbolTable.Last().classes.Last().members[i].type;
                }
            }
            return "invalid";

        }
        //Compatibility
        public bool CC_IncDec(string type)
        {
            switch (type)
            {
                case "aur_int":
                case "_int":
                case "aur_float":
                case "_float":
                case "aur_char":
                case "_char":
                    return true;
                    break;
                default:
                    return false;
            }
        }

        public bool CC_Not_And_Or(string type)
        {
            switch (type)
            {
                case "aur_bool":
                case "true":
                case "false":
                    return true;
                    break;
                default:
                    return false;
            }
            return true;
        }

        public bool CC_Return(string type)
        {
            if (globalSymbolTable.Last().classes.Last().members.Last().type == type)
                return true;
            // implicit conversion
            else if (globalSymbolTable.Last().classes.Last().members.Last().type == "aur_float" && type == "aur_int")
                return true;
            else
                return false;
        }

        public string CC_Return_Type()
        {

            string returnType = globalSymbolTable.Last().classes.Last().members.Last().type;
            return returnType;

        }
        public string CC(string t1, string t2, string oper)
        {
            string returnType = "";

            if (oper == "+" || oper == "-" || oper == "*" || oper == "/")
            {
                switch (t1)
                {
                    case "aur_int":
                        if (t2 == "aur_int")
                            returnType = "aur_int";
                        else if (t2 == "aur_float")
                            returnType = "aur_float";
                        else if (t2 == "aur_string" && oper == "+")
                            returnType = "aur_string";
                        else if (t2 == "aur_char")
                            returnType = "aur_int";
                        else if (t2 == "aur_bool")
                            returnType = "invalid";
                        else returnType = "invalid";
                        break;
                    case "aur_float":
                        if (t2 == "aur_int")
                            returnType = "aur_float";
                        else if (t2 == "aur_float")
                            returnType = "aur_float";
                        else if (t2 == "aur_string" && oper == "+")
                            returnType = "aur_string";
                        else if (t2 == "aur_char")
                            returnType = "aur_float";
                        else if (t2 == "aur_bool")
                            returnType = "invalid";
                        else returnType = "invalid";
                        break;
                    case "aur_string":
                        if (t2 == "aur_int" && oper == "+")
                            returnType = "aur_string";
                        else if (t2 == "aur_float" && oper == "+")
                            returnType = "aur_string";
                        else if (t2 == "aur_string" && oper == "+")
                            returnType = "aur_string";
                        else if (t2 == "aur_char" && oper == "+")
                            returnType = "aur_string";
                        else if (t2 == "aur_bool")
                            returnType = "aur_string";
                        else returnType = "invalid";
                        break;
                    case "aur_char":
                        if (t2 == "aur_int")
                            returnType = "aur_int";
                        else if (t2 == "aur_float")
                            returnType = "aur_float";
                        else if (t2 == "aur_string" && oper == "+")
                            returnType = "aur_string";
                        else if (t2 == "aur_char")
                            returnType = "aur_int";
                        else if (t2 == "aur_bool")
                            returnType = "invalid";
                        else returnType = "invalid";
                        break;
                    case "aur_bool":
                        if (t2 == "aur_int")
                            returnType = "invalid";
                        else if (t2 == "aur_float")
                            returnType = "invalid";
                        else if (t2 == "aur_string" && oper == "+")
                            returnType = "aur_string";
                        else if (t2 == "aur_char")
                            returnType = "invalid";
                        else if (t2 == "aur_bool")
                            returnType = "invalid";
                        else returnType = "invalid";
                        break;
                }
            }
            else if (oper == ">" || oper == ">=" || oper == "<" || oper == "<=" || oper == "&&" || oper == "||" || oper == "==")
            {
                switch (t1)
                {
                    case "aur_int":
                        if (t2 == "aur_int")
                            returnType = "aur_bool";
                        else if (t2 == "aur_float")
                            returnType = "aur_bool";
                        else if (t2 == "aur_string" && oper == "+")
                            returnType = "invalid";
                        else if (t2 == "aur_char")
                            returnType = "aur_bool";
                        else if (t2 == "aur_bool")
                            returnType = "invalid";
                        else returnType = "invalid";
                        break;
                    case "aur_float":
                        if (t2 == "aur_int")
                            returnType = "aur_bool";
                        else if (t2 == "aur_float")
                            returnType = "aur_bool";
                        else if (t2 == "aur_string")
                            returnType = "invalid";
                        else if (t2 == "aur_char")
                            returnType = "aur_bool";
                        else if (t2 == "aur_bool")
                            returnType = "invalid";
                        else returnType = "invalid";
                        break;
                    case "aur_string":
                        if (t2 == "aur_int")
                            returnType = "invalid";
                        else if (t2 == "aur_float")
                            returnType = "invalid";
                        else if (t2 == "aur_string")
                            returnType = "invalid";
                        else if (t2 == "aur_char")
                            returnType = "invalid";
                        else if (t2 == "aur_bool")
                            returnType = "invalid";
                        else returnType = "invalid";
                        break;
                    case "aur_char":
                        if (t2 == "aur_int")
                            returnType = "aur_bool";
                        else if (t2 == "aur_float")
                            returnType = "aur_bool";
                        else if (t2 == "aur_string")
                            returnType = "invalid";
                        else if (t2 == "aur_char")
                            returnType = "aur_bool";
                        else if (t2 == "aur_bool")
                            returnType = "invalid";
                        else returnType = "invalid";
                        break;
                    case "aur_bool":
                        if (t2 == "aur_int")
                            returnType = "invalid";
                        else if (t2 == "aur_float")
                            returnType = "invalid";
                        else if (t2 == "aur_string")
                            returnType = "invalid";
                        else if (t2 == "aur_char")
                            returnType = "invalid";
                        else if (t2 == "aur_bool" && (oper == "&&" || oper == "||"))
                            returnType = "aur_bool";
                        else returnType = "invalid";
                        break;
                }
            }
            else if (oper == "=" || oper == "+=" || oper == "-=")
            {
                switch (t1)
                {
                    case "aur_int":
                        if (t2 == "aur_int")
                            returnType = "aur_int";
                        else if (t2 == "aur_char")
                            returnType = "aur_int";
                        else returnType = "invalid";
                        break;
                    case "aur_float":
                        if (t2 == "aur_int")
                            returnType = "foat";
                        else if (t2 == "aur_float")
                            returnType = "aur_float";
                        else returnType = "invalid";
                        break;
                    case "aur_string":
                        if (t2 == "aur_int" && oper == "+=")
                            returnType = "aur_string";
                        else if (t2 == "aur_float" && oper == "+=")
                            returnType = "aur_string";
                        else if (t2 == "aur_string" && (oper == "+=" || oper == "="))
                            returnType = "aur_string";
                        else if (t2 == "aur_char" && oper == "+=")
                            returnType = "aur_string";
                        else returnType = "invalid";
                        break;
                    case "aur_char":
                        if (t2 == "aur_char")
                            returnType = "aur_char";
                        else returnType = "invalid";
                        break;
                    case "aur_bool":
                        if (t2 == "aur_bool")
                            returnType = "aur_bool";
                        else returnType = "invalid";
                        break;
                }
            }
            return returnType;
        }

        public bool TypeMatch(string t1, string t2)
        {
            return true;
        }

        public void reset()
        {
            Scope.Clear();
            scopeToAdd = 0;
            globalSymbolTable.Clear();
        }


        public bool Search(string name)
        {
            int[] scopeArray = Scope.ToArray();
            for (int i = scopeArray.Count() - 1; i >= 0; i--)
            {
                if (LookUpVariable(name, scopeArray[i]))
                {
                    return true;
                }
            }

            for (int i = 0; i < globalSymbolTable.Last().classes.Last().members.Count; i++)
            {
                if (!globalSymbolTable.Last().classes.Last().members[i].isMethod &&
                    globalSymbolTable.Last().classes.Last().members[i].name == name)
                {
                    return true;
                }
            }
            return false;

        }

        public bool SearchMember(string classType, ref CLASSMEMBER obj)
        {
            // a.b;   || a.b(int i, float j); || a.b(int j)
            // classType.obj
            for (int i = 0; i < globalSymbolTable.Last().classes.Count; i++)
            {

                if (globalSymbolTable.Last().classes[i].name == classType)
                {
                    CLASS currentClass = globalSymbolTable.Last().classes[i];
                    for (int j = 0; j < currentClass.members.Count; j++)
                    {
                        if (currentClass.members[j].name == obj.name)
                        {
                            CLASSMEMBER currentMember = currentClass.members[j];
                            if (!obj.isMethod && !currentMember.isMethod) // check if both obj and currentMember are feilds of a class , NOT METHOD
                            {
                                obj.type = currentMember.type;
                                return true;
                            }

                            else if (obj.isMethod && currentMember.isMethod) // check if both obj and currentMember are methods of a class , NOT feilds
                            {
                                if (obj.param == currentMember.param)
                                {
                                    obj.type = currentMember.type;
                                    return true;
                                }
                                //return true;
                            }
                            else
                            {
                                return false;
                            }
                        }
                    } // For loop end for finding member of a class
                    return false;
                }
            } // For loop end for finding classes 
            return false;
        }

        public string SearchMember(string classType, CLASSMEMBER obj)
        {
            // a.b;   || a.b(int i, float j); || a.b(int j)
            // classType.obj
            for (int i = 0; i < globalSymbolTable.Last().classes.Count; i++)
            {

                if (globalSymbolTable.Last().classes[i].name == classType)
                {
                    CLASS currentClass = globalSymbolTable.Last().classes[i];
                    
                    for (int j = 0; j < currentClass.members.Count; j++)
                    {
                        if (currentClass.members[j].name == obj.name)
                        {
                            CLASSMEMBER currentMember = currentClass.members[j];
                            if (!obj.isMethod && !currentMember.isMethod) // check if both obj and currentMember are feilds of a class , NOT METHOD
                            {
                                obj.type = currentMember.type;
                                return obj.type;
                            }

                            else if (obj.isMethod && currentMember.isMethod) // check if both obj and currentMember are methods of a class , NOT feilds
                            {
                                if (obj.param == currentMember.param)
                                {
                                    obj.type = currentMember.type;
                                    return obj.type;
                                }
                                //return true;
                            }
                            else
                            {
                                return "invalid";
                            }
                        }
                    } // For loop end for finding member of a class
                    return "invalid";
                }
            } // For loop end for finding classes 
            return "invalid";
        }
    }
}
