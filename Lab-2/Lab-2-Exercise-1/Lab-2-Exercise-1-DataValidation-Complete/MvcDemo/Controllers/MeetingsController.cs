using MvcDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcDemo.Controllers
{
    public class MeetingsController : Controller
    {

        private MockMeetingRepository meetingRepository;

        public MeetingsController()
        {
            //When the controller is created instantiate an instance of the repository.
            meetingRepository = new MockMeetingRepository();
        }

        // GET: Meetings
        public ActionResult Index()
        {
            // Load a list of meetings and pass it through to our view.
            List<Meeting> meetings = meetingRepository.GetAll();
            return View(meetings);
        }

        // GET: Meetings/Details/5
        public ActionResult Details(int id)
        {
            //Load the specified Meeting by the Meeting ID provided.
            Meeting meeting = meetingRepository.Get(id);
            return View(meeting);
        }

        // GET: Meetings/Create
        public ActionResult Create()
        {
            //Return the view which contains the form to enter a new meeting.
            var meeting = new Meeting();
            return View(meeting);
        }

        // POST: Meetings/Create
        [HttpPost]
        public ActionResult Create(Meeting meeting)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    //Take tne new meeting which has been posted and save it.
                    meetingRepository.Add(meeting);
                    return RedirectToAction("Index");
                }
                catch
                {
                    //If there is an exception return the form view.
                    return View(meeting);
                }
            }
            else
            {
                //If there is a validation error return the form view.
                return View(meeting);
            }
        }

        // GET: Meetings/Edit/5
        public ActionResult Edit(int id)
        {
            //Return a view with a form containing the editable contents of the meeting ID Provided.
            Meeting meeting = meetingRepository.Get(id);
            return View(meeting);
        }

        // POST: Meetings/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Meeting meeting)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    //Save the updated meeting which has been posted.
                    meetingRepository.Update(meeting);
                    return RedirectToAction("Index");
                }
                catch
                {
                    return View(meeting);
                }
            }
            else
            {
                //If there is a validation error return the form view.
                return View(meeting);
            }
        }

        // GET: Meetings/Delete/5
        public ActionResult Delete(int id)
        {
            //Return a view which shows the contents of the provided meeting id
            //and prompt form confirmation to delete.
            Meeting meeting = meetingRepository.Get(id);
            return View();
        }

        // POST: Meetings/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Meeting meeting)
        {
            try
            {
                //When the user confirms delete handle the posted meeting delete.
                meetingRepository.Remove(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View(meeting);
            }
        }
    }
}
