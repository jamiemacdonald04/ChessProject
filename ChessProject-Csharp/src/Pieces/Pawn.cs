// <copyright file="Pawn.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace SolarWinds.MSP.Chess.Piece
{
    using System.Collections.Generic;
    using System.Linq;
    using SolarWinds.MSP.Chess.Core.Enums;
    using SolarWinds.MSP.Chess.Core.Helpers;
    using SolarWinds.MSP.Chess.Core.Interface;
    using SolarWinds.MSP.Chess.Core.Models;
    using SolarWinds.MSP.Chess.Enums;
    using SolarWinds.MSP.Chess.Interface;
    using SolarWinds.MSP.Chess.Models;

    /// <summary>
    /// Class for the piece.
    /// </summary>
    /// <seealso cref="SolarWinds.MSP.Chess.Interface.IPieceStratagy" />
    public sealed class Pawn : IPieceStrategy
    {
        /// <summary>
        /// The piece color.
        /// </summary>
        private readonly IPieceHelper pieceHelper;

        /// <summary>
        /// The piece color.
        /// </summary>
        private PieceColourEnum pieceColor;

        /// <summary>
        /// The legal moves for piece.
        /// </summary>
        private List<PieceSetting> pieceSettings;

        /// <summary>
        /// Initializes a new instance of the <see cref="Pawn"/> class.
        /// </summary>
        /// <param name="pieceColor">Color of the piece.</param>
        public Pawn(PieceColourEnum pieceColor)
        {
            this.pieceHelper = new PieceHelper();
            this.PieceSettings = new List<PieceSetting>();
            this.pieceColor = pieceColor;
            this.PieceName = PieceTypes.Pawn;
            this.SetUpPiece();
        }

        /// <summary>
        /// Gets or sets the legal moves for the pawn piece.
        /// </summary>
        /// <value>
        /// The legal moves for piece.
        /// </value>
        public List<PieceSetting> PieceSettings
        {
            get { return this.pieceSettings; }
            set { this.pieceSettings = value; }
        }

        /// <summary>
        /// Gets or sets the name of the piece.
        /// </summary>
        /// <value>
        /// The name of the piece.
        /// </value>
        public PieceTypes PieceName { get; set; }

        /// <summary>
        /// Gets the color of the piece.
        /// </summary>
        /// <value>
        /// The color of the piece.
        /// </value>
        public PieceColourEnum PieceColour
        {
            get { return this.pieceColor; }
            private set { this.pieceColor = value; }
        }

        /// <summary>
        /// All the possible next moves in this case forward in the future (diagonal if piece is there to take).
        /// </summary>
        /// <param name="chessboardHelper">chess board helper.</param>
        /// <param name="coordinateX">current x coordinate.</param>
        /// <param name="coordinateY">current y coordinate.</param>
        /// <returns>All Legal moves.</returns>
        List<MoveDetial> IPieceStrategy.AllPossibleNextMoves(IChessBoardHelper chessboardHelper, int coordinateX, int coordinateY)
        {
            List<MoveDetial> possibleMoves = new List<MoveDetial>();
            Coordinate nextMove = new Coordinate(coordinateX, coordinateY);

            if (this.PieceColour == PieceColourEnum.White)
            {
                nextMove.Y = coordinateY + 1;
            }
            else if (this.PieceColour == PieceColourEnum.Black)
            {
                nextMove.Y = coordinateY - 1;
            }

            if (!chessboardHelper.IsLegalBoardPosition(nextMove))
            {
                return null;
            }

            possibleMoves.Add(new MoveDetial() { Coordinates = nextMove, PieceSettingForMove = this.PieceSettings.Where(setting => setting.Move == ClassicChessMovementTypesEnum.Forward).ToList() });

            return possibleMoves;
        }

        /// <summary>
        /// Converts to string.
        /// </summary>
        /// <returns>
        /// A <see cref="string" /> that represents the Pawn and its coordinates.
        /// </returns>
        public override string ToString()
        {
            IChessBoardHelper chessBoardHelper = new ChessBoardHelper();
            string piecesColor = this.pieceHelper.GetPieceColour(this);
            BoardSquare boardSquare = chessBoardHelper.GetPiecesCurrentLocation(ChessBoardSingleton.Instance.ChessBoardGameSquares, this);

            return this.pieceHelper.CurrentPositionAsString(boardSquare, piecesColor);
        }

        /// <summary>
        /// Sets up piece.
        /// </summary>
        private void SetUpPiece()
        {
            this.PieceSettings.Add(new PieceSetting() { Move = ClassicChessMovementTypesEnum.Forward, CanTake = false, CanMoveMultipleSpaces = false });
            this.PieceSettings.Add(new PieceSetting() { Move = ClassicChessMovementTypesEnum.Diagonal, CanTake = true, CanMoveMultipleSpaces = false });
        }
    }
}
