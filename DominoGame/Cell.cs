using System;
using System.Collections.Generic;

namespace DominoGame
{
  public class Cell
  {
   private Domino _domino = null;
   public int Pips { get; set; }
   public int[] XYCoords { get; private set; }
   
   public Domino Domino {
    get {return _domino;}
    set {_domino = value;}
   }
    
    public Cell (int x, int y) {
      Pips = 0;
      XYCoords = new int[2] {x,y};
    }
    
    public Cell(int x, int y, int pips)
    {
      _domino = null;
      Pips = pips;
      XYCoords = new int[2] {x,y};
    }
    
    public bool IsOccupied()
    {
      return _domino == null;
    }
    
    public override string ToString() {
      return "[ " + Pips + (IsOccupied() ? "Occupied" : "Empty") + " ]";
    }
  }
}