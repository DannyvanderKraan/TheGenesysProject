using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using TheGenesysProject.Manager.API.Domain.Commons.Models;
using TheGenesysProject.Manager.API.Domain.Trait.Entities;
using TheGenesysProject.Manager.API.Domain.Trait.ValueObjects;
using TheGenesysProject.Manager.API.Domain.Validations;
using TheGenesysProject.Manager.Shared.DataTransferObjects;

namespace TheGenesysProject.Manager.API.Domain.Trait
{
    internal class Trait : AggregateRoot<TraitId>
    {
        private Trait(string name,
            string description) 
            : base(TraitId.Create() as TraitId)
        {
             Name = name;
            Description = description;
            Validate();
        }

        public static Trait Create(AddTraitDTO addTrait)
        {
            return new Trait(addTrait.Name,
            addTrait.Description);
        }
        /// <summary>
        /// Name cannot be null or whitespace.
        /// Description cannot be null or whitespace.
        /// </summary>
        /// <param name="name">Name of Trait</param>
        /// <param name="description">Description of Trait</param>
        private void Validate()
        {
            if (!string.IsNullOrWhiteSpace(Name)) ValidationResult = new TheGenesysProjectValidationResult() { IsValid = false, Message = "Trait name is invalid." };
            if (!string.IsNullOrWhiteSpace(Description)) ValidationResult = new TheGenesysProjectValidationResult() { IsValid = false, Message = "Trait description is invalid." };
        }

        public string Name { get; }
        public string Description { get; }
        public IEnumerable<TheGenesysProject.Manager.API.Domain.Trait.Entities.Ability> Abilities { get; }
    }
}
