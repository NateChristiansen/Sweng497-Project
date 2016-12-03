using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ErieGarbageOnline.Models;

namespace ErieGarbageOnlineTest.ModelTests
{
    [TestClass]
    public class SuspensionTest
    {
        [TestMethod]
        public void ValidSuspension_ShouldReturnTrue()
        {
            var sus = new Suspension
            {
                CustomerId = 0,
                MessageBody = "asdf",
                SuspensionEnds = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day + 1)
            };
            Assert.IsTrue(sus.CheckValidity());
        }
        [TestMethod]
        public void InvalidSuspensionBadDate_ShouldReturnFalse()
        {
            var sus = new Suspension
            {
                CustomerId = 0,
                MessageBody = "asdf",
                SuspensionEnds = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day - 1)
            };
            Assert.IsFalse(sus.CheckValidity());
        }

        [TestMethod]
        public void InvalidSuspension_ShouldReturnTrue()
        {
            var sus = new Suspension
            {
                CustomerId = 0,
                MessageBody = "",
                SuspensionEnds = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day + 1)
            };
            Assert.IsFalse(sus.CheckValidity());
        }
    }
}
