using KarelTheRobotLib.DTO;
using NUnit.Framework;

namespace KarlTheRobotLibUnitTest
{
    [TestFixture]
    public class LocationPointUnitTest
    {
        private const int _avenue = 1;
        private const int _street = 1;

        private LocationPoint _locationPoint;

        [SetUp]
        public void Seup()
        {
            _locationPoint = new LocationPoint(_avenue, _street);
        }

        [Test]
        public void AvenueAccesorTest()
        {
            Assert.AreEqual(_locationPoint.Avenue, _avenue);
        }

        [Test]
        public void StreetAccesorTest()
        {
            Assert.AreEqual(_locationPoint.Street, _street);
        }

        [Test]
        public void AreEual()
        {
            var firstCorner = new Corner(1, 1);
            var secondCorner = new Corner(1, 1);

            Assert.IsTrue(firstCorner.Equals(secondCorner));
        }

        [Test]
        public void AreNotEual()
        {
            var firstLocationPoint = new LocationPoint(1, 1);
            var secondLocationPoint = new LocationPoint(1, 2);

            Assert.IsFalse(firstLocationPoint.Equals(secondLocationPoint));
        }

        [Test]
        public void AreEqualusingEqualityOperator()
        {
            var firstLocationPoint = new LocationPoint(1, 1);
            var secondLocationPoint = new LocationPoint(1, 1);

            Assert.IsTrue(firstLocationPoint == secondLocationPoint);
        }

        [Test]
        public void TestGetHashCode()
        {
            var firstLocationPoint = new LocationPoint(1, 1);
            var secondLocationPoint = new LocationPoint(1, 1);

            var hashCode = firstLocationPoint.GetHashCode();

            Assert.IsTrue(firstLocationPoint.GetHashCode() == secondLocationPoint.GetHashCode());
        }
    }
}
