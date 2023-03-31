using Azure;
using Azure.Data.Tables;
using System;
using TheGenesysProject.Manager.API.AbilityMaintain.Infrastructure.Repositories.Entities.Entities;

namespace TheGenesysProject.Manager.API.AbilityMaintain.Infrastructure.Repositories.Entities
{
    internal class TraitTableEntity : ITableEntity
    {
        public TraitTableEntity(Trait trait)
        {
            PartitionKey = CreatePartitionKey(trait);
            RowKey = CreateRowKey(trait);
            Age = trait.Age.ToString();
            Name = trait.Name;
            Description = trait.Description;
        }

        public string PartitionKey { get; set; }
        public string RowKey { get; set; }
        public string Age { get; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTimeOffset? Timestamp { get; set; }
        public ETag ETag { get; set; }

        public static string CreatePartitionKey(Trait trait)
        {
            return trait.Age.ToString();
        }

        public static string CreateRowKey(Trait trait)
        {
            return trait.Id;
        }
    }
}
