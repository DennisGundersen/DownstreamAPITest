using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Identity.Abstractions;
using Microsoft.Identity.Web;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pragmatic.Client.CLI.Extensions
{
    internal class TokenAcquirerFactoryWithEnvironment : TokenAcquirerFactory
    {
        public TokenAcquirerFactoryWithEnvironment()
        {
            var builder = new ConfigurationBuilder();
            string basePath = DefineConfiguration(builder);
            builder.SetBasePath(basePath)
                   .AddJsonFile("appsettings.json", optional: true)
                   .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production"}.json", optional: true)
                   .AddEnvironmentVariables();
            Configuration = builder.Build();
        }
        
    }
}
