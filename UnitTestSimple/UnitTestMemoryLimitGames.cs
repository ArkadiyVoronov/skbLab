using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Kontur
{
    [TestClass]
    public class UnitTestMemoryLimitGames: UnitTestImmutableGame
    {
        [TestInitialize()]
        public override void Initialize()
        {
            game = new MemoryLimitGame(0, 1, 2, 3);
            game3by3 = new MemoryLimitGame(0, 1, 2, 3, 4, 5, 6, 7, 8);
            game4by4 = new MemoryLimitGame(0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public override void TestBadInputMoreArgument()
        {
            IGame gameBad = new MemoryLimitGame(0, 1, 2, 3, 4);

            Assert.Fail();
        }

        public override void TestBadInputDublication()
        {
            IGame gameBad = new MemoryLimitGame(0, 1, 2, 1);

            Assert.Fail();
        }
    }
}
