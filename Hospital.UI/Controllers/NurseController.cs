using System;
using System.Web.Mvc;
using AutoMapper;
using Hospital.Service.Interfaces;
using Microsoft.AspNet.Identity;

namespace Hospital.UI.Controllers
{
    [Authorize(Roles = "nurse")]
    public class NurseController : Controller
    {
        private readonly INurseService _nurseService;
        private readonly ILoggerService<NurseController> _loggerService;
        private readonly IMapper _mapper;

        public NurseController(INurseService nurseService, ILoggerService<NurseController> loggerService, IMapper mapper)
        {
            _nurseService = nurseService;
            _loggerService = loggerService;
            _mapper = mapper;
        }
        public ActionResult Index()
        {
            int id = Convert.ToInt32(User.Identity.GetUserId());
            var prescriptions = _nurseService.GetAllNursesJob(id);
            if (prescriptions != null)
            {
                return View(prescriptions);
            }

            return HttpNotFound();
        }
    }
}