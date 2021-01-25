// <copyright file="IPieceHelper.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace SolarWinds.MSP.Chess.Core.Interface
{
    using SolarWinds.MSP.Chess.Interface;
    using SolarWinds.MSP.Chess.Models;

    /// <summary>
    /// Helper methods associated with the piece.
    /// </summary>
    internal interface IPieceHelper
    {
        /// <summary>
        /// Gets the colour of the piece.
        /// </summary>
        /// <param name="piece">the piece to get colour from.</param>
        /// <returns>the pieces colour.</returns>
        internal string GetPieceColour(IPieceStrategy piece);

        /// <summary>
        /// Currents the position as string.
        /// </summary>
        /// <param name="boardSquare">The board square.</param>
        /// <param name="pieceColor">Color of the piece.</param>
        /// <returns>Current Pieces Location.</returns>
        internal string CurrentPositionAsString(BoardSquare boardSquare, string pieceColor);
    }
}
