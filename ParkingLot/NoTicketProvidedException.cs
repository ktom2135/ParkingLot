using System;
using System.Runtime.Serialization;

namespace ParkingLot
{
    [Serializable]
    public class NoTicketProvidedException : Exception
    {
        public NoTicketProvidedException()
        {
        }

        public NoTicketProvidedException(string message) : base(message)
        {
        }

        public NoTicketProvidedException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected NoTicketProvidedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}