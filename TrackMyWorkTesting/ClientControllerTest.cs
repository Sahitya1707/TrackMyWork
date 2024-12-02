
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TrackMyWork.Controllers;
using TrackMyWork.Data;
using TrackMyWork.Models;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using NuGet.ContentModel;

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
            _context.Clients.Add(new Client { ClientId = 105,Email="rich@test.ca", FirstName = "Richard", LastName="Freeman" });
            _context.Clients.Add(new Client { ClientId = 1222, Email = "sahitya@test.ca", FirstName = "Sahitya", LastName = "Neupane" });
            _context.Clients.Add(new Client { ClientId = 2, Email = "sahitya@et.ca", FirstName = "itya", LastName = "Neue" });
            _context.SaveChanges();

            // create controller and pass it mock db
            controller = new ClientController(_context);

        }
        #region "Index"
        [TestMethod]
        public async Task IndexReturnsView()
        {
            // Act
            var result = (ViewResult)controller.Index().Result;


            // Assert
           
            Assert.AreEqual("Index", result.ViewName);
        }

        [TestMethod]
        public void IndexReturnsModel()
        {
            // Act
            var result = (ViewResult)controller.Index().Result;
            var model = (List<Client>)result.Model;

            // Assert
            CollectionAssert.AreEqual(_context.Clients.ToList(), model);
        }

        #endregion

        #region "Create"
        [TestMethod]
        public async Task CreateReturnsView()
        {
            //arrange
           

            //act
            var result = (ViewResult)controller.Create();
            //assert

            Assert.AreEqual("Create", result.ViewName);
        }
        // create post
        [TestMethod]
        public async Task CreateModelValidReturnsIndex()
        {
            // arrange 
            var newClient = new Client
            {
                ClientId = 9999,  // Unique ClientId that doesn't exist in the in-memory database same id wouldnot give us to post
                FirstName = "Sahtiya",
                LastName = "Don",
                Email = "test2@test.com"
            };
           

            //act
            var result = await controller.Create(newClient) as RedirectToActionResult;


            // assert
            Assert.AreEqual("Index", result?.ActionName);
        }

        [TestMethod]

     public async Task CreateInvalidModelReturnsClientView()
        {
            // Create a new client with missing required fields or invalid data
            var invalidClient = new Client
            {
                ClientId = 999,  // Unique ClientId that doesn't exist in the in-memory database
                FirstName = "",   // Invalid: Empty First Name
                LastName = "Doe",
                Email = "invalid-email"  // Invalid Email format
            };


            controller.ModelState.AddModelError("FirstName", "First name is required");
            controller.ModelState.AddModelError("Email", "Invalid email format");
            // Act - Call the Create action with the invalid client model

            var result = await controller.Create(invalidClient) as ViewResult;


            Assert.AreEqual("Create", result?.ViewName);

        }
        [TestMethod]
            public async Task CreateInvalidModelReturnModel()
        {
            // Arrange
            var invalidClient = new Client
            {
                ClientId = 999,
                FirstName = "",
                LastName = "Don",
                Email = "invalid-email"
            };

            controller.ModelState.AddModelError("FirstName", "First name is required");
            controller.ModelState.AddModelError("Email", "Invalid email format");

            // Act
            var result = await controller.Create(invalidClient) as ViewResult;

            // Assert
            Assert.AreSame(invalidClient, result?.Model);

        }
        #endregion

        #region "Edit"
        // post

        #endregion

        #region "Delete"
        [TestMethod]
        public void DeleteClientIdNullReturnNotFound()
        {
            //arrange
            
            //act
            var result = (ViewResult)controller.Delete(null).Result;


            // assert
            Assert.AreEqual("404", result.ViewName);
        }
        [TestMethod]
        public void DeleteClientNotFoundReturnNotFound()
        {
            // arrange

            // act
            var result = (ViewResult)controller.Delete(9999).Result;

            // assert
            Assert.AreEqual("404", result.ViewName);

        }

        [TestMethod]
        public void DeleteSuccessReturnIndex()
        {
            // arrange

            // Act
            var result = controller.Delete(105).Result as RedirectToActionResult;

            // Assert -- is it successfull?
            Assert.AreEqual("Index", result?.ActionName);
        }

        #endregion


    }
}