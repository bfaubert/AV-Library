using Core.Domain.Interfaces;

namespace Core.Domain.Model
{
    public class Name : IValueObject<Name>
    {
        #region Constructors
        
        public Name(string first, string last)
        {
            First = first;
            Last = last;
        }

        #endregion

        #region Properties
        
        public string First { get; private set; }
        public string Last { get; private set; }
        public string Fullname
        {
            get { return string.Format("{0} {1}", First, Last); }
        }

        #endregion

        #region IValueObject Members

        public bool SameValueAs(Name other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(other.First, First) && Equals(other.Last, Last);
        }

        #endregion

        #region Object Overrides
        
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof (Name)) return false;
            return SameValueAs((Name) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (First.GetHashCode()*397) ^ Last.GetHashCode();
            }
        }

        #endregion
    }
}