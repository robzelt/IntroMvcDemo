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

        [Required]
        [StringLength(80)]
        public string Title { get; set; }

        [Required]
        [StringLength(350, MinimumLength = 5, ErrorMessage = "Ya gotta gimme somethin'. I need between 5 and 350 characters!")]
        public string Description { get; set; }


        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM-dd-yyyy}", ApplyFormatInEditMode = true)]        
        [Display(Name = "Meeting Date")]
        public DateTime MeetingDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM-dd-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Make Up Date")]
        public DateTime? MakeUpDate { get; set; }

        [Required]
        [Display(Name = "Expected Attendance")]
        [Range(0, 200)]
        public int? AttendeesExpectedCount { get; set; }

        [Display(Name = "Actual Attendance")]
        [Range(0, 200)]
        public int? AttendeesActualCount { get; set; }

        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "Please enter a valid e-mail adress")]
        [Required(ErrorMessage = "Oh no you don't. Someone has to be in charge of this meeting!")]
        [StringLength(150,ErrorMessage = "150 characters ain't enough for you huh?")]
        [Display(Name = "Meeting Admin Email")]
        public string MeetingAdminEmailAddress { get; set; }

        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "Please enter a valid e-mail adress")]
        [Required(ErrorMessage = "You have to type the email address again to verify you typed it right the first time.")]
        [StringLength(150, ErrorMessage = "150 characters ain't enough for you huh?")]
        [Display(Name = "Confirm Email Address")]
        [Compare("MeetingAdminEmailAddress", ErrorMessage = "Email addreses must match.")]
        public string ConfirmMeetingAdminEmailAddress { get; set; }

        public Meeting()
        {
            MeetingDate = DateTime.Now.AddDays(14);
            MakeUpDate = DateTime.Now.AddDays(21);
            AttendeesExpectedCount = 0;
            AttendeesActualCount = 0;
        }

    }
}