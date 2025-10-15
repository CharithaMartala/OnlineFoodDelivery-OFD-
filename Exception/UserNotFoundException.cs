using UserLogin.Exception;

namespace UserLogin.Exception
{
    public class UserNotFoundException : ApplicationException
    {
        public UserNotFoundException() { }
        public UserNotFoundException(string message) : base(message) { }

    }
}