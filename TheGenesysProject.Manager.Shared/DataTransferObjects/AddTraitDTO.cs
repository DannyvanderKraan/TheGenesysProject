using TheGenesysProject.Manager.Shared.Constants;

namespace TheGenesysProject.Manager.Shared.DataTransferObjects
{
    public class AddTraitDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Ages Age { get; set; }
        public List<TraitAbilityDTO> Abilities { get; set; }
    }
}