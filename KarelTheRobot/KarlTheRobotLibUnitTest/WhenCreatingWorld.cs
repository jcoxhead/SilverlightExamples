using KarelTheRobotLib;
using NUnit.Framework;

namespace KarlTheRobotLibUnitTest
{
    [TestFixture]
    public class WhenCreatingWorld : BaseContext<World>
    {
        private const int NoOfAvenues = 5;
        private const int NoOfStreets = 5;

        protected override World SetupContext()
        {
            return new World(NoOfAvenues, NoOfStreets);
        }

        protected override void Because()
        {
        }

        [Test]
        public void WorldTypesShouldNotBeNull()
        {
            Assert.IsNotNull(Sut);
        }

        [Test]
        public void WorldTypesShouldHaveAvenues()
        {
            Assert.IsTrue(Sut.NumberOfAvenues == 5);
        }

        [Test]
        public void WorldTypesShouldHaveStreetss()
        {
            Assert.IsTrue(Sut.NumberOfStreets == 5);
        }
    }
}
