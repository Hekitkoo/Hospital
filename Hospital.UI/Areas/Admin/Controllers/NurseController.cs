using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hospital.UI.Areas.Admin.Controllers
{
    [Authorize(Roles = "admin")]
    public class NurseController : Controller
    {
        // GET: Admin/Nurse
        public ActionResult Index()
        {
            return View();
        }
    }
}