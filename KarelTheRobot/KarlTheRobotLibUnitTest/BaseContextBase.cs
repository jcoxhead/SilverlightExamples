namespace KarlTheRobotLibUnitTest
{
    public abstract class BaseContextBase<T>
    {
        protected abstract T SetupContext();

        protected abstract void Because();

        protected T Sut { get; set; }

        protected void PerformSetup()
        {
            Sut = SetupContext();
            Because();
        }
    }
}
