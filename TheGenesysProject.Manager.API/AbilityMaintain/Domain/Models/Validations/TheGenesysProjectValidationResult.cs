using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheGenesysProject.Manager.API.AbilityMaintain.Domain.Models.Validations
{
    internal class TheGenesysProjectValidationResult
    {
        public bool IsValid { get; set; } = true;
        public string Message { get; set; } = string.Empty;
    }
}
