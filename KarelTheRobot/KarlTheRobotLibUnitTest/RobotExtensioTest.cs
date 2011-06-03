using KarelRobotCore.Enums;
using KarelTheRobotLib;
using KarelTheRobotLib.Extensions;
using NUnit.Framework;

namespace KarlTheRobotLibUnitTest
{
    [TestFixture]
    public class RobotExtensiotest
    {
        [Test]
        public void TestNorth()
        {
            var robot = new Robot();
            Assert.AreEqual(robot.ToDirectionName(Direction.North), "North");
        }

        [Test]
        public void TestEast()
        {
            var robot = new Robot();
            Assert.AreEqual(robot.ToDirectionName(Direction.East), "East");
        }
        
        [Test]
        public void TestWest()
        {
            var robot = new Robot();
            Assert.AreEqual(robot.ToDirectionName(Direction.West), "West");
        }
        
        [Test]
        public void TestSouth()
        {
            var robot = new Robot();
            Assert.AreEqual(robot.ToDirectionName(Direction.South), "South");
        }

    }
}
