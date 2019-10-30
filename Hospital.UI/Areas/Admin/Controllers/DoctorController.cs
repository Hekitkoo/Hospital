using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using Hospital.Core.Interfaces;
using Hospital.Core.Models;
using Hospital.UI.Areas.Admin.Models;
using PagedList;

namespace Hospital.UI.Areas.Admin.Controllers
{
    [Authorize(Roles = "admin")]
    public class DoctorController : Controller
    {
        private readonly IDoctorService _doctorService;
        private readonly IMapper _mapper;
        private readonly ILoggerService<DoctorController> _loggerService;

        public DoctorController(IDoctorService doctorService, IMapper mapper, ILoggerService<DoctorController> loggerService)
        {
            _doctorService = doctorService;
            _mapper = mapper;
            _loggerService = loggerService;
        }
        public ActionResult Index(string sortOrder, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.CurrentPage = page;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.PatientsSortParm = sortOrder == "Number" ? "number_desc" : "Number";
            IEnumerable<DoctorViewModel> doctors = GetDoctorsForViewModel(_doctorService.GetDoctors());
            switch (sortOrder)
            {
                case "name_desc":
                    doctors = doctors.OrderByDescending(s => s.LastName);
                    break;
                case "Number":
                    doctors = doctors.OrderBy(s => (s.NumberOfPatients));
                    break;
                case "number_desc":
                    doctors = doctors.OrderByDescending(s => s.NumberOfPatients);
                    break;
                default:
                    doctors = doctors.OrderBy(s => s.LastName);
                    break;
            }

            int pageSize = 5;
            int pageNumber = (page ?? 1);
            return View(doctors.ToPagedList(pageNumber, pageSize));
        }
        public ActionResult Create()
        {
            var doctor = new CreateDoctorViewModel();
            doctor.Speciality = GetDoctorTypeListForPatientsViewModel(_doctorService.GetAllSpecialties());
            return View(doctor);
        }

        [HttpPost]
        public async Task<ActionResult> Create(CreateDoctorViewModel doctorViewModel)
        {
            if (!ModelState.IsValid)
            {
                doctorViewModel.Speciality = GetDoctorTypeListForPatientsViewModel(_doctorService.GetAllSpecialties());
                return View(doctorViewModel);
            }
            var doctor = GetDoctorFromViewModel(doctorViewModel);

            if (!_doctorService.Unique(doctor))
            {
                ModelState.AddModelError("", "Doctor with same UserName or Email exist!");
                doctorViewModel.Speciality = GetDoctorTypeListForPatientsViewModel(_doctorService.GetAllSpecialties());
                return View(doctorViewModel);
            }
            await _doctorService.Add(doctor);
            _loggerService.Info($"{User.Identity.Name} added {doctor.FirstName} {doctor.LastName}");
            return RedirectToAction("Index");
        }

        private ICollection<SelectListItem> GetDoctorTypeListForPatientsViewModel(IEnumerable<Specialty> specialties)
        {
            var specialtySelectListItems = new List<SelectListItem>();
            foreach (var specialty in specialties)
            {
                specialtySelectListItems.Add(new SelectListItem
                {
                    Text = $"{specialty.Name}",
                    Value = specialty.Id.ToString()
                });
            }
            return specialtySelectListItems;
        }
        private IEnumerable<DoctorViewModel> GetDoctorsForViewModel(IEnumerable<Doctor> doctors)
        {
            return _mapper.Map<IEnumerable<Doctor>, IEnumerable<DoctorViewModel>>(doctors);
        }
        private Doctor GetDoctorFromViewModel(CreateDoctorViewModel doctorViewModel)
        {
            return _mapper.Map<CreateDoctorViewModel, Doctor>(doctorViewModel);
        }
    }
}