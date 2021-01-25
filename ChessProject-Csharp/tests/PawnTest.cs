namespace SolarWinds.MSP.Chess
{
	using NUnit.Framework;
	using SolarWinds.MSP.Chess.Models;
	using SolarWinds.MSP.Chess.Core.Helpers;
    using SolarWinds.MSP.Chess.Core.Interface;
    using System.Collections.Generic;
    using SolarWinds.MSP.Chess.Interface;

    [TestFixture]
	public class ChessPieceTest
	{
		private IGameMoves chessMoves;
		private IChessBoardHelper chessBoardHelper;
		private List<BoardSquare> chessboardSquares;
		private ChessBoardSingleton chessboard;

		[SetUp]
		public void SetUp()	
		{
			this.chessboard = ChessBoardSingleton.Instance;
			this.chessBoardHelper = new ChessBoardHelper();
			this.chessMoves = new ChessMoves();
			this.chessboardSquares = chessboard.ChessBoardGameSquares;
		}

		#region BlackPieces 

		[Test]
		public void ChessPiece_Move_IllegalCoordinates_Off_Board_Top_Right_DoesNotMove_Black()
		{
			int x = 7;
			int y = 6;
			BoardSquare currentSquare = chessBoardHelper.GetSquare(this.chessboardSquares, new Coordinate(x, y));
			chessMoves.MovePieceOnBoard(currentSquare.Piece, new Coordinate(x + 1, y - 1), this.chessboardSquares);

			Assert.AreEqual(currentSquare.SquaresCoordinates.X, x);
			Assert.AreEqual(currentSquare.SquaresCoordinates.Y, 6);

			Assert.IsNull(chessBoardHelper.GetSquare(this.chessboardSquares, new Coordinate(-1, y)), "No such square");
		}

		[Test]
		public void ChessBoard_Moves_To_Sets_XCoordinate_Black()
		{
			int x = 1;
			int y = 6;
			BoardSquare currentSquare = chessBoardHelper.GetSquare(this.chessboardSquares, new Coordinate(x, y));
			chessMoves.MovePieceOnBoard(currentSquare.Piece, new Coordinate(x, y - 1), this.chessboardSquares);

			// assert 
			Assert.IsNull(currentSquare.Piece);

			BoardSquare newSquare = chessBoardHelper.GetSquare(this.chessboardSquares, new Coordinate(x, y - 1));

			// assert 
			Assert.IsNotNull(newSquare.Piece);
		}

		[Test]
		public void ChessBoard_Does_Not_Move_To_Sets_XCoordinate_Black()
		{
			int x = 1;
			int y = 6;
			BoardSquare currentSquare = chessBoardHelper.GetSquare(this.chessboardSquares, new Coordinate(x, y));
			chessMoves.MovePieceOnBoard(currentSquare.Piece, new Coordinate(x, y -4), this.chessboardSquares);

			// assert 
			Assert.IsNotNull(currentSquare.Piece);

			BoardSquare newSquare = chessBoardHelper.GetSquare(this.chessboardSquares, new Coordinate(x, y -4));

			// assert 
			Assert.IsNull(newSquare.Piece);
		}


		[Test]
		public void ChessPiece_Move_IllegalCoordinates_Right_DoesNotMove_Black()
		{
			int x = 1;
			int y = 6;
			BoardSquare currentSquare = chessBoardHelper.GetSquare(this.chessboardSquares, new Coordinate(x, y));
			chessMoves.MovePieceOnBoard(currentSquare.Piece, new Coordinate(x - 1, y), this.chessboardSquares);

			Assert.AreEqual(currentSquare.SquaresCoordinates.X, 1);
			Assert.AreEqual(currentSquare.SquaresCoordinates.Y, 6);


			Assert.AreNotEqual(chessBoardHelper.GetSquare(this.chessboardSquares, new Coordinate(x - 1, y)).Piece, currentSquare.Piece);
		}

		[Test]
		public void ChessPiece_Move_IllegalCoordinates_Left_DoesNotMove_Black()
		{
			int x = 6;
			int y = 1;
			BoardSquare currentSquare = chessBoardHelper.GetSquare(this.chessboardSquares, new Coordinate(x, y));
			chessMoves.MovePieceOnBoard(currentSquare.Piece, new Coordinate(x + 1, y), this.chessboardSquares);

			Assert.AreEqual(currentSquare.SquaresCoordinates.X, 6);
			Assert.AreEqual(currentSquare.SquaresCoordinates.Y, 1);

			Assert.AreNotEqual(chessBoardHelper.GetSquare(this.chessboardSquares, new Coordinate(x + 1, y)).Piece, currentSquare.Piece);
		}

		#endregion
		#region WhitePieces 
		[Test]
		public void ChessBoard_Moves_To_Sets_XCoordinate_White()
		{
			int x = 6;
			int y = 1;
			BoardSquare currentSquare = chessBoardHelper.GetSquare(this.chessboardSquares, new Coordinate(x, y));
			chessMoves.MovePieceOnBoard(currentSquare.Piece, new Coordinate( x, y + 1), this.chessboardSquares);
			
			// assert 
			Assert.IsNull(currentSquare.Piece);

			BoardSquare newSquare = chessBoardHelper.GetSquare(this.chessboardSquares, new Coordinate(x, y + 1));

			// assert 
			Assert.IsNotNull(newSquare.Piece);
		}

		[Test]
		public void ChessBoard_Does_Not_Move_To_Sets_XCoordinate_White()
		{
			int x = 6;
			int y = 1;
			BoardSquare currentSquare = chessBoardHelper.GetSquare(this.chessboardSquares, new Coordinate(x, y));
			chessMoves.MovePieceOnBoard(currentSquare.Piece, new Coordinate(x, y + 4), this.chessboardSquares);

			// assert 
			Assert.IsNotNull(currentSquare.Piece);

			BoardSquare newSquare = chessBoardHelper.GetSquare(this.chessboardSquares, new Coordinate(x, y + 4));

			// assert 
			Assert.IsNull(newSquare.Piece);

		}

		[Test]
		public void ChessPiece_Move_IllegalCoordinates_Right_DoesNotMove_White()
		{
			int x = 6;
			int y = 1;
			BoardSquare currentSquare = chessBoardHelper.GetSquare(this.chessboardSquares, new Coordinate(x, y));
			chessMoves.MovePieceOnBoard(currentSquare.Piece, new Coordinate( x + 1, y), this.chessboardSquares);

			Assert.AreEqual(currentSquare.SquaresCoordinates.X, 6);
			Assert.AreEqual(currentSquare.SquaresCoordinates.Y, 1);
			
			
			Assert.AreNotEqual(chessBoardHelper.GetSquare(this.chessboardSquares, new Coordinate(x + 1, y)).Piece, currentSquare.Piece);
		}

		[Test]
		public void ChessPiece_Move_IllegalCoordinates_Left_DoesNotMove_White()
		{
			int x = 6;
			int y = 1;
			BoardSquare currentSquare = chessBoardHelper.GetSquare(this.chessboardSquares, new Coordinate(x, y));
			chessMoves.MovePieceOnBoard(currentSquare.Piece, new Coordinate(x - 1, y), this.chessboardSquares);

			Assert.AreEqual(currentSquare.SquaresCoordinates.X, 6);
			Assert.AreEqual(currentSquare.SquaresCoordinates.Y, 1);

			Assert.AreNotEqual(chessBoardHelper.GetSquare(this.chessboardSquares, new Coordinate(x - 1, y)).Piece, currentSquare.Piece);
		}

		[Test]
		public void ChessPiece_Move_IllegalCoordinates_Off_Board_Bottom_Left_DoesNotMove_White()
		{
			int x = 0;
			int y = 1;
			BoardSquare currentSquare = chessBoardHelper.GetSquare(this.chessboardSquares, new Coordinate(x, y));
			chessMoves.MovePieceOnBoard(currentSquare.Piece, new Coordinate(-1, y), this.chessboardSquares);

			Assert.AreEqual(currentSquare.SquaresCoordinates.X, 0, "Piece has moved");
			Assert.AreEqual(currentSquare.SquaresCoordinates.Y, 1, "Piece has moved");

			Assert.IsNull(chessBoardHelper.GetSquare(this.chessboardSquares, new Coordinate(-1, y)), "No such square");
		}
		#endregion

		[Test]
		public void Pawn_Demographics_Tostring_Correct()
		{
			IPieceStrategy whitePawn = ChessBoardSingleton.Instance.ChessBoardGameSquares[8].Piece;
			IPieceStrategy blackPawn = ChessBoardSingleton.Instance.ChessBoardGameSquares[55].Piece;

			Assert.AreEqual(whitePawn.ToString(), $"Current X: 0\r\nCurrent Y: 1\r\nPiece Color: White");
			Assert.AreEqual(blackPawn.ToString(), $"Current X: 7\r\nCurrent Y: 6\r\nPiece Color: Black");
		}

		[TearDown]
		public void TearDown()
		{
			chessboard.ResetBoard();
		}
	}
}