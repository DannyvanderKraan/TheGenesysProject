using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheGenesysProject.Manager.API.Domain.Commons.Models
{
    internal abstract class ValueObject: IEquatable<ValueObject>
    {
        public abstract IEnumerable<object> GetEqualityComponents();

        public override bool Equals(object obj)
        {
            if (obj is null || obj.GetType() != typeof(ValueObject)) return false;
            ValueObject other = (ValueObject)obj;
            return GetEqualityComponents().SequenceEqual(other.GetEqualityComponents());
        }

        public static bool operator ==(ValueObject left, ValueObject right) { return left.Equals(right); }
        public static bool operator !=(ValueObject left, ValueObject right) { return !left.Equals(right); }

        public override int GetHashCode()
        {
            return GetEqualityComponents().Select(x => x?.GetHashCode() ?? 0).Aggregate((x, y) => x ^ y);
        }

        public bool Equals(ValueObject other)
        {
            return Equals((object)other, null);
        }
    }
}
