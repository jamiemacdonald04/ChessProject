// <copyright file="IPieceStrategy.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace SolarWinds.MSP.Chess.Interface
{
    using System.Collections.Generic;
    using SolarWinds.MSP.Chess;
    using SolarWinds.MSP.Chess.Core.Enums;
    using SolarWinds.MSP.Chess.Core.Interface;
    using SolarWinds.MSP.Chess.Core.Models;
    using SolarWinds.MSP.Chess.Models;

    /// <summary>
    /// strategy for chess pieces, all chess pieces will have these properties in common.
    /// </summary>
    public interface IPieceStrategy
    {
        /// <summary>
        /// Gets or sets the name of the piece.
        /// </summary>
        /// <value>
        /// The name of the piece.
        /// </value>
        public PieceTypes PieceName { get; set; }

        /// <summary>
        /// Gets or sets the legal moves for piece.
        /// </summary>
        /// <value>
        /// The legal moves for piece.
        /// </value>
        public List<PieceSetting> PieceSettings { get; set; }

        /// <summary>
        /// Gets the color of the piece. Hiding the setter.  a little bit of interface segregation principle.
        /// </summary>
        /// <value>
        /// The color of the piece.
        /// </value>
        public PieceColourEnum PieceColour { get; }

        /// <summary>
        /// All the possible next moves.
        /// </summary>
        /// <param name="chessboardHelper">Chess board helper.</param>
        /// <param name="coordinateX">The x coordinate.</param>
        /// <param name="coordinateY">The y coordinate.</param>
        /// <returns>Possible moves.</returns>
        internal List<MoveDetial> AllPossibleNextMoves(IChessBoardHelper chessboardHelper, int coordinateX, int coordinateY);
    }
}
