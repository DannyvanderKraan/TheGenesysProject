using Azure.Data.Tables;
using Microsoft.Extensions.Azure;
using System.Threading.Tasks;
using TheGenesysProject.Manager.API.AbilityMaintain.Application.Repositories;
using TheGenesysProject.Manager.API.AbilityMaintain.Domain.Entities;
using TheGenesysProject.Manager.API.Shared.Infrastructure;

namespace TheGenesysProject.Manager.API.AbilityMaintain.Infrastructure.Repositories
{
    internal class TraitTableRepository : StorageTableRepositoryBase, IAbilityRepository
    {
        public TraitTableRepository(IAzureClientFactory<TableServiceClient> clientFactory) : base(clientFactory)
        {
        }

        public override string TableName => "Ability";

        public async Task Add(Ability ability)
        {
            var response = await _tableClient.AddEntityAsync(new AbilityTableEntity(ability)).ConfigureAwait(false);
            EnsureSuccessStatusCode(response);
        }
    }
}
