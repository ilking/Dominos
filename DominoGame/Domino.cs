using System;

namespace DominoGame
{
  public class Domino {
    public int[] Pips { get; set; }
    
    public Domino(int pip1, int pip2) {
      Pips = new int[2] {pip1, pip2};
    }
    
  }
}