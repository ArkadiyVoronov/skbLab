using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Kontur
{
    [TestClass]
    public class UnitTestImmutableGame: UnitTestSimpleGame
    {
        [TestInitialize()]
        public override void Initialize()
        {
            game = new ImmutableGame(0, 1, 2, 3);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public override void TestBadShift()
        {

            game = game.Shift(1);
            game = game.Shift(2);

            Assert.Fail();
        }

        [TestMethod]
        public override void TestShift()
        {
            game = game.Shift(1);

            Assert.AreEqual(1, game[0, 0]);
        }

        [TestMethod]
        public void TestImmutableShift()
        {
            IGame game2;

            game = game.Shift(1);
            game2 = game;
            game = game.Shift(1);

            Assert.AreEqual(0, game[0, 0]);
            Assert.AreEqual(1, game2[0, 0]);
        }

        [TestMethod]
        public override void TestShiftCircle()
        {
           
            game = game.Shift(1);
            game = game.Shift(1);
            game = game.Shift(1);
            game = game.Shift(1);

            Assert.AreEqual(0, game[0, 0]);
        }

        [TestMethod]
        override public void Test3by3()
        {
            IGame game3by3 = new ImmutableGame(0, 1, 2, 3, 4, 5, 6, 7, 8);

            game3by3 = game3by3.Shift(1);
            game3by3 = game3by3.Shift(4);
            game3by3 = game3by3.Shift(5);
            IGame newGame = game3by3.Shift(8);
            game3by3 = game3by3.Shift(8);

            Assert.AreEqual(0, game3by3[2, 2]);
            Assert.AreEqual(0, newGame[2, 2]);            
        }

        [TestMethod]
        override public void Test4by4()
        {
            IGame game4by4 = new ImmutableGame(0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15);
           
            game4by4 = game4by4.Shift(4);
            game4by4 = game4by4.Shift(8);
            game4by4 = game4by4.Shift(9);
            game4by4 = game4by4.Shift(10);
            game4by4 = game4by4.Shift(14);
            game4by4 = game4by4.Shift(13);
            game4by4 = game4by4.Shift(13);
            game4by4 = game4by4.Shift(15);

            Assert.AreEqual(0, game4by4[3, 3]);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public override void TestBadInput()
        {
            IGame gameBad = new ImmutableGame(0, 1, 2, 3, 4);

            Assert.Fail();
        }
    }
}
