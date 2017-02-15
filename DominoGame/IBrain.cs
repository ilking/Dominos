using System;
using System.Collections.Generic;

namespace DominoGame {
  public interface IBrain {
    Board board {get;}
    void Parse(List<List<int>> input);
  }
}