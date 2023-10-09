using Microsoft.Extensions.Configuration;
using Microsoft.Identity.Web;
using System;

namespace Pragmatic.Client.Hourglass.MT4.Extensions
{
    internal class TokenAcquirerFactoryWithEnvironment : TokenAcquirerFactory
    {
        public const string name = "custom TokenAcquirerFactory";
        public TokenAcquirerFactoryWithEnvironment()
        {
            var builder = new ConfigurationBuilder();
            string basePath = DefineConfiguration(builder);
            builder.SetBasePath(basePath)
                   .AddJsonFile("appsettings.json", optional: true)
                   .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production"}.json", optional: true);
                   //.AddEnvironmentVariables();
            Configuration = builder.Build();
        }

    }
}
