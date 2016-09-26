using System;
using Simple;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Simple
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestLocation()
        {
            Game game = new Game(1, 2, 3, 0);
            Assert.AreEqual(game[0, 0], 1);
            Assert.AreEqual(game[1, 1], 0);
        }
        [TestMethod]
        public void TestBadShift()
        {
            Game game = new Game(0, 1, 2, 3);
            try
            {
                game.Shift(3);
                Assert.Fail();
            }
            catch (Exception) { }
        }
        [TestMethod]
        public void TestShift()
        {
            Game game = new Game(0, 1, 2, 3);
            try
            {
                game.Shift(1);
                Assert.AreEqual(game[0, 0], 1);
            }
            catch (Exception) { }
        }
        [TestMethod]
        public void Test3by3()
        {
            Game game = new Game(0, 1, 2, 3, 4, 5, 6, 7, 8);
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
        public void Test4by4()
        {
            Game game = new Game(0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15);
            try
            {
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
            catch (Exception) { }
        }

    }
}
