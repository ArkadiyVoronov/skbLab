using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Kontur
{
    [TestClass]
    public class UnitTestSimpleGame
    {
        protected IGame game;
        protected IGame game3by3;
        protected IGame game4by4;

        [TestInitialize()]
        virtual public void Initialize()
        {
            game = new SimpleGame(0, 1, 2, 3);
            game3by3 = new SimpleGame(0, 1, 2, 3, 4, 5, 6, 7, 8);
            game4by4 = new SimpleGame(0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15);
        }

        [TestMethod]
        virtual public void AccessByIndexator_game2by2_SuccesAccess()
        {
            int expected = 2;

            Assert.AreEqual(expected, game[1, 0]);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public virtual void AccessByIndexator_game2by2_FailedAccess()
        {

            int t = game[2, 0];

            Assert.Fail();
        }

        [TestMethod]
        public virtual void Shift_game2by2_SuccesShift()
        {

            game = game.Shift(1);
            game = game.Shift(3);

            Assert.AreEqual(0, game[1, 1]);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public virtual void Shift_game2by2_FailedShift()
        {
            game = game.Shift(3);

            Assert.Fail();
        }

        [TestMethod]
        public virtual void ShiftCircle_game2by2_SuccessShift()
        {
            game = game.Shift(1);
            game = game.Shift(1);
            game = game.Shift(1);
            game = game.Shift(1);

            Assert.AreEqual(0, game[0, 0]);
        }

        [TestMethod]
        public virtual void CorrectGame_Test3by3_Success()
        {
            game3by3 = game3by3.Shift(1);
            game3by3 = game3by3.Shift(4);
            game3by3 = game3by3.Shift(5);
            game3by3 = game3by3.Shift(8);

            Assert.AreEqual(0, game3by3[2, 2]);
        }

        [TestMethod]
        public virtual void CorrectGame_Test4by4_Success()
        {
            game4by4 = game4by4.Shift(4);
            game4by4 = game4by4.Shift(8);
            game4by4 = game4by4.Shift(9);
            game4by4 = game4by4.Shift(10);
            game4by4 = game4by4.Shift(14);
            game4by4 = game4by4.Shift(13);
            game4by4 = game4by4.Shift(13);
            game4by4 = game4by4.Shift(15);

            Assert.AreEqual(game4by4[3, 3], 0);
           
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public virtual void BadInput_MoreArgument_Failed()
        {
            IGame gameBad = new SimpleGame(0, 1, 2, 3, 4);

            Assert.Fail();
        }

        public virtual void BadInput_Duplicate_Failed()
        {
            IGame gameBad = new SimpleGame(0, 1, 2, 1);

            Assert.Fail();
        }
    }
    
}
