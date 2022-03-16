using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Identity;
using Microsoft.Azure.Services.AppAuthentication;
using Microsoft.Azure.KeyVault;
using Microsoft.Extensions.Configuration.AzureKeyVault;

namespace WhatsTheMove.Web.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = CreateHostBuilder(args);

            builder.Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                    webBuilder.ConfigureAppConfiguration((context, config) =>
                    {

                        var keyVaultEndpoint = GetKeyVaultEndpoint();
                        if (!string.IsNullOrEmpty(keyVaultEndpoint))
                        {
                            var azureServiceTokenProvider = new AzureServiceTokenProvider();
                            var keyVaultClient = new KeyVaultClient(
                                new KeyVaultClient.AuthenticationCallback(
                                    azureServiceTokenProvider.KeyVaultTokenCallback));
                            config.AddAzureKeyVault(keyVaultEndpoint, keyVaultClient, new DefaultKeyVaultSecretManager());
                        }
                    })
                .ConfigureAppConfiguration((context, config) =>
                {
                    var azAppConfigSettings = config.Build();
                    var azAppConfigConnection = azAppConfigSettings["AppConfig"];
                    if (!string.IsNullOrEmpty(azAppConfigConnection))
                    {
                        // Use the connection string if it is available.
                        config.AddAzureAppConfiguration(options =>
                        {
                            options.Connect(azAppConfigConnection)
                            .ConfigureRefresh(refresh =>
                            {
                                // All configuration values will be refreshed if the sentinel key changes.
                                refresh.Register("TestApp:Settings:Sentinel", refreshAll: true);
                            });
                        });
                    }
                    else if (Uri.TryCreate(azAppConfigSettings["Endpoints:AppConfig"], UriKind.Absolute, out var endpoint))
                    {
                        // Use Azure Active Directory authentication.
                        // The identity of this app should be assigned 'App Configuration Data Reader' or 'App Configuration Data Owner' role in App Configuration.
                        // For more information, please visit https://aka.ms/vs/azure-app-configuration/concept-enable-rbac
                        config.AddAzureAppConfiguration(options =>
                        {
                            options.Connect(endpoint, new DefaultAzureCredential())
                            .ConfigureRefresh(refresh =>
                            {
                                // All configuration values will be refreshed if the sentinel key changes.
                                refresh.Register("TestApp:Settings:Sentinel", refreshAll: true);
                            });
                        });
                    }
                })
                    .UseStartup<Startup>());

        private static string GetKeyVaultEndpoint() => "https://whatsthemovewebapivault.vault.azure.net/";
    }
}
