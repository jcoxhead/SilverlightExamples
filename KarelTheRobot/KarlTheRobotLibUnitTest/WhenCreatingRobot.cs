using KarelRobotCore.Interfaces;
using KarelTheRobotLib;
using NUnit.Framework;
using Rhino.Mocks;

namespace KarlTheRobotLibUnitTest
{
    public class WhenCreatingRobot : BaseContext<Robot>
    {
        private IWorld _world;

        protected override Robot SetupContext()
        {
            _world = MockRepository.GenerateStub<IWorld>();
            _world.Stub(x => _world.NumberOfAvenues).Return(5);
            _world.Stub(x => _world.NumberOfStreets).Return(5);

            return new Robot(_world);
        }

        protected override void Because()
        {         
        }

        [Test]
        public void AvenuesShouldHaveBeenSet()
        {
            Assert.AreEqual(Sut.World.NumberOfAvenues, 5);
        }

        [Test]
        public void StreetsShouldHaveBeenSet()
        {
            Assert.AreEqual(Sut.World.NumberOfStreets, 5);
        }

        [Test]
        public void LocationAvenueShouldHaveBeenSet()
        {
            Assert.AreEqual(Sut.Avenue, 1);
        }

        [Test]
        public void LocationStreetShouldHaveBeenSet()
        {
            Assert.AreEqual(Sut.Street, 1);
        }
    }
}
