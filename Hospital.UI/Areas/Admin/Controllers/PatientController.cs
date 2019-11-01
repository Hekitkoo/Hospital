using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using AutoMapper;
using PagedList;
using Hospital.Core.Models;
using Hospital.Service.Interfaces;
using Hospital.UI.Areas.Admin.Models;
using Hospital.UI.Models;

namespace Hospital.UI.Areas.Admin.Controllers
{
    [Authorize(Roles = "admin")]
    public class PatientController : Controller
    {
        private readonly IPatientService _patientService;
        private readonly IDoctorService _doctorService;
        private readonly ILoggerService<PatientController> _loggerService;
        private readonly IMapper _mapper;

        public PatientController(IPatientService patientService,IDoctorService doctorService, ILoggerService<PatientController> loggerService, IMapper mapper)
        {
            _patientService = patientService;
            _doctorService = doctorService;
            _loggerService = loggerService;
            _mapper = mapper;
        }
        
        public ActionResult Index(string sortOrder, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.CurrentPage = page;
            ViewBag.NameSortParm  = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";
            IEnumerable<PatientViewModel> patients = GetPatientsForViewModel(_patientService.GetPatients());
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

            int pageSize = 5;
            int pageNumber = (page ?? 1);
            return View(patients.ToPagedList(pageNumber,pageSize));
        }

        public ActionResult Create()
        {
            var patient = new CreatePatientViewModel();
            patient.Doctors = GetDoctorListForPatientsViewModel(_doctorService.GetDoctors());
            return View(patient);
        }

        [HttpPost]
        public async Task<ActionResult> Create(CreatePatientViewModel patientViewModel)
        {
            if (!ModelState.IsValid)
            {
                patientViewModel.Doctors = GetDoctorListForPatientsViewModel(_doctorService.GetDoctors());
                return View(patientViewModel);
            }
            var patient = GetPatientFromViewModel(patientViewModel);

            if (!_patientService.Unique(patient))
            {
                ModelState.AddModelError("", "User with same UserName or Email exist!");
                patientViewModel.Doctors = GetDoctorListForPatientsViewModel(_doctorService.GetDoctors());
                return View(patientViewModel);
            }
            await _patientService.Add(patient);
            _loggerService.Info($"{User.Identity.Name} added {patient.FirstName} {patient.LastName}");
            return RedirectToAction("Index");
        }

        public ActionResult ChangeDoctor(int id)
        {
            var patient = new ChangeDoctorViewModel();
            patient.Id = id;
            patient.Doctors = GetDoctorListForPatientsViewModel(_doctorService.GetDoctors());
            return View(patient);
        }

        [HttpPost]
        public ActionResult ChangeDoctor(ChangeDoctorViewModel patientvm)
        {
            if (!ModelState.IsValid)
            {
                patientvm.Doctors = GetDoctorListForPatientsViewModel(_doctorService.GetDoctors());
                return View(patientvm);
            }
            var patient = _patientService.FindById(patientvm.Id);
            patient.DoctorId = patientvm.DoctorId;
            _patientService.ChangeDoctor(patient);
            _loggerService.Info($"{User.Identity.Name} changed patients {patient.FirstName} {patient.LastName} (doctor changed) ");
            return RedirectToAction("Details","Patient", new {id = patientvm.Id});
        }

        public ActionResult Details(int id)
        {
            var patient = GetIndexPatientViewModel(_patientService.FindById(id));

            if (patient != null)
            {
                return View(patient);
            }
            return HttpNotFound();
        }
        private IEnumerable<PatientViewModel> GetPatientsForViewModel(IEnumerable<Patient> patients)
        {
            return _mapper.Map<IEnumerable<Patient>, IEnumerable<PatientViewModel>>(patients);
        }
        private Patient GetPatientFromViewModel(CreatePatientViewModel patient)
        {
            return _mapper.Map<CreatePatientViewModel, Patient>(patient);
        }
        private PatientViewModel GetIndexPatientViewModel(Patient patient)
        {
            return _mapper.Map<Patient, PatientViewModel>(patient);
        }
        private ICollection<SelectListItem> GetDoctorListForPatientsViewModel(IEnumerable<Doctor> doctors)
        {
            var doctorSelectListItems = new List<SelectListItem>();
            foreach (var doctor in doctors)
            {
                doctorSelectListItems.Add(new SelectListItem
                {
                    Text = $"{doctor.FirstName} {doctor.LastName}",
                    Value = doctor.Id.ToString()
                });
            }
            return doctorSelectListItems;
        }
    }
}