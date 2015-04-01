using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MvcDemo.Models;
using MvcDemo.Models.Interfaces;

namespace MvcDemo.Tests
{
    [TestClass]
    public class RepositoryTests
    {
        [TestMethod]
        public void RepositoryHasData()
        {
            IMeetingRepository repository = new MockMeetingRepository();
            Assert.IsTrue(repository.GetAll().Count > 0);

        }
        [TestMethod]
        public void RepositoryHasNewData()
        {
            IMeetingRepository repository = new MockMeetingRepository();
            int initialCount = repository.GetAll().Count;

            Meeting meeting = new Meeting() { Title = "Meeting Title" };
            repository.Add(meeting);
            Assert.IsTrue(repository.GetAll().Count == initialCount + 1);

        }
    }
}
