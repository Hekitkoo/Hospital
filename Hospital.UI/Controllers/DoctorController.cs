using System;
using System.Collections.Generic;
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

        public ActionResult CreateDiagnosis(int? id)
        {
            if (id !=null)
            {
                var diagnosis = new CreateDiagnosisViewModel();
                diagnosis.PatientCardId = id;
                return View(diagnosis);
            }
            return HttpNotFound();
        }

        [HttpPost]
        public ActionResult CreateDiagnosis(CreateDiagnosisViewModel createDiagnosisViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(createDiagnosisViewModel);
            }
            var diagnosis = _mapper.Map<CreateDiagnosisViewModel, Diagnosis>(createDiagnosisViewModel);

            _patientCardService.CreateDiagnosis(diagnosis);
            _loggerService.Info($"{User.Identity.Name} added diagnoses for {diagnosis.PatientCard}");
            return RedirectToAction("Index");
        }

        public ActionResult ChangeDiagnosis(int? id)
        {

            var diagnosis = _patientCardService.FindDiagnosisById(id).ProjectToSingleOrDefault<CreateDiagnosisViewModel>();
            if (diagnosis != null)
            {
                return View(diagnosis);
            }

            return HttpNotFound();
        }
        [HttpPost]
        public ActionResult ChangeDiagnosis(CreateDiagnosisViewModel diagnosisvm)
        {
            if (!ModelState.IsValid)
            {
                return View(diagnosisvm);
            }
            var diagnosis = _mapper.Map<CreateDiagnosisViewModel, Diagnosis>(diagnosisvm);
            _patientCardService.ChangeDiagnosis(diagnosis);
            _loggerService.Info($"{User.Identity.Name} change diagnoses for {diagnosis.PatientCard}");
            return RedirectToAction("Index");
        }

        public ActionResult CreatePrescription(int? id)
        {
            if (id != null)
            {
                var diagnosis = new CreatePrescriptionViewModel();
                diagnosis.DiagnosisId = (int) id;
                diagnosis.PrescriptionTypes = GetPrescriptionTypeFoViewModel(_patientCardService.GetPrescriptionTypes());
                return View(diagnosis);
            }
            return HttpNotFound();
        }

        [HttpPost]
        public ActionResult CreatePrescription(CreatePrescriptionViewModel createPrescriptionViewModel)
        {
            if (!ModelState.IsValid)
            {
                createPrescriptionViewModel.PrescriptionTypes = GetPrescriptionTypeFoViewModel(_patientCardService.GetPrescriptionTypes());
                return View(createPrescriptionViewModel);
            }
            var prescription = _mapper.Map<CreatePrescriptionViewModel, Prescription>(createPrescriptionViewModel);

            _patientCardService.CreatePrescription(prescription);
            _loggerService.Info($"{User.Identity.Name} added prescription for {prescription.DiagnosisId}");
            return RedirectToAction("Index");
        }

        public ActionResult ChangePrescription(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            var prescription = _patientCardService.FindPrescriptionById(id).ProjectToSingleOrDefault<CreatePrescriptionViewModel>();
           
            if (prescription != null)
            {
                prescription.PrescriptionTypes = GetPrescriptionTypeFoViewModel(_patientCardService.GetPrescriptionTypes());
                return View(prescription);
            }

            return HttpNotFound();
        }
        [HttpPost]
        public ActionResult ChangePrescription(CreatePrescriptionViewModel prescriptionvm)
        {
            if (!ModelState.IsValid)
            {
                return View(prescriptionvm);
            }
            var prescription = _mapper.Map<CreatePrescriptionViewModel, Prescription>(prescriptionvm);
            _patientCardService.ChangePrescription(prescription);
            _loggerService.Info($"{User.Identity.Name} change prescription for {prescription.DiagnosisId}");
            return RedirectToAction("Index");
        }

        private ICollection<SelectListItem> GetPrescriptionTypeFoViewModel(IEnumerable<PrescriptionType> types)
        {
            var typesSelectListItems = new List<SelectListItem>();
            foreach (var type in types)
            {
                typesSelectListItems.Add(new SelectListItem
                {
                    Text = $"{type.Name}",
                    Value = type.Id.ToString()
                });
            }
            return typesSelectListItems;
        }
    }
}