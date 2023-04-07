using TheGenesysProject.Manager.API.Domain.Ability.ValueObjects;
using TheGenesysProject.Manager.API.Domain.Commons.Models;
using TheGenesysProject.Manager.API.Domain.Trait.ValueObjects;
using TheGenesysProject.Manager.API.Domain.Validations;
using TheGenesysProject.Manager.Shared.DataTransferObjects;

namespace TheGenesysProject.Manager.API.Domain.Ability
{
    internal class Ability : AggregateRoot<TheGenesysProject.Manager.API.Domain.Ability.ValueObjects.AbilityId>
    {
        private Ability(string name,
             string description)
             : base(TheGenesysProject.Manager.API.Domain.Ability.ValueObjects.AbilityId.Create() as TheGenesysProject.Manager.API.Domain.Ability.ValueObjects.AbilityId)
        {
            Name = name;
            Description = description;
            Validate();
        }

        public static Ability Create(AddAbilityDTO addAbility)
        {
            return new Ability(addAbility.Name,
            addAbility.Description);
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
    }
}
