using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcDemo.Models;
using MvcDemo.Models.Interfaces;

namespace MvcDemo.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMeetingRepository meetingRepository;

        public HomeController(IMeetingRepository repositoryParam)
        {
            meetingRepository = repositoryParam;
        }

        // GET: Home
        public ActionResult Index()
        {
            List<Meeting> meetings = meetingRepository.GetAll();
            
            return View(meetings);    
        }
    }
}