using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using MapStates;
using MapStates.GameManagerDomain;

namespace TestCarte
{
    public class GameManagerTest
    {

        #region public methods
        [Fact]
        public void ShouldGoToTheRightSpotWithTreasure()
        {
            #region Arrange
            var gameManager = new GameManager();
            IList<string> fileLines = new List<string>();
            fileLines.Add("C - 3 - 4");
            fileLines.Add("M - 1 - 0");
            fileLines.Add("M - 2 - 1");
            fileLines.Add("T - 0 - 3 - 2");
            fileLines.Add("T - 1 - 3 - 3");
            fileLines.Add("# this is a comment");
            fileLines.Add("A - Indiana - 1 - 1 - S - AADADAGGA");
            #endregion
            #region Act
            var gameResult = gameManager.RunGame(fileLines);
            #endregion

            #region Assert
            var lastLine = gameResult[gameResult.Count - 1];
            Assert.Equal("A - Indiana - 0 - 3 - S - 3", lastLine);
            #endregion

        }
        [Fact]
        public void ShouldHaveTheRightStateHistory()
        {
            #region Arrange
            var gameManager = new GameManager();
            IList<string> fileLines = new List<string>();
            fileLines.Add("C - 3 - 4");
            fileLines.Add("M - 1 - 0");
            fileLines.Add("M - 2 - 1");
            fileLines.Add("T - 0 - 3 - 2");
            fileLines.Add("T - 1 - 3 - 3");
            fileLines.Add("# this is a comment");
            fileLines.Add("A - Indiana - 1 - 1 - S - AADADAGGA");
            #endregion
            #region Act
            var gameHistory = gameManager.RunStepByStep(fileLines);
            #endregion

            #region Assert
            var LastState = gameHistory.History.Pop();
            Assert.Equal(0, LastState.Adventurers.FirstOrDefault(adv => adv.Id == 0).Position.X);
            Assert.Equal(3, LastState.Adventurers.FirstOrDefault(adv => adv.Id == 0).Position.Y);
            Assert.Equal(3, LastState.Adventurers.FirstOrDefault(adv => adv.Id == 0).Treasures);
            #endregion

        }
        #endregion

    }
}
