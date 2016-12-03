using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ErieGarbageOnline.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ErieGarbageOnlineTest.ModelTests
{
    [TestClass]
    public class AdminTest
    {
        [TestMethod]
        public void ValidAdmin_ShouldReturnTrue()
        {
            var admin = new Admin
            {
                Email = "test@test.com",
                Firstname = "testadmin",
                Lastname = "myadmin",
                Password = "Admin5Test"
            };
            Assert.IsTrue(admin.CheckValidity());
        }

        [TestMethod]
        public void InvalidAdmin_ShouldReturnFalse()
        {
            var admin = new Admin {Email = "", Firstname = "", Password = "", Lastname = ""};
            Assert.IsFalse(admin.CheckValidity());
        }

        [TestMethod]
        public void InvalidPasswordNoCapital_ShouldReturnFalse()
        {
            var admin = new Admin
            {
                Email = "test@test.com",
                Firstname = "testadmin",
                Lastname = "admintest",
                Password = "admin5test"
            };
            Assert.IsFalse(admin.CheckValidity());
        }

        [TestMethod]
        public void InvalidPasswordNoNumber_ShouldReturnFalse()
        {
            var admin = new Admin
            {
                Email = "test@test.com",
                Firstname = "testadmin",
                Lastname = "Admintest",
                Password = "ASDfvjlkas"
            };
            Assert.IsFalse(admin.CheckValidity());
        }

        [TestMethod]
        public void InvalidPasswordTooShort_ShouldReturnFalse()
        {
            var admin = new Admin
            {
                Email = "test@test.com",
                Firstname = "testadmin",
                Lastname = "Admintest",
                Password = "asdf5df"
            };
            Assert.IsFalse(admin.CheckValidity());
        }
    }
}
