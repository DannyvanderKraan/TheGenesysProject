using TheGenesysProject.Manager.Shared.Constants;

namespace TheGenesysProject.Manager.Shared.DataTransferObjects
{
    public class AbilityDTO
    {
        public string Id { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public Ages Age { get; set; }
    }
}