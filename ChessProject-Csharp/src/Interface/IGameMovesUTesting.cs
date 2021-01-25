// <copyright file="IGameMovesUTesting.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace SolarWinds.MSP.Chess.Core.Interface
{
    using System.Collections.Generic;
    using SolarWinds.MSP.Chess.Core.Models;
    using SolarWinds.MSP.Chess.Interface;
    using SolarWinds.MSP.Chess.Models;

    /// <summary>
    /// intended for unit tests.
    /// </summary>
    public interface IGameMovesUTesting
    {
        /// <summary>
        /// Will collision happen in this Move on the board.
        /// </summary>
        /// <param name="possibleNextMoves">The possible next moves.</param>
        /// <param name="intendedSquare">The intended square.</param>
        /// <returns>true if the piece will collide, false if he square is empty or they can take.</returns>
        public bool WillCollisionHappenInMove(List<MoveDetial> possibleNextMoves, BoardSquare intendedSquare);

        /// <summary>
        /// Intended move an option for piece.
        /// </summary>
        /// <param name="possibleMoveCoordinates">The possible next moves.</param>
        /// <param name="intendedMovecCoordinates">The moving x coordinate.</param>
        /// <returns>true if this move is an option, else false if it is not an option.</returns>
        public bool IsMoveAnOption(IEnumerable<Coordinate> possibleMoveCoordinates, Coordinate intendedMovecCoordinates);

        /// <summary>
        /// Moving pieces to the board.
        /// </summary>
        /// <param name="piece">this can be any piece within the game.  Going forward this will be a knight, king etc.</param>
        /// <param name="coordinates">coordinates of the board.</param>
        /// <param name="chessBoardGameSquares">Chessboard squares.</param>
        public void MovePieceOnBoard(IPieceStrategy piece, Coordinate coordinates, List<BoardSquare> chessBoardGameSquares);
    }
}
