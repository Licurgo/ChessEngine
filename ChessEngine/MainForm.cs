using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChessEngine
{
    public partial class MainForm : Form
    {
        int boardSize = 8;
        int depth = 0;
        int maxDepth = 4;

        int[] wBestDepth;
        int[] wBestPerm;
        int[] wBestScore;
        string[] wBestMove;

        int[] bBestDepth;
        int[] bBestPerm;
        int[] bBestScore;
        string[] bBestMove;

        //int bScoreActuals;
        ////int tmpWScore;
        ////int tmpBScore;

        
        //int wPerm;
        //int bDepth;
        //int bPerm;

        
        //int bScoreForecast;
        //string wBestMove;
        //string bBestMove;
        //string wBestMoveForecast;
        //string bBestMoveForecast;
        Board initBoard;
        List<Board> permutationsActuals;
        List<Board> permutationsForecast;
        //List<GridViewList> gridList = new List<GridViewList>();

        public MainForm()
        {
            InitializeComponent();

            wBestDepth = new int[2];
            wBestPerm = new int[2];
            wBestScore = new int[2];
            wBestMove = new string[2];

            bBestDepth = new int[2];
            bBestPerm = new int[2];
            bBestScore = new int[2];
            bBestMove = new string[2]; 

            dataGridView1.Columns.Add("Depth", "Depth");
            dataGridView1.Columns.Add("Permutation", "Permutation");
            dataGridView1.Columns.Add("Total Permutations", "Total Permutations");
            dataGridView1.Columns.Add("Score", "Score");
            dataGridView1.Columns.Add("Moves", "Moves");
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
           



            setInitialBoard();

            while (depth < maxDepth)
            {
                permutationsActuals = new List<Board>(permutationsForecast);
                permutationsForecast = new List<Board>();
                MoveCreator();
                //MoveCheck();
                MoveScore();

                wBestDepth[0] = wBestDepth[1];
                wBestPerm[0] = wBestPerm[1];
                wBestScore[0] = wBestScore[1];
                wBestMove[0] = wBestMove[1];

                bBestDepth[0] = bBestDepth[1];
                bBestPerm[0] = bBestPerm[1];
                bBestScore[0] = bBestScore[1];
                bBestMove[0] = bBestMove[1];


                lblwBestDepth.Text = wBestDepth[0].ToString();
                lblbBestDepth.Text = bBestDepth[0].ToString();
                lblwBestPerm.Text = wBestPerm[0].ToString();
                lblbBestPerm.Text = bBestPerm[0].ToString();
                lblwBestScore.Text = wBestScore[0].ToString();
                lblbBestScore.Text = bBestScore[0].ToString();
                lblwBestMove.Text = wBestMove[0];
                lblbBestMove.Text = bBestMove[0];

                DisplayPermutations(false);

                depth++;
                Console.WriteLine("permutationsForecast = " + permutationsForecast.Count());
            }
            DisplayBoard(txtPermNbr.Text);
            dataGridView1.AutoResizeColumns();

        }

        private void setInitialBoard()
        {
            initBoard = new Board();
            //permutationsActuals = new List<Board>();
            permutationsForecast = new List<Board>();

            initBoard.piece[3, 1].piece_type = 'p';
            initBoard.piece[3, 1].white = true;
            initBoard.piece[4, 1].piece_type = 'p';
            initBoard.piece[4, 1].white = true;
            initBoard.piece[4, 0].piece_type = 'k';
            initBoard.piece[4, 0].white = true;

            //initBoard.piece[3, 1].piece_type = 'p';
            //initBoard.piece[3, 1].white = true;
            //initBoard.piece[4, 1].piece_type = 'p';
            //initBoard.piece[4, 1].white = true;

            initBoard.piece[3, 6].piece_type = 'p';
            initBoard.piece[3, 6].white = false;
            initBoard.piece[4, 6].piece_type = 'p';
            initBoard.piece[4, 6].white = false;
            initBoard.piece[4, 7].piece_type = 'k';
            initBoard.piece[4, 7].white = false;

            //initBoard.piece[2, 3].piece_type = 'p';
            //initBoard.piece[2, 3].white = false;
            //initBoard.piece[5, 3].piece_type = 'p';
            //initBoard.piece[5, 3].white = false;

            permutationsForecast.Add(initBoard);
        }

        private void MoveCreator()
        {
            int incX, incY;

            for (int h = 0; h < permutationsActuals.Count(); h++)
            {
                Board prevBoard = new Board();
                prevBoard = CopyBoard(permutationsActuals[h]);
                for (int y = 0; y < prevBoard.piece.GetLength(1); y++)
                {
                    for (int x = 0; x < prevBoard.piece.GetLength(0); x++)
                    {
                        if (prevBoard.isWhiteMove)//White move
                        {
                            if (prevBoard.piece[x, y].piece_type == ('p') && prevBoard.piece[x, y].white == true)
                            {
                                //pawn move fwd 1 tile
                                incX = 0; incY = 1;
                                if (x + incX >= 0 && y + incY >= 0 && x + incX < boardSize && y + incY < boardSize && prevBoard.piece[x + incX, y + incY].piece_type == ' ')
                                {
                                    Board tmpBoard = new Board();
                                    tmpBoard = MovePiece(prevBoard, 'p', true, x, y, x + incX, y + incY);
                                    permutationsForecast.Add(tmpBoard);
                                }

                                //pawn move fwd 2 tiles
                                incX = 0; incY = 2;
                                if (y == 1 && prevBoard.piece[x, y + 1].piece_type == ' ' && prevBoard.piece[x + incX, y + incY].piece_type == ' ')
                                {
                                    Board tmpBoard = new Board();
                                    tmpBoard = MovePiece(prevBoard, 'p', true, x, y, x + incX, y + incY);
                                    tmpBoard.piece[x + incX, y + incY].twoSquare = depth;
                                    permutationsForecast.Add(tmpBoard);
                                }

                                //capture right
                                incX = 1; incY = 1;
                                if (x + incX >= 0 && y + incY >= 0 && x + incX < boardSize && y + incY < boardSize &&
                                    !(prevBoard.piece[x + incX, y + incY].piece_type == ' ') && !(prevBoard.piece[x + incX, y + incY].white))
                                {
                                    Board tmpBoard = new Board();
                                    tmpBoard = MovePiece(prevBoard, 'p', true, x, y, x + incX, y + incY);
                                    permutationsForecast.Add(tmpBoard);
                                }

                                //capture left
                                incX = -1; incY = 1;
                                if (x + incX >= 0 && y + incY >= 0 && x + incX < boardSize && y + incY < boardSize &&
                                    !(prevBoard.piece[x + incX, y + incY].piece_type == ' ') && !(prevBoard.piece[x + incX, y + incY].white))
                                {
                                    Board tmpBoard = new Board();
                                    tmpBoard = MovePiece(prevBoard, 'p', true, x, y, x + incX, y + incY);
                                    permutationsForecast.Add(tmpBoard);
                                }

                                //capture right enpassant
                                incX = 1; incY = 1;
                                if (x + incX >= 0 && y + incY >= 0 && x + incX < boardSize && y + incY < boardSize &&
                                    prevBoard.piece[x + incX, y].piece_type == 'p' && prevBoard.piece[x + incX, y].twoSquare == depth - 1 && !(prevBoard.piece[x + incX, y].white))
                                {
                                    Board tmpBoard = new Board();
                                    tmpBoard = MovePiece(prevBoard, 'p', true, x, y, x + incX, y + incY);
                                    tmpBoard.piece[x + incX, y].piece_type = ' ';
                                    permutationsForecast.Add(tmpBoard);
                                    //TO DO check if last move was enpassant
                                }

                                //capture left enpassant
                                incX = -1; incY = 1;
                                if (x + incX >= 0 && y + incY >= 0 && x + incX < boardSize && y + incY < boardSize &&
                                    prevBoard.piece[x + incX, y].piece_type == 'p' && prevBoard.piece[x + incX, y].twoSquare == depth - 1 && !(prevBoard.piece[x + incX, y].white))
                                {
                                    Board tmpBoard = new Board();
                                    tmpBoard = MovePiece(prevBoard, 'p', true, x, y, x + incX, y + incY);
                                    tmpBoard.piece[x + incX, y].piece_type = ' ';
                                    permutationsForecast.Add(tmpBoard);
                                    //TO DO check if last move was enpassant
                                }
                            }

                            if (prevBoard.piece[x, y].piece_type == ('k') && prevBoard.piece[x, y].white == true)
                            {
                                //king move N
                                incX = 0; incY = 1;
                                if ((x + incX >= 0 && y + incY >= 0 && x + incX < boardSize && y + incY < boardSize) && 
                                    ((prevBoard.piece[x + incX, y + incY].piece_type == ' ')  ||
                                    (!(prevBoard.piece[x + incX, y + incY].piece_type == ' ') && (prevBoard.piece[x + incX, y + incY].white == false))))
                                {
                                    Board tmpBoard = new Board();
                                    tmpBoard = MovePiece(prevBoard, 'k', true, x, y, x + incX, y + incY);
                                    permutationsForecast.Add(tmpBoard);
                                }

                                //king move NE
                                incX = 1; incY = 1;
                                if ((x + incX >= 0 && y + incY >= 0 && x + incX < boardSize && y + incY < boardSize) &&
                                    ((prevBoard.piece[x + incX, y + incY].piece_type == ' ') ||
                                    (!(prevBoard.piece[x + incX, y + incY].piece_type == ' ') && (prevBoard.piece[x + incX, y + incY].white == false))))
                                {
                                    Board tmpBoard = new Board();
                                    tmpBoard = MovePiece(prevBoard, 'k', true, x, y, x + incX, y + incY);
                                    permutationsForecast.Add(tmpBoard);
                                }

                                //king move E
                                incX = 1; incY = 0;
                                if ((x + incX >= 0 && y + incY >= 0 && x + incX < boardSize && y + incY < boardSize) &&
                                    ((prevBoard.piece[x + incX, y + incY].piece_type == ' ') ||
                                    (!(prevBoard.piece[x + incX, y + incY].piece_type == ' ') && (prevBoard.piece[x + incX, y + incY].white == false))))
                                {
                                    Board tmpBoard = new Board();
                                    tmpBoard = MovePiece(prevBoard, 'k', true, x, y, x + incX, y + incY);
                                    permutationsForecast.Add(tmpBoard);
                                }

                                //king move SE
                                incX = 1; incY = -1;
                                if ((x + incX >= 0 && y + incY >= 0 && x + incX < boardSize && y + incY < boardSize) &&
                                    ((prevBoard.piece[x + incX, y + incY].piece_type == ' ') ||
                                    (!(prevBoard.piece[x + incX, y + incY].piece_type == ' ') && (prevBoard.piece[x + incX, y + incY].white == false))))
                                {
                                    Board tmpBoard = new Board();
                                    tmpBoard = MovePiece(prevBoard, 'k', true, x, y, x + incX, y + incY);
                                    permutationsForecast.Add(tmpBoard);
                                }

                                //king move S
                                incX = 0; incY = -1;
                                if ((x + incX >= 0 && y + incY >= 0 && x + incX < boardSize && y + incY < boardSize) &&
                                    ((prevBoard.piece[x + incX, y + incY].piece_type == ' ') ||
                                    (!(prevBoard.piece[x + incX, y + incY].piece_type == ' ') && (prevBoard.piece[x + incX, y + incY].white == false))))
                                {
                                    Board tmpBoard = new Board();
                                    tmpBoard = MovePiece(prevBoard, 'k', true, x, y, x + incX, y + incY);
                                    permutationsForecast.Add(tmpBoard);
                                }

                                //king move SW
                                incX = -1; incY = -1;
                                if ((x + incX >= 0 && y + incY >= 0 && x + incX < boardSize && y + incY < boardSize) &&
                                    ((prevBoard.piece[x + incX, y + incY].piece_type == ' ') ||
                                    (!(prevBoard.piece[x + incX, y + incY].piece_type == ' ') && (prevBoard.piece[x + incX, y + incY].white == false))))
                                {
                                    Board tmpBoard = new Board();
                                    tmpBoard = MovePiece(prevBoard, 'k', true, x, y, x + incX, y + incY);
                                    permutationsForecast.Add(tmpBoard);
                                }

                                //king move W
                                incX = -1; incY = 0;
                                if ((x + incX >= 0 && y + incY >= 0 && x + incX < boardSize && y + incY < boardSize) &&
                                    ((prevBoard.piece[x + incX, y + incY].piece_type == ' ') ||
                                    (!(prevBoard.piece[x + incX, y + incY].piece_type == ' ') && (prevBoard.piece[x + incX, y + incY].white == false))))
                                {
                                    Board tmpBoard = new Board();
                                    tmpBoard = MovePiece(prevBoard, 'k', true, x, y, x + incX, y + incY);
                                    permutationsForecast.Add(tmpBoard);
                                }

                                //king move NW
                                incX = -1; incY = 1;
                                if ((x + incX >= 0 && y + incY >= 0 && x + incX < boardSize && y + incY < boardSize) &&
                                    ((prevBoard.piece[x + incX, y + incY].piece_type == ' ') ||
                                    (!(prevBoard.piece[x + incX, y + incY].piece_type == ' ') && (prevBoard.piece[x + incX, y + incY].white == false))))
                                {
                                    Board tmpBoard = new Board();
                                    tmpBoard = MovePiece(prevBoard, 'k', true, x, y, x + incX, y + incY);
                                    permutationsForecast.Add(tmpBoard);
                                }
                            }

                        }
                        else //Black move
                        {
                            if (prevBoard.piece[x, y].piece_type == ('p') && prevBoard.piece[x, y].white == false)
                            {
                                //pawn move fwd 1 tile
                                incX = 0; incY = -1;
                                if (x + incX >= 0 && y + incY >= 0 && x + incX < boardSize && y + incY < boardSize && prevBoard.piece[x + incX, y + incY].piece_type == ' ')
                                {
                                    Board tmpBoard = new Board();
                                    tmpBoard = MovePiece(prevBoard, 'p', false, x, y, x + incX, y + incY);
                                    permutationsForecast.Add(tmpBoard);
                                }

                                //pawn move fwd 2 tiles
                                incX = 0; incY = -2;
                                if (y == 6 && prevBoard.piece[x, y - 1].piece_type == ' ' && prevBoard.piece[x + incX, y + incY].piece_type == ' ')
                                {
                                    Board tmpBoard = new Board();
                                    tmpBoard = MovePiece(prevBoard, 'p', false, x, y, x + incX, y + incY);
                                    tmpBoard.piece[x + incX, y + incY].twoSquare = depth;
                                    permutationsForecast.Add(tmpBoard);
                                }

                                //capture right
                                incX = 1; incY = -1;
                                if (x + incX >= 0 && y + incY >= 0 && x + incX < boardSize && y + incY < boardSize &&
                                    !(prevBoard.piece[x + incX, y + incY].piece_type == ' ') && (prevBoard.piece[x + incX, y + incY].white))
                                {
                                    Board tmpBoard = new Board();
                                    tmpBoard = MovePiece(prevBoard, 'p', false, x, y, x + incX, y + incY);
                                    permutationsForecast.Add(tmpBoard);
                                }

                                //capture left
                                incX = -1; incY = -1;
                                if (x + incX >= 0 && y + incY >= 0 && x + incX < boardSize && y + incY < boardSize &&
                                    !(prevBoard.piece[x + incX, y + incY].piece_type == ' ') && (prevBoard.piece[x + incX, y + incY].white))
                                {
                                    Board tmpBoard = new Board();
                                    tmpBoard = MovePiece(prevBoard, 'p', false, x, y, x + incX, y + incY);
                                    permutationsForecast.Add(tmpBoard);
                                }

                                //capture right enpassant
                                incX = 1; incY = -1;
                                if (x + incX >= 0 && y + incY >= 0 && x + incX < boardSize && y + incY < boardSize &&
                                    prevBoard.piece[x + incX, y].piece_type == 'p' && prevBoard.piece[x + incX, y].twoSquare == depth - 1 && (prevBoard.piece[x + incX, y].white))
                                {
                                    Board tmpBoard = new Board();
                                    tmpBoard = MovePiece(prevBoard, 'p', false, x, y, x + incX, y + incY);
                                    tmpBoard.piece[x + incX, y].piece_type = ' ';
                                    permutationsForecast.Add(tmpBoard);
                                    //TO DO check if last move was enpassant
                                }

                                //capture left enpassant
                                incX = -1; incY = -1;
                                if (x + incX >= 0 && y + incY >= 0 && x + incX < boardSize && y + incY < boardSize &&
                                    prevBoard.piece[x + incX, y].piece_type == 'p' && prevBoard.piece[x + incX, y].twoSquare == depth - 1 && (prevBoard.piece[x + incX, y].white))
                                {
                                    Board tmpBoard = new Board();
                                    tmpBoard = MovePiece(prevBoard, 'p', false, x, y, x + incX, y + incY);
                                    tmpBoard.piece[x + incX, y].piece_type = ' ';
                                    permutationsForecast.Add(tmpBoard);
                                    //TO DO check if last move was enpassant
                                }
                            }
                            if (prevBoard.piece[x, y].piece_type == ('k') && prevBoard.piece[x, y].white == false)
                            {
                                //king move N
                                incX = 0; incY = 1;
                                if ((x + incX >= 0 && y + incY >= 0 && x + incX < boardSize && y + incY < boardSize) &&
                                    ((prevBoard.piece[x + incX, y + incY].piece_type == ' ') ||
                                    (!(prevBoard.piece[x + incX, y + incY].piece_type == ' ') && (prevBoard.piece[x + incX, y + incY].white == true))))
                                {
                                    Board tmpBoard = new Board();
                                    tmpBoard = MovePiece(prevBoard, 'k', false, x, y, x + incX, y + incY);
                                    permutationsForecast.Add(tmpBoard);
                                }

                                //king move NE
                                incX = 1; incY = 1;
                                if ((x + incX >= 0 && y + incY >= 0 && x + incX < boardSize && y + incY < boardSize) &&
                                    ((prevBoard.piece[x + incX, y + incY].piece_type == ' ') ||
                                    (!(prevBoard.piece[x + incX, y + incY].piece_type == ' ') && (prevBoard.piece[x + incX, y + incY].white == true))))
                                {
                                    Board tmpBoard = new Board();
                                    tmpBoard = MovePiece(prevBoard, 'k', false, x, y, x + incX, y + incY);
                                    permutationsForecast.Add(tmpBoard);
                                }

                                //king move E
                                incX = 1; incY = 0;
                                if ((x + incX >= 0 && y + incY >= 0 && x + incX < boardSize && y + incY < boardSize) &&
                                    ((prevBoard.piece[x + incX, y + incY].piece_type == ' ') ||
                                    (!(prevBoard.piece[x + incX, y + incY].piece_type == ' ') && (prevBoard.piece[x + incX, y + incY].white == true))))
                                {
                                    Board tmpBoard = new Board();
                                    tmpBoard = MovePiece(prevBoard, 'k', false, x, y, x + incX, y + incY);
                                    permutationsForecast.Add(tmpBoard);
                                }

                                //king move SE
                                incX = 1; incY = -1;
                                if ((x + incX >= 0 && y + incY >= 0 && x + incX < boardSize && y + incY < boardSize) &&
                                    ((prevBoard.piece[x + incX, y + incY].piece_type == ' ') ||
                                    (!(prevBoard.piece[x + incX, y + incY].piece_type == ' ') && (prevBoard.piece[x + incX, y + incY].white == true))))
                                {
                                    Board tmpBoard = new Board();
                                    tmpBoard = MovePiece(prevBoard, 'k', false, x, y, x + incX, y + incY);
                                    permutationsForecast.Add(tmpBoard);
                                }

                                //king move S
                                incX = 0; incY = -1;
                                if ((x + incX >= 0 && y + incY >= 0 && x + incX < boardSize && y + incY < boardSize) &&
                                    ((prevBoard.piece[x + incX, y + incY].piece_type == ' ') ||
                                    (!(prevBoard.piece[x + incX, y + incY].piece_type == ' ') && (prevBoard.piece[x + incX, y + incY].white == true))))
                                {
                                    Board tmpBoard = new Board();
                                    tmpBoard = MovePiece(prevBoard, 'k', false, x, y, x + incX, y + incY);
                                    permutationsForecast.Add(tmpBoard);
                                }

                                //king move SW
                                incX = -1; incY = -1;
                                if ((x + incX >= 0 && y + incY >= 0 && x + incX < boardSize && y + incY < boardSize) &&
                                    ((prevBoard.piece[x + incX, y + incY].piece_type == ' ') ||
                                    (!(prevBoard.piece[x + incX, y + incY].piece_type == ' ') && (prevBoard.piece[x + incX, y + incY].white == true))))
                                {
                                    Board tmpBoard = new Board();
                                    tmpBoard = MovePiece(prevBoard, 'k', false, x, y, x + incX, y + incY);
                                    permutationsForecast.Add(tmpBoard);
                                }

                                //king move W
                                incX = -1; incY = 0;
                                if ((x + incX >= 0 && y + incY >= 0 && x + incX < boardSize && y + incY < boardSize) &&
                                    ((prevBoard.piece[x + incX, y + incY].piece_type == ' ') ||
                                    (!(prevBoard.piece[x + incX, y + incY].piece_type == ' ') && (prevBoard.piece[x + incX, y + incY].white == true))))
                                {
                                    Board tmpBoard = new Board();
                                    tmpBoard = MovePiece(prevBoard, 'k', false, x, y, x + incX, y + incY);
                                    permutationsForecast.Add(tmpBoard);
                                }

                                //king move NW
                                incX = -1; incY = 1;
                                if ((x + incX >= 0 && y + incY >= 0 && x + incX < boardSize && y + incY < boardSize) &&
                                    ((prevBoard.piece[x + incX, y + incY].piece_type == ' ') ||
                                    (!(prevBoard.piece[x + incX, y + incY].piece_type == ' ') && (prevBoard.piece[x + incX, y + incY].white == true))))
                                {
                                    Board tmpBoard = new Board();
                                    tmpBoard = MovePiece(prevBoard, 'k', false, x, y, x + incX, y + incY);
                                    permutationsForecast.Add(tmpBoard);
                                }
                            }
                        }
                    }
                }
            }
            //throw new NotImplementedException();
        }

        private Board CopyBoard(Board source_board)
        {
            //source_board = new Board();
            Board destination_Board = new Board();
            for (int y = 0; y < source_board.piece.GetLength(0); y++)
            {
                for (int x = 0; x < source_board.piece.GetLength(1); x++)
                {
                    if (!(source_board.piece[x, y].piece_type == ' '))
                    {
                        destination_Board.piece[x, y].piece_type = source_board.piece[x, y].piece_type;
                        destination_Board.piece[x, y].white = source_board.piece[x, y].white;
                        destination_Board.piece[x, y].enPassant = source_board.piece[x, y].enPassant;
                        destination_Board.piece[x, y].twoSquare = source_board.piece[x, y].twoSquare;
                        destination_Board.piece[x, y].castling = source_board.piece[x, y].castling;
                    }
                }
            }
            destination_Board.current_move = source_board.current_move;
            destination_Board.wScore = source_board.wScore;
            destination_Board.bScore = source_board.bScore;
            destination_Board.isWhiteMove = source_board.isWhiteMove;
            return destination_Board;
            //throw new NotImplementedException();
        }

        private Board MovePiece(Board prevBoard, char piece, bool white, int x1, int y1, int x2, int y2)
        {            
            Board tmpBoard = new Board();
            tmpBoard = CopyBoard(prevBoard);
            tmpBoard.piece[x1, y1].piece_type = ' ';
            tmpBoard.piece[x2, y2].piece_type = piece;
            tmpBoard.piece[x2, y2].white = white;
            //if (string.IsNullOrEmpty(tmpBoard.current_move)) tmpBoard.current_move = Environment.NewLine + GetPGN(piece.ToString(), x1, y1, x2, y2);
            //else if (tmpBoard.isWhiteMove) tmpBoard.current_move += Environment.NewLine + GetPGN(piece.ToString(), x1, y1, x2, y2);
            if (string.IsNullOrEmpty(tmpBoard.current_move)) tmpBoard.current_move = ((depth / 2) + 1) + ". " + GetPGN(piece.ToString(), x1, y1, x2, y2);
            else if (tmpBoard.isWhiteMove) tmpBoard.current_move += " " + ((depth / 2) + 1) + ". " + GetPGN(piece.ToString(), x1, y1, x2, y2);
            else tmpBoard.current_move += " " + GetPGN(piece.ToString(), x1, y1, x2, y2);
            tmpBoard.isWhiteMove = !white;
            return tmpBoard;
            //throw new NotImplementedException();
        }

        private string GetPGN(string piece, int s1, int s2, int d1, int d2)
        {
            string tmpPGN = "";
            //char ts1, td1;
            //if(piece.Equals("p"))
            //{
            //    tmpPGN = "P";
            //}
            if (s1 == 0) tmpPGN += "a";
            else if (s1 == 1) tmpPGN += "b";
            else if (s1 == 2) { tmpPGN += "c"; }
            else if (s1 == 3) { tmpPGN += "d"; }
            else if (s1 == 4) { tmpPGN += "e"; }
            else if (s1 == 5) { tmpPGN += "f"; }
            else if (s1 == 6) { tmpPGN += "g"; }
            else if (s1 == 7) { tmpPGN += "h"; }
            tmpPGN += s2 + 1;
            tmpPGN += "-";
            if (d1 == 0) { tmpPGN += "a"; }
            else if (d1 == 1) { tmpPGN += "b"; }
            else if (d1 == 2) { tmpPGN += "c"; }
            else if (d1 == 3) { tmpPGN += "d"; }
            else if (d1 == 4) { tmpPGN += "e"; }
            else if (d1 == 5) { tmpPGN += "f"; }
            else if (d1 == 6) { tmpPGN += "g"; }
            else if (d1 == 7) { tmpPGN += "h"; }
            tmpPGN += d2 + 1;

            return tmpPGN;
            //throw new NotImplementedException();
        }

        private void DisplayPermutations(bool log)
        {
            if (log)
            {
                for (int h = 0; h < permutationsForecast.Count(); h++)
                {
                    Board tmpBoard = new Board();
                    tmpBoard = permutationsForecast[h];
                    for (int y = 0; y < tmpBoard.piece.GetLength(0); y++)
                    {
                        for (int x = 0; x < tmpBoard.piece.GetLength(1); x++)
                        {
                            if (!(tmpBoard.piece[x, y].piece_type == ' ')) Console.WriteLine("Board" + h + " - piece[" + x + "," + y + "] = " + tmpBoard.piece[x, y].piece_type + " - isWhite = " + tmpBoard.piece[x, y].white);
                        }
                    }
                    Console.WriteLine("Board" + h + " - CurrentMove = " + tmpBoard.current_move);
                    Console.WriteLine("Board" + h + " - wScore = " + tmpBoard.wScore);
                    Console.WriteLine("Board" + h + " - bScore = " + tmpBoard.bScore);
                    Console.WriteLine("--------------------------------------------");
                }

            }
        }

        private void DisplayBoard(string permNbr)
        {
            rtbBoard.Clear();
            Board tmpBoard = new Board();
            tmpBoard = permutationsForecast[int.Parse(permNbr)];
            string strBoard;

            strBoard = "   *-0-*-1-*-2-*-3-*-4-*-5-*-6-*-7-*" + Environment.NewLine;
            strBoard += "   *---*---*---*---*---*---*---*---*" + Environment.NewLine;

            for (int y = tmpBoard.piece.GetLength(1) - 1; y >= 0; y--)
            {
                strBoard += " " + (y + 1) + " |";
                for (int x = 0; x < tmpBoard.piece.GetLength(0); x++)
                {
                    if (tmpBoard.piece[x, y].piece_type == ' ')
                    {
                        strBoard += "   |";
                    }
                    else
                    {
                        strBoard += " ";                      
                        AppendText(Color.Black, false, strBoard);
                        if (tmpBoard.piece[x, y].white) AppendText(Color.White, true, tmpBoard.piece[x, y].piece_type.ToString());
                        else AppendText(Color.Black, true, tmpBoard.piece[x, y].piece_type.ToString());
                        strBoard = " |";
                    }
                }
                strBoard += " " + y + Environment.NewLine;
                strBoard += "   *---*---*---*---*---*---*---*---*" + Environment.NewLine;
            }
            strBoard += "   * A * B * C * D * E * F * G * H *" + Environment.NewLine;
            
            strBoard += "Notation " + tmpBoard.current_move + Environment.NewLine;
            strBoard += "White Score = " + tmpBoard.wScore + Environment.NewLine;
            strBoard += "Black Score = " + tmpBoard.bScore + Environment.NewLine;

            AppendText(Color.Black, false, strBoard);
            //throw new NotImplementedException();
        }

        private void AppendText(Color color, bool bold, string text)
        {
            int start = rtbBoard.TextLength;
            rtbBoard.AppendText(text);
            int end = rtbBoard.TextLength;

            rtbBoard.Select(start, end - start);
            {
                rtbBoard.SelectionColor = color;
                if(bold) rtbBoard.SelectionFont = new Font(rtbBoard.Font.Name,rtbBoard.Font.Size,FontStyle.Bold);
                else rtbBoard.SelectionFont = new Font(rtbBoard.Font.Name, rtbBoard.Font.Size, FontStyle.Regular);
            }
            rtbBoard.SelectionLength = 0; // clear
        }

        private void MoveScore()
        {
            for (int h = 0; h < permutationsForecast.Count(); h++)
            {
                Board current_Board = new Board();
                current_Board = permutationsForecast[h];
                current_Board.wScore = 0;
                current_Board.bScore = 0;
                for (int y = 0; y < current_Board.piece.GetLength(1); y++)
                {
                    for (int x = 0; x < current_Board.piece.GetLength(0); x++)
                    {
                        if (current_Board.piece[x, y].piece_type == 'k')
                        {
                            if (current_Board.piece[x, y].white) current_Board.wScore += 1000;
                            else current_Board.bScore += -1000;
                        }
                        else if (current_Board.piece[x, y].piece_type == 'p')
                        {
                            if (current_Board.piece[x, y].white) current_Board.wScore += 10;
                            else current_Board.bScore += -10;
                        }
                        
                    }
                }
                if ((current_Board.wScore + current_Board.bScore) >= wBestScore[1])
                {
                    wBestDepth[1] = depth;
                    wBestPerm[1] = h;
                    wBestScore[1] = current_Board.wScore + current_Board.bScore;
                    wBestMove[1] = current_Board.current_move;                                        
                }
                if ((current_Board.wScore + current_Board.bScore) <= bBestScore[1]) 
                {
                    bBestDepth[1] = depth;
                    bBestPerm[1] = h;
                    bBestScore[1] = current_Board.wScore + current_Board.bScore;
                    bBestMove[1] = current_Board.current_move;
                }
                dataGridView1.Rows.Add(depth, h, permutationsForecast.Count(), current_Board.wScore + current_Board.bScore, current_Board.current_move);
            }
            //throw new NotImplementedException();
        }
        
        private void btnNext_Click(object sender, EventArgs e)
        {
            int iPermNbr = int.Parse(txtPermNbr.Text) + 1;
            txtPermNbr.Text = iPermNbr.ToString();
            btnBack.Enabled = true;
            if (permutationsForecast.Count - 1 == iPermNbr) btnNext.Enabled = false;
            DisplayBoard(txtPermNbr.Text);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            int iPermNbr = int.Parse(txtPermNbr.Text) - 1;
            txtPermNbr.Text = iPermNbr.ToString();
            btnNext.Enabled = true;
            if (iPermNbr == 0) btnBack.Enabled = false;
            DisplayBoard(txtPermNbr.Text);
        }


    }
}
