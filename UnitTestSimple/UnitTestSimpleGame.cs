using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Kontur
{
    [TestClass]
    public class UnitTestSimpleGame: UnitTestBaseGame
    {
        [TestMethod]
        override public void TestLocation()
        {
            SimpleGame game = new SimpleGame(1, 2, 3, 0);
            Assert.AreEqual(game[0, 0], 1);
            Assert.AreEqual(game[1, 1], 0);
        }
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        override public void TestBadShift()
        {
            SimpleGame game = new SimpleGame(0, 1, 2, 3);
            game.Shift(1);
            game.Shift(2);
        }
        [TestMethod]
        override public void TestShift()
        {
            SimpleGame game = new SimpleGame(0, 1, 2, 3);
            game.Shift(1);
            Assert.AreEqual(game[0, 0], 1);
        }
        [TestMethod]
        override public void Test3by3()
        {
            SimpleGame game = new SimpleGame(0, 1, 2, 3, 4, 5, 6, 7, 8);
            try
            {
                game.Shift(1);
                game.Shift(4);
                game.Shift(5);
                game.Shift(8);
                Assert.AreEqual(game[1, 1], 0);
            }
            catch (Exception) { }
        }
        [TestMethod]
        override public void Test4by4()
        {
            SimpleGame game = new SimpleGame(0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15);
            
                game.Shift(4);
                game.Shift(8);
                game.Shift(9);
                game.Shift(10);
                game.Shift(14);
                game.Shift(13);
                game.Shift(13);
                game.Shift(15);
                Assert.AreEqual(game[3, 3], 0);
           
        }

    }
    
}
