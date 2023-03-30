using Azure;
using Azure.Data.Tables;
using System;
using TheGenesysProject.Manager.API.TraitMaintain.Domain.Entities;

namespace TheGenesysProject.Manager.API.TraitMaintain.Infrastructure.Repositories.Entities
{
    internal class TraitAbilityTableEntity : ITableEntity
    {
        public TraitAbilityTableEntity(TraitAbility ability)
        {
            PartitionKey = CreatePartitionKey(ability);
            RowKey = CreateRowKey(ability);
            TraitId = ability.TraitId;
            AbilityId = ability.AbilityId;
        }

        public string PartitionKey { get; set; }
        public string RowKey { get; set; }
        public string TraitId { get; set; }
        public string AbilityId { get; set; }
        public DateTimeOffset? Timestamp { get; set; }
        public ETag ETag { get; set; }

        public static string CreatePartitionKey(TraitAbility ability)
        {
            return ability.TraitId;
        }

        public static string CreateRowKey(TraitAbility ability)
        {
            return ability.AbilityId;
        }
    }
}
