using System.IO;

namespace DominoGame
{
  public class TxtWriter
  {
    private readonly string _outFile;
    
    public TxtWriter(string outFile) {
      _outFile = outFile;
    }
    
    public void Write(Board board) {
      using (var writer = new StreamWriter(_outFile))
      {
        for (int y = 0; y < board.Height; y++) {
          for (int x = 0; x < board.Width; x++) {
            writer.Write(board.CellAt(x,y).Pips);
          }
          writer.WriteLine("");
        }
      }
    }
  }
}