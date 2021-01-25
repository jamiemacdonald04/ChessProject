// <copyright file="ChessBoardHelper.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace SolarWinds.MSP.Chess.Core.Helpers
{
    using System.Collections.Generic;
    using System.Linq;
    using SolarWinds.MSP.Chess.Core.Interface;
    using SolarWinds.MSP.Chess.Core.Properties;
    using SolarWinds.MSP.Chess.Helpers;
    using SolarWinds.MSP.Chess.Interface;
    using SolarWinds.MSP.Chess.Models;

    /// <summary>
    /// functions to help with the administration of the board.
    /// </summary>
    internal sealed class ChessBoardHelper : IChessBoardHelper
    {
        /// <summary>
        /// Determines whether the coordinates are valid on the board.
        /// </summary>
        /// <param name="boardSquare">The board square.</param>
        /// <returns>
        ///   <c>true</c> if [is valid coordinates] [the specified board square]; otherwise, <c>false</c>.
        /// </returns>
        bool IChessBoardHelper.IsLegalBoardPosition(Coordinate boardSquare)
        {
            int maxboardHeight = IntegerHelper.ParseStringAsIntegerOrZero(ChessResource.MaxBoardHeight);
            int maxboardWidth = IntegerHelper.ParseStringAsIntegerOrZero(ChessResource.MaxBoardWidth);

            return (boardSquare.Y <= maxboardHeight && boardSquare.Y >= 0)
                && (boardSquare.X <= maxboardWidth && boardSquare.X >= 0);
        }

        /// <summary>
        /// Gets a square on the board.
        /// </summary>
        /// <param name="chessBoardGameSquares">The chessboard games squares.</param>
        /// <param name="coordinates">The coordinates.</param>
        /// <returns>the board square.</returns>
        BoardSquare IChessBoardHelper.GetSquare(List<BoardSquare> chessBoardGameSquares, Coordinate coordinates)
        {
            return chessBoardGameSquares.Where(square => square.SquaresCoordinates.X == coordinates.X && square.SquaresCoordinates.Y == coordinates.Y).FirstOrDefault();
        }

        /// <summary>
        /// Gets the piece's current location.
        /// </summary>
        /// <param name="chessBoardGameSquares">The chessboard games squares.</param>
        /// <param name="piece">The piece.</param>
        /// <returns>The Square the piece is on.</returns>
        BoardSquare IChessBoardHelper.GetPiecesCurrentLocation(List<BoardSquare> chessBoardGameSquares, IPieceStrategy piece)
        {
            return chessBoardGameSquares.Where(square => square.Piece == piece).FirstOrDefault();
        }
    }
}
