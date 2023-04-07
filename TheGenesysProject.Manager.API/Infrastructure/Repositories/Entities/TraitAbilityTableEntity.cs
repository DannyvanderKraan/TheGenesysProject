using Azure;
using Azure.Data.Tables;
using System;
using TheGenesysProject.Manager.API.Domain.Trait.Entities;
using TheGenesysProject.Manager.API.Domain.Trait.ValueObjects;

namespace TheGenesysProject.Manager.API.Infrastructure.Repositories.Entities
{
    internal class TraitAbilityTableEntity : ITableEntity
    {
        public TraitAbilityTableEntity(TraitId traitId, Ability ability)
        {
            PartitionKey = CreatePartitionKey(traitId.Value);
            RowKey = CreateRowKey(ability);
            TraitId = traitId.Value;
            AbilityId = ability.Id.Value;
        }

        public string PartitionKey { get; set; }
        public string RowKey { get; set; }
        public string TraitId { get; set; }
        public string AbilityId { get; set; }
        public DateTimeOffset? Timestamp { get; set; }
        public ETag ETag { get; set; }

        public static string CreatePartitionKey(string traitId)
        {
            return traitId;
        }

        public static string CreateRowKey(Ability ability)
        {
            return ability.Id.Value;
        }
    }
}
