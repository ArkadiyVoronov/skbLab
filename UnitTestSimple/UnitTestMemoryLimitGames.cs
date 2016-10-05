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
        }
    }
}
