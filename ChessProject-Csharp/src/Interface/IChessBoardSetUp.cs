// <copyright file="IChessBoardSetUp.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SolarWinds.MSP.Chess.Core.Interface
{
    using System.Collections.Generic;
    using SolarWinds.MSP.Chess.Models;

    /// <summary>
    /// Chessboard setup.
    /// </summary>
    internal interface IChessBoardSetUp
    {
        /// <summary>
        /// Sets up the board this instance.
        /// </summary>
        /// <returns>returns the game squares.</returns>
        internal List<BoardSquare> Setupboard();
    }
}
