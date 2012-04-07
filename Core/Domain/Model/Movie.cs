using System;
using System.Collections.Generic;
using Core.Domain.Interfaces;

namespace Core.Domain.Model
{
    public class Movie : IEntity<Movie>
    {
        #region Constructors

        public Movie(string title, Category category)
        {
            Actors = new List<Actor>();
            Title = title;
            Category = category;
        }

        protected Movie()
        {
            // needed for NHibernate
        }

        #endregion

        #region Properties

        public virtual int Id { get; private set; }
        public virtual IList<Actor> Actors { get; private set; }
        public virtual string Title { get; private set; }
        public virtual Category Category { get; private set; }
        public virtual Name LentTo { get; private set; }

        #endregion


        #region Methods

        public virtual void SetLentTo(Name personLentTo)
        {
            LentTo = personLentTo;
        }

        #endregion

        #region IEntity Members

        public virtual bool SameIdentityAs(Movie other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return other.Id.Equals(Id);
        }

        #endregion

        #region Object Overrides

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof (Movie)) return false;
            return SameIdentityAs((Movie) obj);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        #endregion
    }
}