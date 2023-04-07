using TheGenesysProject.Manager.API.Domain.Commons.Models;
using TheGenesysProject.Manager.API.Domain.Trait.ValueObjects;
using TheGenesysProject.Manager.API.Domain.Validations;
using TheGenesysProject.Manager.Shared.DataTransferObjects;

namespace TheGenesysProject.Manager.API.Domain.Trait.Entities
{
    internal class Ability : Entity<AbilityId>
    {
        private Ability(AbilityId id, 
            string name)
             : base(id)
        {
            Name = name;
           
            Validate();
        }

        public static Ability Create(AddAbilityToTraitDTO addAbilityToTrait)
        {
            return new Ability(AbilityId.Create(addAbilityToTrait.AbilityId) as AbilityId,
            addAbilityToTrait.AbilityName);
        }

        /// <summary>
        /// Name cannot be null or whitespace.
        /// Description cannot be null or whitespace.
        /// </summary>
        /// <param name="name">Name of Trait</param>
        /// <param name="description">Description of Trait</param>
        private void Validate()
        {
            if (Id != null) ValidationResult = new TheGenesysProjectValidationResult() { IsValid = false, Message = "Ability id is invalid." };
            if (!string.IsNullOrWhiteSpace(Name)) ValidationResult = new TheGenesysProjectValidationResult() { IsValid = false, Message = "Ability name is invalid." };
       }

        public string Name { get; }
    }
}
