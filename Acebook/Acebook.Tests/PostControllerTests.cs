using NUnit.Framework;
using Acebook.Controllers;
using Acebook.Models;
using Microsoft.AspNetCore.Mvc;


namespace Tests
{

    public class Tests
    {
        private readonly AcebookContext _context;
        //private readonly AcebookContext _context;
        //public void PostController(AcebookContext context)
        //{
        //    _context = context;
        //}

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }

        [Test]
        public void ReturnsIndexView()
        {
            var Controller = new PostController(_context);
            var result = Controller.Read(12) as ViewResult;
            Assert.AreEqual("Read", result.ViewName);
        }

        //[Fact]
        //public async Task IndexReturnsARedirectToIndexHomeWhenIdIsNull()
        //{
        //    // Arrange
        //    var controller = new PostController();

        //    // Act
        //    var result = await controller.Index(id: null);

        //    // Assert
        //    var redirectToActionResult =
        //        Assert.IsType<RedirectToActionResult>(result);
        //    Assert.Equal("Home", redirectToActionResult.ControllerName);
        //    Assert.Equal("Index", redirectToActionResult.ActionName);
        //}
    }
}