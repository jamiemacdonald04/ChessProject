// <copyright file="IChessBoardHelper.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace SolarWinds.MSP.Chess.Core.Interface
{
    using System.Collections.Generic;
    using SolarWinds.MSP.Chess.Interface;
    using SolarWinds.MSP.Chess.Models;

    /// <summary>
    /// helper for the chess board methods that sit outside of the class itself.
    /// </summary>
    internal interface IChessBoardHelper
    {
        /// <summary>
        /// Determines whether [is legal board position] [the specified board square].
        /// </summary>
        /// <param name="boardSquare">The board square.</param>
        /// <returns>
        ///   <c>true</c> if [is legal board position] [the specified board square]; otherwise, <c>false</c>.
        /// </returns>
        internal bool IsLegalBoardPosition(Coordinate boardSquare);

        /// <summary>
        /// Gets the board square.
        /// </summary>
        /// <param name="chessboardSquares">The chessboard Squares.</param>
        /// <param name="coordinates">The coordinates.</param>
        /// <returns>board square at location.</returns>
        internal BoardSquare GetSquare(List<BoardSquare> chessboardSquares, Coordinate coordinates);

        /// <summary>
        /// Gets the piece's current location.
        /// </summary>
        /// <param name="chessboardSquares">The chessboard Squares.</param>
        /// <param name="piece">The piece.</param>
        /// <returns>the board square.</returns>
        internal BoardSquare GetPiecesCurrentLocation(List<BoardSquare> chessboardSquares, IPieceStrategy piece);
    }
}
