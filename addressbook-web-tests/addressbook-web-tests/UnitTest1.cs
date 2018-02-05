using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace addressbook_web_tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethodSquare()
        {
            Square s1 = new Square(5);

            Assert.AreEqual(s1.Size, 5);

            s1.Size = 14;

            Assert.AreEqual(s1.Size, 14);

            s1.Colored = true;
        }

        [TestMethod]
        public void TestMethodCircle()
        {
            Circle s1 = new Circle(5);

            Assert.AreEqual(s1.Radius, 5);

            s1.Radius = 14;

            Assert.AreEqual(s1.Radius, 14);

            s1.Colored = true;
        }
    }
}
