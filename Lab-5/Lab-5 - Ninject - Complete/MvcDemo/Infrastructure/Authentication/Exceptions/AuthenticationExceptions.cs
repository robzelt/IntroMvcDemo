using System;

namespace MvcDemo.Infrastructure.Authentication.Exceptions
{
    public class IdentityException : Exception
    {
        
    }

    public class InvalidCredentialsException : IdentityException
    {
         
    }

    public class UserNotAuthenticatedException : IdentityException
    {
        
    }

    public class UnsupportedAuthenticationType : IdentityException
    {
        
    }
}