using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Hospital.UI.Models;

namespace Hospital.UI.Areas.Admin.Controllers
{
    [Authorize(Roles = "admin")]
    public class CategoryController : Controller
    {
       

        // GET: Admin/Category
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Index(IEnumerable<PatientViewModel> patients, string sortOrder)
        {
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";
           
            switch (sortOrder)
            {
                case "name_desc":
                    patients = patients.OrderByDescending(s => s.LastName);
                    break;
                case "Date":
                    patients = patients.OrderBy(s => s.Birthday);
                    break;
                case "date_desc":
                    patients = patients.OrderByDescending(s => s.Birthday);
                    break;
                default:
                    patients = patients.OrderBy(s => s.LastName);
                    break;
            }
            return View(patients.ToList());
        }
    }
}