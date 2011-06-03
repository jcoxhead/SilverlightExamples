using KarelTheRobotLib.DTO;
using NUnit.Framework;

namespace KarlTheRobotLibUnitTest
{
    [TestFixture]
    public class CornerUnitTest
    {
        private const int _avenue = 1;
        private const int _street = 1;

        private Corner _corner;

        [SetUp]
        public void Seup()
        {
            _corner = new Corner(_avenue, _street);
        }

        [Test]
        public void AvenueAccesorTest()
        {
            Assert.AreEqual(_corner.Avenue, _avenue);
        }

        [Test]
        public void StreetAccesorTest()
        {
            Assert.AreEqual(_corner.Street, _street);
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
            var firstCorner = new Corner(1, 1);
            var secondCorner = new Corner(1, 2);

            Assert.IsFalse(firstCorner.Equals(secondCorner));
        }

        [Test]
        public void AreEqualusingEqualityOperator()
        {
            var firstCorner = new Corner(1, 1);
            var secondCorner = new Corner(1, 1);

            Assert.IsTrue(firstCorner == secondCorner);
        }

        [Test]
        public void TestGetHashCode()
        {
            var firstCorner = new Corner(1, 1);
            var secondCorner = new Corner(1, 1);

            firstCorner.NumerOfBeepers = 2;
            secondCorner.NumerOfBeepers = 2;

            var hashCode = firstCorner.GetHashCode();

            Assert.IsTrue(firstCorner.GetHashCode() == secondCorner.GetHashCode());
        }
    }
}
