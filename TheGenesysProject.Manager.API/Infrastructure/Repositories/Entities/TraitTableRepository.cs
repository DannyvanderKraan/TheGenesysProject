using Azure.Data.Tables;
using Microsoft.Extensions.Azure;
using System.Linq;
using System.Threading.Tasks;
using TheGenesysProject.Manager.API.AbilityMaintain.Application.Repositories;
using TheGenesysProject.Manager.API.Infrastructure.Commons;
using TheGenesysProject.Manager.API.TraitMaintain.Domain.Entities;
using TheGenesysProject.Manager.API.TraitMaintain.Repositories.Entities;

namespace TheGenesysProject.Manager.API.AbilityMaintain.Infrastructure.Repositories.Entities
{
    internal class TraitTableRepository : StorageTableRepositoryBase, ITraitRepository
    {
        public TraitTableRepository(IAzureClientFactory<TableServiceClient> clientFactory) : base(clientFactory)
        {
        }

        public override string TableName => "Trait";

        public async Task Add(Trait trait)
        {
            var responseTrait = await _tableClient.AddEntityAsync(new TraitTableEntity(trait)).ConfigureAwait(false);
            EnsureSuccessStatusCode(responseTrait);

            var tableTransactionActions = trait.Abilities.Select(ability =>
            new TableTransactionAction(TableTransactionActionType.Add, new TraitAbilityTableEntity(ability)));
            var responseAbilities = await _tableClient.SubmitTransactionAsync(tableTransactionActions);
            EnsureSuccessStatusCode(responseAbilities);
        }
    }
}
