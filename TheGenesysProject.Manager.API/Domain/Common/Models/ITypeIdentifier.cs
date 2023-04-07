using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using TheGenesysProject.Manager.API.Domain.Ability.ValueObjects;

namespace TheGenesysProject.Manager.API.Domain.Common.Models
{
    internal interface ITypeIdentifier
    {
        string Value { get; }
        static abstract ITypeIdentifier Create(string value);
        static abstract ITypeIdentifier Create();
    }
}
