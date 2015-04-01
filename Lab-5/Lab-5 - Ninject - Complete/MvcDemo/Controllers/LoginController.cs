using System;
using System.Web.Mvc;
using System.Web.Security;
using MvcDemo.Infrastructure.Authentication.Exceptions;
using MvcDemo.Infrastructure.Authentication.Interfaces;
using MvcDemo.Models;

namespace MvcDemo.Controllers
{
    public class LoginController : Controller
    {
        private readonly IAuthProvider authProvider;

        public LoginController(IAuthProvider auth)
        {
            authProvider = auth;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View(new LoginModel());
        }

        [HttpPost]
        public ActionResult Index(UserInfo userInfo, LoginModel login, string returnUrl)
        {
            string redirectUrl = returnUrl ?? Url.Action("Index", "Home");
            ActionResult redirect;
            if (ValidateUserNamePasswordLogin(login, redirectUrl, out redirect))
            {
                userInfo.Name = login.Name;
                userInfo.UserName = login.UserName;
                return redirect;
            }
            return RedirectToAction("Fail");
        }

        [Authorize]
        public ActionResult LogOut(LoginModel login)
        {
            authProvider.SignOut(HttpContext);
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Fail(LoginModel login)
        {
            return View();
        }

        private bool ValidateUserNamePasswordLogin(LoginModel login, string redirectUrl, out ActionResult redirect)
        {
            try
            {
                if (authProvider.Authenticate(login.Name, login.UserName, login.Password))
                {
                    redirect = Redirect(redirectUrl);
                    return true;
                }
            }
            catch (InvalidCredentialsException)
            {
                ModelState.AddModelError("", "Invalid user name or password");
                RedirectToAction("Fail");
            }
            catch (UserNotAuthenticatedException)
            {
                ModelState.AddModelError("", "User could not be identified");
                RedirectToAction("Fail");
            }
            catch (UnsupportedAuthenticationType)
            {
                ModelState.AddModelError("", "Authentication mode not supported");
                RedirectToAction("Fail");
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Something went wrong");
                redirect = View();
                return true;
            }
            redirect = View();
            return false;
        }
    }
}