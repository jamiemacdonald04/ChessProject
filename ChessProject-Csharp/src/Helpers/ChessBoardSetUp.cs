// <copyright file="ChessBoardSetUp.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace SolarWinds.MSP.Chess.Core.Helpers
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using SolarWinds.MSP.Chess.Core.Interface;
    using SolarWinds.MSP.Chess.Core.Properties;
    using SolarWinds.MSP.Chess.Models;

    /// <summary>
    /// Chessboard setup.
    /// </summary>
    internal sealed class ChessBoardSetUp : IChessBoardSetUp
    {
        /// <summary>
        /// The file read helper.
        /// </summary>
        private IChessData fileReadHelper;

        /// <summary>
        /// Handling errors.
        /// </summary>
        private IErrorHandling errorHandling;

        /// <summary>
        /// Initializes a new instance of the <see cref="ChessBoardSetUp"/> class.
        /// </summary>
        /// <param name="fileReadHelper">The file read helper.</param>
        /// <param name="errorHandling">Error handling methods.</param>
        public ChessBoardSetUp(IChessData fileReadHelper, IErrorHandling errorHandling)
        {
            this.fileReadHelper = fileReadHelper;
            this.errorHandling = errorHandling;
        }

        /// <summary>
        /// Sets up the board this instance.
        /// </summary>
        /// <returns>returns the game squares.</returns>
        List<BoardSquare> IChessBoardSetUp.Setupboard()
        {
            try
            {
                return this.fileReadHelper.ReadAndDeserialseIntoType<List<BoardSquare>>(Resources.ClassicBoardURL);
            }
            catch (FileNotFoundException fileNotFoundEx)
            {
                this.errorHandling.HandleError(fileNotFoundEx);
                return new List<BoardSquare>();
            }
            catch (Exception ex)
            {
                this.errorHandling.HandleError(ex);
                return new List<BoardSquare>();
            }
            finally
            {
                Console.WriteLine("There has been an error please contact help@solarwinds.com");
            }
        }
    }
}
