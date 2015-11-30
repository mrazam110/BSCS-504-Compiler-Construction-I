using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LexicalAnaylzerRexton
{
    class SemanticClasses
    {
    }

    class GLOBAL
    {
        public string name;
        public List<CLASS> classes;
        public List<GLOBAL> global;

        public GLOBAL()
        {
            name = "";
            classes = new List<CLASS>();
            global = new List<GLOBAL>();
        }
        public GLOBAL ShallowCopy()
        {
            return (GLOBAL)this.MemberwiseClone();
        }
    }

    class CLASS
    {
        public string name;
        public string accessModifier;
        public string parent;
        //public CLASS parentLink;
        public List<CLASSMEMBER> members = new List<CLASSMEMBER>();

        public CLASS ShallowCopy()
        {
            return (CLASS)this.MemberwiseClone();
        }
    }

    class CLASSMEMBER
    {
        public bool isMethod;
        public string name;
        public string type;
        public string accessModifier;
        public string category;
        public List<string> param = new List<string>();
        public List<VARIABLE> variables = new List<VARIABLE>();

        public CLASSMEMBER ShallowCopy()
        {
            return (CLASSMEMBER)this.MemberwiseClone();
        }
    }

    class VARIABLE
    {
        public string name;
        public string type;
        public int scope;

        public VARIABLE ShallowCopy()
        {
            return (VARIABLE)this.MemberwiseClone();
        }
    }

    struct semanticError
    {
        public token token;
        public string message;
        public semanticError(token t, string msg)
        {
            token = t;
            message = msg;
        }
    }
}
