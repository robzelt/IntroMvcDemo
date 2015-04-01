using System.Web.Mvc;
using MvcDemo.Models;

namespace MvcDemo.Infrastructure.Binders
{
    public class UserInfoBinder : IModelBinder
    {
        private const string UserInfoSessionKey = "UserInfoSessionKey";

        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            UserInfo userModel = null;
            if (controllerContext.HttpContext.Session != null)
            {
                userModel = controllerContext.HttpContext.Session[UserInfoSessionKey] as UserInfo;
            }
            if (userModel == null)
            {
                userModel = new UserInfo();
                if (controllerContext.HttpContext.Session != null)
                {
                    controllerContext.HttpContext.Session[UserInfoSessionKey] = userModel;
                }
            }
            return userModel;
        }
    }
}