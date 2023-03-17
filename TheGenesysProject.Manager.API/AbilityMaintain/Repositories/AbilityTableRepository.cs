using Azure.Data.Tables;
using Microsoft.Extensions.Azure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheGenesysProject.Manager.API.AbilityMaintain.Models;
using TheGenesysProject.Manager.API.AbilityMaintain.Repositories.Entities;
using TheGenesysProject.Manager.API.Shared.Repositories;

namespace TheGenesysProject.Manager.API.AbilityMaintain.Repositories
{
    internal class TraitTableRepository : StorageTableRepositoryBase, IAbilityTableRepository
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
