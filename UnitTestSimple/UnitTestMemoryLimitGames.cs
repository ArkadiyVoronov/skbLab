using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Kontur
{
    [TestClass]
    public class UnitTestMemoryLimitGames: UnitTestSimpleGame
    {
        [TestMethod]
        override public void TestIndexator()
        {
            IGame game = new MemoryLimitGame(0, 1, 2, 3);

            int expected = 2;

            Assert.AreEqual(expected, game[1, 0]);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public override void TestBadIndexator()
        {
            IGame game = new MemoryLimitGame(0, 1, 2, 3);

            int t = game[3, 0];

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        override public void TestBadShift()
        {
            IGame game = new MemoryLimitGame(0, 1, 2, 3);

            game = game.Shift(1);
            game = game.Shift(2);

            Assert.Fail();
        }

        [TestMethod]
        override public void TestShift()
        {
            IGame game = new MemoryLimitGame(0, 1, 2, 3);

            game = game.Shift(1);

            Assert.AreEqual(1, game[0, 0]);
        }

        [TestMethod]
        public override void TestShiftCircle()
        {
            IGame game = new MemoryLimitGame(0, 1, 2, 3, 4, 5, 6, 7, 8);

            game = game.Shift(1);
            game = game.Shift(1);
            game = game.Shift(1);
            game = game.Shift(1);

            Assert.AreEqual(0, game[0, 0]);
        }

        [TestMethod]
        override public void Test3by3()
        {
            IGame game = new MemoryLimitGame(0, 1, 2, 3, 4, 5, 6, 7, 8);

            game = game.Shift(1);
            game = game.Shift(4);
            game = game.Shift(5);
            IGame newGame = game.Shift(8);
            game = game.Shift(8);

            Assert.AreEqual(0, game[2, 2]);
            Assert.AreEqual(0, newGame[2, 2]);
        }

        [TestMethod]
        override public void Test4by4()
        {
            IGame game = new MemoryLimitGame(0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15);

            game = game.Shift(4);
            game = game.Shift(8);
            game = game.Shift(9);
            game = game.Shift(10);
            game = game.Shift(14);
            game = game.Shift(13);
            game = game.Shift(13);
            game = game.Shift(15);

            Assert.AreEqual(0, game[3, 3]);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public override void TestBadInput()
        {
            IGame game = new MemoryLimitGame(0, 1, 2, 3, 4);

            Assert.Fail();
        }

    }
}
