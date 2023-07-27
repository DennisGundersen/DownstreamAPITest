using Microsoft.Extensions.DependencyInjection;
using Microsoft.Identity.Abstractions;
using Microsoft.Identity.Web;
using Pragmatic.Client.CLI.Models;
using Microsoft.Extensions.Configuration;
using Pragmatic.Client.CLI.Extensions;

namespace Pragmatic.Client.CLI
{
    internal class Program
    {
        const string ApiName = "DownstreamApi";
        const string ApiSectionName = "DownstreamApi";
        static async Task Main(string[] args)
        {

            var tokenAcquirerFactory = TokenAcquirerFactory.GetDefaultInstance<TokenAcquirerFactoryWithEnvironment>();
            var downstreamOptions = tokenAcquirerFactory.Configuration.GetSection(ApiSectionName);
            tokenAcquirerFactory.Services.AddDownstreamApi(ApiName, downstreamOptions);
            var sp = tokenAcquirerFactory.Build();

            var api = sp.GetRequiredService<IDownstreamApi>();
            
            var result = await api.GetForAppAsync<IEnumerable<ValueModel>>(ApiName, options =>
            {
                options.RelativePath = "Values";
            });
            Console.WriteLine($"result = {result?.Count()}");
        }
    }
}