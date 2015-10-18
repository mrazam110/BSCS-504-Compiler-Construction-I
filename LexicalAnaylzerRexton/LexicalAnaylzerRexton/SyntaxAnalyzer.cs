﻿using System;
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

        public bool validateCfg()
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
            if (tokenList[index].classStr == Singleton.SingletonEnums._Access_Modifier.ToString() || 
                tokenList[index].classStr == Singleton.SingletonEnums._class.ToString())
            {
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
            if (tokenList[index].classStr == Singleton.SingletonEnums._Access_Modifier.ToString() ||
                tokenList[index].classStr == Singleton.SingletonEnums._static.ToString() ||
                tokenList[index].classStr == Singleton.SingletonEnums._DT.ToString() ||
                tokenList[index].classStr == Singleton.SingletonEnums._void.ToString() ||
                tokenList[index].classStr == Singleton.nonKeywords.IDENTIFIER.ToString())
            {
                if (tokenList[index].classStr == Singleton.SingletonEnums._Access_Modifier.ToString())
                {
                    index++;
                }
            }
            return false;
        }

        private bool Class_Link()
        {
            return false;
        }

    }
}
