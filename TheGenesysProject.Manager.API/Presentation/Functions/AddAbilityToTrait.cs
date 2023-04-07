using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using System.Web.Http;
using TheGenesysProject.Manager.Shared.DataTransferObjects;

namespace TheGenesysProject.Manager.API.Presentation.Functions
{
    public class AddAbilityToTrait
    {
        [FunctionName(nameof(AddAbilityToTrait))]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = null)] AddAbilityToTraitDTO addAbilityToTrait,
            ILogger log)
        {
            try
            {
                return new OkResult();
            }
            catch (Exception ex)
            {
                log.LogError(ex, "Adding an ability to trait failed.");
                return new InternalServerErrorResult();
            }
        }
    }
}
