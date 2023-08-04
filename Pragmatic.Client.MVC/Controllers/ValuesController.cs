using Azure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Abstractions;
using Microsoft.Identity.Web;
using Newtonsoft.Json;
using Pragmatic.Client.MVC.Models;
using System.Net;
using System.Net.NetworkInformation;
using System.Reflection;

namespace Pragmatic.Client.MVC.Controllers
{
     public class ValuesController : ControllerBase<ValuesController, ValueModel>
    {
        // Constructor uses base class to set up all actions using generics
        public ValuesController(ILogger<ValuesController> logger, IDownstreamApi downstreamApi, APIOptions apiOptions) 
            : base(logger, downstreamApi, apiOptions, relativePath: "values")
        {
        }

        

    }
}
