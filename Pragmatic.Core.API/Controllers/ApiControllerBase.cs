using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web.Resource;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Pragmatic.Core.API.Controllers
{
    [ApiController]
    [Authorize]
    [RequiredScopeOrAppPermission(RequiredScopesConfigurationKey = "AzureAd:Scopes", RequiredAppPermissionsConfigurationKey = "AzureAd:AppPermissions")]
    [Route("api/[controller]")]
    public class ApiControllerBase : ControllerBase
    {
    }
}
