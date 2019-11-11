using System;
using System.Threading.Tasks;
using System.Web.Mvc;
using AutoMapper;
using Hospital.Core.Models;
using Hospital.Service.Interfaces;
using Hospital.UI.Models;
using Microsoft.AspNet.Identity;

namespace Hospital.UI.Controllers
{
    [Authorize(Roles = "doctor")]
    public class DoctorController : Controller
    {
        private readonly IDoctorService _doctorService;
        private readonly IPatientCardService _patientCardService;
        private readonly ILoggerService<DoctorController> _loggerService;
        private readonly IMapper _mapper;

        public DoctorController(IDoctorService doctorService, IMapper mapper, IPatientCardService patientCardService, ILoggerService<DoctorController> loggerService)
        {
            _doctorService = doctorService;
            _mapper = mapper;
            _patientCardService = patientCardService;
            _loggerService = loggerService;
        }
        // GET: Doctor
        public ActionResult Index()
        {
            int id = Convert.ToInt32(User.Identity.GetUserId());
            var doctor = _doctorService.FindById(id).ProjectToSingleOrDefault<DetailsDoctorViewModel>();
            if (doctor != null)
            {

                return View(doctor);
            }
            return HttpNotFound();
        }

        public ActionResult CreateDiagnosis()
        {
            var diagnosis = new CreateDiagnosisViewModel();
            return View(diagnosis);
        }

        [HttpPost]
        public ActionResult Create(CreateDiagnosisViewModel createDiagnosisViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(createDiagnosisViewModel);
            }
            var diagnosis = _mapper.Map<CreateDiagnosisViewModel, Diagnosis>(createDiagnosisViewModel);

            _patientCardService.CreateDiagnosis(diagnosis);
            _loggerService.Info($"{User.Identity.Name} added diagnoses for {diagnosis.PatientCard.Patient.LastName}");
            return RedirectToAction("Index");
        }

    }
}