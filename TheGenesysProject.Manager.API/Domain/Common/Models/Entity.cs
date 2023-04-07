using System;
using TheGenesysProject.Manager.API.Domain.Validations;
using TheGenesysProject.Manager.Shared.Constants;

namespace TheGenesysProject.Manager.API.Domain.Common.Models
{
    internal abstract class Entity<TId>: IEquatable<Entity<TId>> where TId : notnull 
    {
        protected Entity(TId id)
        {
            Id = id;
        }

        public TId Id { get; protected set; }
        internal TheGenesysProjectValidationResult ValidationResult { get; private protected set; } = new TheGenesysProjectValidationResult() { IsValid = true };
        internal Ages Age { get; private protected set; } = Ages.First;

        public override bool Equals(object obj)
        {
            return obj is Entity<TId> entity && Id.Equals(entity.Id);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        public bool Equals(Entity<TId> other)
        {
            return Equals((object)other, null);
        }

        public static bool operator ==(Entity<TId> left, Entity<TId> right) { return left.Equals(right); }
        public static bool operator !=(Entity<TId> left, Entity<TId> right) { return !left.Equals(right); }
    }
}
