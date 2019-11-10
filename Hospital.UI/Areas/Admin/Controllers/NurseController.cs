using AutoMapper;
using Hospital.Core.Models;
using Hospital.Service.Interfaces;
using Hospital.UI.Areas.Admin.Models;
using Hospital.UI.Models;
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
        private readonly INurseService _nurseService;

        private readonly ILoggerService<NurseController> _loggerService;
        private readonly IMapper _mapper;
        public NurseController(ILoggerService<NurseController> loggerService, INurseService nurseService, IMapper mapper)
        {
            _loggerService = loggerService;
            _nurseService = nurseService;
            _mapper = mapper;
        }

        // GET: Admin/Nurse
        public ActionResult Index()
        {
            var nurses = _nurseService.GetNurses().ProjectToQueryable<NurseViewModel>();
            return View(nurses);
        }

        public ActionResult Details(int? id)
        {
            var nurse = _nurseService.FindById(id).ProjectToSingleOrDefault<NurseViewModel>();
            if (nurse != null)
            {
                return View(nurse);
            }
            return HttpNotFound();
        }

        public ActionResult Create()
        {
            var nurse = new CreateNurseViewModel();
            return View(nurse);
        }

        [HttpPost]
        public ActionResult Create(CreateNurseViewModel nursevm)
        {
            if (!ModelState.IsValid)
            {
                return View(nursevm);
            }
            var nurse = _mapper.Map<CreateNurseViewModel, User>(nursevm);

            if (!_nurseService.CheckUniqueness(nurse))
            {
                ModelState.AddModelError("", "User with same UserName or Email exist!");
                return View(nursevm);
            }
            _nurseService.Create(nurse);
            _loggerService.Info($"{User.Identity.Name} added {nurse.FirstName} {nurse.LastName}");
            return RedirectToAction("Index");
        }
    }
}