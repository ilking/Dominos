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
      
      bool result = true;
      Cell cell = board.CellAt(x,y);
      Cell check = null;

      foreach (Direction dir in dirs) {
        switch (dir) {
          case Direction.UP:
            check = board.CellAt(x, y-1);
            break;
          case Direction.DOWN:
            check = board.CellAt(x, y+1);
            break;
          case Direction.LEFT:
            check = board.CellAt(x-1, y);
            break;
          case Direction.RIGHT:
            check = board.CellAt(x+1, y);
            break;
        }
        
        if (check != null) {
          if (check.IsOccupied()) {
            result = result && (check.Pips == pips);
          } else {
            result = result && true;
          }
        }
      } 
      
      return result;
    }
  }
}