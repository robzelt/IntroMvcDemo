using System.Collections.Generic;

namespace MvcDemo.Models.Interfaces
{
    public interface IMeetingRepository
    {
        Meeting Get(int id);
        Meeting Get(IMeeting meeting);
        List<Meeting> GetAll();
        Meeting Add(Meeting entity);
        bool Remove(int id);
        Meeting Update(Meeting meeting);
    }
}