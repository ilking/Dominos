using System;
using System.Collections.Generic;

// Making Changes
namespace DominoGame
{
    class Program
    {
        private const string cInFileArg = "-inFile";
        private const string cOutFileArg = "-outFile";
        private const string cBrainType = "-brain";
        private static string _inFile;
        
        
        static void Main(string[] args)
        {
            var l = args.Length;
            if (l < 2)
            {
                Usage();
            }
            else
            {
                FindInputArgs(args);
                if (_inFile == null) return;

                var rd = new TxtReader(_inFile);
                foreach (List<int> nums in rd.Nums)
                {
                    Console.WriteLine("[ " + string.Join(" ", nums) + " ]");
                }
                Console.ReadKey();
            }

        }

        private static void Usage()
        {
            Console.WriteLine("You did it wrong!");
        }

        private static void FindInputArgs(IList<string> args)
        {
            for (var i = 0; i < args.Count; i += 2)
            {
                if (String.CompareOrdinal(args[i], cInFileArg) == 0)
                {
                    _inFile = args[i + 1];
                }
            }
        }
    }
}
