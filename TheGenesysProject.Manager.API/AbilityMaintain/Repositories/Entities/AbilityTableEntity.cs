using Azure;
using Azure.Data.Tables;
using System;
using System.ComponentModel;
using TheGenesysProject.Manager.API.AbilityMaintain.Models;
using TheGenesysProject.Manager.Shared.Constants;

namespace TheGenesysProject.Manager.API.AbilityMaintain.Repositories.Entities
{
    internal class AbilityTableEntity : ITableEntity
    {
        public AbilityTableEntity(Ability ability)
        {
            PartitionKey = CreatePartitionKey(ability);
            RowKey = CreateRowKey(ability);
            Age = ability.Age.ToString();
            Name = ability.Name;
            Description = ability.Description;
       }

        public string PartitionKey { get; set; }
        public string RowKey { get; set; }
        public string Age { get; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTimeOffset? Timestamp { get; set; }
        public ETag ETag { get; set; }

        public static string CreatePartitionKey(Ability ability)
        {
            return ability.Age.ToString();
        }

        public static string CreateRowKey(Ability ability)
        {
            return ability.Id;
        }
    }
}
