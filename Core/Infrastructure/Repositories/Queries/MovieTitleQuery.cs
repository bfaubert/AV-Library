using System;
using System.Linq.Expressions;
using Core.Domain.Model;

namespace Core.Infrastructure.Repositories.Queries
{
    public class MovieTitleQuery : QueryBase<Movie>
    {
        private readonly string title;

        public MovieTitleQuery(string title)
        {
            this.title = title;
        }

        #region Overrides of QueryBase<Movie>

        public override Expression<Func<Movie, bool>> MatchingCriteria
        {
            get { return movie => movie.Title.Equals(title); }
        }

        #endregion
    }
}