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
            if (obj.name == NamespaceSymbolTable.Last().classes.Last().name)
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
    }
}
