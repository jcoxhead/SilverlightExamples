using KarelRobotCore.Interfaces;

namespace KarelTheRobotLib.Factories
{
    // Exemplifies class abstract factory pattern
    // Please note: - Violates YAGNI - but being used to demonstrate 
    // extensibility - potential requirements is that
    // different robots will be created over time.
    public abstract class AbstractRobotFactory
    {
        public abstract IRobot CreateRobot(IWorld world);
    }
}
