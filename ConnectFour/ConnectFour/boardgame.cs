using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectFour
{

    public enum Side { None, Red, Blue };

    public class boardgame
    {
        public Side[,] Gameboard { get; private set; }

        public boardgame(int rows, int columns)
        {
            Gameboard = new Side[rows, columns];
            for (int row = 0; row < this.Gameboard.GetLength(0); row++)
                for (int col = 0; col < this.Gameboard.GetLength(1); col++)
                    this.Gameboard[row, col] = Side.None;
        }


    }
}
