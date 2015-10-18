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
                               {"aur_int","DT"},
                               {"aur_float","DT"},
                               {"aur_double","DT"},
                               {"aur_char", "DT"},
                               {"aur_string", "DT"},
                               {"aur_bool", "DT"},
                               {"agar","agar"},
                               {"warna","warna"},
                               {"break","break"},
                               {"barbar","barbar"},
                               {"jabtak","jabtak"},
                               {"foreach","foreach"},
                               {"continue","continue"},
                               {"new","new"},
                               {"class","class"},
                               {"this","this"},
                               {"stored","static"},
                               {"abstract","abstract"},
                               {"return","return"},
                               {"void","void"},
                               {"super","super"},
                               {"public","Access_Modifier"},
                               {"private","Access_Modifier"},
                               {"true","boolean"},
                               {"false","boolean"},
                               {"nil","nil"},
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
