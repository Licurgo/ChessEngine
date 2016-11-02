using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChessEngine
{
    class Piece
    {
        public char piece_type;
        public bool white;
        public bool enPassant;
        public int twoSquare;
        public bool castling;

        public Piece()
        {
            this.piece_type = ' ';
            this.white = true;
            this.enPassant = false;
            this.twoSquare = 0;
            this.castling = false;
        }   
    }
}
