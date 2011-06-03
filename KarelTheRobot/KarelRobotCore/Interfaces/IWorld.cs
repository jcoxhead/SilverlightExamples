using KarelRobotCore.Enums;

namespace KarelRobotCore.Interfaces
{
    public interface IWorld
    {
        #region Public Accesors

        int NumberOfAvenues { get; }
        int NumberOfStreets { get; }
        int RobotStartBeepers { get; set; }
        int RobotStartAvenue { get; set; }
        int RobotStartStreet { get; set; }
        Direction RobotStartDirection { get; set; }

        #endregion

        #region Public Methods

        ICorner GetCorner(int avenue, int street);
        void AddEastWestWall(int startAvenue, int northOfStreet, int numberOfBlocks);
        void AddNorthSouthWall(int eastOfAvenue, int startStreet, int numberOfBlocks);
        bool CheckEastWestWallExists(int atAvenue, int northOfStreet);
        bool CheckNorthSouthWallExists(int eastOfAvenue, int atStreet);
        bool IsInBounds(int avenue, int street);
        bool CheckBeepersExists(int avenue, int street);
        void PickBeeper(int avenue, int street);
        void PutBeeper(int avenue, int street);

        #endregion
    }
}