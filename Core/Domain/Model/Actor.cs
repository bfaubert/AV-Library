using Core.Domain.Enums;
using Core.Domain.Interfaces;

namespace Core.Domain.Model
{
    public class Actor : IValueObject<Actor>
    {
        #region Constructors
        
        public Actor(Name name, Sex sex)
        {
            Name = name;
            Sex = sex;
        }

        #endregion

        #region Properties
        
        public Name Name { get; private set; }
        public Sex Sex { get; private set; }

        #endregion

        

        #region IValueObect Members

        public bool SameValueAs(Actor other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(other.Name, Name) && Equals(other.Sex, Sex);
        }

        #endregion

        #region Object Overrides
        
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof (Actor)) return false;
            return SameValueAs((Actor) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (Name.GetHashCode()*397) ^ Sex.GetHashCode();
            }
        }

        #endregion
    }
}