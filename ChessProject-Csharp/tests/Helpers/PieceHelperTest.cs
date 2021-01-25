namespace SolarWinds.MSP.Chess.tests.Helpers
{
	using Moq;
    using NUnit.Framework;
    using SolarWinds.MSP.Chess.Core.Helpers;
    using SolarWinds.MSP.Chess.Core.Interface;
    using SolarWinds.MSP.Chess.Interface;
    using SolarWinds.MSP.Chess.Models;

    [TestFixture]
	public class PieceHelperTest
    {
        /// <summary>
        /// The piece helper
        /// </summary>
        private IPieceHelper pieceHelper;

		[SetUp]
		public void SetUp()
		{
			pieceHelper = new PieceHelper();
		}

		[Test]
		public void Check_Correct_String_Returned_Black() 
		{
			Mock<IPieceStrategy> MockPieceStrategy = new Mock<IPieceStrategy>();
			MockPieceStrategy.Setup(property => property.PieceColour).Returns(PieceColourEnum.Black);
			
			Assert.AreEqual(pieceHelper.GetPieceColour(MockPieceStrategy.Object), "Black");
		}

		[Test]
		public void Check_Correct_String_Returned_White()
		{
			Mock<IPieceStrategy> MockPieceStrategy = new Mock<IPieceStrategy>();
			MockPieceStrategy.Setup(property => property.PieceColour).Returns(PieceColourEnum.White);

			Assert.AreEqual(pieceHelper.GetPieceColour(MockPieceStrategy.Object), "White");
		}

		[Test]
		public void Pawn_Demographics_Tostring_Correct()
		{
			BoardSquare square = new BoardSquare { SquaresCoordinates = new Coordinate(1, 1) };

			Assert.AreEqual(pieceHelper.CurrentPositionAsString(square, "Black"), $"Current X: 1\r\nCurrent Y: 1\r\nPiece Color: Black");
		}
	}
}
