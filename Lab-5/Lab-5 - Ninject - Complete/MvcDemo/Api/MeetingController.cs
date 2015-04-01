using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MvcDemo.Models;
using MvcDemo.Models.Interfaces;

namespace MvcDemo.Api
{
    public class MeetingController : ApiController
    {
        private readonly IMeetingRepository meetingRepository;

        public MeetingController(IMeetingRepository repository)
        {
            meetingRepository = repository;
        }

        // GET: api/Meeting
        public IEnumerable<IMeeting> Get()
        {

            List<Meeting> meetings = meetingRepository.GetAll();
            
            return meetings;
        }

        // GET: api/Meeting/5
        public IMeeting Get(int id)
        {

            IMeeting meeting = meetingRepository.Get(id);
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
