using GameComponent.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameComponent.Piece
{
    public class Pawn : Piece
    {
        private bool isFirstMove;
        public Pawn(Colour colour, Position position, Board board)
        {
            this.Colour = colour;
            this.CurrentPosition = position;
            this.board = board;
            this.Name = "Pawn";
            isFirstMove = true;
        }
        public override List<Position> ValidMoves()
        {
            var validMoves = new List<Position>();
            bool isFrontBlocked = false;

            #region first step
            if (this.Colour == Colour.Black)
            {
                isFrontBlocked = isFrontBlocked || board.IsAnyPieceAvailable(this.CurrentPosition.X, this.CurrentPosition.Y + 1);
                if (!isFrontBlocked)
                {
                    validMoves.Add(new Position(this.CurrentPosition.X, this.CurrentPosition.Y + 1));
                }
            }
            else
            {
                isFrontBlocked = isFrontBlocked || board.IsAnyPieceAvailable(this.CurrentPosition.X, this.CurrentPosition.Y - 1);
                if (!isFrontBlocked)
                {
                    validMoves.Add(new Position(this.CurrentPosition.X, this.CurrentPosition.Y - 1));
                }
            }
            #endregion

            #region double step
            if (isFirstMove)
            {
                if (this.Colour == Colour.Black)
                {
                    isFrontBlocked = isFrontBlocked || board.IsAnyPieceAvailable(this.CurrentPosition.X, this.CurrentPosition.Y + 2);
                    if (!isFrontBlocked)
                    {
                        validMoves.Add(new Position(this.CurrentPosition.X, this.CurrentPosition.Y + 2));
                    }
                }
                else
                {
                    isFrontBlocked = isFrontBlocked || board.IsAnyPieceAvailable(this.CurrentPosition.X, this.CurrentPosition.Y - 2);
                    if (!isFrontBlocked)
                    {
                        validMoves.Add(new Position(this.CurrentPosition.X, this.CurrentPosition.Y - 2));
                    }
                }
            }
            #endregion

            #region cross step
            if (this.Colour == Colour.Black)
            {
                if (board.IsAnyPieceAvailable(this.CurrentPosition.X + 1, this.CurrentPosition.Y + 1, this.Colour.GetOpposite()))
                {
                    validMoves.Add(new Position(this.CurrentPosition.X + 1, this.CurrentPosition.Y + 1));
                }
                if (board.IsAnyPieceAvailable(this.CurrentPosition.X - 1, this.CurrentPosition.Y + 1, this.Colour.GetOpposite()))
                {
                    validMoves.Add(new Position(this.CurrentPosition.X - 1, this.CurrentPosition.Y + 1));
                }
            }
            else
            {
                if (board.IsAnyPieceAvailable(this.CurrentPosition.X + 1, this.CurrentPosition.Y - 1, this.Colour.GetOpposite()))
                {
                    validMoves.Add(new Position(this.CurrentPosition.X + 1, this.CurrentPosition.Y - 1));
                }
                if (board.IsAnyPieceAvailable(this.CurrentPosition.X - 1, this.CurrentPosition.Y - 1, this.Colour.GetOpposite()))
                {
                    validMoves.Add(new Position(this.CurrentPosition.X - 1, this.CurrentPosition.Y - 1));
                }
            }
            #endregion

            FilterOutOfBoardMoves(validMoves);
            return validMoves;
        }
        public override void MakeMove(int x, int y)
        {
            if (isFirstMove)
            {
                isFirstMove = false;
            }
            this.CurrentPosition.X = x;
            this.CurrentPosition.Y = y;
            this.board.ToQueen(this);
        }
    }
}
