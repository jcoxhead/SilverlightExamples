using KarelRobotCore.Enums;

namespace KarelTheRobotLib.Extensions
{
    public static class RobotExtensions
    {
        public static string ToDirectionName(this Robot str, Direction direction)
        {
            switch (direction)
            {
                case Direction.North:
                    return "North";
                case Direction.East:
                    return "East";
                case Direction.South:
                    return "South";
                case Direction.West:
                    return "West";
                default:
                    return "Unknown";
            }
        }
    }
}
