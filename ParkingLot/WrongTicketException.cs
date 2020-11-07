using System;
using System.Runtime.Serialization;

namespace ParkingLot
{
    [Serializable]
    public class WrongTicketException : Exception
    {
        public WrongTicketException()
        {
        }

        public WrongTicketException(string message) : base(message)
        {
        }

        public WrongTicketException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected WrongTicketException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}