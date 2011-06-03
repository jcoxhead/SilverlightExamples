using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KarelTheRobotLib;
using NUnit.Framework;

namespace KarlTheRobotLibUnitTest
{
    [TestFixture]
    public class WhenComparingWorldWithNullItem : BaseContext<World>
    {
        private bool _result;

        private const int NoOfAvenues = 5;
        private const int NoOfStreets = 5;

        protected override World SetupContext()
        {
            return new World(NoOfAvenues, NoOfStreets);
        }

        protected override void Because()
        {
            _result = Sut.Equals(null);
        }

        [Test]
        public void WorldTypesShouldNotMatch()
        {
            _result.ShouldBeFalse();
        }
    }
}
