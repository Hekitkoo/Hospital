using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hospital.UI.Areas.Admin.Controllers
{
    [Authorize(Roles = "admin")]
    public class DoctorController : Controller
    {
        // GET: Admin/Doctor
        public ActionResult Index()
        {
            return View();
        }
    }
}