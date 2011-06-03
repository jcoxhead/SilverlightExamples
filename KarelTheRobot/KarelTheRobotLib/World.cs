using KarelRobotCore.Enums;
using KarelRobotCore.Interfaces;
using KarelTheRobotLib.DTO;
using KarelTheRobotLib.Exceptions;

namespace KarelTheRobotLib
{
    public class World : IWorld
    {
        private readonly Corner[][] _corners;

        #region Public Constructors

        public World(int numberOfAvenues, int numberOfStreets)
        {
            NumberOfAvenues = numberOfAvenues;
            NumberOfStreets = numberOfStreets;

            _corners = new Corner[numberOfAvenues][];

            for (int currentAvenue = 0; currentAvenue < numberOfAvenues; currentAvenue++)
            {
                _corners[currentAvenue] = new Corner[NumberOfStreets];
                for (int currentStreet = 0; currentStreet < numberOfStreets; currentStreet++)
                {
                    _corners[currentAvenue][currentStreet] = new Corner(currentAvenue + 1, currentStreet + 1);
                }
            }
            AddEastWestWall(1, numberOfStreets, numberOfAvenues);
            AddNorthSouthWall(numberOfAvenues, 1, numberOfStreets);
        }

        #endregion

        #region Public Properties

        public int NumberOfAvenues
        {
            get;
            private set;
        }

        public int NumberOfStreets
        {
            get;
            private set;
        }

        public int RobotStartBeepers
        {
            get;
            set;
        }

        public int RobotStartAvenue
        {
            get;
            set;
        }

        public int RobotStartStreet
        {
            get;
            set;
        }

        public Direction RobotStartDirection
        {
            get;
            set;
        }

        #endregion

        #region Protected Members

        public ICorner GetCorner(int avenue, int street)
        {
            return _corners[avenue - 1][street - 1];
        }

        #endregion

        #region Private Fields

        private bool CheckIfCornersAreEual(World that)
        {
            for (int a = 1; a <= NumberOfAvenues; a++)
                for (int s = 1; s <= NumberOfStreets; s++)
                    if (!this.GetCorner(a, s).Equals(that.GetCorner(a, s)))
                    {
                        return false;
                    }
            return true;
        }

        private static bool CheckIfCornersAreEual(World worldA, World b)
        {
            for (int a = 1; a <= worldA.NumberOfAvenues; a++)
                for (int s = 1; s <= worldA.NumberOfStreets; s++)
                    if (!worldA.GetCorner(a, s).Equals(b.GetCorner(a, s)))
                    {
                        return false;
                    }
            return true;
        }

        #endregion

        #region Public Overrides

        public override bool Equals(System.Object obj)
        {
            // If parameter is null return false.
            if (obj == null)
            {
                return false;
            }

            // If parameter cannot be cast to Point return false.
            World world = obj as World;
            if ((System.Object)world == null)
            {
                return false;
            }

            var that = (World)obj;
            if (this.NumberOfAvenues == that.NumberOfAvenues
            && this.NumberOfStreets == that.NumberOfStreets)
            {
                return CheckIfCornersAreEual(world);
            }
            else
            {
                return false;
            }
        }

        public override int GetHashCode()
        {
            return NumberOfAvenues + NumberOfStreets + _corners[0].GetHashCode(); // this neeeds stenghening ...
        }

        #endregion

        #region Overloaded Operators

        public static bool operator ==(World a, World b)
        {
            // If both are null, or both are same instance, return true.
            if (System.Object.ReferenceEquals(a, b))
            {
                return true;
            }

            // If one is null, but not both, return false.
            if (((object)a == null) || ((object)b == null))
            {
                return false;
            }

            // Return true if the fields match:
            return (a.NumberOfAvenues == b.NumberOfAvenues
                    && a.NumberOfStreets == b.NumberOfStreets && CheckIfCornersAreEual(a, b));
        }

        public static bool operator !=(World a, World b)
        {
            return !(a == b);
        }

        #endregion

        #region Public  Methods

        #region Add Wall Members

        public void AddEastWestWall(int startAvenue, int northOfStreet, int numberOfBlocks)
        {
            for (int blockNumber = 0; blockNumber < numberOfBlocks; blockNumber++)
            {
                var corner = GetCorner(startAvenue + blockNumber, northOfStreet);
                corner.HasNorthWall = true;
            }
        }

        public void AddNorthSouthWall(int eastOfAvenue, int startStreet, int numberOfBlocks)
        {
            for (int blockNumber = 0; blockNumber < numberOfBlocks; blockNumber++)
            {
                var corner = GetCorner(eastOfAvenue, startStreet + blockNumber);
                corner.HasEastWall = true;
            }
        }

        #endregion

        #region Util Members

        public bool CheckEastWestWallExists(int atAvenue, int northOfStreet)
        {
            return GetCorner(atAvenue, northOfStreet).HasNorthWall;
        }

        public bool CheckNorthSouthWallExists(int eastOfAvenue, int atStreet)
        {
            return GetCorner(eastOfAvenue, atStreet).HasEastWall;
        }

        public bool IsInBounds(int avenue, int street)
        {
            return ValidStreet(street) && street <= NumberOfStreets
                   && ValidAvenue(avenue) && avenue <= NumberOfAvenues;
        }

        #endregion

        #region Beeper Methods

        public bool CheckBeepersExists(int avenue, int street)
        {
            var corner = GetCorner(avenue, street);
            return (corner.NumerOfBeepers > 0);
        }

        public void PickBeeper(int avenue, int street)
        {
            var corner = GetCorner(avenue, street);
            int numberOfBeepers = corner.NumerOfBeepers;
            if (numberOfBeepers > 0)
            {
                corner.NumerOfBeepers = numberOfBeepers - 1;
                return;
            }

            throw new KarelNoBeeperAtCornerException();
        }

        public void PutBeeper(int avenue, int street)
        {
            var corner = GetCorner(avenue, street);
            corner.NumerOfBeepers = corner.NumerOfBeepers + 1;
        }

        #endregion

        #endregion

        #region Private Helpers

        private static bool ValidStreet(int street)
        {
            return street > 0;
        }

        private static bool ValidAvenue(int avenue)
        {
            return avenue > 0;
        }

        #endregion
    }
}


