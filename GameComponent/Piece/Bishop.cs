using GameComponent.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameComponent.Piece
{
    public class Bishop : Piece
    {
        public Bishop(Colour colour, Position position, Board board)
        {
            this.Colour = colour;
            this.CurrentPosition = position;
            this.Name = "Bishop";
            this.board = board;
        }
        public override List<Position> ValidMoves()
        {
            var validMoves = new List<Position>();
            bool isFrontLeftBlocked = false;
            bool isFrontRightBlocked = false;
            bool isBackLeftBlocked = false;
            bool isBackRightBlocked = false;
            for (int i = 1; i < 8; i++)
            {
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
