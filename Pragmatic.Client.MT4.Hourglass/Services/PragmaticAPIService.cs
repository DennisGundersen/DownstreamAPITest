using Microsoft.Extensions.DependencyInjection;
using Microsoft.Identity.Abstractions;
using Microsoft.Identity.Web;
using Pragmatic.Client.MT4.Hourglass.Extensions;

namespace Pragmatic.Client.MT4.Hourglass.Services
{
    public class PragmaticAPIService : IPragmaticAPIService
    {
        public readonly IDownstreamApi DownstreamAPI;

        public PragmaticAPIService()
        {
            /*
            var tokenAcquirerFactory = TokenAcquirerFactory.GetDefaultInstance<TokenAcquirerFactoryWithEnvironment>();
            var downstreamOptions = tokenAcquirerFactory.Configuration.GetSection(Trader.ApiSectionName);
            tokenAcquirerFactory.Services.AddDownstreamApi(Trader.ApiName, downstreamOptions);
            var sp = tokenAcquirerFactory.Build();

            DownstreamAPI = sp.GetRequiredService<IDownstreamApi>();
            */
        }

        public IDownstreamApi GetDownstreamAPI()
        {
            return DownstreamAPI;
        }
    }
}