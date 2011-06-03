using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using KarelTheRobotLib.Extensions;

namespace KarlTheRobotLibUnitTest
{
    [TestFixture]
    public class Md5UnitTest
    {
        [Test]
        public void TestExtension()
        {
            string firstString = "Jack and Jill went up the hill".GetMd5Sum();
            string secondString = "Jack and Jill went up the hill".GetMd5Sum();

            Assert.AreEqual(firstString, secondString);                        
        }
    }
}
