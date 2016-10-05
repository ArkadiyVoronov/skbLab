using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Kontur
{
    [TestClass]
    public class UnitTestSimpleGame
    {
        protected IGame game;

        [TestInitialize()]
        virtual public void Initialize()
        {
            game = new SimpleGame(0, 1, 2, 3);
        }

        [TestMethod]
        virtual public void TestIndexator()
        {
            int expected = 2;

            Assert.AreEqual(expected, game[1, 0]);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public virtual void TestBadIndexator()
        {

            int t = game[2, 0];

            Assert.Fail();
        }

        [TestMethod]
        public virtual void TestShift()
        {

            game.Shift(1);
            game.Shift(3);

            Assert.AreEqual(0, game[1, 1]);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public virtual void TestBadShift()
        {

            game.Shift(1);
            game.Shift(2);

            Assert.Fail();
        }

        [TestMethod]
        public virtual void TestShiftCircle()
        {
            game.Shift(1);
            game.Shift(1);
            game.Shift(1);
            game.Shift(1);

            Assert.AreEqual(0, game[0, 0]);
        }

        [TestMethod]
        public virtual void Test3by3()
        {
            IGame game3by3 = new SimpleGame(0, 1, 2, 3, 4, 5, 6, 7, 8);

            game3by3.Shift(1);
            game3by3.Shift(4);
            game3by3.Shift(5);
            game3by3.Shift(8);

            Assert.AreEqual(0, game3by3[2, 2]);
        }

        [TestMethod]
        public virtual void Test4by4()
        {
            IGame game4by4 = new SimpleGame(0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15);

            game4by4.Shift(4);
            game4by4.Shift(8);
            game4by4.Shift(9);
            game4by4.Shift(10);
            game4by4.Shift(14);
            game4by4.Shift(13);
            game4by4.Shift(13);
            game4by4.Shift(15);

            Assert.AreEqual(game4by4[3, 3], 0);
           
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public virtual void TestBadInput()
        {
            IGame gameBad = new SimpleGame(0, 1, 2, 3, 4);

            Assert.Fail();
        }
    }
    
}
