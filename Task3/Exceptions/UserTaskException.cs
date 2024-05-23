using System;

namespace Task3.Exceptions
{
    public class UserTaskException : Exception
    {
        public UserTaskException() { }

        public UserTaskException(string message) : base(message) { }

        public UserTaskException(string message, Exception innerException) : base(message, innerException) { }
    }
}
