namespace SolarWinds.MSP.Chess.tests.Helpers
{
	using NUnit.Framework;
    using SolarWinds.MSP.Chess.Core.Helpers;
    using SolarWinds.MSP.Chess.Core.Interface;
    using SolarWinds.MSP.Chess.Core.Properties;
    using SolarWinds.MSP.Chess.Helpers;
    using SolarWinds.MSP.Chess.Models;
    using System.Collections.Generic;

	[TestFixture]
	public class ChessBoardHelperTest
    {
		private IChessBoardHelper chessBoardHelper;
		private int maxboardHieght;
		private int maxboardWidth;

		[SetUp]
		public void SetUp()
		{
			chessBoardHelper = new ChessBoardHelper();
			maxboardHieght = IntegerHelper.ParseStringAsIntegerOrZero(ChessResource.MaxBoardHeight);
			maxboardWidth = IntegerHelper.ParseStringAsIntegerOrZero(ChessResource.MaxBoardWidth);
		}

		[Test]
		public void IsLegalBoardPosition_all_Valid_Fringe_Coordinates()
		{
			List<Coordinate> FringeQuardinates = new List<Coordinate>();

			for (int heightIndex = 0; heightIndex < (maxboardHieght + 1); heightIndex++) 
			{
				FringeQuardinates.Add(new Coordinate(0, heightIndex));
			}

			for (int widthIndex = 0; widthIndex < (maxboardWidth + 1); widthIndex++)
			{
				FringeQuardinates.Add(new Coordinate(widthIndex, 0));
			}

			foreach (Coordinate FringeQuardinate in FringeQuardinates) 
			{
				Assert.IsTrue(chessBoardHelper.IsLegalBoardPosition(FringeQuardinate), "is on board");
			}
		}

		[Test]
		public void IsLegalBoardPosition_Sample_inValid_Coridinates()
		{
			List<Coordinate> SampleOfInvalidQuardinates = new List<Coordinate>();

			for (int heightIndex = 0; heightIndex < (maxboardHieght + 1); heightIndex++)
			{
				SampleOfInvalidQuardinates.Add(new Coordinate(-1, heightIndex));
				SampleOfInvalidQuardinates.Add(new Coordinate(-1, 8));
			}

			for (int widthIndex = 0; widthIndex < (maxboardWidth + 1); widthIndex++)
			{
				SampleOfInvalidQuardinates.Add(new Coordinate(widthIndex, -1));
				SampleOfInvalidQuardinates.Add(new Coordinate(8, -1));
			}

			foreach (Coordinate FringeQuardinate in SampleOfInvalidQuardinates)
			{
				Assert.IsFalse(chessBoardHelper.IsLegalBoardPosition(FringeQuardinate), "is not on board");
			}
		}

		[Test]
		public void IsLegalBoardPosition_True_X_equals_0_Y_equals_0()
		{
			var isValidPosition = chessBoardHelper.IsLegalBoardPosition(new Coordinate(0, 0));
			Assert.IsTrue(isValidPosition);
		}

		[Test]
		public void IsLegalBoardPosition_True_X_equals_5_Y_equals_5()
		{
			var isValidPosition = chessBoardHelper.IsLegalBoardPosition(new Coordinate(5, 5));
			Assert.IsTrue(isValidPosition);
		}

		[Test]
		public void IsLegalBoardPosition_False_X_equals_11_Y_equals_5()
		{
			var isValidPosition = chessBoardHelper.IsLegalBoardPosition(new Coordinate(11, 5));
			Assert.IsFalse(isValidPosition);
		}

		[Test]
		public void IsLegalBoardPosition_False_X_equals_0_Y_equals_9()
		{
			var isValidPosition = chessBoardHelper.IsLegalBoardPosition(new Coordinate(0, 9));
			Assert.IsFalse(isValidPosition);
		}

		[Test]
		public void IsLegalBoardPosition_False_X_equals_11_Y_equals_0()
		{
			var isValidPosition = chessBoardHelper.IsLegalBoardPosition(new Coordinate(11, 0));
			Assert.IsFalse(isValidPosition);
		}

		[Test]
		public void IsLegalBoardPosition_False_For_Negative_X_Values()
		{
			var isValidPosition = chessBoardHelper.IsLegalBoardPosition(new Coordinate(-1, 5));
			Assert.IsFalse(isValidPosition);
		}

		[Test]
		public void IsLegalBoardPosition_False_For_Negative_Y_Values()
		{
			var isValidPosition = chessBoardHelper.IsLegalBoardPosition(new Coordinate(5, -1));
			Assert.IsFalse(isValidPosition);
		}
	}
}
