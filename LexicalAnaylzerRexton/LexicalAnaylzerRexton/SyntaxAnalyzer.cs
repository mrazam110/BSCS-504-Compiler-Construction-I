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

        private bool validateCfg()
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
            return false;
        }
    }
}
