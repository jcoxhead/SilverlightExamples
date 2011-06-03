namespace KarelTheRobotLib.DTO
{
    public class LocationPoint
    {
        #region Private Fields

        #endregion

        #region Public Constructors

        public LocationPoint()
        {
            Avenue = 0;
            Street = 0;
        }

        public LocationPoint(int avenue, int street)
        {
            Avenue = avenue;
            Street = street;
        }

        #endregion

        #region Public Accessors

        public int Street
        {
            get;
            set;
        }

        public int Avenue
        {
            get;
            set;
        }

        #endregion

        #region Equality Overloads

        public override bool Equals(System.Object obj)
        {
            // If parameter is null return false.
            if (obj == null)
            {
                return false;
            }

            // If parameter cannot be cast to Point return false.
            var kpoint = obj as LocationPoint;
            if ((System.Object)kpoint == null)
            {
                return false;
            }

            var that = (LocationPoint)obj;
            if (this.Avenue == that.Avenue
            && this.Street == that.Street)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override int GetHashCode()
        {
            return Avenue ^ Street;
        }

        public override string ToString()
        {
            return "#<LocationPoint " + Avenue + "," + Street + ">";
        }

        #endregion

        #region Overloaded Operators

        public static bool operator ==(LocationPoint leftSideAssignement, LocationPoint rightHandAssignement)
        {
            // If both are null, or both are same instance, return true.
            if (System.Object.ReferenceEquals(leftSideAssignement, rightHandAssignement))
            {
                return true;
            }

            // If one is null, but not both, return false.
            if (((object)leftSideAssignement == null) || ((object)rightHandAssignement == null))
            {
                return false;
            }

            // Return true if the fields match:
            return (leftSideAssignement.Street == rightHandAssignement.Street
                    && leftSideAssignement.Avenue == rightHandAssignement.Avenue);
        }

        public static bool operator !=(LocationPoint leftSideAssignement, LocationPoint rightSideAssignement)
        {
            return !(leftSideAssignement == rightSideAssignement);
        }

        #endregion
    }
}
