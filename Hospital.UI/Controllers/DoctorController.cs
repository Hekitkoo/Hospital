using System;
using System.Web.Mvc;
using AutoMapper;
using Hospital.Service.Interfaces;
using Hospital.UI.Models;
using Microsoft.AspNet.Identity;

namespace Hospital.UI.Controllers
{
    [Authorize(Roles = "doctor")]
    public class DoctorController : Controller
    {
        private readonly IDoctorService _doctorService;
        private readonly IPatientService _patientService;
        private readonly IMapper _mapper;

        public DoctorController(IDoctorService doctorService, IMapper mapper, IPatientService patientService)
        {
            _doctorService = doctorService;
            _mapper = mapper;
            _patientService = patientService;
        }
        // GET: Doctor
        public ActionResult Index()
        {
            int id = Convert.ToInt32(User.Identity.GetUserId());
            var doctor = _doctorService.FindById(id).ProjectToSingleOrDefault<DetailsDoctorViewModel>() ;
            if (doctor != null)
            {
               
                return View(doctor);
            }
            return HttpNotFound();
        }
    }
}