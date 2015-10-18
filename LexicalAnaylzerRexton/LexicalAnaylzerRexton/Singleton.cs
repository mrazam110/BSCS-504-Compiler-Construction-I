﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LexicalAnaylzerRexton
{
    static class Singleton
    {

        public enum SingletonEnums
        {
            _DT, _agar, _warna, _break, _barbar, _jabtak, _continue, _new, _class, _this, _static,
            _abstract, _return, _void, _super, _Access_Modifier, _boolean, _nil, _main, _const,

            NotOp, IncDec, MultiDivideMode, PlusMinus, RelationalOp, AndOp, OrOp, AssignmentOp
        }

        public static string[,] keywords = {
                               {"aur_int",      Singleton.SingletonEnums._DT.ToString()                 },
                               {"aur_float",    Singleton.SingletonEnums._DT.ToString()                 },
                               {"aur_double",   Singleton.SingletonEnums._DT.ToString()                 },
                               {"aur_char",     Singleton.SingletonEnums._DT.ToString()                 },
                               {"aur_string",   Singleton.SingletonEnums._DT.ToString()                 },
                               {"aur_bool",     Singleton.SingletonEnums._DT.ToString()                 },
                               {"agar",         Singleton.SingletonEnums._agar.ToString()               },
                               {"warna",        Singleton.SingletonEnums._warna.ToString()              },
                               {"break",        Singleton.SingletonEnums._break.ToString()              },
                               {"barbar",       Singleton.SingletonEnums._barbar.ToString()             },
                               {"jabtak",       Singleton.SingletonEnums._jabtak.ToString()             },
                               {"continue",     Singleton.SingletonEnums._continue.ToString()           },
                               {"new",          Singleton.SingletonEnums._new.ToString()                },
                               {"class",        Singleton.SingletonEnums._class.ToString()              },
                               {"this",         Singleton.SingletonEnums._this.ToString()               },
                               {"stored",       Singleton.SingletonEnums._static.ToString()             },
                               {"abstract",     Singleton.SingletonEnums._abstract.ToString()           },
                               {"return",       Singleton.SingletonEnums._return.ToString()             },
                               {"void",         Singleton.SingletonEnums._void.ToString()               },
                               {"super",        Singleton.SingletonEnums._super.ToString()              },
                               {"public",       Singleton.SingletonEnums._Access_Modifier.ToString()    },
                               {"private",      Singleton.SingletonEnums._Access_Modifier.ToString()    },
                               {"true",         Singleton.SingletonEnums._boolean.ToString()            },
                               {"false",        Singleton.SingletonEnums._boolean.ToString()            },
                               {"nil",          Singleton.SingletonEnums._nil.ToString()                },
                               {"main",         Singleton.SingletonEnums._main.ToString()               },
                               {"const",        Singleton.SingletonEnums._const.ToString()              },
                           };

        public static string[,] Operators = {
                                                {"!",    Singleton.SingletonEnums.NotOp.ToString()              },
                                                {"++",   Singleton.SingletonEnums.IncDec.ToString()             },
                                                {"--",   Singleton.SingletonEnums.IncDec.ToString()             },
                                                {"*",    Singleton.SingletonEnums.MultiDivideMode.ToString()    },
                                                {"/",    Singleton.SingletonEnums.MultiDivideMode.ToString()    },
                                                {"%",    Singleton.SingletonEnums.MultiDivideMode.ToString()    },
                                                {"+",    Singleton.SingletonEnums.PlusMinus.ToString()          },
                                                {"-",    Singleton.SingletonEnums.PlusMinus.ToString()          },
                                                {">",    Singleton.SingletonEnums.RelationalOp.ToString()       },
                                                {"<",    Singleton.SingletonEnums.RelationalOp.ToString()       },
                                                {">=",   Singleton.SingletonEnums.RelationalOp.ToString()       },
                                                {"<=",   Singleton.SingletonEnums.RelationalOp.ToString()       },
                                                {"!=",   Singleton.SingletonEnums.RelationalOp.ToString()       },
                                                {"==",   Singleton.SingletonEnums.RelationalOp.ToString()       },
                                                {"&&",   Singleton.SingletonEnums.AndOp.ToString()              },
                                                {"||",   Singleton.SingletonEnums.OrOp.ToString()              },
                                                {"=",    "="                                                    },
                                                {"+=",   Singleton.SingletonEnums.AssignmentOp.ToString()       },
                                                {"*=",   Singleton.SingletonEnums.AssignmentOp.ToString()       },
                                                {"/=",   Singleton.SingletonEnums.AssignmentOp.ToString()       },
                                                {"%=",   Singleton.SingletonEnums.AssignmentOp.ToString()       },
                                                {"-=",   Singleton.SingletonEnums.AssignmentOp.ToString()       },                                             
                                            };

        public static string[,] punctuators = {
                                              { ",","," },
                                              { ";",";" },
                                              { ":",":" },                                           
                                              { "[","[" },
                                              { "]","]" },
                                              { "{","{" },
                                              { "}","}" },
                                              { "(","(" },
                                              { ")",")" },
                                              { ".","." }
                                              };

       

        public enum nonKeywords
        {
            IDENTIFIER, INT_CONSTANT, FLOAT_CONSTANT, STRING_CONSTANT, CHAR_CONSTANT, BOOL_CONSTANT, _INVALID
        };

        public static string[] others =  {"IDENTIFIER", 
                                          "INT_CONSTANT",
                                          "FLOAT_CONSTANT",
                                          "STRING_CONSTANT",
                                          "CHAR_CONSTANT",
                                          "BOOL_CONSTANT",
                                          "_INVALID"
                                        };

        public static char[] breakers = { ' ','\t', '\n', '<', '>' , '+', '-', '*', '/', '=', '&', '|', '!', '#', '$', ',', ';', ':', '(', ')',
        '{', '}', '[', ']', '.', '\'', '@' };
    }

    public static class RegularExpression {
        public static string digits = @"^[0-9]+$";
        public static string alphabet = @"^[a-zA-Z]+$";
        public static string signs = @"[+-]";
        public static string escapeCharacters = @"[nrtfbv]";
        public static string sc = "[\\\\\"\']";
    }
}
