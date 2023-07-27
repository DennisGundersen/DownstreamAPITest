using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pragmatic.Client.MVC.Models;
using System.Diagnostics;
using Microsoft.Identity.Web;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Builder.Extensions;
using Microsoft.Identity.Web.Resource;
using Microsoft.Identity.Abstractions;

namespace Pragmatic.Client.MVC.Controllers
{
    [Authorize]
    [AuthorizeForScopes(ScopeKeySection = "DownstreamApi:Scopes")] // Must replace RequiredScope (see Blazor) or access tokens won't be refreshed
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [AllowAnonymous]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}