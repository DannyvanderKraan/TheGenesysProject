using Azure.Data.Tables;
using Microsoft.Extensions.Azure;
using System.Linq;
using System.Threading.Tasks;
using TheGenesysProject.Manager.API.Shared.Repositories;
using TheGenesysProject.Manager.API.TraitMaintain.Models;
using TheGenesysProject.Manager.API.TraitMaintain.Repositories.Entities;

namespace TheGenesysProject.Manager.API.TraitMaintain.Repositories
{
    internal class TraitTableRepository : StorageTableRepositoryBase, ITraitTableRepository
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
