using System;
using System.Collections.Generic;
using TheGenesysProject.Manager.API.Domain.Commons.Models;

namespace TheGenesysProject.Manager.API.Domain.Trait.ValueObjects
{
    internal class AbilityId: ValueObject, ITypeIdentifier
    {
        public string Value { get; private set; }

        public static ITypeIdentifier Create()
        {
            return new AbilityId() { Value = Guid.NewGuid().ToString() };
        }

        public static ITypeIdentifier Create(string value)
        {
            return new AbilityId() { Value= value };
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
