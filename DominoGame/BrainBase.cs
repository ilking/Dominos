using System;
using System.Collections.Generic;
using System.IO;

namespace DominoGame
{
  public abstract class BrainBase : IBrain
  {
    public Board board {get; protected set;}
    
    abstract public void Parse(List<List<int>> input);
    
    protected bool AtLeastOneNeighbor(List<Direction> dirs, int x, int y) 
    {
      if (board.CellAt(x,y) == null) return false;
      return board.Neighbors(board.CellAt(x,y)).Count > 0;
    }
    
    protected bool CanPlacePip(List<Direction> dirs, int x, int y, int pips)
    {
      if (pips == 0) return true;
      
      Cell cell = board.CellAt(x,y);
      
      foreach (Cell neighbor in board.OccupiedNeighbors(cell)) {
        if (neighbor.Pips != 0 && neighbor.Pips != pips) return false;
      }
      
      return true;
    }
  }
}