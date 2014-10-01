using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace MvcDemo.Helpers
{
    public static class CopyrightHelper
    {
        public static MvcHtmlString Copyright(
            this HtmlHelper htmlHelper,
            string text)
        {
            MvcHtmlString result = new MvcHtmlString("Copyright " + DateTime.Now.Year + " " + text);
            return result;
        }
    }
}