using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace addon365.FindMatch360.Controllers
{
    public class ErrorCustomController : Controller
    {
        private readonly ILogger<ErrorCustomController> logger;

        public ErrorCustomController(ILogger<ErrorCustomController> logger)
        {
            this.logger = logger;
        }

        [Route("Error/{statusCode}")]
        public IActionResult HttpStatusCodeHandler(int statusCode)
        {
            var statusCodeResult =
                HttpContext.Features.Get<IStatusCodeReExecuteFeature>();
            switch (statusCode)
            {
                case 404:
                    ViewBag.ErrorMessage =
                       "Sorry, the resource you requested could not be found";
                    logger.LogWarning($"404 error occured. Path = " +
                  $"{statusCodeResult.OriginalPath} and QueryString = " +
                  $"{statusCodeResult.OriginalQueryString}");
                    break;
            }

            return View("NotFound");
        }
        [AllowAnonymous]
       
        public IActionResult ErrorCustom()
        {
            // Retrieve the exception Details
            var exceptionHandlerPathFeature =
                    HttpContext.Features.Get<IExceptionHandlerPathFeature>();
            logger.LogError($"The path {exceptionHandlerPathFeature.Path} " +
                $"threw an exception {exceptionHandlerPathFeature.Error}");

            return View("Error");
        }
    }
}
