using System.Security.Principal;
using System.Web.Configuration;
using MvcDemo.Infrastructure.Authentication.Exceptions;

namespace MvcDemo.Infrastructure.Authentication
{
    public class UserIdentity : IPrincipal
    {
        private GenericIdentity identity;
        private readonly string userRole;

        public IIdentity Identity
        {
            get { return identity; }
        }

        public bool IsInRole(string role)
        {
            return role == userRole;
        }

        public static UserIdentity GetUserIdentity(string username)
        {
            return new UserIdentity(username);
        }

        private UserIdentity(string username)
        {
            userRole = "user";
            InitializeUserIdentity(username);
        }

        private void InitializeUserIdentity(string username)
        {
            string authenticationType;
            AuthenticationMode authenticationMode = ((AuthenticationSection) WebConfigurationManager.GetSection("system.web/authentication")).Mode;
            switch (authenticationMode)
            {
                case AuthenticationMode.Forms:
                    authenticationType = authenticationMode.ToString();
                    break;
                default:
                    throw new UnsupportedAuthenticationType();
            }
            identity = new GenericIdentity(username, authenticationType);
        }
    }
}