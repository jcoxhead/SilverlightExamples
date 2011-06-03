using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KarelTheRobotLib.Exceptions
{
    [Serializable]
    public class KarelCrashedException : Exception
    {
        public KarelCrashedException() { }
        public KarelCrashedException(string message) : base(message) { }
        public KarelCrashedException(string message, Exception inner) : base(message, inner) { }
        protected KarelCrashedException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context)
            : base(info, context) { }
    }
}
