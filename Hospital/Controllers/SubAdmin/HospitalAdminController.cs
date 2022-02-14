using Hospital.CollectionViewModel;
using Hospital.Models;
using Hospital.Models.SubAdmin;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;
using Hospital.Helper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Hospital.Services;
using Hospital.Models.AccountViewModels;
using Microsoft.AspNetCore.Identity.UI.Services;
using Hospital.DBServices.SuperAdmin;
using Hospital.Models.CommonModels;
using Hospital.DBServices.HospitalAdmin;
using Microsoft.AspNetCore.Http;
using static Hospital.Models.CommonModels.ChatViewModel;
using Hospital.ViewModels;
using Newtonsoft.Json.Serialization;
using Hospital.Models.SuperAdminModels;
using AutoMapper;

namespace Hospital.Controllers.SubAdmin
{
    [Authorize(Roles = "HospitalAdmin,StaffMember")]
    public class HospitalAdminController : Controller
    {
        private readonly HMSContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger<HomeController> _logger;
        private readonly IEmailSender _emailSender;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ISuperAdmin _superAdmin;
        private readonly IHospitalAdmin _hospitalAdmin;
        private readonly IMapper _mapper;
        public HospitalAdminController(HMSContext context, IHospitalAdmin hospitalAdmin, ISuperAdmin superAdmin, UserManager<ApplicationUser> userManager, ILogger<HomeController> logger, IEmailSender emailSender, SignInManager<ApplicationUser> signInManager, IMapper mapper)
        {
            _context = context;
            _userManager = userManager;
            _logger = logger;
            _emailSender = emailSender;
            _signInManager = signInManager;
            _superAdmin = superAdmin;
            _hospitalAdmin = hospitalAdmin;
            _mapper = mapper;
        }
        public IActionResult Index(int findId)
        {
            string date = DateTime.Now.ToString("dd-MM-yyyy");
            ViewBag.NumberOfDialyPatients = _context.Patients.Where(c => c.CreatedDate == date).ToList();
            ViewBag.btnValue = findId;
            if (findId == 1)
            {
                ViewBag.NumberOfDialyPatients = _context.Patients.Where(c => c.CreatedDate == date && c.HospitalID == _userManager.GetUserId(HttpContext.User)).ToList();
            }
            else
            if (findId == 2)
            {
                ViewBag.NumberOfDialyPatients = _context.Appointments.Where(c => c.CreatedDate == date && c.HospitalID == _userManager.GetUserId(HttpContext.User)).ToList();
            }

            ViewBag.TotalDoctor = _context.Users.Where(c => c.Role == "Doctor" && c.HospitalID == _userManager.GetUserId(HttpContext.User)).ToList();
            ViewBag.TotalNumberOfNurse = _context.Users.Where(c => c.Role == "Nurse" && c.HospitalID == _userManager.GetUserId(HttpContext.User)).ToList();
            ViewBag.TotalPatients = _context.Users.Where(c => c.Role == "Patients" && c.HospitalID == _userManager.GetUserId(HttpContext.User)).ToList();
           // ViewBag.TotalPatients = _context.Patients.Where(c => c.HospitalID == _userManager.GetUserId(HttpContext.User)).ToList();
          //  ViewBag.Patients = _context.Patients.Where(c => c.HospitalID == _userManager.GetUserId(HttpContext.User)).ToList();
            ViewBag.Department = _context.Departments.Where(c => c.HospitalID == _userManager.GetUserId(HttpContext.User)).ToList();
            ViewBag.Appointments = _context.Appointments.Where(c => c.HospitalID == _userManager.GetUserId(HttpContext.User)).ToList();
            ViewBag.Schedules = _context.Schedules.Where(c => c.HospitalID == _userManager.GetUserId(HttpContext.User)).ToList();
            ViewBag.Allotments = _context.Allotments.ToList();
            var model = new CollectionOfAll
            {

                Doctors = _context.Doctor.ToList(),
                Patients = _context.Patients.Where(c => c.HospitalID == _userManager.GetUserId(HttpContext.User)).ToList(),
                Appointments = _context.Appointments.Where(c => c.HospitalID == _userManager.GetUserId(HttpContext.User)).ToList(),
                Department = _context.Departments.Where(c => c.HospitalID == _userManager.GetUserId(HttpContext.User)).ToList(),
                Schedules = _context.Schedules.Where(c => c.HospitalID == _userManager.GetUserId(HttpContext.User)).ToList(),
                Allotments = _context.Allotments.ToList(),
                Nurses = _context.Nurses.ToList()

            };
            return View(model);
        }

        //public IActionResult DialyRecords(int findId)
        //{
        //    string date = DateTime.Now.ToString("dd-MM-yyyy");
        //    if (findId == 1)
        //    {
        //        ViewBag.NumberOfDialyPatients = _context.Patients.Where(c => c.CreatedDate == date && c.HospitalID == _userManager.GetUserId(HttpContext.User)).ToList();
        //    }else
        //    if (findId == 2)
        //    {
        //        ViewBag.NumberOfDialyPatients = _context.Appointments.Where(c => c.CreatedDate == date && c.HospitalID == _userManager.GetUserId(HttpContext.User)).ToList();
        //    }

        //    return RedirectToAction(nameof(Index));
        //}

        //GET: Doctors
        public async Task<IActionResult> DoctorList()
        {
            //var data = _context.Users.Where(c => c.Role == "Doctor").ToList();
            //ViewBag.doclist = data;

            return View(await _context.Users.Where(c => c.Role == "Doctor" && c.HospitalID == _userManager.GetUserId(HttpContext.User)).ToListAsync());
        }

        //ss GET: Doctors/Details/5
        public async Task<IActionResult> DoctorDetails(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var doctor = await _context.Users
                .FirstOrDefaultAsync(m => m.Id == id);
            if (doctor == null)
            {
                return NotFound();
            }

            return View(doctor);
        }



        // GET: Doctors/Create
        public IActionResult AddDoctor()
        {
            return View();
        }



        // POST: Doctors/Create

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DoctorList([Bind("DoctorId,DoctorName,DOB,Age,Specialization,Experience,Email,PhoneNo,FaxNo,Street,City,State,ZipCode,Country,DoctorDetails,Password,Availiablity")] Doctor doctor)
        //{

        //    var docter = _context.Doctor.Where(c => c.Email == doctor.Email).ToList();

        //    var patient = _context.Patients.Where(c => c.Email == doctor.Email).ToList();

        //    var nurse = _context.Nurses.Where(c => c.EmailAddress == doctor.Email).ToList();

        //    if(patient.Count != 0)
        //    {
        //        Console.WriteLine("Email Already used in Patient.");
        //    }

        //    if (nurse.Count != 0)
        //    {
        //        Console.WriteLine("Email Already used in Nurses.");
        //    }

        //    if (docter.Count == 0 && patient.Count == 0 && nurse.Count == 0)
        //    {

        //        //var roleDocter = _context.Roles.Where(c => c.Name == "Doctor").FirstOrDefault();

        //        if (ModelState.IsValid)
        //        {
        //            var pass = EncryptDecrypt.Encode(doctor.Password);
        //            doctor.Password = pass;
        //            //var docterid = EncryptDecrypt.Encode(doctor.DoctorId);



        //            _context.Add(doctor);
        //            await _context.SaveChangesAsync();


        //            return RedirectToAction(nameof(DoctorList));
        //        }
        //    }
        //    //Console.WriteLine("Email already exist......");
        //    return View("AddDoctor");

        //}

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<dynamic> AddDoctor(DoctorViewModel model)
        {

            model.Email = model.Email;

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = new ApplicationUser { UserName = model.Email, Email = model.Email, FirstName = model.DoctorName, DOB = model.DOB, Age = model.Age, Availiablity = model.Availiablity, City = model.City, Country = model.Country, DoctorDetails = model.DoctorDetails, Experience = model.Experience, FaxNo = model.FaxNo, Specialization = model.Specialization, State = model.State, Street = model.Street, ZipCode = model.ZipCode, PhoneNumber = model.PhoneNo, Role = "Doctor", HospitalID = _userManager.GetUserId(HttpContext.User), CreatedDate = DateTime.Now.ToString("dd-MM-yyyy") };
            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {

                // Add a user to the default role, or any role you prefer here
                await _userManager.AddToRoleAsync(user, "Doctor");
                //await _userManager.AddToRoleAsync(user, model.UserRole.ToString());

                //var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                //var callbackUrl = Url.EmailConfirmationLink(user.Id, code, Request.Scheme);
                //await _emailSender.SendEmailConfirmationAsync(model.Email, callbackUrl);

                //await _signInManager.SignInAsync(user, isPersistent: false);
                // _logger.LogInformation("User created a new account with password.");
                ViewBag.isSuccess = true;
                return View(model);

                //return RedirectToAction(nameof(DoctorList));

            }
            TempData["msg"] = "<script>alert('This email already existed, please try another email..');</script>";
            return View(model);
        }

        // GET: Doctors/Edit/5
        public async Task<IActionResult> EditDoctor(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var doctor = await _context.Users.FindAsync(id);
            if (doctor == null)
            {
                return NotFound();
            }
            return View(doctor);
        }

        // POST: Doctors/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditDoctor(string id, ApplicationUser doctor)
        {
            if (id != doctor.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                //try
                //{

                var data = _context.Users.Find(id);

                if (data != null)
                {
                    data.FirstName = doctor.FirstName;
                    data.DOB = doctor.DOB;
                    data.Age = doctor.Age;
                    data.Specialization = doctor.Specialization;
                    data.Experience = doctor.Experience;
                    data.Email = doctor.Email;
                    data.PhoneNumber = doctor.PhoneNumber;
                    data.FaxNo = doctor.FaxNo;
                    data.Street = doctor.Street;
                    data.City = doctor.City;
                    data.State = doctor.State;
                    data.ZipCode = doctor.ZipCode;
                    data.Country = doctor.Country;
                    data.DoctorDetails = doctor.DoctorDetails;
                    data.Availiablity = doctor.Availiablity;
                    data.ModifiedDate = DateTime.Now.ToString("dd-MM-yyyy");

                    _context.Update(data);
                    await _context.SaveChangesAsync();
                }
                //_context.Update(doctor);
                //await _context.SaveChangesAsync();
                //}
                //catch (DbUpdateConcurrencyException)
                //{
                //    if (!DoctorExists(doctor.Id))
                //    {
                //        return NotFound();
                //    }
                //    else
                //    {
                //        throw;
                //    }
                //}
                return RedirectToAction(nameof(DoctorList));
            }
            return View(doctor);
        }
        #region Hospital patients Start.
        [HttpGet]
        public IActionResult Hostpitalpatients()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> HospitalPatientsLit()
        {
            string draw = Request.Form["draw"];
            string order = Request.Form["order[0][column]"];
            string orderDir = Request.Form["order[0][dir]"];
            int startRec = Convert.ToInt32(Request.Form["start"]);
            int pageSize = Convert.ToInt32(Request.Form["length"]);
            string featurename = Request.Form["columns[0][search][value]"];
            string createddate = Request.Form["columns[2][search][value]"];
            string modifieddate = Request.Form["columns[3][search][value]"];
            string searchTerm = Request.Form["search[value]"];


            var _user = await _userManager.FindByNameAsync(this.User.Identity.Name);
            IEnumerable<Patients> stateList = _context.Patients.Where(x => x.HospitalID.Equals(_user.Id)).ToList();
            long TotalRecordsCount = stateList.Count();

            #region filters   
            if (!string.IsNullOrEmpty(searchTerm) && !string.IsNullOrWhiteSpace(searchTerm))
            {
                stateList = stateList.Where(x =>
                    x.PatientName != null && x.PatientName.ToLower().Contains(searchTerm.ToLower()));
            }
            if (!string.IsNullOrEmpty(featurename) && !string.IsNullOrWhiteSpace(featurename))
            {
                stateList = stateList.Where(x => x.PatientName != null && x.PatientName.ToLower().Contains(featurename.ToLower()));
            }
            #endregion


            long FilteredRecordCount = stateList.Count();

            #region Sorting  


            switch (order)
            {
                case "0":
                    stateList = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? stateList.OrderByDescending(p => p.PatientName) : stateList.OrderBy(p => p.PatientName);
                    break;
                default:
                    stateList = stateList.OrderByDescending(p => p.Id);
                    break;
            }
            #endregion

            var listfeatures = stateList.Skip(startRec).Take(pageSize).ToList();
            return Json(new
            {
                draw = Convert.ToInt32(draw),
                recordsTotal = TotalRecordsCount,
                recordsFiltered = FilteredRecordCount,
                data = listfeatures
            });
        }
        #endregion Hospital patients END.
        public async Task<IActionResult> DoctorDelete(string id)
        {
            var book = await _context.Users.FindAsync(id);
            if (book == null)
            {
                return NotFound();

            }
            _context.Users.Remove(book);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(DoctorList));
        }

        private bool DoctorExists(int id)
        {
            return _context.Doctor.Any(e => e.DoctorId == id);
        }


        //Patients
        // GET: Patients
        public async Task<IActionResult> PatientList()
        {
            return View(await _context.Patients.Where(c => c.HospitalID == _userManager.GetUserId(HttpContext.User)).ToListAsync());
        }


        // GET: Patients/Details/5

        public async Task<IActionResult> PatientDetails(int? id)
        {
            PatientViewModel model = new PatientViewModel();
            try
            {
                model = await _context.Patients.Where(m => m.Id == id).Select(x => new PatientViewModel()
                {
                    Id = x.Id,
                    PatientID = x.PatientID,
                    PatientName = x.PatientName,
                    Age = x.Age,
                    Gender = x.Gender,
                    Email = x.Email,
                    Phone = x.Phone,
                    CountryId = x.CountryId,
                    CountryName = x.CountryName,
                    CityId = x.CityId,
                    CityName = x.CityName,
                    StateId = x.StateId,
                    StateName = x.StateName,
                    Street = x.Street,
                    ZipCode = x.ZipCode,
                    DOB = x.DOB,
                    IsActive = x.IsActive,
                    HospitalID = x.HospitalID,
                    CreatedDate = x.CreatedDate,
                    ModifiedDate = x.ModifiedDate,
                    Nationality = x.Nationality,
                    Address = x.Address,
                    Emergency_Contact_Name = x.Emergency_Contact_Name,
                    Emergency_Contact_Number = x.Emergency_Contact_Number,
                    Occupation = x.Occupation,
                    Patient_Visit_Status = x.Patient_Visit_Status,
                    Patient_Type = x.Payment_Type,
                    Payment_Type = x.Payment_Type,
                    DoctorId = x.DoctorId
                }).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                _logger.LogInformation("User created a new account with password.");
            }
            return View(model);
        }


       
        [HttpPost]
        public IEnumerable<StateMaster> StateListByCountryId(int CountryId)
        {
            return _superAdmin.StateListByCountryId(CountryId);
        }

        [HttpPost]
        public IEnumerable<CityStateModel> CitiesByCountryStatesId(int CountryId, int StateId)
        {
            return _superAdmin.CityListByStateId(StateId);
        }

        #region Create Patient START.
        [HttpGet]
        public IActionResult CreatePatient()
        {
            Random rand = new Random();
            var patientid = rand.Next(Environment.TickCount);
            PatientViewModel patients = new PatientViewModel();
            var randmId = _context.Patients.Where(c => c.PatientID == patientid).ToList();
            if (randmId.Count != 0)
                CreatePatient();
            else
                patients.PatientID = patientid;
            //patients.CityMasters = _superAdmin.CityList();
            //patients.StateMasters = _superAdmin.StateList();
            return View(patients);
        }
        #endregion Create Patient END.



        [HttpGet]
        public IActionResult AddPatient()
        {
            ViewBag.countrylist = _context.CountryMasters.ToList();
            //ViewBag.statelist = _context.StateMasters.ToList();
            ViewBag.citylist = _context.CityMasters.ToList();

            PatientViewModel patients = new PatientViewModel();
            try
            {
                Random rand = new Random();
                var patientid = rand.Next(Environment.TickCount);
                var randmId = _context.Patients.Where(c => c.PatientID == patientid).ToList();
                if (randmId.Count != 0)
                {
                    AddPatient();
                }
                else
                {
                    patients.PatientID = patientid;
                    //patients.CountryMasters = _superAdmin.CountryList();
                    //patients.StateMasters = _superAdmin.StateList();
                }
            }
            catch (Exception ex)
            {
                _logger.LogInformation("HospitalAdminController/AddPatient " + ex.Message);
            }
            return View(patients);
            return View();
        }
        // POST: Patients/Create


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddPatient(PatientViewModel model)
        {
            var countryName = _context.CountryMasters.Where(c => c.Id == model.CountryId).FirstOrDefault();
            var stateName = _context.StateMasters.Where(c => c.Id == model.StateId).FirstOrDefault();
            var cityName = _context.CityMasters.Where(c => c.Id == model.CityId).FirstOrDefault();
            
            model.CountryName = countryName.CountryName;
            model.StateName = stateName.StateName;
            model.CityName = cityName.CityName;
            try
            {
                if (ModelState.IsValid)
                {
                    Patients patients = new Patients();
  
                    model.CreatedDate = DateTime.Now.ToString("dd-MM-yyyy");
                    patients.Id = model.Id;
                    patients.PatientID = model.PatientID;
                    patients.PatientName = model.PatientName;
                    patients.Age = model.Age;
                    patients.Gender = model.Gender;
                    patients.Email = model.Email;
                    patients.Phone = model.Phone;
                    patients.CountryId = model.CountryId;
                    patients.CityId = model.CityId;
                    patients.StateId = model.StateId;
                    patients.Street = model.Street;
                    patients.ZipCode = model.ZipCode;
                    patients.DOB = model.DOB;
                    patients.IsActive = model.IsActive;
                    patients.HospitalID = _userManager.GetUserId(HttpContext.User);
                    patients.CreatedDate = model.CreatedDate;
                    patients.ModifiedDate = model.ModifiedDate;
                    patients.Nationality = model.Nationality;
                    patients.Address = model.Address;
                    patients.Emergency_Contact_Name = model.Emergency_Contact_Name;
                    patients.Emergency_Contact_Number = model.Emergency_Contact_Number;
                    patients.Occupation = model.Occupation;
                    patients.Patient_Visit_Status = model.Patient_Visit_Status;
                    patients.Patient_Type = model.Patient_Type;
                    patients.Payment_Type = model.Payment_Type;
                    patients.DoctorId = model.DoctorId;
                    patients.CountryName = model.CountryName;
                    patients.StateName = model.StateName;
                    patients.CityName = model.CityName;
                    _context.Add(patients);
                    await _context.SaveChangesAsync();
                    ViewBag.isSuccess = true;
                }
                #region Generate Patient ID
                Random rand = new Random();
                var patientid = rand.Next(Environment.TickCount);
                var randmId = _context.Patients.Where(c => c.PatientID == patientid).ToList();
                if (randmId.Count != 0)
                {
                    AddPatient();
                }
                else
                {
                    model.PatientID = patientid;
                    //model.CountryMasters = _superAdmin.CountryList();
                    //model.StateMasters = _superAdmin.StateList();
                }
                #endregion Generate Patient ID 
            }
            catch (Exception ex)
            {
                _logger.LogInformation("HospitalAdminController/AddPatient " + ex.Message);
            }
            return View(model);
        }
        [AcceptVerbs("GET", "POST")]
        public IActionResult IsEmailtExists(string Email)
        {
            var isExists = _context.Patients.Where(c => c.Email.Equals(Email)).FirstOrDefault();
            if (isExists != null)
                return Json(false);
            else
                return Json(true);
        }

        // GET: Patients/Edit/5

        public async Task<IActionResult> EditPatient(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patients = await _context.Patients.FindAsync(id);
            if (patients == null)
            {
                return NotFound();
            }
            return View(patients);
        }

        // POST: Patients/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPatient(int id, [Bind("PatientID,PatientName,Age,Gender,Email,Phone,Street,City,State,ZipCode,Country,DOB,IsActive,CreatedDate")] Patients patients)
        {
            if (id != patients.PatientID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    patients.HospitalID = _userManager.GetUserId(HttpContext.User);
                    patients.ModifiedDate = DateTime.Now.ToString("dd-MM-yyyy");
                    _context.Update(patients);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PatientsExists(patients.PatientID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(PatientList));
            }
            return View(patients);
        }
        [HttpPost]
        public async Task<RequestResponse> DeletePatient(Patients patients)
        {
            RequestResponse response = new RequestResponse();
            var PatientInfo = await _context.Patients.FirstOrDefaultAsync(x => x.Id == patients.Id);
            if (PatientInfo != null)
            {
                PatientInfo.IsActive = patients.IsActive;
                //await _context.SaveChangesAsync();
                response.Status = true;
            }
            else
            {
                response.Status = true;
            }
            return response;
        }


        private bool PatientsExists(int id)
        {
            return _context.Patients.Any(e => e.PatientID == id);
        }


        //Appointment
        // GET: Appointments
        public async Task<IActionResult> AppointmentList()
        {
            return View(await _context.Appointments.Where(c => c.HospitalID == _userManager.GetUserId(HttpContext.User)).ToListAsync());

        }

        // GET: Appointments/Details/5
        public async Task<IActionResult> AppointmentDetails(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appointments = await _context.Appointments
                .FirstOrDefaultAsync(m => m.AppointmentId == id);
            if (appointments == null)
            {
                return NotFound();
            }

            return View(appointments);
        }

        // GET: Appointments/Create
        public IActionResult AddAppointment(int id)
        {
            if (id != 0)
            {
                ViewBag.patientID = _context.Patients.Where(c => c.Id == id).FirstOrDefault();
            }
            else
            {
                ViewBag.patientID = null;
                ViewBag.patientIDWithName = _context.Patients.Where(c => c.HospitalID == _userManager.GetUserId(HttpContext.User)).ToList();
            }
            ViewBag.AllDoctors = _context.Users.Where(c => c.Role == "Doctor" && c.HospitalID == _userManager.GetUserId(HttpContext.User)).ToList();
            ViewBag.Department = _context.Departments.Where(c => c.DepartmentStatus == "Active" && c.HospitalID == _userManager.GetUserId(HttpContext.User)).ToList();

            //Random rand = new Random();
            //var patientid = rand.Next(Environment.TickCount); 

            //var randmId = _context.Appointments.Where(c => c.PatientId == patientid).ToList();

            //if(randmId.Count != 0)
            //{
            //    AddAppointment();
            //} else
            //{
            //    ViewBag.RandomId = patientid;

            //    var i = 0;
            //    i++;
            //    ViewBag.TokenNo = i;
            //}
            return View();
        }

        // POST: Appointments/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddAppointment([Bind("AppointmentId,PatientId,DoctorID,Department,TokenNumber,Problem,AppointmentDate,TimeSlot,AppointmentStatus")] Appointments appointments)
        {
            if (ModelState.IsValid)
            {
                var data = _context.Users.Where(c => c.Id == appointments.DoctorID).FirstOrDefault();
                appointments.DoctorName = data.FirstName + " " + data.LastName;
                appointments.HospitalID = _userManager.GetUserId(HttpContext.User);
                appointments.CreatedDate = DateTime.Now.ToString("dd-MM-yyyy");
                _context.Add(appointments);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(AppointmentList));
            }
            return View(appointments);
        }

        // GET: Appointments/Edit/5
        public async Task<IActionResult> EditAppointment(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appointments = await _context.Appointments.FindAsync(id);
            if (appointments == null)
            {
                return NotFound();
            }
            return View(appointments);
        }

        // POST: Appointments/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditAppointment(int id, [Bind("AppointmentId,PatientId,DoctorName,Department,TokenNumber,Problem,AppointmentDate,TimeSlot,AppointmentStatus,CreatedDate")] Appointments appointments)
        {
            if (id != appointments.AppointmentId)
            {
                return NotFound();
            }
            
                if (ModelState.IsValid)
                {
                    try
                    {
                        appointments.HospitalID = _userManager.GetUserId(HttpContext.User);
                        appointments.ModifiedDate = DateTime.Now.ToString("dd-MM-yyyy");
                        _context.Update(appointments);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!AppointmentsExists(appointments.AppointmentId))
                        {
                            return NotFound();
                        }
                        else
                        {
                            throw;
                        }
                    }
                    return RedirectToAction(nameof(AppointmentList));
                }
           
            return View(appointments);
        }
        public async Task<IActionResult> AppointmentDelete(int id)
        {
            var book = await _context.Appointments.FindAsync(id);
            if (book == null)
            {
                return NotFound();

            }
            _context.Appointments.Remove(book);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(AppointmentList));
        }

        private bool AppointmentsExists(int id)
        {
            return _context.Appointments.Any(e => e.AppointmentId == id);
        }

        //Room Allotment
        // GET: Allotments
        public async Task<IActionResult> AllotmentList()
        {
            return View(await _context.Allotments.ToListAsync());
        }

        // GET: Allotments/Details/5
        public async Task<IActionResult> AllotmentDetails(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var allotment = await _context.Allotments
                .FirstOrDefaultAsync(m => m.AllotmentId == id);
            if (allotment == null)
            {
                return NotFound();
            }

            return View(allotment);
        }

        //// GET: Allotments/Create
        //public IActionResult AddAllotment()
        //{
        //    return View();
        //}

        //// POST: Allotments/Create

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> AddAllotment([Bind("AllotmentId,Room,RoomType,PatientName,AllotmentDate,DischargeDate,DoctorName,Status")] Allotment allotment)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(allotment);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(AllotmentList));
        //    }
        //    return View(allotment);
        //}

        //// GET: Allotments/Edit/5
        //public async Task<IActionResult> EditAllotment(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var allotment = await _context.Allotments.FindAsync(id);
        //    if (allotment == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(allotment);
        //}

        //// POST: Allotments/Edit/5

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> EditAllotment(int id, [Bind("AllotmentId,Room,RoomType,PatientName,AllotmentDate,DischargeDate,DoctorName,Status")] Allotment allotment)
        //{
        //    if (id != allotment.AllotmentId)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(allotment);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!AllotmentExists(allotment.AllotmentId))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(AllotmentList));
        //    }
        //    return View(allotment);
        //}

        public async Task<IActionResult> AllotmentDelete(int id)
        {
            var book = await _context.Allotments.FindAsync(id);
            if (book == null)
            {
                return NotFound();

            }
            _context.Allotments.Remove(book);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(AllotmentList));
        }
        private bool AllotmentExists(int id)
        {
            return _context.Allotments.Any(e => e.AllotmentId == id);
        }

        //Schedules
        // GET: Schedules
        public async Task<IActionResult> ScheduleList()
        {
            return View(await _context.Schedules.Where(c => c.HospitalID == _userManager.GetUserId(HttpContext.User)).ToListAsync());
        }

        // GET: Schedules/Details/5
        public async Task<IActionResult> ScheduleDetails(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var schedule = await _context.Schedules
                .FirstOrDefaultAsync(m => m.Id == id);
            if (schedule == null)
            {
                return NotFound();
            }

            return View(schedule);
        }

        // GET: Schedules/Create
        public IActionResult AddSchedule()
        {
            ViewBag.Doctor = _context.Users.Where(c => c.Role == "Doctor" && c.HospitalID == _userManager.GetUserId(HttpContext.User)).ToList();
            ViewBag.Patient = _context.Patients.Where(c => c.HospitalID == _userManager.GetUserId(HttpContext.User)).ToList();
            return View();
        }
        [HttpPost]
        public IActionResult getDiseaseDoctor(int PatientId)
        {
            ScheduleViewModel scheduleViewModel = new ScheduleViewModel();
            var disease = _context.Patients.Where(c => c.HospitalID == _userManager.GetUserId(HttpContext.User) && c.PatientID == PatientId).Select(p => p.Disease).SingleOrDefault();
            if (disease != null)
            {
                scheduleViewModel.Disease = _context.DiseaseMasters.Where(d => d.Id == Convert.ToInt32(disease)).Select(d => d.Disease).SingleOrDefault();
                scheduleViewModel.DoctorList = _context.Users.Where(c => c.Role == "Doctor" && c.HospitalID == _userManager.GetUserId(HttpContext.User) && c.Specialization.Contains(disease)).ToList();
            }
            return Json(scheduleViewModel);
        }

        [HttpPost]
        public IActionResult getDoctorTime(string DoctorId)
        {

            List<string> lstTimeSlot = new List<string>();
            var doctor = _context.Users.Where(c => c.Role == "Doctor" && c.HospitalID == _userManager.GetUserId(HttpContext.User) && c.Id == DoctorId).SingleOrDefault();
            TimeSpan start = doctor.StartTime.TimeOfDay;
            TimeSpan end = doctor.EndTime.TimeOfDay;
            TimeSpan interval = new TimeSpan(0, 15, 0);
            // If Start is bigger than end, Add a day to the end.
            if (start > end)
                end = end.Add(new TimeSpan(1, 0, 0, 0));
            while (true)
            {
                //Console.WriteLine((new DateTime() + start).ToString("hh:mm tt"));
                start = start.Add(interval);
                if (start > end)
                    break;
                lstTimeSlot.Add((new DateTime() + start).ToString("hh:mm tt"));
            }
            return Json(lstTimeSlot);
        }

        // POST: Schedules/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddSchedule([Bind("Id,Doctor,DoctorId,AvailableStartDay,AvailableEndDay,AvailableStartTime,AvailableEndTime,TimePerPatient,Status")] Schedule schedule)
        {
            if (ModelState.IsValid)
            {
                schedule.HospitalID = _userManager.GetUserId(HttpContext.User);
                schedule.CreatedDate = DateTime.Now.ToString("dd-MM-yyyy");
                _context.Add(schedule);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(ScheduleList));
            }
            return View(schedule);
        }

        // GET: Schedules/Edit/5
        public async Task<IActionResult> EditSchedule(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var schedule = await _context.Schedules.FindAsync(id);
            if (schedule == null)
            {
                return NotFound();
            }
            return View(schedule);
        }

        // POST: Schedules/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditSchedule(int id, [Bind("Id,Doctor,DoctorId,AvailableStartDay,AvailableEndDay,AvailableStartTime,AvailableEndTime,TimePerPatient,Status,CreatedDate")] Schedule schedule)
        {
            if (id != schedule.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    schedule.CreatedDate = schedule.CreatedDate;
                    schedule.HospitalID = _userManager.GetUserId(HttpContext.User);
                    schedule.ModifiedDate = DateTime.Now.ToString("dd-MM-yyyy");
                    _context.Update(schedule);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ScheduleExists(schedule.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(ScheduleList));
            }
            return View(schedule);
        }

        public async Task<IActionResult> ScheduleDelete(int id)
        {
            var book = await _context.Schedules.FindAsync(id);
            if (book == null)
            {
                return NotFound();

            }
            _context.Schedules.Remove(book);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(ScheduleList));
        }
        private bool ScheduleExists(int id)
        {
            return _context.Schedules.Any(e => e.Id == id);
        }

        //Department
        // GET: Departments
        public async Task<IActionResult> DepartmentList()
        {
            return View(await _context.Departments.Where(c => c.HospitalID == _userManager.GetUserId(HttpContext.User)).ToListAsync());
        }

        // GET: Departments/Details/5
        public async Task<IActionResult> DepartmentDetails(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var department = await _context.Departments
                .FirstOrDefaultAsync(m => m.DepartmentID == id);
            if (department == null)
            {
                return NotFound();
            }

            return View(department);
        }

        // GET: Departments/Create
        public IActionResult AddDepartment()
        {
            return View();
        }

        // POST: Departments/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddDepartment([Bind("DepartmentID,DepartmentName,Description,DepartmentStatus")] Department department)
        {
            if (ModelState.IsValid)
            {
                department.HospitalID = _userManager.GetUserId(HttpContext.User);
                _context.Add(department);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(DepartmentList));
            }
            return View(department);
        }

        // GET: Departments/Edit/5
        public async Task<IActionResult> EditDepartment(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var department = await _context.Departments.FindAsync(id);
            if (department == null)
            {
                return NotFound();
            }
            return View(department);
        }

        // POST: Departments/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditDepartment(int id, [Bind("DepartmentID,DepartmentName,Description,DepartmentStatus")] Department department)
        {
            if (id != department.DepartmentID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    department.HospitalID = _userManager.GetUserId(HttpContext.User);
                    _context.Update(department);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DepartmentExists(department.DepartmentID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(DepartmentList));
            }
            return View(department);
        }
        public async Task<IActionResult> DepartmentDelete(int id)
        {
            var book = await _context.Departments.FindAsync(id);
            if (book == null)
            {
                return NotFound();

            }
            _context.Departments.Remove(book);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(DepartmentList));
        }


        private bool DepartmentExists(int id)
        {
            return _context.Departments.Any(e => e.DepartmentID == id);
        }

        //Nuses
        // GET: Nurses
        public async Task<IActionResult> NurseList()
        {
            //var hMSContext = _context.Nurses.Include(n => n.ApplicationUser);
            //return View(await hMSContext.ToListAsync());
            return View(await _context.Users.Where(c => c.Role == "Nurse" && c.HospitalID == _userManager.GetUserId(HttpContext.User)).ToListAsync());
        }

        // GET: Nurses/Details/5
        public async Task<IActionResult> NurseDetails(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nurse = await _context.Users
                .FirstOrDefaultAsync(m => m.Id == id);
            if (nurse == null)
            {
                return NotFound();
            }

            return View(nurse);
        }

        // GET: Nurses/Create
        public IActionResult AddNurse()
        {
            ViewData["ApplicationUserId"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddNurse(NurseViewModel model)
        {

            model.Email = model.Email;
            if (!ModelState.IsValid)
            {
                return View(model);
            }


            var user = new ApplicationUser { UserName = model.Email, Email = model.Email, FirstName = model.FullName, DOB = model.DateOfBirth, Availiablity = model.Status, City = model.City, Country = model.Country, State = model.State, Street = model.Street, ZipCode = model.ZipCode, BloodGroup = model.BloodGroup, Gender = model.Gender, PhoneNumber = model.MobileNo, Role = "Nurse", HospitalID = _userManager.GetUserId(HttpContext.User), CreatedDate = DateTime.Now.ToString("dd-MM-yyyy") };
            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {


                // Add a user to the default role, or any role you prefer here
                await _userManager.AddToRoleAsync(user, "Nurse");
                //await _userManager.AddToRoleAsync(user, model.UserRole.ToString());

                //var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                //var callbackUrl = Url.EmailConfirmationLink(user.Id, code, Request.Scheme);
                //await _emailSender.SendEmailConfirmationAsync(model.Email, callbackUrl);

                //await _signInManager.SignInAsync(user, isPersistent: false);
                //_logger.LogInformation("User created a new account with password.");
                ViewBag.isSuccess = true;
                return View(model);
                //return RedirectToAction("NurseList", "HospitalAdmin");


            }
            TempData["msg"] = "<script>alert('This email already existed, please try another email..');</script>";
            return View(model);
        }

        // POST: Nurses/Create

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> AddNurse([Bind("Id,ApplicationUserId,FullName,EmailAddress,MobileNo,Gender,BloodGroup,DateOfBirth,Street,City,State,ZipCode,Country,Password,Status")] Nurse nurse)
        //{

        //    var docter = _context.Doctor.Where(c => c.Email == nurse.EmailAddress).ToList();

        //    var patient = _context.Patients.Where(c => c.Email == nurse.EmailAddress).ToList();

        //    var nurs = _context.Nurses.Where(c => c.EmailAddress == nurse.EmailAddress).ToList();

        //    if (patient.Count != 0)
        //    {
        //        Console.WriteLine("Email Already used in Patient.");
        //    }

        //    if (docter.Count != 0)
        //    {
        //        Console.WriteLine("Email Already used in Nurses.");
        //    }

        //    if (docter.Count == 0 && patient.Count == 0 && nurs.Count == 0)
        //    {

        //        if (ModelState.IsValid)
        //        {
        //            var pass = EncryptDecrypt.Encode(nurse.Password);
        //            nurse.Password = pass;

        //            _context.Add(nurse);
        //            await _context.SaveChangesAsync();
        //            return RedirectToAction(nameof(NurseList));
        //        }
        //    }
        //    ViewData["ApplicationUserId"] = new SelectList(_context.Users, "Id", "Id", nurse.ApplicationUserId);
        //    return View(nurse);
        //}

        // GET: Nurses/Edit/5
        public async Task<IActionResult> EditNurse(string? id)
        {

            NurseViewModel nurs = new NurseViewModel();
            if (id == null)
            {
                return NotFound();
            }

            var nurse = await _context.Users.FindAsync(id);

            if (nurse == null)
            {
                return NotFound();
            }
            ViewData["Id"] = new SelectList(_context.Users, "Id", "Id", nurse.Id);
            return View(nurse);
        }

        // POST: Nurses/Edit/5

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> EditNurse(int id, [Bind("Id,ApplicationUserId,FullName,EmailAddress,MobileNo,Gender,BloodGroup,DateOfBirth,Street,City,State,ZipCode,Country,Status")] Nurse nurse)
        //{
        //    if (id != nurse.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(nurse);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!NurseExists(nurse.Id))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(NurseList));
        //    }
        //    ViewData["ApplicationUserId"] = new SelectList(_context.Users, "Id", "Id", nurse.ApplicationUserId);
        //    return View(nurse);
        //}

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditNurse(string id, ApplicationUser nurse)
        {

            if (id != nurse.Id)
            {
                return NotFound();
            }

            var data = _context.Users.Find(id);

            if (ModelState.IsValid)
            {
                data.FirstName = nurse.FirstName;
                data.Email = nurse.Email;
                data.PhoneNumber = nurse.PhoneNumber;
                data.Street = nurse.Street;
                data.City = nurse.City;
                data.State = nurse.State;
                data.ZipCode = nurse.ZipCode;
                data.Country = nurse.Country;
                data.Gender = nurse.Gender;
                data.DOB = nurse.DOB;
                data.Availiablity = nurse.Availiablity;
                data.ModifiedDate = DateTime.Now.ToString("dd-MM-yyyy");

                _context.Update(data);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(NurseList));
            }
            ViewData["Id"] = new SelectList(_context.Users, "Id", "Id", nurse.Id);
            return View(nurse);
        }

        //Nurse Delete 
        public async Task<IActionResult> NurseDelete(string id)
        {
            var book = await _context.Users.FindAsync(id);
            if (book == null)
            {
                return NotFound();

            }
            _context.Users.Remove(book);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(NurseList));
        }

        private bool NurseExists(int id)
        {
            return _context.Nurses.Any(e => e.Id == id);
        }

        public async Task<IActionResult> Payment()
        {
            var data = _context.Payment.Where(c => c.HospitalID == _userManager.GetUserId(HttpContext.User)).ToList();


            foreach (var item2 in data)
            {

                var userDetail = _context.Payment.Where(c => c.Patient_ID == item2.Patient_ID).ToList();
                var amnt = 0;
                foreach (var toalAmount in userDetail)
                {
                    amnt += int.Parse(toalAmount.Amount);
                    toalAmount.Amount = Convert.ToString(amnt);
                }
                ViewBag.PatientsAmountList = data.ToList();

            }

            foreach (var item in data)
            {
                if (item.Amount == item.Deposit_Amount)
                {
                    item.Payment_Complete = "1";
                }
                else
                {
                    item.Payment_Complete = "0";
                }
            }


            return View();
        }

        public IActionResult AddAmount(int PatientID)
        {
            var amount = _context.Payment.Where(c => c.Patient_ID == Convert.ToString(PatientID)).ToList();
            if (amount != null)
            {
                ViewBag.patientamount = amount;
            }

            var data = _context.Patients.Where(c => c.PatientID == PatientID).FirstOrDefault();

            ViewBag.PatienForAmount = data;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddAmount([Bind("Patient_ID,Patient_Name,Amount,Status,CreatedDate,HospitalID,PaymentDetail")] Payment payment)
        {

            payment.Status = "Pending";
            payment.CreatedDate = DateTime.Now.ToString("dd-MM-yyyy");
            payment.HospitalID = _userManager.GetUserId(HttpContext.User);
            _context.Add(payment);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(AddAmount));
        }


        public async Task<IActionResult> AddDepositAmount(Payment payment)
        {
            var data = _context.Payment.Where(c => c.Patient_ID == payment.Patient_ID).FirstOrDefault();

            if (data != null)
            {
                var depAmount = int.Parse(data.Deposit_Amount) + int.Parse(payment.Deposit_Amount);
                var pendAmount = int.Parse(data.Amount) - depAmount;
                data.Pending_Amount = Convert.ToString(pendAmount);
                data.Deposit_Amount = Convert.ToString(depAmount);

                if (int.Parse(data.Deposit_Amount) < int.Parse(data.Amount) && int.Parse(data.Deposit_Amount) != null)
                {
                    data.Status = "Some Amount Pending";
                }
                else
                if (int.Parse(data.Deposit_Amount) == int.Parse(data.Amount))
                {
                    data.Status = "Amount Deposit";
                }
                else
                {
                    data.Status = "Pending";
                }

                _context.Update(data);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Payment));
        }

        public async Task<IActionResult> AddStaff()
        {
            StaffModel model = new StaffModel();
            model.Cities = _superAdmin.CityList();
            model.States = _superAdmin.StateList();
            ViewBag.HospitalID = _userManager.GetUserId(HttpContext.User);
            ViewBag.Role = _context.Roles.Where(c => c.Name != "StaffMember" && c.Name != "HospitalAdmin" && c.Name != "Admin");
            return View(model);

        }
        [HttpPost]
        public async Task<IActionResult> AddStaff(StaffModel staffModel)
        {
            RequestResponse response = new RequestResponse();
            response = await _hospitalAdmin.CreateStaff(staffModel);
            // return response;
            if (response.Status == true)
            {
                 RedirectToAction(nameof(AddStaff));
                ViewBag.isSuccess = true;
            }
            StaffModel model = new StaffModel();
            model.Cities = _superAdmin.CityList();
            model.States = _superAdmin.StateList();
            ViewBag.HospitalID = _userManager.GetUserId(HttpContext.User);
            ViewBag.Role = _context.Roles.Where(c => c.Name != "StaffMember" && c.Name != "HospitalAdmin" && c.Name != "Admin");
            
            return View();
        }

        public IActionResult EditStaff(string id)
        {
            var user = _context.ApplicationUser.Where(a => a.Id == id).FirstOrDefault();
            StaffModel model = new StaffModel();
            model.Cities = _superAdmin.CityList();
            model.States = _superAdmin.StateList();
            model.StaffName = user.FirstName;
            model.RoleName = user.UserRole.Split(",").ToList();
            model.PhoneNo = user.PhoneNumber;
            model.StateId = Convert.ToInt32(user.State);
            model.CityId = Convert.ToInt32(user.City);
            model.ZipCode = user.ZipCode;
            model.Email = user.Email;
            model.IsActive = true;
            model.CountryId = Convert.ToInt32(user.Country);

            ViewBag.HospitalID = _userManager.GetUserId(HttpContext.User);
            ViewBag.Role = _context.Roles.Where(c => c.Name != "StaffMember" && c.Name != "HospitalAdmin" && c.Name != "Admin");
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditStaff(StaffModel staffModel)
        {
            RequestResponse response = new RequestResponse();
            response = await _hospitalAdmin.EditStaff(staffModel);
            // return response;
            if (response.Status == true)
            {
                return RedirectToAction(nameof(EditStaff));
            }
            return View();
        }

        public async Task<IActionResult> StaffList()
        {
            List<string> role = new List<string>();

            var model =await (from ur in _context.ApplicationUser
                         where ur.HospitalID == _userManager.GetUserId(HttpContext.User)
                         join r in _context.UserRoles on ur.Id equals r.UserId
                         join R in _context.Roles on r.RoleId equals R.Id
                         where R.Name == "StaffMember"
                         select new ApplicationUser {
                             Id=ur.Id,
                             FirstName=ur.FirstName,
                             UserName=ur.UserName,
                             UserRole=ur.UserRole,
                             HospitalID=ur.HospitalID,
                             Email=ur.Email,
                             IsActive=ur.IsActive
                              }).ToListAsync();


            //foreach (var item in model)
            //{
            //    //foreach (var roleId in item.UserRole.Split(",").ToList())
            //    //{
            //    //    var roleName = (from r in _context.Roles
            //    //                    where r.Id == roleId
            //    //                    select r.Name).Single();
            //    //    role.Add(roleName);
            //    //}
            //    item.UserRole = string.Join(",", role);
            //    role.Clear();
            //}
            return View(model);
        }

      
        public async Task<IActionResult> StaffDelete(string id)
        {
            var staff = await _context.Users.FindAsync(id);
            if (staff == null)
            {
                return NotFound();

            }
            _context.Users.Remove(staff);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(StaffList));
        }

        //public async Task<IActionResult> Chat()
        //{
        //    if (HttpContext.Session.GetString("CurrentRole") == "StaffMember")
        //    {
        //        ViewBag.AllMembers = _context.ApplicationUser.Where(a => a.Id == (from c in _context.ApplicationUser where c.Id == _userManager.GetUserId(HttpContext.User) select c.HospitalID).Single()).ToList();
        //    }
        //    else if (HttpContext.Session.GetString("CurrentRole") == "HospitalAdmin")
        //    {
        //        ViewBag.AllMembers = _context.ApplicationUser.Where(a => a.HospitalID == _userManager.GetUserId(HttpContext.User)).ToList();
        //    }
        //    return View();
        //}

        public IActionResult Chat(/*string searchstrin*/)
        {
            var msg = _context.ChatModels.ToList();
            foreach(var mm in msg)
            {
                var newmsg= mm.Message.LastOrDefault();
                ViewBag.Nmsg = newmsg;
            }
            ViewBag.Message = msg.LastOrDefault();
            var allmsg = _context.ChatMessages.ToList();
            ViewBag.MessageCount = allmsg.Count();
            //ChatViewModel chatViewModels = new ChatViewModel();
            //var chat = from c in (chatViewModels.ReciverMessages) select c;
            //if (!string.IsNullOrEmpty(searchstring))
            //{
            //    chat = chat.Where(s => (s.FirstName).Contains(searchstring));
            //}
            ViewBag.AllChatMembers = _context.Users.Where(c => c.HospitalID == _userManager.GetUserId(HttpContext.User)).ToList();
            ViewBag.loginId = _userManager.GetUserId(HttpContext.User);
            return View();
        }

        public JsonResult SelectedUserChat(string Id)
        {
            ResponseViewModel responsemodel = new ResponseViewModel();
            var logusr = _userManager.GetUserId(HttpContext.User);
            var result = _context.Users.Where(c => c.Id == Id).FirstOrDefault();
            var chats = _context.ChatMessages.Where(c => c.SenderID == Id || c.RecieverID == Id && (c.SenderID == logusr || c.SenderID == logusr)).ToList();
            responsemodel.Data = result;
            responsemodel.Chat = chats;
            responsemodel.loginId = _userManager.GetUserId(HttpContext.User);
            //ViewBag.chats = chats;
            return Json(responsemodel);
        }

        public JsonResult SendChatMessage(ChatMessages msg)
        {
            if (msg.Message != null)
            {
                msg.SenderID = _userManager.GetUserId(HttpContext.User);
                msg.Date = DateTime.Now.ToString("dd-MM-yyyy");

                _context.ChatMessages.Add(msg);
                _context.SaveChanges();
            }
            return Json(msg);
        }

        [HttpPost]
        public IActionResult ChatPartial(string Id)
        {

            ChatViewModel chatViewModels = new ChatViewModel();
            var reciverMessage = (from c in _context.ChatModels
                                  join u in _context.ApplicationUser on c.SenderId equals u.Id
                                  where
                                  c.ReciverId == Id && c.SenderId == _userManager.GetUserId(HttpContext.User) &&
                                  c.IsDelete != true
                                  select new ReciverMessage { FirstName = u.FirstName, Message = c.Message, MessageDate = c.MessageDate }
                         ).OrderByDescending(c => c.MessageDate).ToList();
            var SenderMessage = (from c in _context.ChatModels
                                 join u in _context.ApplicationUser on c.SenderId equals u.Id
                                 where
                                 c.SenderId == Id && c.ReciverId == _userManager.GetUserId(HttpContext.User) &&
                                 c.IsDelete != true
                                 select new SenderMessage { FirstName = u.FirstName, Message = c.Message, MessageDate = c.MessageDate }
                       ).OrderByDescending(c => c.MessageDate).ToList();
            chatViewModels.ReciverMessages = reciverMessage;
            chatViewModels.SenderMessages = SenderMessage;
            ViewBag.SelectedId = Id;
            return PartialView("_ChatPartial", chatViewModels);
        }

        [HttpPost]
        public async Task<IActionResult> SendMessage(string id, string Message)
        {
            ChatModel chatModel = new ChatModel();
            chatModel.IsDelete = false;
            chatModel.IsRead = false;
            chatModel.Message = Message;
            chatModel.MessageDate = DateTime.Now;
            chatModel.ReciverId = id;
            chatModel.SenderId = _userManager.GetUserId(HttpContext.User);
            await _context.ChatModels.AddAsync(chatModel);
            await _context.SaveChangesAsync();
            return View();
        }

        public IActionResult ResetPassword()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ResetPasswordAsync(changePassViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            else
            {
                ApplicationUser user = await _userManager.FindByIdAsync(_userManager.GetUserId(HttpContext.User));

                if (user != null)
                {
                    user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, model.Password);
                    var result = await _userManager.UpdateAsync(user);
                    if (result.Succeeded)
                    {
                        return View("Index");
                    }
                }
            }
            return View();   
        }

        public JsonResult getstates(int? id)
        {
            var data = _context.StateMasters.Where(c => c.CountryId == id).ToList();
            return Json(data);
        }

        public JsonResult getcity(int? id)
        {
            var data = _context.CityMasters.Where(c => c.StateId == id).ToList();
            return Json(data);
        }


        public IActionResult Add_Birth_Report()
        {
            return View();
        }
        public IActionResult Birth_Report_List()
        {
            return View();
        }
        public IActionResult Birth_Report_Detail()
        {
            return View();
        }


    }
}
