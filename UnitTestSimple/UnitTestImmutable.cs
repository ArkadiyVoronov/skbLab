using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Kontur
{
    [TestClass]
    public class UnitTestImmutableGame: UnitTestBaseGame
    {
        [TestMethod]
        override public void TestLocation()
        {
            ImmutableGame game = new ImmutableGame(1, 2, 3, 0);
            Assert.AreEqual(game[0, 0], 1);
            Assert.AreEqual(game[1, 1], 0);
        }
        [TestMethod]
        override public void TestBadShift()
        {
            ImmutableGame game = new ImmutableGame(0, 1, 2, 3);
            try
            {
                game = game.Shift(1);
                game = game.Shift(2);
                Assert.Fail();
            }
            catch (Exception) { }
        }
        [TestMethod]
        override public void TestShift()
        {
            ImmutableGame game = new ImmutableGame(0, 1, 2, 3);
            try
            {
                game = game.Shift(1);
                Assert.AreEqual(game[0, 0], 1);
            }
            catch (Exception) { }
        }
        [TestMethod]
        override public void Test3by3()
        {
            ImmutableGame game = new ImmutableGame(0, 1, 2, 3, 4, 5, 6, 7, 8);
            try
            {
                game = game.Shift(1);
                game = game.Shift(4);
                game = game.Shift(5);
                ImmutableGame game2 = game.Shift(8);
                game = game.Shift(8);
                Assert.AreEqual(game[1, 1], 0);
                Assert.AreEqual(game2[1, 1], 0);
            }
            catch (Exception) { }
        }
        [TestMethod]
        override public void Test4by4()
        {
            ImmutableGame game = new ImmutableGame(0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15);
            try
            {
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
            catch (Exception) { }
        }

    }
}
