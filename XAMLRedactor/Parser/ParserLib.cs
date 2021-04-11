using Antlr4.Runtime;
using Antlr4.Runtime.Misc;
using System;
using System.Collections.Generic;
using System.IO;

namespace ParserLib
{
    public static class ParserLib
    {
        public static List<Tuple<int, int>> Coordinates { get; private set; } = new List<Tuple<int, int>>();
        public static void Start(string text)
        {

            AntlrInputStream inputStream = new AntlrInputStream(text.ToString());
            XAMLLexer speakLexer = new XAMLLexer(inputStream);
            CommonTokenStream commonTokenStream = new CommonTokenStream(speakLexer);
            XAMLParser speakParser = new XAMLParser(commonTokenStream);
            
            GetAttributes(speakParser.content());

        }
        /// <summary>
        /// Обойдём дерево сгенерированное antlr dfs чтобы найти всё что надо подсвечивать(пока находит только атрибуты)
        /// </summary>
        /// <param name="parser"> Корень дерева</param>
        static void GetAttributes(Antlr4.Runtime.Tree.IParseTree parser)
        {
            if(parser is XAMLParser.AttributeContext attribute)
            {
                Coordinates.Add(Tuple.Create(attribute.Name().Symbol.StartIndex, attribute.Name().Symbol.StopIndex));
            }
            File.AppendAllText("ans.txt", parser.Payload.ToString());
            for(int i=0; i<parser.ChildCount; i++)
            {
                GetAttributes(parser.GetChild(i));
            }
           
        }
    }
    
}
