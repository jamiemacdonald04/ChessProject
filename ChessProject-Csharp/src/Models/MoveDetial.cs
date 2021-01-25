// <copyright file="MoveDetial.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace SolarWinds.MSP.Chess.Core.Models
{
    using System.Collections.Generic;
    using SolarWinds.MSP.Chess.Models;

    /// <summary>
    /// User type to hold the details of any moves that are possible.
    /// </summary>
    public sealed class MoveDetial
    {
        /// <summary>
        /// Gets or sets the coordinates for the move.
        /// </summary>
        /// <value>
        /// The coordinates for the move.
        /// </value>
        public Coordinate Coordinates { get; set; }

        /// <summary>
        /// Gets or sets the piece settings for move.
        /// </summary>
        /// <value>
        /// The piece settings for move.
        /// </value>
        public List<PieceSetting> PieceSettingForMove { get; set; }
    }
}
