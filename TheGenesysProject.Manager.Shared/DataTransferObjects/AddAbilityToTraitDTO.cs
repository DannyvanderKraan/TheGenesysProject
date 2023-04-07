using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheGenesysProject.Manager.Shared.DataTransferObjects
{
    public class AddAbilityToTraitDTO
    {
        public string TraitId { get; set; } = null!;
        public string AbilityId { get; set; } = null!;
        public string AbilityName { get; set; } = null!;
    }
}
