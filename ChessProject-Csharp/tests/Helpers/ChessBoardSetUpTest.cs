namespace SolarWinds.MSP.Chess.tests.Helpers
{
    using Moq;
	using NUnit.Framework;
	using SolarWinds.MSP.Chess.Core.Helpers;
	using SolarWinds.MSP.Chess.Core.Interface;
    using SolarWinds.MSP.Chess.Models;
    using System;
    using System.Collections.Generic;
    using System.IO;

	[TestFixture]
	public class ChessBoardSetUpTest
	{
		private Mock<IChessData> mockFileReadHelper;
		private Mock<IErrorHandling> mockErrorHandling;

		[SetUp]
		public void SetUp()
		{
			mockFileReadHelper = new Mock<IChessData>();
			mockErrorHandling = new Mock<IErrorHandling>();
				
		}

		[Test]
		public void Chess_Board_Set_Up_Exception_Handle()
		{
			this.mockFileReadHelper.Setup(mock => mock.ReadAndDeserialseIntoType<List<BoardSquare>>(It.IsAny<string>())).Throws(new Exception());
			IChessBoardSetUp setUpChessBoard = new ChessBoardSetUp(mockFileReadHelper.Object, mockErrorHandling.Object);
			
			setUpChessBoard.Setupboard();

			this.mockErrorHandling.Verify(mock => mock.HandleError(It.IsAny<Exception>()), Times.Once);
			this.mockErrorHandling.Verify(mock => mock.HandleError(It.IsAny<FileNotFoundException>()), Times.Never);
		}

		[Test]
		public void Chess_Board_Set_Up_File_Not_Found_Exception_Handle()
		{
			mockFileReadHelper.Setup(methodSetup => methodSetup.ReadAndDeserialseIntoType<List<BoardSquare>>(It.IsAny<string>())).Throws(new FileNotFoundException());
			IChessBoardSetUp setUpChessBoard = new ChessBoardSetUp(mockFileReadHelper.Object, mockErrorHandling.Object);

			setUpChessBoard.Setupboard();

			this.mockErrorHandling.Verify(mock => mock.HandleError(It.IsAny<FileNotFoundException>()), Times.Once);
			this.mockErrorHandling.Verify(mock => mock.HandleError(It.IsAny<Exception>()), Times.Never);
		}
	}
}
