using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KarelTheRobotLib.Exceptions
{  
    [Serializable]
    public class KarelOutOfBoundsExcception : Exception
    {
        public KarelOutOfBoundsExcception() { }
        public KarelOutOfBoundsExcception(string message) : base(message) { }
        public KarelOutOfBoundsExcception(string message, Exception inner) : base(message, inner) { }
        protected KarelOutOfBoundsExcception(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context)
            : base(info, context) { }
    }
}
