using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcDemo.Models
{
    public class Meeting
    {
        public int Id { get; set; }

        [Required(ErrorMessage="Don't even think about it!")]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        public DateTime? MeetingDate { get; set; }

        public DateTime? MakeUpDate { get; set; }

        [Required]
        public int AttendeesExpectedCount { get; set; }

        public int AttendeesActualCount { get; set; }

        [Required]
        public string MeetingAdminEmailAddress { get; set; }

        [Required]
        public string ConfirmMeetingAdminEmailAddress { get; set; }


    }
}