using Microsoft.Identity.Abstractions;

namespace Pragmatic.Client.MT4.Hourglass.Services
{
    public interface IPragmaticAPIService
    {
        IDownstreamApi GetDownstreamAPI();
    }
}