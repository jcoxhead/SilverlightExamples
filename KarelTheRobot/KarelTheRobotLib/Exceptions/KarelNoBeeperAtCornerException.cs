using System;

namespace KarelTheRobotLib.Exceptions
{
    [Serializable]
    public class KarelNoBeeperAtCornerException : Exception
    {
        public KarelNoBeeperAtCornerException() { }
        public KarelNoBeeperAtCornerException(string message) : base(message) { }
        public KarelNoBeeperAtCornerException(string message, Exception inner) : base(message, inner) { }
        protected KarelNoBeeperAtCornerException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context)
            : base(info, context) { }
    }

}
