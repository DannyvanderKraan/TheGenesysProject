using TheGenesysProject.Manager.Shared.Constants;

namespace TheGenesysProject.Manager.Shared.DataTransferObjects
{
    public class AddAbilityDTO
    {
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public Ages Age { get; set; }
    }
}