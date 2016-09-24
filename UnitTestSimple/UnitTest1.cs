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
            Location actualLoc = game.GetLocation(0);
            Location expectLoc = new Location(1,  1);
            Assert.AreEqual(expectLoc.x, actualLoc.x);
            Assert.AreEqual(expectLoc.y, actualLoc.y);

            expectLoc = new Location(0, 0);
            actualLoc = game.GetLocation(1);
            Assert.AreEqual(expectLoc.x, actualLoc.x);
            Assert.AreEqual(expectLoc.y, actualLoc.y);

            expectLoc = new Location(0, 1);
            actualLoc = game.GetLocation(2);
            Assert.AreEqual(expectLoc.x, actualLoc.x);
            Assert.AreEqual(expectLoc.y, actualLoc.y);

        }
        [TestMethod]
        public void TestIndexator()
        {
            Game game = new Game(0, 1, 2, 3);
            Assert.AreEqual(0, game[0, 0]);
            Assert.AreEqual(3, game[1, 1]);
        }
        [TestMethod]
        public void TestShift()
        {
            Game game = new Game(0, 1, 2, 3);
            try
            {
                game.Shift(3);
                Assert.Fail();
            }
            catch (Exception) { }
        }
    }
}
