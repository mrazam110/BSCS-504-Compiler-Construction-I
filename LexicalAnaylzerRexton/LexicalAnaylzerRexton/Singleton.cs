using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LexicalAnaylzerRexton
{
    static class Singleton
    {
        public static string[,] keywords = {
                               {"aur_int","DataType"},
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
                                              { ":","Colon" },                                           
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
