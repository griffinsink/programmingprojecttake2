using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectFour
{

    public enum Side { None, Red, Black };

    public class bg
    {
        public Side[,] gb { get; private set; }

        public bg(int rows, int columns)
        {
            gb = new Side[rows, columns];
            for (int row = 0; row < this.gb.GetLength(0); row++)
                for (int col = 0; col < this.gb.GetLength(1); col++)
                    this.gb[row, col] = Side.None;
        }

        public bool Tie()
        {
            for (int col = 0; col < this.gb.GetLength(1); col++)
            {
                if (gb[0, col] == Side.None)
                {

                    return false;
                }
            }
            return true;
        }

        public Side Winner()
        {



            for (int row = 0; row < this.gb.GetLength(0); row++)
            {
                for (int col = 0; col < this.gb.GetLength(1); col++)
                {
                    if (gb[row, col] != Side.None && (VertFour(row, col) || HorFour(row, col) || ForDiagFour(row, col) || BackDiagFour(row, col)))
                    {
                        return gb[row, col];
                    }
                }
                
            }
            return Side.None;
        }

        public Side Winner(int row, int col)
        {
            int point = 0;

            if (gb[row, col] != Side.None &&
                (VertFour(row, col) || HorFour(row, col) ||
                ForDiagFour(row, col) || BackDiagFour(row, col)))
            {
                point++;
                return gb[row, col];
            }

            else
            {
                return Side.None;
            }

        }

        private bool VertFour(int row, int col)
        {
            if (gb[row, col] == Side.None)
            {
                return false;
            }
            int count = 1;
            int RowCur = row - 1;
            while (RowCur >= 0 && gb[RowCur, col] == gb[row, col])
            {
                count++;
                RowCur--;
            }
            RowCur = row + 1;
            while (RowCur < gb.GetLength(0) && gb[RowCur, col] == gb[row, col])
            {
                count++;
                RowCur++;
            }
            if (count < 4)
            {
                return false;

            }
            return true;
        }

        private bool HorFour(int row, int col)
        {
            if (gb[row, col] == Side.None)
            {
                return false;
            }
            int count = 1;
            int ColCur = col - 1;
            while (ColCur >= 0 && gb[row, ColCur] == gb[row, col])
            {
                count++;
                ColCur--;
            }
            ColCur = col + 1;
            while (ColCur < gb.GetLength(1) && gb[row, ColCur] == gb[row, col])
            {
                count++;
                ColCur++;
            }
            if (count < 4)
            {
                return false;
            }
            return true;
        }

        private bool ForDiagFour(int row, int col)
        {
            if (gb[row, col] == Side.None)
                return false;
            int count = 1;
            int RowCur = row - 1;
            int ColCur = col + 1;
            while (RowCur >= 0 && ColCur < gb.GetLength(1) && gb[RowCur, ColCur] == gb[row, col])
            {
                count++;
                RowCur--;
                ColCur++;
            }
            RowCur = row + 1;
            ColCur = col - 1;
            while (RowCur < gb.GetLength(0) && ColCur >= 0 && gb[RowCur, ColCur] == gb[row, col])
            {
                count++;
                RowCur++;
                ColCur--;
            }
            if (count < 4)
            {
                return false;
            }
            return true;


        }

        private bool BackDiagFour(int row, int col)
        {
            if (gb[row, col] == Side.None)
                return false;
            int count = 1;
            int RowCur = row + 1;
            int ColCur = col + 1;
            while (RowCur < gb.GetLength(0) && ColCur < gb.GetLength(1) && gb[RowCur, ColCur] == gb[row, col])
            {
                count++;
                RowCur++;
                ColCur++;
            }
            RowCur = row - 1;
            ColCur = col - 1;
            while (RowCur >= 0 && ColCur >= 0 && gb[RowCur, ColCur] == gb[row, col])
            {
                count++;
                RowCur--;
                ColCur--;
            }
            if (count < 4)
                return false;
            return true;
        }

        public bool Insert(Side side, int column)
        {

            for(int row = gb.GetLength(0) - 1; row >= 0; row--)
            {
                if (gb[row, column] == Side.None)
                {
                    gb[row, column] = side;
                    return true;
                }
            }
            return false;
        }


        public int ColPieces(int column)
        {
            int piecesNum = 0;
            for(int row = gb.GetLength(0) -1; row >=0; row--)
            {
                if (gb[row,column] != Side.None)
                {
                    piecesNum++;
                }
            }

            return piecesNum;

        }

    }


}



    

   