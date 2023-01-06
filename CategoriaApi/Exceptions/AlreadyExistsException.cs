using System;

namespace ApiRevenda.Exceptions
{
    public class AlreadyExistsException: Exception
    {
        private const string MessageDefault = "O objeto já existe";
        public AlreadyExistsException() : base(MessageDefault)
        {

        }

        public AlreadyExistsException(string message): base (message)
        {

        }

        public AlreadyExistsException(Exception innerException): base(MessageDefault, innerException)
        {

        }
    }
}
