// <copyright file="PieceHelper.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace SolarWinds.MSP.Chess.Core.Helpers
{
    using System;
    using SolarWinds.MSP.Chess.Core.Interface;
    using SolarWinds.MSP.Chess.Interface;
    using SolarWinds.MSP.Chess.Models;

    /// <summary>
    /// Helper methods associated with the piece.
    /// </summary>
    public sealed class PieceHelper : IPieceHelper
    {
        /// <summary>
        /// Gets the colour of the piece.
        /// </summary>
        /// <param name="piece">the piece to get colour from.</param>
        /// <returns>the pieces colour.</returns>
        string IPieceHelper.GetPieceColour(IPieceStrategy piece)
        {
            return Enum.GetName(typeof(PieceColourEnum), piece.PieceColour);
        }

        /// <summary>
        /// Currents the position as string.
        /// </summary>
        /// <param name="boardSquare">The board square.</param>
        /// <param name="pieceColor">Color of the piece.</param>
        /// <returns>Current Pieces Location.</returns>
        string IPieceHelper.CurrentPositionAsString(BoardSquare boardSquare, string pieceColor)
        {
            return $"Current X: {boardSquare.SquaresCoordinates.X}{Environment.NewLine}Current Y: {boardSquare.SquaresCoordinates.Y}{Environment.NewLine}Piece Color: {pieceColor}";
        }
    }
}
