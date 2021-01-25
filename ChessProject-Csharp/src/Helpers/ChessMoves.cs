// <copyright file="ChessMoves.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace SolarWinds.MSP.Chess.Core.Helpers
{
    using System.Collections.Generic;
    using System.Linq;
    using SolarWinds.MSP.Chess.Core.Interface;
    using SolarWinds.MSP.Chess.Core.Models;
    using SolarWinds.MSP.Chess.Interface;
    using SolarWinds.MSP.Chess.Models;

    /// <summary>
    /// functions related to chess moves.
    /// </summary>
    internal class ChessMoves : IGameMoves, IGameMovesUTesting
    {
        /// <summary>
        /// Moving pieces to the board.
        /// </summary>
        /// <param name="piece">This can be any piece within the game.  Going forward this will be a knight, king etc.</param>
        /// <param name="coordinates">Which space along the x should the piece sit.</param>
        /// <param name="chessBoardGameSquares">The chess Board Game Squares.</param>
        public void MovePieceOnBoard(IPieceStrategy piece, Coordinate coordinates, List<BoardSquare> chessBoardGameSquares)
        {
            IChessBoardHelper chessboardHelper = new ChessBoardHelper();
            BoardSquare intendedSquare = chessboardHelper.GetSquare(chessBoardGameSquares, coordinates);
            BoardSquare currentSquare = chessboardHelper.GetPiecesCurrentLocation(chessBoardGameSquares, piece);

            List<MoveDetial> possibleNextMoves = currentSquare.Piece.AllPossibleNextMoves(chessboardHelper, currentSquare.SquaresCoordinates.X, currentSquare.SquaresCoordinates.Y);

            bool isPossibleMove = this.IsMoveAnOption(possibleNextMoves.Select(move => move.Coordinates), coordinates);

            if (!isPossibleMove)
            {
                return;
            }

            if (this.WillCollisionHappenInMove(possibleNextMoves, intendedSquare))
            {
                return;
            }

            currentSquare.Piece = null;
            intendedSquare.Piece = piece;
        }

        /// <summary>
        /// Will collision happen in this Move on the board.
        /// </summary>
        /// <param name="possibleNextMoves">The possible next moves.</param>
        /// <param name="intendedSquare">The intended square.</param>
        /// <returns>true if the piece will collide, false if he square is empty or they can take.</returns>
        public bool WillCollisionHappenInMove(List<MoveDetial> possibleNextMoves, BoardSquare intendedSquare)
        {
            bool willCollide = false;
            MoveDetial moveDetials = possibleNextMoves.Where(possibleMove => possibleMove.Coordinates.Y == intendedSquare.SquaresCoordinates.Y && possibleMove.Coordinates.X == intendedSquare.SquaresCoordinates.X).FirstOrDefault();
            foreach (var movedetail in moveDetials.PieceSettingForMove)
            {
                if (!movedetail.CanTake && intendedSquare.Piece != null)
                {
                    willCollide = true;
                    break;
                }
            }

            return willCollide;
        }

        /// <summary>
        /// Intended move an option for piece.
        /// </summary>
        /// <param name="possibleMoveCoordinates">The possible next moves.</param>
        /// <param name="intendedMovecCoordinates">The moving x coordinate.</param>
        /// <returns>true if this move is an option, else false if it is not an option.</returns>
        public bool IsMoveAnOption(IEnumerable<Coordinate> possibleMoveCoordinates, Coordinate intendedMovecCoordinates)
        {
            return possibleMoveCoordinates.Where(possibleMove => possibleMove.Y == intendedMovecCoordinates.Y
                                                     && possibleMove.X == intendedMovecCoordinates.X).Count() > 0;
        }
    }
}
