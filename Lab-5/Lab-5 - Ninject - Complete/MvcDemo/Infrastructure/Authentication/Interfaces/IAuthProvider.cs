using System.Web;

namespace MvcDemo.Infrastructure.Authentication.Interfaces
{
    public interface IAuthProvider
    {
        bool Authenticate(string name, string username, string password);
        void SignOut(HttpContextBase context);
    }
}