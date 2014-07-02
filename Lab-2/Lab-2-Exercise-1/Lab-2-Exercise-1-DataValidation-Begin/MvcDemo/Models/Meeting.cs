using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcDemo.Models
{
    public class Meeting
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime? MeetingDate { get; set; }

        public DateTime? MakeUpDate { get; set; }

        public int AttendeesExpectedCount { get; set; }

        public int AttendeesActualCount { get; set; }

        public string MeetingAdminEmailAddress { get; set; }

        public string ConfirmMeetingAdminEmailAddress { get; set; }


    }
}