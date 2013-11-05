using System;
using ProjectTemplate.Domain.Entities;

namespace ProjectTemplate.Domain.Common
{
    public class Entity<T> where T : struct
    {
        public virtual T? Id { get; set; }
        public virtual User CreatedBy { get; set; }
        public virtual DateTime CreatedOn { get; set; }
        public virtual User LastModifiedBy { get; set; }
        public virtual DateTime? LastModifiedOn { get; set; }
        public virtual bool Deleted { get; set; }
        private int? _hashCode;

        public override bool Equals(object obj)
        {
            var other = obj as Entity<T>;
            if (other == null) return false;

            if (other.Id.Equals(default(T)) && Id.Equals(default(T)))
                return other == this;

            if (other.Id.Equals(default(T)) || Id.Equals(default(T)))
                return false;

            return other.Id.Equals(Id);
        }

        public override int GetHashCode()
        {
            if (_hashCode.HasValue)
                return _hashCode.Value;

            if (Id.Equals(default(T)))
            {
                _hashCode = base.GetHashCode();
                return _hashCode.Value;
            }

            return Id.GetHashCode();
        }
    }
}
