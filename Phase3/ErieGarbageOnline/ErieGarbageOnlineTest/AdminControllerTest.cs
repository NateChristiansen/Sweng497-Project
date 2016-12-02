using ErieGarbageOnline.Controllers;
using ErieGarbageOnline.Models;
using ErieGarbageOnline.Database;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace ErieGarbageOnlineTest
{
    [TestClass]
    public class AdminControllerTest
    {
        [TestMethod]
        public void GetMessageResponseFromIndex_Invalid()
        {
            var admin = new Admin()
            {
                Email = "testemail@email.com",
                Firstname = "Yes",
                Id = 999,
                Lastname = "No",
                Password = "testpass"
            };


            var adminController = new AdminController(admin);
        }
    }
}