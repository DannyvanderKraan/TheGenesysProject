using System;
using TheGenesysProject.Manager.API.AbilityMaintain.Domain.Validations;
using TheGenesysProject.Manager.Shared.Constants;

namespace TheGenesysProject.Manager.API.Shared.Domain
{
    internal abstract class DomainModelBase
    {
        protected void CreateIdentifier()
        {
            Id = Guid.NewGuid().ToString();
        }

        internal TheGenesysProjectValidationResult ValidationResult { get; private protected set; } = new TheGenesysProjectValidationResult() { IsValid = true };
        internal string Id { get; private set; } = string.Empty;
        internal Ages Age { get; private protected set; } = Ages.First;

    }
}
