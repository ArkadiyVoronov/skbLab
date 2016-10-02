using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Kontur
{
    [TestClass]
    public class UnitTestBaseGame
    {
        [TestMethod]
        virtual public void TestLocation(){}

        [TestMethod]
        virtual public void TestBadShift(){}

        [TestMethod]
        virtual public void TestShift(){}

        [TestMethod]
        virtual public void Test3by3(){}

        [TestMethod]
        virtual public void Test4by4(){}
    }
}
