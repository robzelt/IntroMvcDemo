using System.Web;
using System.Web.Security;
using MvcDemo.Infrastructure.Authentication.Exceptions;
using MvcDemo.Infrastructure.Authentication.Interfaces;

namespace MvcDemo.Infrastructure.Authentication
{
    public class FormsAuthProvider : IAuthProvider
    {

        public bool Authenticate(string name, string username, string password)
        {
            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                throw new InvalidCredentialsException();
            }
            UserIdentity userIdentity = UserIdentity.GetUserIdentity(username);
            HttpContext.Current.User = userIdentity;
            FormsAuthentication.SetAuthCookie(username, false);
            return true;
        }


        public void SignOut(HttpContextBase context)
        {
            FormsAuthentication.SignOut();
        }
    }
}