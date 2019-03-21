using GameComponent.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameComponent.Piece
{
    public class Queen : Piece
    {
        public Queen(Colour colour, Position position, Board board)
        {
            this.Colour = colour;
            this.CurrentPosition = position;
            this.board = board;
            this.Name = "Queen";
        }
        public override List<Position> ValidMoves()
        {
            var validMoves = new List<Position>();
            bool isFrontBlocked = false;
            bool isBackBlocked = false;
            bool isRightBlocked = false;
            bool isLeftBlocked = false;
            bool isFrontLeftBlocked = false;
            bool isFrontRightBlocked = false;
            bool isBackLeftBlocked = false;
            bool isBackRightBlocked = false;

            for (int i = 1; i < 8; i++)
            {
                if (!isFrontBlocked)
                {
                    isFrontBlocked = isFrontBlocked || AddIfNotOurPiece(validMoves, this.CurrentPosition.X + i, this.CurrentPosition.Y);
                }

                if (!isBackBlocked)
                {
                    isBackBlocked = isBackBlocked || AddIfNotOurPiece(validMoves, this.CurrentPosition.X - i, this.CurrentPosition.Y);
                }

                if (!isRightBlocked)
                {
                    isRightBlocked = isRightBlocked || AddIfNotOurPiece(validMoves, this.CurrentPosition.X, this.CurrentPosition.Y + i);
                }

                if (!isLeftBlocked)
                {
                    isLeftBlocked = isLeftBlocked || AddIfNotOurPiece(validMoves, this.CurrentPosition.X, this.CurrentPosition.Y - i);
                }

                if (!isFrontLeftBlocked)
                {
                    isFrontLeftBlocked = isFrontLeftBlocked || AddIfNotOurPiece(validMoves, this.CurrentPosition.X + i, this.CurrentPosition.Y + i);
                }

                if (!isFrontRightBlocked)
                {
                    isFrontRightBlocked = isFrontRightBlocked || AddIfNotOurPiece(validMoves, this.CurrentPosition.X + i, this.CurrentPosition.Y - i);
                }

                if (!isBackLeftBlocked)
                {
                    isBackLeftBlocked = isBackLeftBlocked || AddIfNotOurPiece(validMoves, this.CurrentPosition.X - i, this.CurrentPosition.Y + i);
                }

                if (!isBackRightBlocked)
                {
                    isBackRightBlocked = isBackRightBlocked || AddIfNotOurPiece(validMoves, this.CurrentPosition.X - i, this.CurrentPosition.Y - i);
                }

            }

            FilterOutOfBoardMoves(validMoves);
            return validMoves;
        }
    }
}
