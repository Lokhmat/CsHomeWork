//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.6.6
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from D:\Work\C#HW\XAMLRedactor\Parser\XAMLLexer.g4 by ANTLR 4.6.6

// Unreachable code detected
#pragma warning disable 0162
// The variable '...' is assigned but its value is never used
#pragma warning disable 0219
// Missing XML comment for publicly visible type or member '...'
#pragma warning disable 1591
// Ambiguous reference in cref attribute
#pragma warning disable 419

namespace ParserLib {
using Antlr4.Runtime;
using Antlr4.Runtime.Atn;
using Antlr4.Runtime.Misc;
using DFA = Antlr4.Runtime.Dfa.DFA;

[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.6.6")]
[System.CLSCompliant(false)]
public partial class XAMLLexer : Lexer {
	public const int
		COMMENT=1, CDATA=2, DTD=3, EntityRef=4, CharRef=5, SEA_WS=6, OPEN=7, XMLDeclOpen=8, 
		TEXT=9, CLOSE=10, SPECIAL_CLOSE=11, SLASH_CLOSE=12, SLASH=13, EQUALS=14, 
		STRING=15, Name=16, S=17, PI=18;
	public const int INSIDE = 1;
	public const int PROC_INSTR = 2;
	public static string[] modeNames = {
		"DEFAULT_MODE", "INSIDE", "PROC_INSTR"
	};

	public static readonly string[] ruleNames = {
		"COMMENT", "CDATA", "DTD", "EntityRef", "CharRef", "SEA_WS", "OPEN", "XMLDeclOpen", 
		"SPECIAL_OPEN", "TEXT", "CLOSE", "SPECIAL_CLOSE", "SLASH_CLOSE", "SLASH", 
		"EQUALS", "STRING", "Name", "S", "HEXDIGIT", "DIGIT", "NameChar", "NameStartChar", 
		"PI", "IGNORE"
	};


	public XAMLLexer(ICharStream input)
		: base(input)
	{
		_interp = new LexerATNSimulator(this,_ATN);
	}

	private static readonly string[] _LiteralNames = {
		null, null, null, null, null, null, null, "'<'", null, null, "'>'", null, 
		"'/>'", "'/'", "'='"
	};
	private static readonly string[] _SymbolicNames = {
		null, "COMMENT", "CDATA", "DTD", "EntityRef", "CharRef", "SEA_WS", "OPEN", 
		"XMLDeclOpen", "TEXT", "CLOSE", "SPECIAL_CLOSE", "SLASH_CLOSE", "SLASH", 
		"EQUALS", "STRING", "Name", "S", "PI"
	};
	public static readonly IVocabulary DefaultVocabulary = new Vocabulary(_LiteralNames, _SymbolicNames);

	[System.Obsolete("Use Vocabulary instead.")]
	public static readonly string[] tokenNames = GenerateTokenNames(DefaultVocabulary, _SymbolicNames.Length);

	private static string[] GenerateTokenNames(IVocabulary vocabulary, int length) {
		string[] tokenNames = new string[length];
		for (int i = 0; i < tokenNames.Length; i++) {
			tokenNames[i] = vocabulary.GetLiteralName(i);
			if (tokenNames[i] == null) {
				tokenNames[i] = vocabulary.GetSymbolicName(i);
			}

			if (tokenNames[i] == null) {
				tokenNames[i] = "<INVALID>";
			}
		}

		return tokenNames;
	}

	[System.Obsolete("Use IRecognizer.Vocabulary instead.")]
	public override string[] TokenNames
	{
		get
		{
			return tokenNames;
		}
	}

	[NotNull]
	public override IVocabulary Vocabulary
	{
		get
		{
			return DefaultVocabulary;
		}
	}

	public override string GrammarFileName { get { return "XAMLLexer.g4"; } }

	public override string[] RuleNames { get { return ruleNames; } }

	public override string[] ModeNames { get { return modeNames; } }

	public override string SerializedAtn { get { return _serializedATN; } }

	public static readonly string _serializedATN =
		"\x3\xAF6F\x8320\x479D\xB75C\x4880\x1605\x191C\xAB37\x2\x14\xE9\b\x1\b"+
		"\x1\b\x1\x4\x2\t\x2\x4\x3\t\x3\x4\x4\t\x4\x4\x5\t\x5\x4\x6\t\x6\x4\a\t"+
		"\a\x4\b\t\b\x4\t\t\t\x4\n\t\n\x4\v\t\v\x4\f\t\f\x4\r\t\r\x4\xE\t\xE\x4"+
		"\xF\t\xF\x4\x10\t\x10\x4\x11\t\x11\x4\x12\t\x12\x4\x13\t\x13\x4\x14\t"+
		"\x14\x4\x15\t\x15\x4\x16\t\x16\x4\x17\t\x17\x4\x18\t\x18\x4\x19\t\x19"+
		"\x3\x2\x3\x2\x3\x2\x3\x2\x3\x2\x3\x2\a\x2<\n\x2\f\x2\xE\x2?\v\x2\x3\x2"+
		"\x3\x2\x3\x2\x3\x2\x3\x3\x3\x3\x3\x3\x3\x3\x3\x3\x3\x3\x3\x3\x3\x3\x3"+
		"\x3\x3\x3\x3\x3\a\x3P\n\x3\f\x3\xE\x3S\v\x3\x3\x3\x3\x3\x3\x3\x3\x3\x3"+
		"\x4\x3\x4\x3\x4\x3\x4\a\x4]\n\x4\f\x4\xE\x4`\v\x4\x3\x4\x3\x4\x3\x4\x3"+
		"\x4\x3\x5\x3\x5\x3\x5\x3\x5\x3\x6\x3\x6\x3\x6\x3\x6\x6\x6n\n\x6\r\x6\xE"+
		"\x6o\x3\x6\x3\x6\x3\x6\x3\x6\x3\x6\x3\x6\x3\x6\x6\x6y\n\x6\r\x6\xE\x6"+
		"z\x3\x6\x3\x6\x5\x6\x7F\n\x6\x3\a\x3\a\x5\a\x83\n\a\x3\a\x6\a\x86\n\a"+
		"\r\a\xE\a\x87\x3\b\x3\b\x3\b\x3\b\x3\t\x3\t\x3\t\x3\t\x3\t\x3\t\x3\t\x3"+
		"\t\x3\t\x3\t\x3\n\x3\n\x3\n\x3\n\x3\n\x3\n\x3\n\x3\n\x3\v\x6\v\xA1\n\v"+
		"\r\v\xE\v\xA2\x3\f\x3\f\x3\f\x3\f\x3\r\x3\r\x3\r\x3\r\x3\r\x3\xE\x3\xE"+
		"\x3\xE\x3\xE\x3\xE\x3\xF\x3\xF\x3\x10\x3\x10\x3\x11\x3\x11\a\x11\xB9\n"+
		"\x11\f\x11\xE\x11\xBC\v\x11\x3\x11\x3\x11\x3\x11\a\x11\xC1\n\x11\f\x11"+
		"\xE\x11\xC4\v\x11\x3\x11\x5\x11\xC7\n\x11\x3\x12\x3\x12\a\x12\xCB\n\x12"+
		"\f\x12\xE\x12\xCE\v\x12\x3\x13\x3\x13\x3\x13\x3\x13\x3\x14\x3\x14\x3\x15"+
		"\x3\x15\x3\x16\x3\x16\x3\x16\x3\x16\x5\x16\xDC\n\x16\x3\x17\x5\x17\xDF"+
		"\n\x17\x3\x18\x3\x18\x3\x18\x3\x18\x3\x18\x3\x19\x3\x19\x3\x19\x3\x19"+
		"\x5=Q^\x2\x2\x1A\x5\x2\x3\a\x2\x4\t\x2\x5\v\x2\x6\r\x2\a\xF\x2\b\x11\x2"+
		"\t\x13\x2\n\x15\x2\x2\x17\x2\v\x19\x2\f\x1B\x2\r\x1D\x2\xE\x1F\x2\xF!"+
		"\x2\x10#\x2\x11%\x2\x12\'\x2\x13)\x2\x2+\x2\x2-\x2\x2/\x2\x2\x31\x2\x14"+
		"\x33\x2\x2\x5\x2\x3\x4\f\x4\x2\v\v\"\"\x4\x2((>>\x4\x2$$>>\x4\x2))>>\x5"+
		"\x2\v\f\xF\xF\"\"\x5\x2\x32;\x43H\x63h\x3\x2\x32;\x4\x2/\x30\x61\x61\x5"+
		"\x2\xB9\xB9\x302\x371\x2041\x2042\n\x2<<\x43\\\x63|\x2072\x2191\x2C02"+
		"\x2FF1\x3003\xD801\xF902\xFDD1\xFDF2\xFFFF\xF3\x2\x5\x3\x2\x2\x2\x2\a"+
		"\x3\x2\x2\x2\x2\t\x3\x2\x2\x2\x2\v\x3\x2\x2\x2\x2\r\x3\x2\x2\x2\x2\xF"+
		"\x3\x2\x2\x2\x2\x11\x3\x2\x2\x2\x2\x13\x3\x2\x2\x2\x2\x15\x3\x2\x2\x2"+
		"\x2\x17\x3\x2\x2\x2\x3\x19\x3\x2\x2\x2\x3\x1B\x3\x2\x2\x2\x3\x1D\x3\x2"+
		"\x2\x2\x3\x1F\x3\x2\x2\x2\x3!\x3\x2\x2\x2\x3#\x3\x2\x2\x2\x3%\x3\x2\x2"+
		"\x2\x3\'\x3\x2\x2\x2\x4\x31\x3\x2\x2\x2\x4\x33\x3\x2\x2\x2\x5\x35\x3\x2"+
		"\x2\x2\a\x44\x3\x2\x2\x2\tX\x3\x2\x2\x2\v\x65\x3\x2\x2\x2\r~\x3\x2\x2"+
		"\x2\xF\x85\x3\x2\x2\x2\x11\x89\x3\x2\x2\x2\x13\x8D\x3\x2\x2\x2\x15\x97"+
		"\x3\x2\x2\x2\x17\xA0\x3\x2\x2\x2\x19\xA4\x3\x2\x2\x2\x1B\xA8\x3\x2\x2"+
		"\x2\x1D\xAD\x3\x2\x2\x2\x1F\xB2\x3\x2\x2\x2!\xB4\x3\x2\x2\x2#\xC6\x3\x2"+
		"\x2\x2%\xC8\x3\x2\x2\x2\'\xCF\x3\x2\x2\x2)\xD3\x3\x2\x2\x2+\xD5\x3\x2"+
		"\x2\x2-\xDB\x3\x2\x2\x2/\xDE\x3\x2\x2\x2\x31\xE0\x3\x2\x2\x2\x33\xE5\x3"+
		"\x2\x2\x2\x35\x36\a>\x2\x2\x36\x37\a#\x2\x2\x37\x38\a/\x2\x2\x38\x39\a"+
		"/\x2\x2\x39=\x3\x2\x2\x2:<\v\x2\x2\x2;:\x3\x2\x2\x2<?\x3\x2\x2\x2=>\x3"+
		"\x2\x2\x2=;\x3\x2\x2\x2>@\x3\x2\x2\x2?=\x3\x2\x2\x2@\x41\a/\x2\x2\x41"+
		"\x42\a/\x2\x2\x42\x43\a@\x2\x2\x43\x6\x3\x2\x2\x2\x44\x45\a>\x2\x2\x45"+
		"\x46\a#\x2\x2\x46G\a]\x2\x2GH\a\x45\x2\x2HI\a\x46\x2\x2IJ\a\x43\x2\x2"+
		"JK\aV\x2\x2KL\a\x43\x2\x2LM\a]\x2\x2MQ\x3\x2\x2\x2NP\v\x2\x2\x2ON\x3\x2"+
		"\x2\x2PS\x3\x2\x2\x2QR\x3\x2\x2\x2QO\x3\x2\x2\x2RT\x3\x2\x2\x2SQ\x3\x2"+
		"\x2\x2TU\a_\x2\x2UV\a_\x2\x2VW\a@\x2\x2W\b\x3\x2\x2\x2XY\a>\x2\x2YZ\a"+
		"#\x2\x2Z^\x3\x2\x2\x2[]\v\x2\x2\x2\\[\x3\x2\x2\x2]`\x3\x2\x2\x2^_\x3\x2"+
		"\x2\x2^\\\x3\x2\x2\x2_\x61\x3\x2\x2\x2`^\x3\x2\x2\x2\x61\x62\a@\x2\x2"+
		"\x62\x63\x3\x2\x2\x2\x63\x64\b\x4\x2\x2\x64\n\x3\x2\x2\x2\x65\x66\a(\x2"+
		"\x2\x66g\x5%\x12\x2gh\a=\x2\x2h\f\x3\x2\x2\x2ij\a(\x2\x2jk\a%\x2\x2km"+
		"\x3\x2\x2\x2ln\x5+\x15\x2ml\x3\x2\x2\x2no\x3\x2\x2\x2om\x3\x2\x2\x2op"+
		"\x3\x2\x2\x2pq\x3\x2\x2\x2qr\a=\x2\x2r\x7F\x3\x2\x2\x2st\a(\x2\x2tu\a"+
		"%\x2\x2uv\az\x2\x2vx\x3\x2\x2\x2wy\x5)\x14\x2xw\x3\x2\x2\x2yz\x3\x2\x2"+
		"\x2zx\x3\x2\x2\x2z{\x3\x2\x2\x2{|\x3\x2\x2\x2|}\a=\x2\x2}\x7F\x3\x2\x2"+
		"\x2~i\x3\x2\x2\x2~s\x3\x2\x2\x2\x7F\xE\x3\x2\x2\x2\x80\x86\t\x2\x2\x2"+
		"\x81\x83\a\xF\x2\x2\x82\x81\x3\x2\x2\x2\x82\x83\x3\x2\x2\x2\x83\x84\x3"+
		"\x2\x2\x2\x84\x86\a\f\x2\x2\x85\x80\x3\x2\x2\x2\x85\x82\x3\x2\x2\x2\x86"+
		"\x87\x3\x2\x2\x2\x87\x85\x3\x2\x2\x2\x87\x88\x3\x2\x2\x2\x88\x10\x3\x2"+
		"\x2\x2\x89\x8A\a>\x2\x2\x8A\x8B\x3\x2\x2\x2\x8B\x8C\b\b\x3\x2\x8C\x12"+
		"\x3\x2\x2\x2\x8D\x8E\a>\x2\x2\x8E\x8F\a\x41\x2\x2\x8F\x90\az\x2\x2\x90"+
		"\x91\ao\x2\x2\x91\x92\an\x2\x2\x92\x93\x3\x2\x2\x2\x93\x94\x5\'\x13\x2"+
		"\x94\x95\x3\x2\x2\x2\x95\x96\b\t\x3\x2\x96\x14\x3\x2\x2\x2\x97\x98\a>"+
		"\x2\x2\x98\x99\a\x41\x2\x2\x99\x9A\x3\x2\x2\x2\x9A\x9B\x5%\x12\x2\x9B"+
		"\x9C\x3\x2\x2\x2\x9C\x9D\b\n\x4\x2\x9D\x9E\b\n\x5\x2\x9E\x16\x3\x2\x2"+
		"\x2\x9F\xA1\n\x3\x2\x2\xA0\x9F\x3\x2\x2\x2\xA1\xA2\x3\x2\x2\x2\xA2\xA0"+
		"\x3\x2\x2\x2\xA2\xA3\x3\x2\x2\x2\xA3\x18\x3\x2\x2\x2\xA4\xA5\a@\x2\x2"+
		"\xA5\xA6\x3\x2\x2\x2\xA6\xA7\b\f\x6\x2\xA7\x1A\x3\x2\x2\x2\xA8\xA9\a\x41"+
		"\x2\x2\xA9\xAA\a@\x2\x2\xAA\xAB\x3\x2\x2\x2\xAB\xAC\b\r\x6\x2\xAC\x1C"+
		"\x3\x2\x2\x2\xAD\xAE\a\x31\x2\x2\xAE\xAF\a@\x2\x2\xAF\xB0\x3\x2\x2\x2"+
		"\xB0\xB1\b\xE\x6\x2\xB1\x1E\x3\x2\x2\x2\xB2\xB3\a\x31\x2\x2\xB3 \x3\x2"+
		"\x2\x2\xB4\xB5\a?\x2\x2\xB5\"\x3\x2\x2\x2\xB6\xBA\a$\x2\x2\xB7\xB9\n\x4"+
		"\x2\x2\xB8\xB7\x3\x2\x2\x2\xB9\xBC\x3\x2\x2\x2\xBA\xB8\x3\x2\x2\x2\xBA"+
		"\xBB\x3\x2\x2\x2\xBB\xBD\x3\x2\x2\x2\xBC\xBA\x3\x2\x2\x2\xBD\xC7\a$\x2"+
		"\x2\xBE\xC2\a)\x2\x2\xBF\xC1\n\x5\x2\x2\xC0\xBF\x3\x2\x2\x2\xC1\xC4\x3"+
		"\x2\x2\x2\xC2\xC0\x3\x2\x2\x2\xC2\xC3\x3\x2\x2\x2\xC3\xC5\x3\x2\x2\x2"+
		"\xC4\xC2\x3\x2\x2\x2\xC5\xC7\a)\x2\x2\xC6\xB6\x3\x2\x2\x2\xC6\xBE\x3\x2"+
		"\x2\x2\xC7$\x3\x2\x2\x2\xC8\xCC\x5/\x17\x2\xC9\xCB\x5-\x16\x2\xCA\xC9"+
		"\x3\x2\x2\x2\xCB\xCE\x3\x2\x2\x2\xCC\xCA\x3\x2\x2\x2\xCC\xCD\x3\x2\x2"+
		"\x2\xCD&\x3\x2\x2\x2\xCE\xCC\x3\x2\x2\x2\xCF\xD0\t\x6\x2\x2\xD0\xD1\x3"+
		"\x2\x2\x2\xD1\xD2\b\x13\x2\x2\xD2(\x3\x2\x2\x2\xD3\xD4\t\a\x2\x2\xD4*"+
		"\x3\x2\x2\x2\xD5\xD6\t\b\x2\x2\xD6,\x3\x2\x2\x2\xD7\xDC\x5/\x17\x2\xD8"+
		"\xDC\t\t\x2\x2\xD9\xDC\x5+\x15\x2\xDA\xDC\t\n\x2\x2\xDB\xD7\x3\x2\x2\x2"+
		"\xDB\xD8\x3\x2\x2\x2\xDB\xD9\x3\x2\x2\x2\xDB\xDA\x3\x2\x2\x2\xDC.\x3\x2"+
		"\x2\x2\xDD\xDF\t\v\x2\x2\xDE\xDD\x3\x2\x2\x2\xDF\x30\x3\x2\x2\x2\xE0\xE1"+
		"\a\x41\x2\x2\xE1\xE2\a@\x2\x2\xE2\xE3\x3\x2\x2\x2\xE3\xE4\b\x18\x6\x2"+
		"\xE4\x32\x3\x2\x2\x2\xE5\xE6\v\x2\x2\x2\xE6\xE7\x3\x2\x2\x2\xE7\xE8\b"+
		"\x19\x4\x2\xE8\x34\x3\x2\x2\x2\x15\x2\x3\x4=Q^oz~\x82\x85\x87\xA2\xBA"+
		"\xC2\xC6\xCC\xDB\xDE\a\b\x2\x2\a\x3\x2\x5\x2\x2\a\x4\x2\x6\x2\x2";
	public static readonly ATN _ATN =
		new ATNDeserializer().Deserialize(_serializedATN.ToCharArray());
}
} // namespace ParserLib
