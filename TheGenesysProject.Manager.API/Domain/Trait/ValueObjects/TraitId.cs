using System;
using TheGenesysProject.Manager.API.Domain.Commons.Models;

namespace TheGenesysProject.Manager.API.Domain.Trait.ValueObjects
{
    internal class TraitId: ITypeIdentifier
    {
        public string Value { get; private set; }

        public static ITypeIdentifier Create()
        {
            return new TraitId() { Value = Guid.NewGuid().ToString() };
        }

        public static ITypeIdentifier Create(string value)
        {
            return new TraitId() { Value = value };
        }
    }
}
