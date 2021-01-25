namespace SolarWinds.MSP.Chess
{
	using NUnit.Framework;
	using SolarWinds.MSP.Chess.Piece;
	using SolarWinds.MSP.Chess.Interface;
    using SolarWinds.MSP.Chess.Models;
    using System.Collections.Generic;
	using System.Linq;
    using SolarWinds.MSP.Chess.Core.Helpers;
    using SolarWinds.MSP.Chess.Core.Interface;

    [TestFixture]
	public class ChessBoardTest
	{
		private ChessBoardSingleton chessBoard;
		private IChessBoardHelper chessBoardHelper;
		private List<BoardSquare> chessBoardGameSquares;
		private IGameMoves chessMoves;

		[SetUp]
		public void SetUp()
		{
			this.chessBoardHelper = new ChessBoardHelper();
			this.chessBoard =  ChessBoardSingleton.Instance;
			this.chessBoardGameSquares = chessBoard.ChessBoardGameSquares;
			this.chessMoves = new ChessMoves();
	}

        [Test]
		public void Has_MaxBoardWidth_of_7()
		{
			////Arrange
			IEnumerable<BoardSquare> chessBoardGameSquares = this.chessBoardGameSquares.Where(square => square.SquaresCoordinates.Y == 1);

			////Act
			int chessBoardSquares = chessBoardGameSquares.Count();
			int lastCoordinate = chessBoardGameSquares.LastOrDefault().SquaresCoordinates.X;
			int FirstCoordinate = chessBoardGameSquares.FirstOrDefault().SquaresCoordinates.X;

			//// Assert
			Assert.AreEqual(chessBoardSquares, 8);
			Assert.AreEqual(lastCoordinate, 7);
			Assert.AreEqual(FirstCoordinate, 0);
		}

		[Test]
		public void Has_MaxBoardHeight_of_8()
		{
			////Arrange
			IEnumerable<BoardSquare> chessBoardGameSquares = this.chessBoardGameSquares.Where(square => square.SquaresCoordinates.X == 1);

			////Act
			int chessBoardSquares = chessBoardGameSquares.Count();
			int lastCoordinate = chessBoardGameSquares.LastOrDefault().SquaresCoordinates.Y;
			int FirstCoordinate = chessBoardGameSquares.FirstOrDefault().SquaresCoordinates.Y;

			//// Assert
			Assert.AreEqual(chessBoardSquares, 8);
			Assert.AreEqual(lastCoordinate, 7);
			Assert.AreEqual(FirstCoordinate, 0);
		}

        [Test]
		public void Avoids_Duplicate_Positioning()
		{
			int x = 0;
			int y = 6;

			BoardSquare currentSquare = chessBoardHelper.GetSquare(this.chessBoardGameSquares, new Coordinate(x, y));

			for (int yIndex = 0; yIndex <= 4; yIndex++)
			{
				y -= 1;
				chessMoves.MovePieceOnBoard(currentSquare.Piece, new Coordinate(x, y), this.chessBoardGameSquares);
				currentSquare = chessBoardHelper.GetSquare(this.chessBoardGameSquares, new Coordinate(x, y));

				if (yIndex == 4)
				{
					BoardSquare StillOnThisSquare = chessBoardHelper.GetSquare(this.chessBoardGameSquares, new Coordinate(x, y + 1));
					Assert.IsTrue(StillOnThisSquare.Piece.PieceColour == PieceColourEnum.Black);
					Assert.IsTrue(currentSquare.Piece.PieceColour == PieceColourEnum.White); 
				}
			}
		}

          [Test]
        public void Correct_Number_Of_Pawns()
        {
			IEnumerable<IPieceStrategy> pawns = this.chessBoardGameSquares.Where(square => square.Piece is Pawn).Select(square => square.Piece );
			int whitePawns = pawns.Where(piece => piece.PieceColour == PieceColourEnum.White).Count();
			int blackPawns = pawns.Where(piece => piece.PieceColour == PieceColourEnum.White).Count();
			Assert.AreEqual(whitePawns, 8);
			Assert.AreEqual(blackPawns, 8);
		}
    }
}
