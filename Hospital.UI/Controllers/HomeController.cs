using System.Threading.Tasks;
using System.Web.Mvc;
using Hospital.Core.Interfaces;
using Hospital.UI.Models;
using Microsoft.AspNet.Identity;

namespace Hospital.UI.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILoggerService<HomeController> _loggerService;
        private readonly IHomeService _homeService;
        public HomeController(ILoggerService<HomeController> loggerService, IHomeService homeService)
        {
            _loggerService = loggerService;
            _homeService = homeService;
        }
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToLocal("Home");
            }
            ViewBag.returnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public async Task<ActionResult> Login(LoginViewModel model, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            bool login = await _homeService.LogIn(model.UserName, model.Password, model.RememberMe);

            if (login)
            {
                _loggerService.Info($"{model.UserName} logged in");
                return RedirectToLocal(returnUrl);
            }
            _loggerService.Info($"{model.UserName} can't login");
            ModelState.AddModelError("", "Invalid login or password.");
            return View(model);
        }
       
        [AllowAnonymous]
        public ActionResult LogOff()
        {
            if (User.Identity.IsAuthenticated)
            {
                _loggerService.Info($"{User.Identity.Name} signed out");
                _homeService.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            }
            return RedirectToLocal("Home");
        }
        [AllowAnonymous]
        public ActionResult Contact()
        {
            return View();
        }
        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Index", "Home");
        }
    }
}