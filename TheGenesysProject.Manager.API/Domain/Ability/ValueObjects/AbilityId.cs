using System;
using TheGenesysProject.Manager.API.Domain.Commons.Models;

namespace TheGenesysProject.Manager.API.Domain.Ability.ValueObjects
{
    internal class AbilityId: ITypeIdentifier
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
    }
}
