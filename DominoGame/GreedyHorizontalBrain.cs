using System;
using System.IO;
using System.Collections.Generic;

namespace DominoGame
{
  public class GreedyHorizontalBrain : BrainBase
  {
    //Board board { public get {return board;} }
  
    public override void Parse(List<List<int>> input) {
      board = new Board(input.Count, input[0].Count);
      
      // Populate board with all input pips.
      for (int x = 0; x < board.Width; x++) {
        for (int y = 0; y < board.Height; y++) {
          int pips = input[x][y];
          
          List<Direction> dirs_to_check = new List<Direction>();
          if (board.CellAt(x+1,y) != null) {
            dirs_to_check.Add(Direction.RIGHT);
          }
          if (board.CellAt(x-1,y) != null) {
            dirs_to_check.Add(Direction.LEFT);
          }
          if (board.CellAt(x,y-1) != null) {
            dirs_to_check.Add(Direction.UP);
          }
          if (board.CellAt(x,y+1) != null) {
            dirs_to_check.Add(Direction.DOWN);
          }
            
          if (CanPlacePip(dirs_to_check, x, y, pips)) {
            board.CellAt(x,y).Pips = pips;
          }
          
          Cell cell = board.CellAt(x,y);
          if (cell.Pips > 0 && AtLeastOneNeighbor(dirs_to_check, x, y)) {
            foreach (var d in dirs_to_check) {
              Cell neighbor = board.AdjacentCell(x,y,d);
              if (neighbor.Pips > 0) {
                board.PlaceDomino(cell, neighbor, new Domino(cell.Pips, neighbor.Pips));
                break;
              }
            }
          }
        }
        
        Console.WriteLine(board);
      }
    } 
  }
}