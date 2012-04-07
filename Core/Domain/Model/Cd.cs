using System;
using System.Collections.Generic;
using Core.Domain.Interfaces;

namespace Core.Domain.Model
{
    public class Cd : IEntity<Cd>
    {
        #region Constructors

        public Cd(string artist, string albumTitle, Category category)
        {
            Artist = artist;
            AlbumTitle = albumTitle;
            Category = category;
            Songs = new List<Song>();
        }

        #endregion

        #region Properties

        public Guid Id { get; set; }
        public string Artist { get; private set; }
        public string AlbumTitle { get; private set; }
        public Category Category { get; private set; }
        public IList<Song> Songs { get; private set; }

        #endregion



        #region Methods

        public void AddSong(Song songToAdd)
        {
            Songs.Add(songToAdd);
        }

        #endregion

        #region IEntity Members

        public bool SameIdentityAs(Cd other)
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
            if (obj.GetType() != typeof (Cd)) return false;
            return SameIdentityAs((Cd) obj);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        #endregion
    }
}