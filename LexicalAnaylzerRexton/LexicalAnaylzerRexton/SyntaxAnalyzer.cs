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

        private string errors;
        CFG cfg;
        public SyntaxAnalyzer(List<token> tokenList)
        {
            this.tokenList = tokenList;
            cfg = new CFG(tokenList);
            addDollarToken();
        }

        private void addDollarToken(){
            token temp = new token(-1, "$", "$");
            tokenList.Add(temp);
        }

        public bool validateCfg()
        {
            bool t = cfg.validate();
            this.errors = cfg.getErrors();
            return t;
        }

        public string getErrors()
        {
            return errors;
        }

        public string getSemanticError()
        {
            return cfg.getSemanticErrors();
        }

    }
}
