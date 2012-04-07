using Core.Domain.Interfaces;

namespace Core.Domain.Model
{
    public class Category :IValueObject<Category>
    {
        #region Constructors

        public Category(string name)
        {
            Name = name;
        }

        #endregion

        #region Properties

        public string Name { get; private set; }

        #endregion

        #region IValueObject Members

        public bool SameValueAs(Category other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(other.Name, Name);
        }

        #endregion

        #region Object Overrides

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof (Category)) return false;
            return SameValueAs((Category) obj);
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }

        #endregion
    }
}