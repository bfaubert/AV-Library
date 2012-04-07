using System.Linq;
using System.Web.Mvc;
using Core.Domain.Interfaces;
using Core.Domain.Model;
using Moq;
using NUnit.Framework;
using Tests.Unit.Helpers;
using UI.Controllers.Pages;
using UI.Models.Pages;
using UI.Models.Views;

namespace Tests.Unit.UI.Controllers
{
    [TestFixture]
    public class MoviesControllerTests
    {
        private MoviesController _controller;

        [SetUp]
        public void Setup()
        {
            var repository = new Mock<IRepository<Movie>>();
            //_controller = new MoviesController(repository.Object){ CurrentItem = new MoviesN2() };
        }

        [Test]
        public void Index_should_display_movie_list()
        {
            var result = (ViewResult)_controller.Index();
            Assert.AreEqual(typeof(IQueryable<MovieListView>), result.ViewData.Model, "Model type is not correct.");
            ViewHelpers.VerifyViewNameIsSameAsMethodName(result);

        }
    }
}