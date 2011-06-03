using KarelRobotCore.Enums;

namespace KarelRobotCore.Interfaces
{
    public interface IRobot
    {
        IWorld World { get; set; }
        int Beepers { get; set; }
        Direction Direction { get; set; }
        int Street { get; set; }
        int Avenue { get; set; }
        void TurnLeft();
        void TurnRight();
        void TurnAround();
        void Move();
        void PickBeeper();

        ///**
        // * TODO: bounds checking on putBeeper!  Is beeper bag empty?
        // */
        void PutBeeper();

        bool NoBeepersPresent();
        void Turnoff();
        bool IsDirectionBlocked(Direction direction);
        bool FacingEast();
        bool FacingNorth();
        bool FacingSouth();
        bool FacingWest();
        bool NotFacingEast();
        bool NotFacingNorth();
        bool NotFacingSouth();
        bool NotFacingWest();
        bool FrontIsBlocked();
        bool FrontIsClear();
        bool LeftIsBlocked();
        bool LeftIsClear();
        bool RightIsBlocked();
        bool RightIsClear();
        bool AnyBeepersInBeeperBag();
        bool NextToABeeper();
        bool NoBeepersInBeeperBag();
        bool NotNextToABeeper();
    }
}