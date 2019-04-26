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

        public bool Tie()
        {
            for (int col = 0; col < this.Gameboard.GetLength(1); col++)
            {


                if (Gameboard[0, col] == Side.None)
                {

                    return false;
                }
            }
            return true;
        }

        public Side Winner()
        {



            for (int row = 0; row < this.Gameboard.GetLength(0); row++)
            {
                for (int col = 0; col < this.Gameboard.GetLength(1); col++)
                {
                    if (Gameboard[row, col] != Side.None && (VerticalConnectFour(row, col) || HorizontalConnectFour(row, col) || ForwardDiagonalConnectFour(row, col) || BackwardDiagonalConnectFour(row, col)))
                    {
                        return Gameboard[row, col];
                    }
                }
                
            }
            return Side.None;
        }

        public Side Winner(int row, int col)
        {
            if (Gameboard[row, col] != Side.None &&
                (VerticalConnectFour(row, col) || HorizontalConnectFour(row, col) ||
                ForwardDiagonalConnectFour(row, col) || BackwardDiagonalConnectFour(row, col)))
                return Gameboard[row, col];
            else
            {
                return Side.None;
            }

        }

        private bool VerticalConnectFour(int row, int col)
        {
            if (Gameboard[row, col] == Side.None)
            {
                return false;
            }
            int count = 1;
            int rowCursor = row - 1;
            while (rowCursor >= 0 && Gameboard[rowCursor, col] == Gameboard[row, col])
            {
                count++;
                rowCursor--;
            }
            rowCursor = row + 1;
            while (rowCursor < Gameboard.GetLength(0) && Gameboard[rowCursor, col] == Gameboard[row, col])
            {
                count++;
                rowCursor++;
            }
            if (count < 4)
            {
                return false;

            }
            return true;
        }

        private bool HorizontalConnectFour(int row, int col)
        {
            if (Gameboard[row, col] == Side.None)
            {
                return false;
            }
            int count = 1;
            int colCursor = col - 1;
            while (colCursor >= 0 && Gameboard[row, colCursor] == Gameboard[row, col])
            {
                count++;
                colCursor--;
            }
            colCursor = col + 1;
            while (colCursor < Gameboard.GetLength(1) && Gameboard[row, colCursor] == Gameboard[row, col])
            {
                count++;
                colCursor++;
            }
            if (count < 4)
            {
                return false;
            }
            return true;
        }

        private bool ForwardDiagonalConnectFour(int row, int col)
        {
            if (Gameboard[row, col] == Side.None)
                return false;
            int count = 1;
            int rowCursor = row - 1;
            int colCursor = col + 1;
            while (rowCursor >= 0 && colCursor < Gameboard.GetLength(1) && Gameboard[rowCursor, colCursor] == Gameboard[row, col])
            {
                count++;
                rowCursor--;
                colCursor++;
            }
            rowCursor = row + 1;
            colCursor = col - 1;
            while (rowCursor < Gameboard.GetLength(0) && colCursor >= 0 && Gameboard[rowCursor, colCursor] == Gameboard[row, col])
            {
                count++;
                rowCursor++;
                colCursor--;
            }
            if (count < 4)
            {
                return false;
            }
            return true;


        }

        private bool BackwardDiagonalConnectFour(int row, int col)
        {
            if (Gameboard[row, col] == Side.None)
                return false;
            int count = 1;
            int rowCursor = row + 1;
            int colCursor = col + 1;
            while (rowCursor < Gameboard.GetLength(0) && colCursor < Gameboard.GetLength(1) && Gameboard[rowCursor, colCursor] == Gameboard[row, col])
            {
                count++;
                rowCursor++;
                colCursor++;
            }
            rowCursor = row - 1;
            colCursor = col - 1;
            while (rowCursor >= 0 && colCursor >= 0 && Gameboard[rowCursor, colCursor] == Gameboard[row, col])
            {
                count++;
                rowCursor--;
                colCursor--;
            }
            if (count < 4)
                return false;
            return true;
        }

        public bool Insert(Side side, int column)
        {

            for(int row = Gameboard.GetLength(0) - 1; row >= 0; row--)
            {
                if (Gameboard[row, column] == Side.None)
                {
                    Gameboard[row, column] = side;
                    return true;
                }
            }
            return false;
        }

        public int PiecesInCol(int column)
        {
            int numOfPieces = 0;
            for(int row = Gameboard.GetLength(0) -1; row >=0; row--)
            {
                if (Gameboard[row,column] != Side.None)
                {
                    numOfPieces++;
                }
            }

            return numOfPieces;

        }

    }


}



    

   