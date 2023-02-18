using System;

namespace ApiRevenda.Exceptions
{
    public class MinCaracterException: Exception
    {
        public const string DefaultMessage = "You didn´t get the min caractere";

        public MinCaracterException():base(DefaultMessage)
        {

        }

        public MinCaracterException(string message): base (message)
        {

        }

        public MinCaracterException(Exception innerException): base(DefaultMessage, innerException)
        {

        }
    }
}
