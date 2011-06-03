using System;
using KarelRobotCore.Interfaces;

namespace KarelTheRobotLib.Factories
{
    // Exemplifies class abstract factory pattern
    // Please note: - Violates YAGNI - but being used to demonstrate 
    // basic extensibility - potential requirements is that
    // different robots will be created over time.

    public class RobotFactory : AbstractRobotFactory
    {
        public override IRobot CreateRobot(IWorld world)
        {
            return new Robot(world);
        }
    }
}
