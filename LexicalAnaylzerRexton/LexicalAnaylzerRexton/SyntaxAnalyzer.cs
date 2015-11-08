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
            bool t = cfg.validate();
            this.errors = cfg.getErrors();
            return t;
        }

        public string getErrors()
        {
            return errors;
        }

    }
}
