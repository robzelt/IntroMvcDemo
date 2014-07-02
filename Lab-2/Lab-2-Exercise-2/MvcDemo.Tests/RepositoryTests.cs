using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MvcDemo.Models;

namespace MvcDemo.Tests
{
    [TestClass]
    public class RepositoryTests
    {
        [TestMethod]
        public void RepositoryHasData()
        {
            MockMeetingRepository repository = new MockMeetingRepository();
            Assert.IsTrue(repository.GetAll().Count > 0);

        }
        [TestMethod]
        public void RepositoryHasNewData()
        {
            MockMeetingRepository repository = new MockMeetingRepository();
            int initialCount = repository.GetAll().Count;

            Meeting meeting = new Meeting() { Title = "Meeting Title" };
            repository.Add(meeting);
            Assert.IsTrue(repository.GetAll().Count == initialCount + 1);

        }
    }
}
