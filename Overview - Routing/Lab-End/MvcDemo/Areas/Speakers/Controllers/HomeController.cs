using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcDemo.Areas.Speakers.Controllers
{
    public class HomeController : Controller
    {
        // GET: Speakers/Home
        public ActionResult Index()
        {
            return View();
        }
    }
}