using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace MvcDemo.Helpers
{
    public static class MenuItemHelper
    {
        public static MvcHtmlString MenuItem(this HtmlHelper htmlHelper,
            string text,string action,string controller)
        {
            var currentAction = (string)htmlHelper.ViewContext.RouteData.Values["action"];
            var currentController = (string)htmlHelper.ViewContext.RouteData.Values["controller"];
            var sb = new StringBuilder();
            string activeClass = "active";

            MvcHtmlString actionLink;
            actionLink = htmlHelper.ActionLink(text, action, controller);

            if ((string.Equals(currentAction,action,StringComparison.CurrentCultureIgnoreCase)
            ) & (string.Equals(currentController,controller,StringComparison.CurrentCultureIgnoreCase)))
            {
                sb.AppendFormat("<li class=\"{0}\">{1}</li>",activeClass,actionLink);
            }
            else
            {
                sb.AppendFormat("<li >{0}</li>",actionLink);
            }
            MvcHtmlString result = new MvcHtmlString(sb.ToString());
            return result;
        }
    }
}