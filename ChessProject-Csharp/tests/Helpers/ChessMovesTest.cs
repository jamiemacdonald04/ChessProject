namespace SolarWinds.MSP.Chess.tests.Helpers
{
    using NUnit.Framework;
    using SolarWinds.MSP.Chess.Core.Helpers;
    using SolarWinds.MSP.Chess.Core.Interface;
    using SolarWinds.MSP.Chess.Core.Models;
    using SolarWinds.MSP.Chess.Enums;
    using SolarWinds.MSP.Chess.Interface;
    using SolarWinds.MSP.Chess.Models;
    using SolarWinds.MSP.Chess.Piece;
    using System.Collections.Generic;

    [TestFixture]
    public class ChessMovesTest
    {
        private IGameMovesUTesting gameMovesUTesting;
        private IGameMoves gameMoves;
        private IChessBoardHelper chessBoardHelper;
        private List<BoardSquare> chessboardSquares;
        private ChessBoardSingleton chessboard;

        [SetUp]
        public void SetUp()
        {
            this.gameMoves = new ChessMoves();
            this.gameMovesUTesting = new ChessMoves();
            this.chessboard = ChessBoardSingleton.Instance;
            this.chessBoardHelper = new ChessBoardHelper();
            this.chessboardSquares = chessboard.ChessBoardGameSquares;
        }


        [Test]
        public void ChessPiece_Move_IllegalCoordinates_Off_Board_Top_Right_DoesNotMove_Black()
        {
            int x = 7;
            int y = 6;
            BoardSquare currentSquare = chessBoardHelper.GetSquare(this.chessboardSquares, new Coordinate(x, y));
            this.gameMovesUTesting.MovePieceOnBoard(currentSquare.Piece, new Coordinate(x + 1, y - 1), this.chessboardSquares);

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
            this.gameMovesUTesting.MovePieceOnBoard(currentSquare.Piece, new Coordinate(x, y - 1), this.chessboardSquares);

            // assert 
            Assert.IsNull(currentSquare.Piece);

            BoardSquare newSquare = chessBoardHelper.GetSquare(this.chessboardSquares, new Coordinate(x, y - 1));

            // assert 
            Assert.IsNotNull(newSquare.Piece);
        }

        [Test]
        public void check_Concrete_implimentation_Interface_Segregation()
        {
            Assert.AreEqual(this.gameMovesUTesting.GetType(), this.gameMoves.GetType(), "Concrete implimentation changed.");
        }

        [Test]
        public void Loop_pieces_none_Are_possible_moves()
        {
            List<Coordinate> possibleMoveCoordinates = new List<Coordinate>() { new Coordinate(7, 0), new Coordinate(6, 1), new Coordinate(5, 2), new Coordinate(4, 5) };

            for (int moveIndex = 0; moveIndex < possibleMoveCoordinates.Count; moveIndex++)
            {
                Assert.IsFalse(this.gameMovesUTesting.IsMoveAnOption(possibleMoveCoordinates, new Coordinate(moveIndex, 1)), "Should all be valid moves");
            }
        }

        [Test]
        public void Loop_pieces_All_Are_possible_moves()
        {
            List<Coordinate> possibleMoveCoordinates = new List<Coordinate>() { new Coordinate(1, 0), new Coordinate(1, 1), new Coordinate(1, 2), new Coordinate(1, 3) };

            for (int moveIndex = 0; moveIndex < possibleMoveCoordinates.Count; moveIndex++)
            {
                Assert.IsTrue(this.gameMovesUTesting.IsMoveAnOption(possibleMoveCoordinates, new Coordinate(1, moveIndex)), "Should all be valid moves");
            }
        }

        [Test]
        public void Collision_will_Happen_Test()
        {
            IPieceStrategy Piece = new Pawn(PieceColourEnum.White);
            List<MoveDetial> moveDetails = new List<MoveDetial>()
            {
                new MoveDetial()
                {
                    Coordinates = new Coordinate(1, 2),
                    PieceSettingForMove = new List<PieceSetting>()
                    {
                        new PieceSetting()
                        {
                            CanMoveMultipleSpaces = false,
                            CanTake = false,
                            Move = ClassicChessMovementTypesEnum.Forward
                        }
                    }
                }
            };

            BoardSquare intendedSquare = new BoardSquare()
            {
                Piece = Piece,
                SquaresCoordinates = new Coordinate(1, 2)
            };

            Assert.IsTrue(this.gameMovesUTesting.WillCollisionHappenInMove(moveDetails, intendedSquare));
        }

        [Test]
        public void Collision_Wont_Happen_can_take_Test()
        {
            IPieceStrategy Piece = new Pawn(PieceColourEnum.White);
            List<MoveDetial> moveDetails = new List<MoveDetial>()
            {
                new MoveDetial()
                {
                    Coordinates = new Coordinate(1, 2),
                    PieceSettingForMove = new List<PieceSetting>()
                    {
                        new PieceSetting()
                        {
                            CanMoveMultipleSpaces = false,
                            CanTake = true,
                            Move = ClassicChessMovementTypesEnum.Forward
                        }
                    }
                }
            };

            BoardSquare intendedSquare = new BoardSquare()
            {
                Piece = Piece,
                SquaresCoordinates = new Coordinate(1, 2)
            };

            Assert.False(this.gameMovesUTesting.WillCollisionHappenInMove(moveDetails, intendedSquare));
        }

        [Test]
        public void Collision_Wont_Happen_Empty_Test()
        {
            IPieceStrategy Piece = null;
            List<MoveDetial> moveDetails = new List<MoveDetial>()
            {
                new MoveDetial()
                {
                    Coordinates = new Coordinate(1, 2),
                    PieceSettingForMove = new List<PieceSetting>()
                    {
                        new PieceSetting()
                        {
                            CanMoveMultipleSpaces = false,
                            CanTake = true,
                            Move = ClassicChessMovementTypesEnum.Forward
                        }
                    }
                }
            };

            BoardSquare intendedSquare = new BoardSquare()
            {
                Piece = Piece,
                SquaresCoordinates = new Coordinate(1, 2)
            };

            Assert.False(this.gameMovesUTesting.WillCollisionHappenInMove(moveDetails, intendedSquare));
        }
    }
}
