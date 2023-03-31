using TheGenesysProject.Manager.API.AbilityMaintain.Domain.Validations;
using TheGenesysProject.Manager.API.Domain.Commons;
using TheGenesysProject.Manager.Shared.DataTransferObjects;

namespace TheGenesysProject.Manager.API.AbilityMaintain.Domain.Entities
{
    internal class Ability : DomainModelBase
    {
        public Ability(AddAbilityDTO addAbility)
        {
            Validate(addAbility);
            if (ValidationResult.IsValid)
            {
                CreateIdentifier();

                Name = addAbility.Name;
                Description = addAbility.Description;
            }
        }

        /// <summary>
        /// Name cannot be null or whitespace.
        /// Description cannot be null or whitespace.
        /// </summary>
        /// <param name="addAbility"></param>
        private void Validate(AddAbilityDTO addAbility)
        {
            if (!string.IsNullOrWhiteSpace(addAbility.Name)) ValidationResult = new TheGenesysProjectValidationResult() { IsValid = false, Message = "Ability name is invalid." };
            if (!string.IsNullOrWhiteSpace(addAbility.Description)) ValidationResult = new TheGenesysProjectValidationResult() { IsValid = false, Message = "Ability description is invalid." };
        }

        public string Name { get; }
        public string Description { get; }
    }
}
