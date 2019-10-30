using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using AutoMapper;
using PagedList;
using Hospital.Core.Interfaces;
using Hospital.Core.Models;
using Hospital.UI.Areas.Admin.Models;

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
            IEnumerable<IndexPatientViewModel> patients = GetPatientsForViewModel(_patientService.GetPatients());
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
                return View(patientViewModel);
            }
            var patient = GetPatientFromViewModel(patientViewModel);

            if (!_patientService.Unique(patient))
            {
                ModelState.AddModelError("", "User with same UserName or Email exist!");
                return View(patientViewModel);
            }
            await _patientService.Add(patient);
            _loggerService.Info($"{User.Identity.Name} added {patient.FirstName} {patient.LastName}");
            return RedirectToAction("Index");
        }
        private IEnumerable<IndexPatientViewModel> GetPatientsForViewModel(IEnumerable<Patient> patients)
        {
            return _mapper.Map<IEnumerable<Patient>, IEnumerable<IndexPatientViewModel>>(patients);
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

        private Patient GetPatientFromViewModel(CreatePatientViewModel patient)
        {
            return _mapper.Map<CreatePatientViewModel, Patient>(patient);
        }
    }
}