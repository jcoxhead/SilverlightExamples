using System;
using KarelRobotCore.Interfaces;

namespace KarelTheRobotLib.DTO
{
    public class Corner : ICorner
    {
        #region Private Fields

        readonly int _avenue;
        readonly int _street;

        #endregion

        #region Public Constructors

        public Corner(int avenue, int street)
        {
            _avenue = avenue;
            _street = street;
        }

        #endregion

        #region Public Properties

        public int Avenue
        {
            get
            {
                return _avenue;
            }
        }

        public int Street
        {
            get
            {
                return _street;
            }
        }

        public int NumerOfBeepers
        {
            get;
            set;
        }

        public bool HasNorthWall
        {
            get;
            set;
        }

        public bool HasEastWall
        {
            get;
            set;
        }

        #endregion

        #region Equality Operators

        public static bool operator ==(Corner firstCorner, Corner secondCorner)
        {
            // If both are null, or both are same instance, return true.
            if (System.Object.ReferenceEquals(firstCorner, secondCorner))
            {
                return true;
            }

            // If one is null, but not both, return false.
            if (((object)firstCorner == null) || ((object)secondCorner == null))
            {
                return false;
            }

            // Return true if the fields match:
            return (firstCorner._avenue == secondCorner._avenue
                    && firstCorner._street == secondCorner._street
                    && firstCorner.NumerOfBeepers == secondCorner.NumerOfBeepers
                    && firstCorner.HasNorthWall == secondCorner.HasNorthWall
                    && firstCorner.HasEastWall == secondCorner.HasEastWall);
        }

        public static bool operator !=(Corner firstCorner, Corner secondCorner)
        {
            return !(firstCorner == secondCorner);
        }

        public override bool Equals(System.Object obj)
        {
            // If parameter is null return false.
            if (obj == null)
            {
                return false;
            }

            // If parameter cannot be cast to Point return false.
            var cornerToCompare = obj as Corner;
            if ((System.Object)cornerToCompare == null)
            {
                return false;
            }

            // Return true if the fields match:
            return (_avenue == cornerToCompare._avenue
                   && _street == cornerToCompare._street
                   && NumerOfBeepers == cornerToCompare.NumerOfBeepers
                   && HasNorthWall == cornerToCompare.HasNorthWall
                   && HasEastWall == cornerToCompare.HasEastWall);
        }

        public bool Equals(Corner cornerToCompare)
        {
            // If parameter is null return false:
            if ((object)cornerToCompare == null)
            {
                return false;
            }

            // Return true if the fields match:
            return (_avenue == cornerToCompare._avenue
                    && _street == cornerToCompare._street
                    && NumerOfBeepers == cornerToCompare.NumerOfBeepers
                    && HasNorthWall == cornerToCompare.HasNorthWall
                    && HasEastWall == cornerToCompare.HasEastWall);
        }

        public override int GetHashCode()
        {
            return NumerOfBeepers + Convert.ToInt32(HasNorthWall) ^ Convert.ToInt32(HasEastWall);
        }

        #endregion
    }
}
