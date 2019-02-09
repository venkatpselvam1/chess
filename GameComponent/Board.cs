using GameComponent.Enum;
using GameComponent.Piece;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace GameComponent
{
    public class Board
    {
        private List<Piece.Piece> Pieces { get; }
        public Colour CurrenTurn { get; private set; }
        public Board()
        {
            CurrenTurn = Colour.White;
            this.Pieces = new List<Piece.Piece>();
            #region black
            this.Pieces.Add(new Pawn(Enum.Colour.Black, new Position(1, 2), this));
            this.Pieces.Add(new Pawn(Enum.Colour.Black, new Position(2, 2), this));
            this.Pieces.Add(new Pawn(Enum.Colour.Black, new Position(3, 2), this));
            this.Pieces.Add(new Pawn(Enum.Colour.Black, new Position(4, 2), this));
            this.Pieces.Add(new Pawn(Enum.Colour.Black, new Position(5, 2), this));
            this.Pieces.Add(new Pawn(Enum.Colour.Black, new Position(6, 2), this));
            this.Pieces.Add(new Pawn(Enum.Colour.Black, new Position(7, 2), this));
            this.Pieces.Add(new Pawn(Enum.Colour.Black, new Position(8, 2), this));

            this.Pieces.Add(new Bishop(Enum.Colour.Black, new Position(3, 1), this));
            this.Pieces.Add(new Bishop(Enum.Colour.Black, new Position(6, 1), this));

            this.Pieces.Add(new Knight(Enum.Colour.Black, new Position(2, 1), this));
            this.Pieces.Add(new Knight(Enum.Colour.Black, new Position(7, 1), this));

            this.Pieces.Add(new Rook(Enum.Colour.Black, new Position(1, 1), this));
            this.Pieces.Add(new Rook(Enum.Colour.Black, new Position(8, 1), this));

            this.Pieces.Add(new King(Enum.Colour.Black, new Position(4, 1), this));
            this.Pieces.Add(new Queen(Enum.Colour.Black, new Position(5, 1), this));
            #endregion
            #region White
            this.Pieces.Add(new Pawn(Enum.Colour.White, new Position(1, 7), this));
            this.Pieces.Add(new Pawn(Enum.Colour.White, new Position(2, 7), this));
            this.Pieces.Add(new Pawn(Enum.Colour.White, new Position(3, 7), this));
            this.Pieces.Add(new Pawn(Enum.Colour.White, new Position(4, 7), this));
            this.Pieces.Add(new Pawn(Enum.Colour.White, new Position(5, 7), this));
            this.Pieces.Add(new Pawn(Enum.Colour.White, new Position(6, 7), this));
            this.Pieces.Add(new Pawn(Enum.Colour.White, new Position(7, 7), this));
            this.Pieces.Add(new Pawn(Enum.Colour.White, new Position(8, 7), this));

            this.Pieces.Add(new Bishop(Enum.Colour.White, new Position(3, 8), this));
            this.Pieces.Add(new Bishop(Enum.Colour.White, new Position(6, 8), this));

            this.Pieces.Add(new Knight(Enum.Colour.White, new Position(2, 8), this));
            this.Pieces.Add(new Knight(Enum.Colour.White, new Position(7, 8), this));

            this.Pieces.Add(new Rook(Enum.Colour.White, new Position(1, 8), this));
            this.Pieces.Add(new Rook(Enum.Colour.White, new Position(8, 8), this));

            this.Pieces.Add(new King(Enum.Colour.White, new Position(5, 8), this));
            this.Pieces.Add(new Queen(Enum.Colour.White, new Position(4, 8), this));
            #endregion
        }

        internal bool IsAnyPieceAvailable(int x, int y)
        {
            return this.Pieces.Any(p => p.CurrentPosition.X == x && p.CurrentPosition.Y == y);
        }
        internal bool IsAnyPieceAvailable(int x, int y, Colour colour)
        {
            return this.Pieces.Any(p => p.CurrentPosition.X == x && p.CurrentPosition.Y == y && p.Colour == colour);
        }
        public string GetJson()
        {
            var t = JsonConvert.SerializeObject(this.Pieces, Formatting.Indented);
            return t;
        }
        public string GetHintJson(int x, int y)
        {
            var hintMoves = this.GetHint(x, y);
            var hints = JsonConvert.SerializeObject(hintMoves, Formatting.Indented);
            return hints;
        }

        internal void ToQueen(Pawn pawn)
        {
            if (pawn.Colour == Colour.Black && pawn.CurrentPosition.Y == 8)
            {
                this.Pieces.Remove(pawn);
                this.Pieces.Add(new Queen(pawn.Colour, pawn.CurrentPosition, this));
            }
            if (pawn.Colour == Colour.White && pawn.CurrentPosition.Y == 1)
            {
                this.Pieces.Remove(pawn);
                this.Pieces.Add(new Queen(pawn.Colour, pawn.CurrentPosition, this));
            }
        }

        public List<Position> GetHint(int x, int y)
        {
            try
            {
                Piece.Piece currentPiece = this.Pieces.First(p => p.CurrentPosition.X == x && p.CurrentPosition.Y == y && p.Colour == this.CurrenTurn);
                return currentPiece.ValidMoves();
            }
            catch (Exception)
            {

            }
            return new List<Position>();
        }
        internal bool MakeMove(int x1, int y1, int x2, int y2)
        {
            Piece.Piece currentPiece = this.Pieces.First(p => p.CurrentPosition.X == x1 && p.CurrentPosition.Y == y1 && p.Colour == this.CurrenTurn);
            var validMoves = currentPiece.ValidMoves().Where(p => p.X == x2 && p.Y == y2);
            if (!validMoves.Any())
            {
                return false;
            }

            #region Make the move
            this.Pieces.RemoveAll(p => p.CurrentPosition.X == x2 && p.CurrentPosition.Y == y2);
            currentPiece.MakeMove(x2, y2);
            int t = (int)Convert.ChangeType(CurrenTurn, CurrenTurn.GetTypeCode());
            CurrenTurn = (Enum.Colour)((t + 1) % 2);
            #endregion
            return true;
        }

        public bool IsGameOver()
        {
            return this.Pieces.Count(x => x is King) != 2;
        }
    }
}