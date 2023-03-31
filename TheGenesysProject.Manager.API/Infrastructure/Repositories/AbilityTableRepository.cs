using Azure.Data.Tables;
using Microsoft.Extensions.Azure;
using System.Threading.Tasks;
using TheGenesysProject.Manager.API.Application.Repositories;
using TheGenesysProject.Manager.API.Domain.Entities;
using TheGenesysProject.Manager.API.Infrastructure.Commons;
using TheGenesysProject.Manager.API.Infrastructure.Repositories.Entities;

namespace TheGenesysProject.Manager.API.Infrastructure.Repositories
{
    internal class AbilityTableRepository : StorageTableRepositoryBase, IAbilityRepository
    {
        public AbilityTableRepository(IAzureClientFactory<TableServiceClient> clientFactory) : base(clientFactory)
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
