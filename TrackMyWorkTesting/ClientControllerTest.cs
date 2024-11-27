
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TrackMyWork.Controllers;
using TrackMyWork.Data;
using TrackMyWork.Models;
using System.Linq;

namespace TrackMyWorkTesting
{
    [TestClass]
    public class ClientControllerTest

    {
        // create in-memory db to replace SQL Server for testing
        private ApplicationDbContext _context;

        ClientController controller;


        // startup method to run automatically before each test
        [TestInitialize]
        public void TestInitialize()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            _context = new ApplicationDbContext(options);
            // populate client into mock db
            _context.Clients.Add(new Client { ClientId = 102,Email="rich@test.ca", FirstName = "Richard", LastName="Freeman" });
            _context.Clients.Add(new Client { ClientId = 12, Email = "sahitya@test.ca", FirstName = "Sahitya", LastName = "Neupane" });
            _context.SaveChanges();

        }


            [TestMethod]
        public void TestMethod1()
        {
        }
    }
}