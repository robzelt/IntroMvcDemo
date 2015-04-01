using MvcDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace MvcDemo
{

    public class MockMeetingRepository
    {
        public static int NextMeetingId = -1;

        public MockMeetingRepository()
        {
            if (NextMeetingId == -1)
            {
                NextMeetingId = 1;
                Meeting m1 = new Meeting() { Title = "Data sig: A Gentle Intro to In-Memory OLTP in SQL Server 2014 - Kevin Feasel", Description = "A Gentle Introduction to In-Memory OLTP in SQL Server 2014", MeetingDate = DateTime.Parse("5/21/2014 18:00"), AttendeesExpectedCount = 50, AttendeesActualCount = 75, MeetingAdminEmailAddress = "gpugh@nc.rr.com", ConfirmMeetingAdminEmailAddress = "gpugh@nc.rr.com" };
                Meeting m2 = new Meeting() { Title = "Dev Craftsmanship sig: Developing a Win 8.1 app", Description = "We will continue to work with the MVVM pattern by looking at some examples", MeetingDate = DateTime.Parse("5/28/2014 18:00"), AttendeesExpectedCount = 65, AttendeesActualCount = 65, MeetingAdminEmailAddress = "gpugh@nc.rr.com", ConfirmMeetingAdminEmailAddress = "gpugh@nc.rr.com" };
                Meeting m3 = new Meeting() { Title = "Web/Mobile Apps sig: MVC5", Description = "A hands on lab intro to ASP.NET MVC", MeetingDate = DateTime.Parse("6/4/2014 18:00"), AttendeesExpectedCount = 40, AttendeesActualCount = 85, MeetingAdminEmailAddress = "gpugh@nc.rr.com", ConfirmMeetingAdminEmailAddress = "gpugh@nc.rr.com" };
                Meeting m4 = new Meeting() { Title = "Main Meeting: Unlocking the Power of Object-Oriented C# - Jay Hil", Description = "This lively session will draw and enforce connections among object-oriented design principles and patterns through imaginative visualization, thought experiments, and short live coding demonstrations.", MeetingDate = DateTime.Parse("6/11/2014 18:00"), AttendeesExpectedCount = 50, AttendeesActualCount = 87, MeetingAdminEmailAddress = "gpugh@nc.rr.com", ConfirmMeetingAdminEmailAddress = "gpugh@nc.rr.com" };
                Meeting m5 = new Meeting() { Title = "F#/Data Analytics Hands-On Lab", Description = "Adam Haile will show how to do the Twitter analysis using a more functional style", MeetingDate = DateTime.Parse("6/26/2014 18:00"), AttendeesExpectedCount = 50, AttendeesActualCount = 45, MeetingAdminEmailAddress = "gpugh@nc.rr.com", ConfirmMeetingAdminEmailAddress = "gpugh@nc.rr.com" };
                Meeting m6 = new Meeting()
                {
                    Title = "An evening with Thomas Petricek", 
                    Description = "Thomas is well know in the functional community for his work on F#, Deedle (data frame for time-series analysis), and FSharp.Data.", 
                    MeetingDate = DateTime.Parse("7/10/2014 18:00"), 
                    AttendeesExpectedCount = 50, AttendeesActualCount = 62, MeetingAdminEmailAddress = "gpugh@nc.rr.com", ConfirmMeetingAdminEmailAddress = "gpugh@nc.rr.com"
                };


                Meeting m7 = new Meeting()
                {
                    Title = "Web sig: Intro to MVC - Hands on Lab",
                    Description = "For our final 2014 Intro to MVC meeting we will continue to evolve the demo project by looking at Output Caching, basic Action Filters, and extend some more client side code for basic JSON data access using ASP.Net Web Api. ",
                    MeetingDate = DateTime.Parse("10/1/2014 18:00"),
                    AttendeesExpectedCount = 50,
                    AttendeesActualCount = 62,
                    MeetingAdminEmailAddress = "gpugh@nc.rr.com",
                    ConfirmMeetingAdminEmailAddress = "gpugh@nc.rr.com"
                };

                Meeting m8 = new Meeting()
                {
                    Title = "Main Meeting: Get Kinect-ed - Chris Gardner",
                    Description = "As the availability and feature set of the Kinect expands, it is becoming more important for .NET developers to become familiar with the abilities of this amazing device. This talk will bring you up to speed with the basic capabilities of this device. Starting with simple camera support, we will work our way all the way through voice recognition. Then, we will take a look at the newest revision of the hardware to give you a head start on what to expect.",
                    MeetingDate = DateTime.Parse("10/8/2014 18:00"),
                    AttendeesExpectedCount = 50,
                    AttendeesActualCount = 62,
                    MeetingAdminEmailAddress = "gpugh@nc.rr.com",
                    ConfirmMeetingAdminEmailAddress = "gpugh@nc.rr.com"
                };

                Meeting m9 = new Meeting()
                {
                    Title = "F# SIG - Concurrency in F# (Riccardo Terrell from MSFT)",
                    Description = "Writing safe concurrent programs has become a principal concern in the past years, as multicore CPUs have become more widespread. ",
                    MeetingDate = DateTime.Parse("10/21/2014 18:00"),
                    AttendeesExpectedCount = 50,
                    AttendeesActualCount = 62,
                    MeetingAdminEmailAddress = "gpugh@nc.rr.com",
                    ConfirmMeetingAdminEmailAddress = "gpugh@nc.rr.com"
                };



                
                this.Add(m1);
                this.Add(m2);
                this.Add(m3);
                this.Add(m4);
                this.Add(m5);
                this.Add(m6);
                this.Add(m7);
                this.Add(m8);
                this.Add(m9);
            }
        }
        public Meeting Get(int id)
        {
            return ListFor<Meeting>().Where(x => x.Id == id).FirstOrDefault();
        }
        public Meeting Get(Meeting meeting)
        {
            return ListFor<Meeting>().Where(x => x.Id == meeting.Id).FirstOrDefault();
        }
        public List<Meeting> GetAll()
        {
            return ListFor<Meeting>().ToList();
        }


        public Meeting Add(Meeting entity)
        {
            entity.Id = NextMeetingId;
            ListFor<Meeting>().Add(entity);
            NextMeetingId = NextMeetingId + 1;
            return entity;
        }
        public bool Remove(int id)
        {
            ListFor<Meeting>().Remove(ListFor<Meeting>().FirstOrDefault(m => m.Id == id));
            return true;
        }
        
        public Meeting Update(Meeting meeting)
        {
            ListFor<Meeting>().Remove(ListFor<Meeting>().Find(x => x.Id == meeting.Id));
            ListFor<Meeting>().Add(meeting);
            return meeting;
        }
        
        /**********************************************************************/
        private static readonly IDictionary<Type, object> _lists = new Dictionary<Type, object>();
        private static readonly object _lockObject = new object();
        private static List<Meeting> ListFor<T>()
        {
            var type = typeof(T);
            if (!_lists.ContainsKey(type))
            {
                lock (_lockObject)
                {
                    if (!_lists.ContainsKey(type))
                    {
                        Type listType = typeof(List<>).MakeGenericType(type);
                        _lists[type] = Activator.CreateInstance(listType);
                    }
                }
            }
            return (List<Meeting>)_lists[type];
        }
    }

}