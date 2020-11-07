using System;
using System.Runtime.Serialization;

namespace ParkingLot
{
    [Serializable]
    public class NoPositonException : Exception
    {
        public NoPositonException()
        {
        }

        public NoPositonException(string message) : base(message)
        {
        }

        public NoPositonException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected NoPositonException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}