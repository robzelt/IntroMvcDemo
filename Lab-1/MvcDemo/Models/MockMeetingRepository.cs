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
                Meeting m1 = new Meeting() { Title = "Data sig: A Gentle Intro to In-Memory OLTP in SQL Server 2014 - Kevin Feasel", Description = "A Gentle Introduction to In-Memory OLTP in SQL Server 2014", MeetingDate = DateTime.Parse("5/21/2014 18:00") };
                Meeting m2 = new Meeting() { Title = "Dev Craftsmanship sig: Developing a Win 8.1 app", Description = "We will continue to work with the MVVM pattern by looking at some examples", MeetingDate = DateTime.Parse("5/28/2014 18:00") };                
                Meeting m3 = new Meeting() { Title = "Web/Mobile Apps sig: MVC5", Description = "A hands on lab intro to ASP.NET MVC", MeetingDate = DateTime.Parse("6/4/2014 18:00") };
                Meeting m4 = new Meeting() { Title = "Main Meeting: Unlocking the Power of Object-Oriented C# - Jay Hil", Description = "This lively session will draw and enforce connections among object-oriented design principles and patterns through imaginative visualization, thought experiments, and short live coding demonstrations.", MeetingDate = DateTime.Parse("6/11/2014 18:00") };
                Meeting m5 = new Meeting() { Title = "F#/Data Analytics Hands-On Lab", Description = "Adam Haile will show how to do the Twitter analysis using a more functional style", MeetingDate = DateTime.Parse("6/26/2014 18:00") };
                Meeting m6 = new Meeting() { Title = "An evening with Thomas Petricek", Description = "Thomas is well know in the functional community for his work on F#, Deedle (data frame for time-series analysis), and FSharp.Data.", MeetingDate = DateTime.Parse("7/10/2014 18:00") };
                
                this.Add(m1);
                this.Add(m2);
                this.Add(m3);
                this.Add(m4);
                this.Add(m5);
                this.Add(m6);
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