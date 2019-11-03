using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using Hospital.Core.Models;
using Hospital.Service.Interfaces;
using Hospital.UI.Areas.Admin.Models;
using Hospital.UI.Models;

namespace Hospital.UI.Areas.Admin.Controllers
{
    [Authorize(Roles = "admin")]
    public class SpecialityController : Controller
    {
        private readonly ISpecialityService _specialityService;
        private readonly IMapper _mapper;
        private readonly ILoggerService<SpecialityController> _loggerService;

        public SpecialityController(ISpecialityService specialityService, IMapper mapper, ILoggerService<SpecialityController> loggerService)
        {
            _specialityService = specialityService;
            _mapper = mapper;
            _loggerService = loggerService;
        }
        // GET: Admin/Category
        public ActionResult Index()
        {
            var specialities = _specialityService.GetAllSpecialities().ProjectToQueryable<SpecialityViewModel>().AsEnumerable();
            return View(specialities);
        }

        public ActionResult Details(int? id)
        {
            var speciality = _specialityService.FindById(id).ProjectToSingleOrDefault<DetailsSpecialityViewModel>();
            if (speciality == null)
            {
                return HttpNotFound();
            }
            return View(speciality);
        }

        public ActionResult Create()
        {
            var speciality = new SpecialityViewModel();
            return View(speciality);
        }

        [HttpPost]
        public ActionResult Create(SpecialityViewModel specialityvm)
        {
            if (!ModelState.IsValid)
            {
                return View(specialityvm);
            }
            var speciality = _mapper.Map<SpecialityViewModel, Speciality>(specialityvm);
            _specialityService.Create(speciality);
            _loggerService.Info($"{User.Identity.Name} added speciality{speciality.Name}");
            return RedirectToAction("Index");
        }

    }
}