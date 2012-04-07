using System.Linq;
using System.Web.Mvc;
using Core.Domain.Interfaces;
using Core.Domain.Model;
using Core.Infrastructure.Repositories;
using N2.Web;
using NHibernate;
using UI.Infrastructure;
using UI.Models.Pages;
using UI.Models.Views;

namespace UI.Controllers.Pages
{
    /// <summary>
    /// This controller returns a view that displays the item created via the management interface
    /// </summary>
    [Controls(typeof(MoviesN2))]
    public class MoviesController : ContentControllerBase<MoviesN2>
    {
        //private readonly IRepository<Movie> _repository;
        private readonly ISession _repository;
  
        public MoviesController(ISession repository)
        {
            _repository = repository;
        }

        public override ActionResult Index()
        {
            ViewBag.N2Content = CurrentItem;
            //var movies = _repository.GetAll();
            //var viewModel = AutoMapperWrapper.Map<IQueryable<Movie>, IQueryable<MovieListView>>(movies);
            return View(/*viewModel*/);
        }

        
      
    }
}