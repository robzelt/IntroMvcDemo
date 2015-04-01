using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MvcDemo.Models;

namespace MvcDemo.Api
{
    public class MeetingController : ApiController
    {
        // GET: api/Meeting
        public IEnumerable<Meeting> Get()
        {

            var meetingRepository = new MockMeetingRepository();
            List<Meeting> meetings = meetingRepository.GetAll();
            
            return meetings;
        }

        // GET: api/Meeting/5
        public Meeting Get(int id)
        {

            var meetingRepository = new MockMeetingRepository();
            Meeting meeting = meetingRepository.Get(id);
            return meeting;
        }

        // POST: api/Meeting
        public void Post([FromBody]Meeting meeting)
        {

        }

        // PUT: api/Meeting/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Meeting/5
        public void Delete(int id)
        {
        }
    }
}
