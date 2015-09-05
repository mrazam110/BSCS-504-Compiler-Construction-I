using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LexicalAnaylzerRexton
{
    static class SingletonClass
    {
        public static string[,] keywords = {
                               {"aur_int","class_dt"},
                               {"aur_float","DataType"},
                               {"aur_double","DataType"},
                               {"aur_char", "DataType"},
                               {"aur_string", "DataType"},
                               {"aur_bool", "DataType"},
                               {"agar","class_ifCond"},
                               {"warna","class_elsecond"},
                               {"break","_break"},
                               {"barbar","class_forloop"},
                               {"jabtak","class_whileloop"},
                               {"foreach","_foreach"},
                               {"continue","class_continue"},
                               {"new","new"},
                               {"class","class"},
                               {"this","this"},
                               {"stored","class_static"},
                               {"abstract","abstract"},
                               {"return","class_returning"},
                               {"void","void"},
                               {"override","VirtualOverride"},
                               {"virtual","VirtualOverride"},
                               {"super","super"},
                               {"public","accessModifier"},
                               {"private","accessModifier"},
                               {"true","boolean"},
                               {"false","boolean"},
                               {"nil","nil"},
                               {"void", "_void"},
                               {"main", "main"},
                               {"const", "const"}
                           };

        public static string[,] Operators = {
                                                {"!","NotOp"},
                                                {"++","IncDec"},
                                                {"--","IncDec"},
                                                {"*","MultiDivideMode"},
                                                {"/","MultiDivideMode"},
                                                {"%","MultiDivideMode"},
                                                {"+","PlusMinus"},
                                                {"-","PlusMinus"},
                                                {">","RelationalOp"},
                                                {"<","RelationalOp"},
                                                {">=","RelationalOp"},
                                                {"<=","RelationalOp"},
                                                {"!=","RelationalOp"},
                                                {"==","RelationalOp"},
                                                {"&&","AndOp"},
                                                {"||","OrOp"},
                                                {"=","AssignmentOp"},
                                                {"+=","AssignmentOp"},
                                                {"*=","AssignmentOp"},
                                                {"/=","AssignmentOp"},
                                                {"%=","AssignmentOp"},
                                                {"-=","AssignmentOp"}                                                
                                            };
        public static string[,] punctuators = {
                                              { ",","Comma" },
                                              { ";","Terminator" },
                                              { ":","_Colon" },                                           
                                              { "[","SquareBraces" },
                                              { "]","SquareBraces" },
                                              { "{","CurlyBraces" },
                                              { "}","CurlyBraces" },
                                              { "(","Parentheses" },
                                              { ")","Parentheses" },
                                              { ".","Dot" }
                                              };

        public enum nonKeywords
        {
            _identifier, _int_constant, _float_constant, _string_constant, _char_constant, _bool_constant, _invalid
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
        '{', '}', '[', ']', '.', '\'', '\"' };
    }
}
