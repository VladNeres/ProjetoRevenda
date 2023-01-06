using System;

namespace ApiRevenda.Exceptions
{
    public class NullReferenceException: Exception
    {
        public const string MessageDefault = "object null";

        public NullReferenceException(): base(MessageDefault)
        {

        }

        public NullReferenceException(string message): base(message)
        {

        }

        public NullReferenceException(Exception innerException): base (MessageDefault, innerException)
        {

        }
    }
}
