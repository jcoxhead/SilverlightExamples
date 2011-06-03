using NUnit.Framework;

namespace KarlTheRobotLibUnitTest
{
    [Category("UnitTests")]
    public abstract class BaseContext
    {
        protected abstract void Because();

        protected virtual void SetupContext()
        {

        }

        [SetUp]
        public virtual void TestFixtureSetup()
        {
            SetupContext();
            Because();
        }
    }

    [Category("UnitTests")]
    public abstract class BaseContext<T> : BaseContextBase<T>
    {
        [SetUp]
        public virtual void TestFixtureSetup()
        {
            PerformSetup();
        }
    }

    [Category("IntegrationTests")]
    public abstract class IntegratiuonBaseContext<T> : BaseContextBase<T>
    {
        [SetUp]
        public virtual void TestFixtureSetup()
        {
            PerformSetup();
        }
    }
}
