using Azure.Identity;
using Bryder.PropertyInfoAggregate.EntriesBufferer;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.Azure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TheGenesysProject.Manager.API.Application.Repositories;
using TheGenesysProject.Manager.API.Infrastructure.Repositories;
using static TheGenesysProject.Manager.API.Application.Settings.AzureClientFactoryNames;
using static TheGenesysProject.Manager.API.Application.Settings.ConnectionStringPaths;

[assembly: FunctionsStartup(typeof(Startup))]
namespace Bryder.PropertyInfoAggregate.EntriesBufferer
{
    public class Startup : FunctionsStartup
    {
        private IConfiguration Configuration { get; set; }

        public override void Configure(IFunctionsHostBuilder builder)
        {
            Configuration = builder.GetContext().Configuration;

            var services = builder.Services;

            services.AddAzureClients(ConfigureAzureClients);

            AddRepositories(services);
            AddServices(services);
            AddHandlers(services);
            AddSenders(services);
        }

        private void AddSenders(IServiceCollection services)
        {
            //ToDo
        }

        private void ConfigureAzureClients(AzureClientFactoryBuilder builder)
        {
            builder.UseCredential(new DefaultAzureCredential());
            builder.ConfigureDefaults(Configuration.GetSection("AzureDefaults"));
            builder.AddTableServiceClient(Configuration[TheGenesysProjectManagerTablePath]).WithName(TheGenesysProjectManagerTableName);
            

        }

        private void AddRepositories(IServiceCollection services)
        {
            services.AddSingleton<ITraitRepository, TraitTableRepository>();
         }
        private void AddServices(IServiceCollection services)
        {
           //ToDo
        }

        private void AddHandlers(IServiceCollection services)
        {
            //ToDo
        }
    }
}
