using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LexicalAnaylzerRexton
{
    class SemanticAnalyzer
    {
        //Class Symbol Table
        private List<CLASS> ClassSymbolTable = new List<CLASS>();
        public List<GLOBAL> GlobalSymbolTable = new List<GLOBAL>();

        //Scope Stack
        Stack<int> Scope = new Stack<int>();
        int scopeToAdd = 0;

        public void CreateScope()
        {
            Scope.Push(scopeToAdd);
            scopeToAdd++;
        }

        public void DeleteScope()
        {
            Scope.Pop();
        }

        public int CurrentScope()
        {
            return Scope.Peek();
        }

        /*ADD*/
        public bool AddGlobal(GLOBAL obj)
        {
            GLOBAL currentname = (GLOBAL)obj.ShallowCopy();
            if (!LookUpGlobal(currentname.name))
            {
                GlobalSymbolTable.Add(currentname);
                return true;
            }
            else
            {
                currentname.name = "ERROR: " + currentname.name;
                GlobalSymbolTable.Add(currentname);
                return false;
            }

        }

        public bool AddClass(CLASS obj)
        {
            CLASS currentClass = (CLASS)obj.ShallowCopy();

            if (!LookUpClass(currentClass.name))
            {
                GlobalSymbolTable[GlobalSymbolTable.Count - 1].classes.Add(currentClass);
                return true;
            }
            return false;
        }

        public bool AddMember(CLASSMEMBER obj)
        {
            CLASSMEMBER currentMember = (CLASSMEMBER)obj.ShallowCopy();
            if (LookUpMember(currentMember))
            {
                currentMember.name = "ERROR: " + currentMember.name;
                GlobalSymbolTable.Last().classes.Last().members.Add(currentMember);
                return false;
            }
            else
            {
                GlobalSymbolTable.Last().classes.Last().members.Add(currentMember);
                return true;
            }
        }

        public bool AddConstructor(CLASSMEMBER obj)
        {
            if (obj.name == GlobalSymbolTable.Last().classes.Last().name)
            {
                bool RT = AddMember(obj);
                return RT;
            }
            else
            {
                obj.name = "ERROR: " + obj.name;
                AddMember(obj);
                return false;
            }
        }

        public bool AddVariables(VARIABLE obj)
        {
            VARIABLE currentVariable = (VARIABLE)obj.ShallowCopy();
            if (LookUpVariable(currentVariable.name, currentVariable.scope))
            {
                currentVariable.name = "ERROR: " + currentVariable.name;
                GlobalSymbolTable.Last().classes.Last().members.Last().variables.Add(currentVariable);
                return false;

            }
            else
            {
                GlobalSymbolTable.Last().classes.Last().members.Last().variables.Add(currentVariable);
                return true;
            }
        }

        public bool LookUpVariable(string name, int scope)
        {
            if (GlobalSymbolTable.Last().classes.Last().members.Count > 0)
            {

                for (int i = 0; i < GlobalSymbolTable.Last().classes.Last().members.Last().variables.Count; i++)
                {
                    if (GlobalSymbolTable.Last().classes.Last().members.Last().variables[i].scope == scope &&
                        GlobalSymbolTable.Last().classes.Last().members.Last().variables[i].name == name)
                    {
                        return true;
                    }
                }
                return false;
            }
            else
            {
                return false;
            }
        }

        public bool LookUpClass(string name)
        {

            for (int j = 0; j < GlobalSymbolTable[GlobalSymbolTable.Count - 1].classes.Count; j++)
            {
                if (GlobalSymbolTable.Last().classes[j].name == name) return true;
            }

            return false;

        }
        public bool LookUpGlobal(string name)
        {
            for (int i = 0; i < GlobalSymbolTable.Count; i++)
            {
                if (GlobalSymbolTable[i].name == name) return true;
            }
            return false;
        }

        public bool LookUpMember(CLASSMEMBER obj)
        {
            bool paramNotMatch = true;
            if (obj.isMethod)
            {
                for (int i = 0; i < GlobalSymbolTable.Last().classes.Last().members.Count; i++)
                {
                    if (GlobalSymbolTable.Last().classes.Last().members[i].isMethod &&
                        GlobalSymbolTable.Last().classes.Last().members[i].name == obj.name)
                    {
                        if (GlobalSymbolTable.Last().classes.Last().members[i].param.Count != obj.param.Count)
                        {
                            continue; // To next class member, count not same
                        }
                        string objParam = "";
                        string memberParam = "";

                        foreach (string s in GlobalSymbolTable.Last().classes.Last().members[i].param)
                        {
                            memberParam += s;
                        }

                        foreach (string s in obj.param)
                        {
                            objParam += s;
                        }

                        if (objParam != memberParam)
                        {
                            paramNotMatch = true;
                        }
                        else
                        {
                            paramNotMatch = false;
                            break;
                        }

                        // Param traverse
                        //for (int j = 0; j < GlobalSymbolTable.Last().classes.Last().members[i].param.Count; j++)
                        //{
                        //    if (GlobalSymbolTable.Last().classes.Last().members[i].param[j] != obj.param[j])
                        //    {
                        //        paramNotMatch = true;
                        //        break;
                        //    }
                        //}

                    }
                }

                if (paramNotMatch)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }

            else
            {
                for (int i = 0; i < GlobalSymbolTable.Last().classes.Last().members.Count; i++)
                {
                    if (!GlobalSymbolTable.Last().classes.Last().members[i].isMethod &&
                        GlobalSymbolTable.Last().classes.Last().members[i].name == obj.name)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool LookUpConstructor(CLASSMEMBER obj)
        {
            if (obj.param.Count == 0)
            {
                return true;
            }
            string obj_s = ""; // object params in one string
            string mem_s = ""; // class member params in one string
            foreach (string s in obj.param)
            {
                obj_s += s;
            }
            for (int j = 0; j < GlobalSymbolTable[GlobalSymbolTable.Count - 1].classes.Count; j++)
            {
                if (GlobalSymbolTable.Last().classes[j].name == obj.type)
                {
                    foreach (CLASSMEMBER i in GlobalSymbolTable.Last().classes[j].members)
                    {
                        if (obj.type == i.name)
                        {
                            foreach (string s in i.param)
                            {
                                mem_s += s;
                            }
                            if (mem_s == obj_s)
                            {
                                return true;
                            }
                            else
                            {
                                mem_s = "";
                            }
                        }
                    }
                }
            }

            return false;
        }

        public bool LookUpLabel(string name)
        {
            int currScope = this.CurrentScope();
            for (int i = 0; i < GlobalSymbolTable.Last().classes.Last().members.Last().variables.Count; i++)
            {
                if (GlobalSymbolTable.Last().classes.Last().members.Last().variables[i].scope == currScope &&
                    GlobalSymbolTable.Last().classes.Last().members.Last().variables[i].type == "Label" &&
                    GlobalSymbolTable.Last().classes.Last().members.Last().variables[i].name == name)
                {
                    return true;
                }
            }
            return false;
        }

        public string removeIndex(string actualType, string toRemove)
        {

            string newType = "";
            int index = actualType.IndexOf(toRemove);
            if (index != -1)
            {
                newType = actualType.Substring(0, index);
                return newType;
            }
            return "invalid";

        }

        public string getCurrentClass()
        {
            return GlobalSymbolTable.Last().classes.Last().name;
        }

        public void reset()
        {
            Scope.Clear();
            scopeToAdd = 0;
            GlobalSymbolTable.Clear();
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

            for (int i = 0; i < GlobalSymbolTable.Last().classes.Last().members.Count; i++)
            {
                if (!GlobalSymbolTable.Last().classes.Last().members[i].isMethod &&
                    GlobalSymbolTable.Last().classes.Last().members[i].name == name)
                {
                    return true;
                }
            }
            return false;

        }

        public bool CC_IncDec(string type)
        {
            switch (type)
            {
                case "int":
                case "_int":
                case "float":
                case "_float":
                case "char":
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
                case "bool":
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
            if (NamespaceSymbolTable.Last().classes.Last().members.Last().type == type)
                return true;
            // implicit conversion
            else if (NamespaceSymbolTable.Last().classes.Last().members.Last().type == "float" && type == "int")
                return true;
            else
                return false;
        }

        public string CC_Return_Type()
        {

            string returnType = NamespaceSymbolTable.Last().classes.Last().members.Last().type;
            return returnType;

        }
        public string CC(string t1, string t2, string oper)
        {
            string returnType = "";

            if (oper == "+" || oper == "-" || oper == "*" || oper == "/")
            {
                switch (t1)
                {
                    case "int":
                        if (t2 == "int")
                            returnType = "int";
                        else if (t2 == "float")
                            returnType = "float";
                        else if (t2 == "string" && oper == "+")
                            returnType = "string";
                        else if (t2 == "char")
                            returnType = "int";
                        else if (t2 == "bool")
                            returnType = "invalid";
                        else returnType = "invalid";
                        break;
                    case "float":
                        if (t2 == "int")
                            returnType = "float";
                        else if (t2 == "float")
                            returnType = "float";
                        else if (t2 == "string" && oper == "+")
                            returnType = "string";
                        else if (t2 == "char")
                            returnType = "float";
                        else if (t2 == "bool")
                            returnType = "invalid";
                        else returnType = "invalid";
                        break;
                    case "string":
                        if (t2 == "int" && oper == "+")
                            returnType = "string";
                        else if (t2 == "float" && oper == "+")
                            returnType = "string";
                        else if (t2 == "string" && oper == "+")
                            returnType = "string";
                        else if (t2 == "char" && oper == "+")
                            returnType = "string";
                        else if (t2 == "bool")
                            returnType = "string";
                        else returnType = "invalid";
                        break;
                    case "char":
                        if (t2 == "int")
                            returnType = "int";
                        else if (t2 == "float")
                            returnType = "float";
                        else if (t2 == "string" && oper == "+")
                            returnType = "string";
                        else if (t2 == "char")
                            returnType = "int";
                        else if (t2 == "bool")
                            returnType = "invalid";
                        else returnType = "invalid";
                        break;
                    case "bool":
                        if (t2 == "int")
                            returnType = "invalid";
                        else if (t2 == "float")
                            returnType = "invalid";
                        else if (t2 == "string" && oper == "+")
                            returnType = "string";
                        else if (t2 == "char")
                            returnType = "invalid";
                        else if (t2 == "bool")
                            returnType = "invalid";
                        else returnType = "invalid";
                        break;
                }
            }
            else if (oper == ">" || oper == ">=" || oper == "<" || oper == "<=" || oper == "&&" || oper == "||" || oper == "==")
            {
                switch (t1)
                {
                    case "int":
                        if (t2 == "int")
                            returnType = "bool";
                        else if (t2 == "float")
                            returnType = "bool";
                        else if (t2 == "string" && oper == "+")
                            returnType = "invalid";
                        else if (t2 == "char")
                            returnType = "bool";
                        else if (t2 == "bool")
                            returnType = "invalid";
                        else returnType = "invalid";
                        break;
                    case "float":
                        if (t2 == "int")
                            returnType = "bool";
                        else if (t2 == "float")
                            returnType = "bool";
                        else if (t2 == "string")
                            returnType = "invalid";
                        else if (t2 == "char")
                            returnType = "bool";
                        else if (t2 == "bool")
                            returnType = "invalid";
                        else returnType = "invalid";
                        break;
                    case "string":
                        if (t2 == "int")
                            returnType = "invalid";
                        else if (t2 == "float")
                            returnType = "invalid";
                        else if (t2 == "string")
                            returnType = "invalid";
                        else if (t2 == "char")
                            returnType = "invalid";
                        else if (t2 == "bool")
                            returnType = "invalid";
                        else returnType = "invalid";
                        break;
                    case "char":
                        if (t2 == "int")
                            returnType = "bool";
                        else if (t2 == "float")
                            returnType = "bool";
                        else if (t2 == "string")
                            returnType = "invalid";
                        else if (t2 == "char")
                            returnType = "bool";
                        else if (t2 == "bool")
                            returnType = "invalid";
                        else returnType = "invalid";
                        break;
                    case "bool":
                        if (t2 == "int")
                            returnType = "invalid";
                        else if (t2 == "float")
                            returnType = "invalid";
                        else if (t2 == "string")
                            returnType = "invalid";
                        else if (t2 == "char")
                            returnType = "invalid";
                        else if (t2 == "bool" && (oper == "&&" || oper == "||"))
                            returnType = "bool";
                        else returnType = "invalid";
                        break;
                }
            }
            else if (oper == "=" || oper == "+=" || oper == "-=")
            {
                switch (t1)
                {
                    case "int":
                        if (t2 == "int")
                            returnType = "int";
                        else if (t2 == "char")
                            returnType = "int";
                        else returnType = "invalid";
                        break;
                    case "float":
                        if (t2 == "int")
                            returnType = "foat";
                        else if (t2 == "float")
                            returnType = "float";
                        else returnType = "invalid";
                        break;
                    case "string":
                        if (t2 == "int" && oper == "+=")
                            returnType = "string";
                        else if (t2 == "float" && oper == "+=")
                            returnType = "string";
                        else if (t2 == "string" && (oper == "+=" || oper == "="))
                            returnType = "string";
                        else if (t2 == "char" && oper == "+=")
                            returnType = "string";
                        else returnType = "invalid";
                        break;
                    case "char":
                        if (t2 == "char")
                            returnType = "char";
                        else returnType = "invalid";
                        break;
                    case "bool":
                        if (t2 == "bool")
                            returnType = "bool";
                        else returnType = "invalid";
                        break;
                }
            }
            return returnType;
        }
    }
}
