using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace DominoGame
{
  public class Board
  {
    protected List<List<Cell>> Cells { get; set; }
    public int Height { get; private set; }
    public int Width { get; private set; }
    public int CoveredCells { get; private set; } 

    public Board(int x, int y) {
      Cells = new List<List<Cell>>();
      
      for (int a = 0; a <= y; a++) {
        List<Cell> row = new List<Cell>();
        for (int b = 0; b <= x; b++){
          row.Add(new Cell(b,a));
        }
        Cells.Add(row);
      }
      
      Height = y;
      Width = x;
    }

    public Cell CellAt(int x, int y) {
      if (x >= Height || x < 0 || y >= Width || y < 0) {
        return null;
      }
      
      return Cells[x][y];
    }
    
    public Cell AdjacentCell(int x, int y, Direction direction) {
      switch (direction) {
        case Direction.RIGHT:
          return CellAt(x+1, y);
        case Direction.LEFT:
          return CellAt(x-1, y);
        case Direction.UP:
          return CellAt(x,y-1);
        case Direction.DOWN:
          return CellAt(x,y+1);
      }
      
      return null;
    }
    
    public void PlaceDomino(Cell cell1, Cell cell2, Domino domino) {
      cell1.Domino = domino;
      cell2.Domino = domino;
      CoveredCells += 2;
    }
    
    public List<Cell> Neighbors(Cell cell) {
      List<Cell> neighbors = new List<Cell>();
      
      int[] cell_coords = cell.XYCoords;
      
      foreach (Direction dir in Enum.GetValues(typeof(Direction))) {
        Cell adj = AdjacentCell(cell_coords[0], cell_coords[1], dir);
        if (adj != null) neighbors.Add(adj);
      }
      
      return neighbors;
    }
    
    public List<Cell> UnoccupiedNeighbors(Cell cell) {
      return Neighbors(cell).Where(c => !c.IsOccupied()).ToList();
    }
    
    public List<Cell> OccupiedNeighbors(Cell cell) {
       return Neighbors(cell).Where(c => c.IsOccupied()).ToList();
    }
  }
}