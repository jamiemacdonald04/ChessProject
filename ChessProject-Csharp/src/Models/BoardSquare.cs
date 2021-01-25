// <copyright file="BoardSquare.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace SolarWinds.MSP.Chess.Models
{
    using SolarWinds.MSP.Chess.Interface;

    /// <summary>
    /// the settings for each boards square.
    /// </summary>
    public sealed class BoardSquare
    {
        /// <summary>
        /// Gets or sets the location of the square.
        /// </summary>
        public Coordinate SquaresCoordinates { get; set; }

        /// <summary>
        /// Gets or sets a piece to a square.
        /// </summary>
        public IPieceStrategy Piece { get; set; }
    }
}
