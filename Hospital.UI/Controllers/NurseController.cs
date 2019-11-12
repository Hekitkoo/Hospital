using System;
using System.Web.Mvc;
using AutoMapper;
using Hospital.Service.Interfaces;
using Hospital.UI.Models;
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
            return View();
        }

        public ActionResult Prescriptions()
        {
            var prescriptions = _nurseService.GetPrescriptions().ProjectToList<PrescriptionViewModel>();
            if (prescriptions != null)
            {
                return View(prescriptions);
            }
            return HttpNotFound();
        }
        [HttpPost]
        public ActionResult Prescriptions(int? id)
        {
            _nurseService.ChangePrescriptionStatus(id);
            var prescriptions = _nurseService.GetPrescriptions().ProjectToList<PrescriptionViewModel>();
            if (prescriptions != null)
            {
                return View(prescriptions);
            }
            return HttpNotFound();
        }
    }
}