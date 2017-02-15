using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DominoGame
{
  public class TxtReader
  {
    private readonly string _inFile;
    public List<List<int>> Nums { get; private set; }
    
    public TxtReader(string inFile) {
      _inFile = inFile;
      ReadFile();
    }

    private void ReadFile() {
      Nums = new List<List<int>>();
      using (var rdr = new StreamReader(_inFile)) {
        while (!rdr.EndOfStream) {
          var line = rdr.ReadLine();
          List<int> nums = line.ToCharArray().Select(s => int.Parse("" + s)).ToList();
          Nums.Add(nums);
        }
      }
    }
  }
}