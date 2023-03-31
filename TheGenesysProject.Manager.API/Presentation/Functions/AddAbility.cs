using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using System.Web.Http;
using TheGenesysProject.Manager.API.Application.Repositories;
using TheGenesysProject.Manager.API.Domain.Entities;
using TheGenesysProject.Manager.Shared.DataTransferObjects;

namespace TheGenesysProject.Manager.API.AbilityMaintain.Presentation.Functions
{
    internal class AddAbility
    {
        private readonly IAbilityRepository _abilityRepository;

        public AddAbility(IAbilityRepository abilityTableRepository)
        {
            _abilityRepository = abilityTableRepository;
        }

        [FunctionName(nameof(AddAbility))]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = null)] AddAbilityDTO addAbility,
            ILogger log)
        {
            try
            {
                var ability = new Ability(addAbility);
                if (!ability.ValidationResult.IsValid) return new BadRequestObjectResult("Ability not valid");
                await _abilityRepository.Add(ability).ConfigureAwait(false);
                return new OkObjectResult(ability.Id);
            }
            catch (Exception ex)
            {
                log.LogError(ex, "Adding of ability failed.");
                return new InternalServerErrorResult();
            }
        }
    }
}
