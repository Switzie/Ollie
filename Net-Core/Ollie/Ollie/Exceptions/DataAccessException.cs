using System;

namespace Ollie.Exceptions
{
        public class DataAccessException : Exception
        {
            public DataAccessException(string message, Exception innerException) :
                base(message, innerException)
            {
            }
        }
}