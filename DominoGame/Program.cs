using System;
using System.Collections.Generic;

namespace DominoGame
{
  internal class Program
  {
    private const string cInFileArg = "-inFile";
    private const string cOutFileArg = "-outFile";
    private const string cBrainType = "-brainType";
    
    private static string _inFile;
    private static string _outFile;
    
    private static string _brainType;
    
    public static void Main(string[] args) {
      var I = args.Length;
      
      if (I < 6) {
        Usage();
      } else {
        FindInputArgs(args);
        FindOutputArgs(args);
        if (_inFile == null || _brainType == null) return;
        
        var rd  = new TxtReader(_inFile);
        var numbers = rd.Nums;
        
        IBrain brain = null;
        switch (_brainType) {
          case "GreedyHorizontalBrain":
            brain = Factory.CreateInstance<GreedyHorizontalBrain>();
            break;
        }
        
        if (brain == null) return;
        brain.Parse(numbers);
        var ot = brain.board;
        var wr = new TxtWriter(_outFile);
        wr.Write(ot);
      }
    }
    
    private static void Usage()
    {
        Console.WriteLine(
            "usage: Dominos -inFile c:/path/to/file -outFile c:/path/to/out -brainType <B>");
        Console.WriteLine("where <B> is one of the implemented Brain algorithms.");
        Console.WriteLine();
    }
    
    private static void FindInputArgs(IList<string> args) {
      for (var i = 0; i < args.Count; i += 2) {
        if (String.CompareOrdinal(args[i], cInFileArg) == 0) {
          _inFile = args[i+1];
        }
        
        if (String.CompareOrdinal(args[i], cBrainType) == 0) {
          _brainType = args[i+1];
        }
      }
    }
    
    private static void FindOutputArgs(IList<string> args) {
      for (var i = 0; i < args.Count; i += 2) {
        if (String.CompareOrdinal(args[i], cOutFileArg) == 0) {
          _outFile = args[i+1];
        }
      }
    }
  }
}