using System;
using System.ComponentModel.DataAnnotations;

namespace MvcDemo.Models.Interfaces
{
    public interface IMeeting
    {
        int Id { get; set; }

        [Required]
        [StringLength(80)]
        string Title { get; set; }

        [Required]
        [StringLength(350, MinimumLength = 5, ErrorMessage = "Ya gotta gimme somethin'. I need between 5 and 350 characters!")]
        string Description { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM-dd-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Meeting Date")]
        DateTime MeetingDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM-dd-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Make Up Date")]
        DateTime? MakeUpDate { get; set; }

        [Required]
        [Display(Name = "Expected Attendance")]
        [Range(0, 200)]
        int? AttendeesExpectedCount { get; set; }

        [Display(Name = "Actual Attendance")]
        [Range(0, 200)]
        int? AttendeesActualCount { get; set; }

        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "Please enter a valid e-mail adress")]
        [Required(ErrorMessage = "Oh no you don't. Someone has to be in charge of this meeting!")]
        [StringLength(150, ErrorMessage = "150 characters ain't enough for you huh?")]
        [Display(Name = "Meeting Admin Email")]
        string MeetingAdminEmailAddress { get; set; }

        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "Please enter a valid e-mail adress")]
        [Required(ErrorMessage = "You have to type the email address again to verify you typed it right the first time.")]
        [StringLength(150, ErrorMessage = "150 characters ain't enough for you huh?")]
        [Display(Name = "Confirm Email Address")]
        [Compare("MeetingAdminEmailAddress", ErrorMessage = "Email addreses must match.")]
        string ConfirmMeetingAdminEmailAddress { get; set; }
    }
}