using Hospital.Service.Interfaces;
using System.Net;
using System.Web.Mvc;

namespace Hospital.UI.Controllers
{
    public class ErrorController : Controller
    {
        private readonly ILoggerService<ErrorController> _loggerService;

        public ErrorController(ILoggerService<ErrorController> loggerService)
        {
            _loggerService = loggerService;
        }
        public ActionResult PageNotFound()
        {
            Response.StatusCode = (int)HttpStatusCode.NotFound;
            return View();
        }

        public ActionResult ServerError()
        {
            Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            if (!(Server.GetLastError() is null))
            {
                _loggerService.Error(Server.GetLastError().Message);
            }
            return View();
        }
    }
}