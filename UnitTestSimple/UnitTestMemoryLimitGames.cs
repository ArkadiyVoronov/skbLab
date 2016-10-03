using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Kontur
{
    [TestClass]
    public class UnitTestMemoryLimitGames: UnitTestSimpleGame
    {
        [TestMethod]
        public override void Test4by4()
        {
            MemoryLimitGame game = new MemoryLimitGame(0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15);

            game = (MemoryLimitGame)game.Shift(4);
            game = (MemoryLimitGame)game.Shift(8);
            game = (MemoryLimitGame)game.Shift(9);
            game = (MemoryLimitGame)game.Shift(10);
            game = (MemoryLimitGame)game.Shift(14);
            game = (MemoryLimitGame)game.Shift(13);
            game = (MemoryLimitGame)game.Shift(13);
            game = (MemoryLimitGame)game.Shift(15);

            Assert.AreEqual(game[3, 3], 0);
           
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TRRestBadShift()
        {
            MemoryLimitGame game = new MemoryLimitGame(0, 1, 2, 3);
            game = (MemoryLimitGame)game.Shift(1);
            game = (MemoryLimitGame)game.Shift(2);     
        }
    }
}
