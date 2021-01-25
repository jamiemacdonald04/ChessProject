// <copyright file="IGameMoves.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace SolarWinds.MSP.Chess.Core.Interface
{
    using System.Collections.Generic;
    using SolarWinds.MSP.Chess.Interface;
    using SolarWinds.MSP.Chess.Models;

    /// <summary>
    /// intended for game play but will use in some test to show segregation principle working.
    /// </summary>
    public interface IGameMoves
    {
        /// <summary>
        /// Moving pieces to the board.
        /// </summary>
        /// <param name="piece">This can be any piece within the game.  Going forward this will be a knight, king etc.</param>
        /// <param name="coordinates">Which space along the x should the piece sit.</param>
        /// <param name="chessBoardGameSquares">The chess Board Game Squares.</param>
        public void MovePieceOnBoard(IPieceStrategy piece, Coordinate coordinates, List<BoardSquare> chessBoardGameSquares);
    }
}
