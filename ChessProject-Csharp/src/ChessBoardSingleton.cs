// <copyright file="ChessBoardSingleton.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace SolarWinds.MSP.Chess
{
    using System.Collections.Generic;
    using SolarWinds.MSP.Chess.Core.Helpers;
    using SolarWinds.MSP.Chess.Core.Interface;
    using SolarWinds.MSP.Chess.Core.Properties;
    using SolarWinds.MSP.Chess.Helpers;
    using SolarWinds.MSP.Chess.Models;

    /// <summary>
    /// the chess board class.
    /// </summary>
    public sealed class ChessBoardSingleton
    {
        /// <summary>
        /// The singleton instance.
        /// </summary>
        private static readonly ChessBoardSingleton ChessBoardSingletonInstance = new ChessBoardSingleton(new ChessBoardHelper());

        /// <summary>
        /// The chessboard helper.
        /// </summary>
        private readonly IChessBoardHelper chessboardHelper;

        /// <summary>
        /// The file read helper.
        /// </summary>
        private readonly IChessData fileReadHelper = new FileReadHelper();

        /// <summary>
        /// Error handling methods.
        /// </summary>
        private readonly IErrorHandling errorHandling = new ErrorHandling();

        /// <summary>
        /// The chess board set up.
        /// </summary>
        private readonly IChessBoardSetUp chessBoardSetUp;

        /// <summary>
        /// Initializes static members of the <see cref="ChessBoardSingleton"/> class.
        /// </summary>
        static ChessBoardSingleton()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ChessBoardSingleton"/> class.
        /// </summary>
        /// <param name="chessboardHelper">Chess board helper.</param>
        private ChessBoardSingleton(IChessBoardHelper chessboardHelper)
        {
            this.chessBoardSetUp = new ChessBoardSetUp(this.fileReadHelper, this.errorHandling);
            this.ChessBoardGameSquares = this.chessBoardSetUp.Setupboard();
            this.chessboardHelper = chessboardHelper;
        }

        /// <summary>
        /// Gets the instance.
        /// </summary>
        /// <value>
        /// The instance.
        /// </value>
        public static ChessBoardSingleton Instance
        {
            get
            {
                return ChessBoardSingletonInstance;
            }
        }

        /// <summary>
        /// Gets or sets all gaming squares on the board.
        /// </summary>
        public List<BoardSquare> ChessBoardGameSquares { get; set; }

        /// <summary>
        /// Gets the width of the chess board from reference.
        /// </summary>
        public int MaxBoardWidth { get; private set; } = IntegerHelper.ParseStringAsIntegerOrZero(ChessResource.MaxBoardWidth);

        /// <summary>
        /// Gets the height of the chess board from reference.
        /// </summary>
        internal int MaxBoardHeight { get; private set; } = IntegerHelper.ParseStringAsIntegerOrZero(ChessResource.MaxBoardHeight);

        /// <summary>
        /// Resets the board.
        /// </summary>
        public void ResetBoard()
        {
          this.ChessBoardGameSquares = this.chessBoardSetUp.Setupboard();
        }
    }
}
