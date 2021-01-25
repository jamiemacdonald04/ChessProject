// <copyright file="PieceSetting.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace SolarWinds.MSP.Chess.Models
{
    using SolarWinds.MSP.Chess.Enums;

    /// <summary>
    /// user defined object to store a movement type for a chess piece and if they can take using this method.
    /// </summary>
    public sealed class PieceSetting
    {
        /// <summary>
        /// Gets or sets the move.
        /// </summary>
        /// <value>
        /// The move.
        /// </value>
        public ClassicChessMovementTypesEnum Move { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance can take.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance can take; otherwise, <c>false</c>.
        /// </value>
        public bool CanTake { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance can take.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance can take; otherwise, <c>false</c>.
        /// </value>
        public bool CanMoveMultipleSpaces { get; set; }
    }
}
