using System.Collections.Generic;
using System.Linq;
using TheGenesysProject.Manager.API.AbilityMaintain.Models.Validations;
using TheGenesysProject.Manager.API.Shared.Domain;
using TheGenesysProject.Manager.Shared.DataTransferObjects;

namespace TheGenesysProject.Manager.API.TraitMaintain.Domain.Entities
{
    internal class Trait : DomainModelBase
    {
        public Trait(AddTraitDTO addTrait)
        {
            Validate(addTrait);
            if (ValidationResult.IsValid)
            {
                CreateIdentifier();

                Name = addTrait.Name;
                Description = addTrait.Description;
                Abilities = addTrait.Abilities.Select(dto => new TraitAbility() { AbilityId = dto.AbilityId, TraitId = dto.TraitId });
            }
        }

        /// <summary>
        /// Name cannot be null or whitespace.
        /// Description cannot be null or whitespace.
        /// Abilities should be atleast 1.
        /// </summary>
        /// <param name="addTrait"></param>
        private void Validate(AddTraitDTO addTrait)
        {
            if (!string.IsNullOrWhiteSpace(addTrait.Name)) ValidationResult = new TheGenesysProjectValidationResult() { IsValid = false, Message = "Trait name is invalid." };
            if (!string.IsNullOrWhiteSpace(addTrait.Description)) ValidationResult = new TheGenesysProjectValidationResult() { IsValid = false, Message = "Trait description is invalid." };
            if (!addTrait.Abilities.Any()) ValidationResult = new TheGenesysProjectValidationResult() { IsValid = false, Message = "Abilities should be atleast 1." };
        }

        public string Name { get; }
        public string Description { get; }
        public IEnumerable<TraitAbility> Abilities { get; }
    }
}
