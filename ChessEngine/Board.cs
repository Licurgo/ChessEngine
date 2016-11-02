using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChessEngine
{
    class Board
    {
        public Piece[,] piece = new Piece[8, 8];
        public int wScore;
        public int bScore;
        public string current_move;
        public bool isWhiteMove;

        public Board()
        {
            for (int i = 0; i < piece.GetLength(0); i++)
            {
                for (int j = 0; j < piece.GetLength(1); j++)
                {
                    this.piece[i, j] = new Piece();
                }
            }
            this.wScore = 0;
            this.bScore = 0;
            this.current_move = null;
            this.isWhiteMove = true;
        }
    }
}
