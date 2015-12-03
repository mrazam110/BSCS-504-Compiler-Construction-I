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
}
