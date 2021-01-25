// <copyright file="ClassicChessMovementTypesEnum.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace SolarWinds.MSP.Chess.Enums
{
    /// <summary>
    /// possible moves in the classic game of chess.
    /// </summary>
    public enum ClassicChessMovementTypesEnum
    {
        /// <summary>
        /// can move forward.
        /// </summary>
        Forward,

        /// <summary>
        /// can move backwards
        /// </summary>
        Backwards,

        /// <summary>
        /// can move diagonal
        /// </summary>
        Diagonal,

        /// <summary>
        /// can move in an L shape
        /// </summary>
        LShape,

        /// <summary>
        /// Can jump.
        /// </summary>
        Jump,
    }
}
