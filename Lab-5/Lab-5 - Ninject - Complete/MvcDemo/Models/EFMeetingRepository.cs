using System.Collections.Generic;
using System.Linq;
using MvcDemo.Models.Interfaces;

namespace MvcDemo.Models
{
    public class EFMeetingRepository : IMeetingRepository
    {
        private readonly EFDbContext context = new EFDbContext();

        public Meeting Get(int id)
        {
            return context.Meetings.Find(id);
        }

        public Meeting Get(IMeeting meeting)
        {
            return context.Meetings.Find(meeting.Id);
        }

        public List<Meeting> GetAll()
        {
            return context.Meetings.ToList();
        }

        public Meeting Add(Meeting entity)
        {
            if (entity.Id == 0)
            {
                context.Meetings.Add(entity);
                context.SaveChanges();
            }
            return entity;
        }

        public bool Remove(int id)
        {
            Meeting meeting = context.Meetings.Find(id);
            if (meeting != null)
            {
                context.Meetings.Remove(meeting);
                context.SaveChanges();
                return true;
            }
            return false;
        }

        public Meeting Update(Meeting meeting)
        {
            Meeting dbMeeting = context.Meetings.Find(meeting.Id);
            if (dbMeeting != null)
            {
                dbMeeting.Title = meeting.Title;
                dbMeeting.Description = meeting.Description;
                dbMeeting.MeetingDate = meeting.MeetingDate;
                dbMeeting.MakeUpDate = meeting.MakeUpDate;
                dbMeeting.AttendeesExpectedCount = meeting.AttendeesExpectedCount;
                dbMeeting.AttendeesActualCount = meeting.AttendeesActualCount;
                dbMeeting.MeetingAdminEmailAddress = meeting.MeetingAdminEmailAddress;
                dbMeeting.ConfirmMeetingAdminEmailAddress = meeting.ConfirmMeetingAdminEmailAddress;
                context.SaveChanges();
            }
            return meeting;
        }
    }
}