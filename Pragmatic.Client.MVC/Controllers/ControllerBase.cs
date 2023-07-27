using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.Identity.Abstractions;
using Microsoft.Identity.Web;
using Pragmatic.Client.MVC.Models;

namespace Pragmatic.Client.MVC.Controllers
{
    [Authorize]
    [AuthorizeForScopes(ScopeKeySection = "DownstreamApi:Scopes")] // Must replace RequiredScope (see Blazor) or access tokens won't be refreshed

    public class ControllerBase<ControllerType, ViewModelType> : Controller
        where ControllerType : Controller
        where ViewModelType: class, IModelIdentifier, new()
    {
        protected readonly IDownstreamApi _downstreamApi;
        protected readonly APIOptions _apiOptions;
        protected readonly ILogger<ControllerType> _logger;
        protected readonly string _downstreamServiceName;
        protected readonly string _relativePath;

        public ControllerBase(ILogger<ControllerType> logger, IDownstreamApi downstreamApi, APIOptions apiOptions, string relativePath, string downstreamServiceName = "DownstreamApi")
        {
            _logger = logger;
            _downstreamApi = downstreamApi;
            _apiOptions = apiOptions;
            _downstreamServiceName = downstreamServiceName;
            _relativePath = relativePath;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var apiResult = await _downstreamApi
                .GetForUserAsync<IEnumerable<ViewModelType>>(_downstreamServiceName,
                    options =>
                    {
                        options.BaseUrl = _apiOptions.BaseAddress;  //  https://localhost:7086/api/
                        options.RelativePath = _relativePath;            //  NB! "api/" is included in the default BaseAddress
                    });
            return View(apiResult);
        }


        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var apiResult = await _downstreamApi
                .GetForUserAsync<ViewModelType>(_downstreamServiceName,
                    options =>
                    {
                        options.BaseUrl = _apiOptions.BaseAddress;  //  https://localhost:7086/api/
                        options.RelativePath = $"{_relativePath}/{id}";      //  NB! "api/" is included in the default BaseAddress
                    });

            return View(apiResult);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var model = new ViewModelType();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ViewModelType model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var response = await _downstreamApi.PostForUserAsync<ViewModelType, ViewModelType>(_downstreamServiceName, model,
                        options =>
                        {
                            options.BaseUrl = _apiOptions.BaseAddress;  //  https://localhost:7086/api/
                            options.RelativePath = $"{_relativePath}/create";    //  NB! "api/" is included in the default BaseAddress
                        });

                    if (response != null)
                    {
                        return RedirectToAction("Index");
                    }
                    return View(model);
                }
                catch (Exception ex)
                {
                    ViewBag.Message = "Oops";

                }
            }
            return View(model);
        }


        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                var apiResult = await _downstreamApi
                    .GetForUserAsync<ViewModelType>(_downstreamServiceName,
                        options =>
                        {
                            options.BaseUrl = _apiOptions.BaseAddress;  //  https://localhost:7086/api/
                            options.RelativePath = $"{_relativePath}/{id}";      //  NB! "api/" is included in the default BaseAddress
                        });

                return View(apiResult);
            }
            catch (Exception ex)
            {
                return View("Error", ex.Message);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ViewModelType model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var response = await _downstreamApi.PostForUserAsync<ViewModelType, ViewModelType>(_downstreamServiceName, model,
                        options =>
                        {
                            options.BaseUrl = _apiOptions.BaseAddress;  //  https://localhost:7086/api/
                            options.RelativePath = $"{_relativePath}/edit/{model.GetId()}";    //  NB! "api/" is included in the default BaseAddress
                        }).ConfigureAwait(false);

                    if (response != null)
                    {
                        return RedirectToAction("Index");
                    }
                    return View(model);
                }
                catch (Exception ex)
                {
                    ViewBag.Message = "Oops";
                }
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var apiResult = await _downstreamApi
                    .GetForUserAsync<ViewModelType>(_downstreamServiceName,
                        options =>
                        {
                            options.BaseUrl = _apiOptions.BaseAddress;  //  https://localhost:7086/api/
                            options.RelativePath = $"values/{id}";      //  NB! "api/" is included in the default BaseAddress
                        });
                return View(apiResult);
            }
            catch (Exception ex)
            {
                return View("Error", ex.Message);
            }
        }


        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ConfirmDelete(int id)
        {
            if (id > 0)
            {
                try
                {
                    var response = await _downstreamApi.DeleteForUserAsync<object, IActionResult>(_downstreamServiceName, null,
                    options =>
                    {
                        options.BaseUrl = _apiOptions.BaseAddress;          //  https://localhost:7086/api/
                        options.RelativePath = $"{_relativePath}/delete/{id}";       //  NB! "api/" is included in the default BaseAddress
                    });

                    if ((response as OkResult) != null)
                    {
                        return RedirectToAction("Index");
                    }
                    return View();
                }
                catch (Exception ex)
                {
                    ViewBag.Message = "Oops";
                    return View();
                }
            }
            else
            {
                return View();
            }
        }

    }
}
