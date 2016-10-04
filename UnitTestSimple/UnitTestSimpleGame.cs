using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Kontur
{
    [TestClass]
    public class UnitTestSimpleGame: UnitTestGame
    {
        [TestMethod]
        public override void TestIndexator()
        {
            IGame game = new SimpleGame(0, 1, 2, 3);

            int expected = 2;

            Assert.AreEqual(expected, game[1, 0]);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public override void TestBadIndexator()    
        {
            IGame game = new SimpleGame(0, 1, 2, 3);

            int t = game[3, 0];

            Assert.Fail();
        }

        [TestMethod]
        public override void TestShift()
        {
            SimpleGame game = new SimpleGame(0, 1, 2, 3);

            game.Shift(1);
            game.Shift(3);

            Assert.AreEqual(0, game[1, 1]);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public override void TestBadShift()
        {
            IGame game = new SimpleGame(0, 1, 2, 3);

            game.Shift(1);
            game.Shift(2);

            Assert.Fail();
        }

        [TestMethod]
        public override void TestShiftCircle()
        {
            IGame game = new SimpleGame(0, 1, 2, 3, 4, 5, 6, 7, 8);

            game.Shift(1);
            game.Shift(1);
            game.Shift(1);
            game.Shift(1);

            Assert.AreEqual(0, game[0, 0]);
        }

        [TestMethod]
        public override void Test3by3()
        {
            SimpleGame game = new SimpleGame(0, 1, 2, 3, 4, 5, 6, 7, 8);

            game.Shift(1);
            game.Shift(4);
            game.Shift(5);
            game.Shift(8);

            Assert.AreEqual(0, game[2, 2]);
        }

        [TestMethod]
        public override void Test4by4()
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

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public override void TestBadInput()
        {
            IGame game = new SimpleGame(0, 1, 2, 3, 4);

            Assert.Fail();
        }
    }
    
}
