using Azure.Data.Tables;
using Microsoft.Extensions.Azure;
using System;
using System.Net.Http;
using static TheGenesysProject.Manager.API.Application.Settings.AzureClientFactoryNames;

namespace TheGenesysProject.Manager.API.Infrastructure.Commons
{
    internal abstract class StorageTableRepositoryBase
    {
        private const string HttpRequestExceptionMessage = "HttpStatusCode does not indicate success";

        protected readonly TableClient _tableClient;

        protected StorageTableRepositoryBase(IAzureClientFactory<TableServiceClient> clientFactory)
        {
            if (clientFactory is null) throw new ArgumentNullException(nameof(clientFactory));

            var tableServiceClient = clientFactory.CreateClient(TheGenesysProjectManagerTableName);
            _tableClient = tableServiceClient.GetTableClient(TableName);
            _tableClient.CreateIfNotExists();
        }

        public abstract string TableName { get; }

        protected void EnsureSuccessStatusCode(Azure.Response response)
        {
            if (!IsSuccessStatusCode(response.Status)) throw new HttpRequestException(HttpRequestExceptionMessage);
        }

        protected void EnsureSuccessStatusCode<T>(Azure.Response<T> response)
        {
            EnsureSuccessStatusCode(response.GetRawResponse());
        }

        protected bool IsSuccessStatusCode(int statusCode)
        {
            return statusCode >= 200 && statusCode <= 299;
        }
    }
}
