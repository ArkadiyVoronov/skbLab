using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Kontur
{
    [TestClass]
    public class UnitTestMemoryLimitGames
    {
        [TestMethod]
        public void TRRRest4by4()
        {
            MemoryLimitGame game = new MemoryLimitGame(0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15);
          
                game = game.Shift(4);
                game = game.Shift(8);
                game = game.Shift(9);
                game = game.Shift(10);
                game = game.Shift(14);
                game = game.Shift(13);
                game = game.Shift(13);
                game = game.Shift(15);
                Assert.AreEqual(game[3, 3], 0);
           
        }
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TRRestBadShift()
        {
            MemoryLimitGame game = new MemoryLimitGame(0, 1, 2, 3);
            game = game.Shift(1);
            game = game.Shift(2);     
        }
    }
}
