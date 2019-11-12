using AutoMapper;
using Hospital.Service.Interfaces;
using System;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Hospital.UI.Models;

namespace Hospital.UI.Controllers
{
    [Authorize(Roles = "doctor, patient")]
    public class PatientController : Controller
    {
        private readonly IPatientService _patientService;
        private readonly IPatientCardService _patientCardService;
        private readonly IMapper _mapper;

        public PatientController(IMapper mapper, IPatientService patientService, IPatientCardService patientCardService)
        {
            _mapper = mapper;
            _patientService = patientService;
            _patientCardService = patientCardService;
        }
        [Authorize(Roles = "patient")]
        public ActionResult Index()
        {
            int id = Convert.ToInt32(User.Identity.GetUserId());
            var patient = _patientService.FindById(id).ProjectToSingleOrDefault<PatientViewModel>();
            if (patient != null)
            {
                return View(patient);
            }
            return HttpNotFound();
        }
        public ActionResult CardDetails(int? id)
        {
            var patientCard = _patientCardService.FindCardById(id).ProjectToSingleOrDefault<PatientCardViewModel>();
            if (patientCard != null)
            {
                return View(patientCard);
            }
            return HttpNotFound();
        }

        public ActionResult DiagnosisDetails(int? id)
        {
            var patientDiagnosis = _patientCardService.FindDiagnosisById(id).ProjectToSingleOrDefault<DiagnosisViewModel>();
            if (patientDiagnosis != null)
            {
                return View(patientDiagnosis);
            }
            return HttpNotFound();
        }
        public ActionResult PrescriptionDetails(int? id)
        {
            var patientPrescription = _patientCardService.FindPrescriptionById(id).ProjectToSingleOrDefault<PrescriptionViewModel>();
            if (patientPrescription != null)
            {
                return View(patientPrescription);
            }
            return HttpNotFound();
        }
    }
}