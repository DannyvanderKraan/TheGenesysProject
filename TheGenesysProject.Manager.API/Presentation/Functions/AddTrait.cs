using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using System.Web.Http;
using TheGenesysProject.Manager.API.Application.Repositories;
using TheGenesysProject.Manager.API.Domain.Trait;
using TheGenesysProject.Manager.API.Domain.Trait.Entities;
using TheGenesysProject.Manager.Shared.DataTransferObjects;

namespace TheGenesysProject.Manager.API.AbilityMaintain.Presentation.Functions
{
    internal class AddTrait
    {
        private readonly ITraitRepository _traitRepository;

        public AddTrait(ITraitRepository traitRepository)
        {
            _traitRepository = traitRepository;
        }

        [FunctionName(nameof(AddTrait))]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = null)] AddTraitDTO addTrait,
            ILogger log)
        {
            try
            {
                var trait = Trait.Create(addTrait);
                if (!trait.ValidationResult.IsValid) return new BadRequestObjectResult("Trait not valid");
                await _traitRepository.Add(trait).ConfigureAwait(false);
                return new OkObjectResult(trait.Id);
            }
            catch (Exception ex)
            {
                log.LogError(ex, "Adding of trait failed.");
                return new InternalServerErrorResult();
            }
        }
    }
}
