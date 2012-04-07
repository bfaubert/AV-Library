using Core.Domain.Interfaces;

namespace Core.Domain.Model
{
    public class Song : IValueObject<Song>
    {
        #region Constructors

        public Song(string name, Name artist)
        {
            Name = name;
            Artist = artist;
        }

        #endregion

        #region Properties

        public string Name { get; private set; }
        public Name Artist { get; private set; }

        #endregion

        #region IValueObject Members

        public bool SameValueAs(Song other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(other.Name, Name) && Equals(other.Artist, Artist);
        }

        #endregion

        #region Object Overrides


        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof (Song)) return false;
            return SameValueAs((Song) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (Name.GetHashCode()*397) ^ Artist.GetHashCode();
            }
        }

        #endregion

    }
}