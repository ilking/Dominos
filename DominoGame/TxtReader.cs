using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace DominoGame
{
    class TxtReader
    {
        private readonly string _inFile;

        public TxtReader(string inFile)
        {
            _inFile = inFile;
            ReadFile();
        }

        public List<List<int>> Nums { get; private set; }

        private void ReadFile()
        {
            Nums = new List<List<int>>();
            using (var rdr = new StreamReader(_inFile))
            {
                while (!rdr.EndOfStream)
                {
                    var line = rdr.ReadLine();
                    List<int> nums = line.ToCharArray().Select(s => int.Parse("" + s)).ToList();
                    Nums.Add(nums);
                }
            }
        }
    }
}
