using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper.Configuration;
using Hospital.Collection;
using Hospital.CollectionViewModel;
using Hospital.Data;
using Hospital.DBServices.Features;
using Hospital.DBServices.SuperAdmin;
using Hospital.Helper;
using Hospital.Models;
using Hospital.Models.AccountViewModels;
using Hospital.Models.CommonModels;
using Hospital.Models.SuperAdminModels;
using Hospital.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Hospital.Controllers
{

    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly HMSContext _context;
        private IManageFAQService _manageFAQService;
        private IFeatureService _featureService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IEmailSender _emailSender;
        private readonly ILogger _logger;
        private readonly ISuperAdmin superAdmin;

        public AdminController(IManageFAQService manageFAQService, IFeatureService featureService, RoleManager<IdentityRole> roleManager,
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IEmailSender emailSender,
            ISuperAdmin _superAdmin,
            ILogger<AccountController> logger, HMSContext context)
        {
            _manageFAQService = manageFAQService;
            _featureService = featureService;
            _userManager = userManager;
            _signInManager = signInManager;
            _emailSender = emailSender;
            _logger = logger;
            _context = context;
            superAdmin = _superAdmin;
            _roleManager = roleManager;
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Index()
        {
          
            var date = DateTime.Now.Date;
            var model = new collectionofall
            {
                Doctors = _context.Doctor.ToList(),
                Patients = _context.Patients.Where(c => c.HospitalID == _userManager.GetUserId(HttpContext.User)).ToList(),
                Appointments = _context.Appointments.Where(c => c.HospitalID == _userManager.GetUserId(HttpContext.User)).ToList(),
                Department = _context.Departments.Where(c => c.HospitalID == _userManager.GetUserId(HttpContext.User)).ToList(),
                Schedules = _context.Schedules.Where(c => c.HospitalID == _userManager.GetUserId(HttpContext.User)).ToList(),
                Allotments = _context.Allotments.ToList(),
                Nurses = _context.Nurses.ToList(),
                PricingPacks = _context.PricingPacks.ToList(),
                AppFeatures = _context.AppFeatures.ToList(),
                ManageFAQs = _context.ManageFAQ.ToList(),
                applicationUsers = _context.ApplicationUser.ToList()
            };
            ViewBag.TotalDoctor = _context.Doctor.ToList();
            ViewBag.TotalAllotments = _context.Allotments.ToList();
            ViewBag.TotalNurses = _context.Nurses.ToList();
            ViewBag.TotalPricingPacks = _context.PricingPacks.ToList();
            ViewBag.Patients = _context.Patients.ToList();
            ViewBag.TotalDoctor = _context.Doctor.ToList();
            ViewBag.TotalDoctor = _context.Doctor.ToList();
            return View(model);

        }

        public IActionResult FeaturesList()
        {
            return View();
        }
        public IActionResult FAQList()
        {
            return View();
        }
        public IActionResult Chat_UI()
        {
            return View();
        }
        public IActionResult ManageFAQ()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GetUsers()
        {
            ApplicationUser app = new ApplicationUser();
            var user = _context.ApplicationUser.Where(c => c.Role == "HospitalAdmin").ToList();
            if (app.Role == "HospitalAdmin")
            {
                var users = _userManager.Users;
            }
            return View(user);

        }

        [HttpPost]
        public JsonResult GetFAQ()
        {
            string draw = Request.Form["draw"];
            string order = Request.Form["order[0][column]"];
            string orderDir = Request.Form["order[0][dir]"];
            int startRec = Convert.ToInt32(Request.Form["start"]);
            int pageSize = Convert.ToInt32(Request.Form["length"]);
            string question = Request.Form["columns[0][search][value]"];
            string answer = Request.Form["columns[1][search][value]"];
            string createddate = Request.Form["columns[2][search][value]"];
            string modifieddate = Request.Form["columns[3][search][value]"];
            string searchTerm = Request.Form["search[value]"];
            IQueryable<ManageFAQ> faq = _manageFAQService.GetAllFAQ();


            long TotalRecordsCount = faq.Count();

            #region filters  

            //if (!string.IsNullOrEmpty(searchTerm) && !string.IsNullOrWhiteSpace(searchTerm))
            //{
            //    faq = faq.Where(x =>
            //        x. != null && x.FeatureName.ToLower().Contains(searchTerm.ToLower()));
            //}
            //if (!string.IsNullOrEmpty(question) && !string.IsNullOrWhiteSpace(question))
            //{
            //    faq = faq.Where(x => x.FeatureName != null && x.FeatureName.ToLower().Contains(featurename.ToLower()));
            //}
            #endregion


            //count of record after filter   
            long FilteredRecordCount = faq.Count();

            #region Sorting  

            // Sorting     
            switch (order)
            {
                case "0":
                    faq = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? faq.OrderByDescending(p => p.Question) : faq.OrderBy(p => p.Question);
                    break;
                case "1":
                    faq = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? faq.OrderByDescending(p => p.Answer) : faq.OrderBy(p => p.Answer);
                    break;
                case "2":
                    faq = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? faq.OrderByDescending(p => p.CreatedDate) : faq.OrderBy(p => p.CreatedDate);
                    break;
                default:
                    faq = faq.OrderByDescending(p => p.Id);
                    break;
            }
            #endregion
            /* Apply pagination to employee iqueryable, startRec will hold the record number from which we need to display and pageSize will hold the number of records to display. Then assign the values to EmployeeDetails model.  */
            var listfeatures = faq.Skip(startRec).Take(pageSize).ToList()
                .Select(d => new ManageFAQViewModel()
                {
                    Id = d.Id,
                    Question = d.Question,
                    Answer = d.Answer,
                    CreatedDate = d.CreatedDate,
                    ModifiedDate = d.ModifiedDate,
                    EncryptedID = EncryptDecrypt.Encode(d.Id.ToString())
                }).ToList();

            // To avoid object reference error incase of listemployee being null.    
            if (listfeatures == null)
                listfeatures = new List<ManageFAQViewModel>();


            return this.Json(new
            {
                draw = Convert.ToInt32(draw),
                recordsTotal = TotalRecordsCount,
                recordsFiltered = FilteredRecordCount,
                data = listfeatures
            });
        }

        [HttpPost]
        public JsonResult FeatureList()
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

            IQueryable<AppFeatures> features = _featureService.GetAllFeatures();


            long TotalRecordsCount = features.Count();

            #region filters  

            if (!string.IsNullOrEmpty(searchTerm) && !string.IsNullOrWhiteSpace(searchTerm))
            {
                features = features.Where(x =>
                    x.FeatureName != null && x.FeatureName.ToLower().Contains(searchTerm.ToLower()));
            }
            if (!string.IsNullOrEmpty(featurename) && !string.IsNullOrWhiteSpace(featurename))
            {
                features = features.Where(x => x.FeatureName != null && x.FeatureName.ToLower().Contains(featurename.ToLower()));
            }
            #endregion


            //count of record after filter   
            long FilteredRecordCount = features.Count();

            #region Sorting  

            // Sorting     
            switch (order)
            {
                case "0":
                    features = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? features.OrderByDescending(p => p.FeatureName) : features.OrderBy(p => p.FeatureName);
                    break;
                case "1":
                    features = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? features.OrderByDescending(p => p.Description) : features.OrderBy(p => p.Description);
                    break;
                case "2":
                    features = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? features.OrderByDescending(p => p.CreatedDate) : features.OrderBy(p => p.CreatedDate);
                    break;
                case "3":
                    features = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? features.OrderByDescending(p => p.IsActive) : features.OrderBy(p => p.IsActive);
                    break;
                default:
                    features = features.OrderByDescending(p => p.Id);
                    break;
            }
            #endregion
            /* Apply pagination to employee iqueryable, startRec will hold the record number from which we need to display and pageSize will hold the number of records to display. Then assign the values to EmployeeDetails model.  */
            var listfeatures = features.Skip(startRec).Take(pageSize).ToList()
                .Select(d => new AppFeatureViewModel()
                {
                    Id = d.Id,
                    FeatureName = d.FeatureName,
                    Description = d.Description,
                    CreatedDate = d.CreatedDate,
                    ModifiedDate = d.ModifiedDate,
                    IsActive = d.IsActive,
                    EncryptedID = EncryptDecrypt.Encode(d.Id.ToString())
                }).ToList();

            // To avoid object reference error incase of listemployee being null.    
            if (listfeatures == null)
                listfeatures = new List<AppFeatureViewModel>();


            return this.Json(new
            {
                draw = Convert.ToInt32(draw),
                recordsTotal = TotalRecordsCount,
                recordsFiltered = FilteredRecordCount,
                data = listfeatures
            });
        }

        public async Task<IActionResult> OnPostDelete(int Id)
        {
            var book = await _context.ApplicationUser.FindAsync(Id);
            if (book == null)
            {
                return NotFound();

            }
            _context.ApplicationUser.Remove(book);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }


        [HttpPost]
        public async Task<IActionResult> DeleteUser(string id)
        {
            var user = await _userManager.FindByIdAsync(id);

            if (user == null)
            {
                ViewBag.ErrorMessage = $"User with Id = {id} cannot be found";
                return View("NotFound");
            }
            else
            {
                var result = await _userManager.DeleteAsync(user);

                if (result.Succeeded)
                {
                    return RedirectToAction("GetUsers");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

                return View("GetUsers");
            }
        }
        #region Start ManageCountry
        [HttpGet]
        public IActionResult ManageCountry()
        {
            return View();
        }
        [HttpPost]
        public async Task<RequestResponse> ManageCountry(CountryMaster countryMaster)
        {
            RequestResponse result = await superAdmin.ManageCountry(countryMaster);
            return result;
        }
        [HttpPost]
        public IActionResult CountryList()
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
            IEnumerable<CountryMaster> countryList = superAdmin.CountryList();
            long TotalRecordsCount = countryList.Count();

            #region filters   
            if (!string.IsNullOrEmpty(searchTerm) && !string.IsNullOrWhiteSpace(searchTerm))
            {
                countryList = countryList.Where(x =>
                    x.CountryName != null && x.CountryName.ToLower().Contains(searchTerm.ToLower()));
            }
            if (!string.IsNullOrEmpty(featurename) && !string.IsNullOrWhiteSpace(featurename))
            {
                countryList = countryList.Where(x => x.CountryName != null && x.CountryName.ToLower().Contains(featurename.ToLower()));
            }
            #endregion


            //count of record after filter   
            long FilteredRecordCount = countryList.Count();

            #region Sorting  

            // Sorting     
            switch (order)
            {
                case "0":
                    countryList = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? countryList.OrderByDescending(p => p.CountryName) : countryList.OrderBy(p => p.CountryName);
                    break;
                default:
                    countryList = countryList.OrderByDescending(p => p.Id);
                    break;
            }
            #endregion
            /* Apply pagination to employee iqueryable, startRec will hold the record number from which we need to display and pageSize will hold the number of records to display. Then assign the values to EmployeeDetails model.  */
            var listfeatures = countryList.Skip(startRec).Take(pageSize).ToList()
                .Select(d => new CountryMaster()
                {
                    Id = d.Id,
                    CountryName = d.CountryName,
                }).ToList();
            return Json(new
            {
                draw = Convert.ToInt32(draw),
                recordsTotal = TotalRecordsCount,
                recordsFiltered = FilteredRecordCount,
                data = listfeatures
            });
        }
        [HttpGet]
        public async Task<IActionResult> UpdateCountry(int Id)
        {
            CountryMaster country = new CountryMaster();
            if (!String.IsNullOrEmpty(Id.ToString()))
            {
                country = await superAdmin.GetCountry(Id);
            }
            return View(country);
        }
        #endregion Manage country End
//<---------------------------------manage country region end============================================================>


        #region ManageState State START.
        [HttpGet]
        public IActionResult ManageState()
        {
            ViewBag.Countrys = _context.CountryMasters.ToList();
            return View();
        }
        [HttpPost]
        public async Task<RequestResponse> ManageState(StateMaster stateMaster)
        {
            RequestResponse result = await superAdmin.ManageState(stateMaster);
            return result;
        }
        [HttpPost]
        public IActionResult StateList()
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
            IEnumerable<CountryStateModel> stateList = superAdmin.CountryStateList();
            long TotalRecordsCount = stateList.Count();

            #region filters   
            if (!string.IsNullOrEmpty(searchTerm) && !string.IsNullOrWhiteSpace(searchTerm))
            {
                stateList = stateList.Where(x =>
                    x.StateName != null && x.StateName.ToLower().Contains(searchTerm.ToLower()));
            }
            if (!string.IsNullOrEmpty(featurename) && !string.IsNullOrWhiteSpace(featurename))
            {
                stateList = stateList.Where(x => x.StateName != null && x.StateName.ToLower().Contains(featurename.ToLower()));
            }
            #endregion


            //count of record after filter   
            long FilteredRecordCount = stateList.Count();

            #region Sorting  

            // Sorting     
            switch (order)
            {
                case "0":
                    stateList = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? stateList.OrderByDescending(p => p.StateName) : stateList.OrderBy(p => p.StateName);
                    break;
                default:
                    stateList = stateList.OrderByDescending(p => p.Id);
                    break;
            }
            #endregion
            /* Apply pagination to employee iqueryable, startRec will hold the record number from which we need to display and pageSize will hold the number of records to display. Then assign the values to EmployeeDetails model.  */
            var listfeatures = stateList.Skip(startRec).Take(pageSize).ToList()
                .Select(d => new StateMaster()
                {
                    Id = d.Id,
                    StateName = d.StateName,
                }).ToList();
            return Json(new
            {
                draw = Convert.ToInt32(draw),
                recordsTotal = TotalRecordsCount,
                recordsFiltered = FilteredRecordCount,
                data = listfeatures
            });
        }
        [HttpGet]
        public async Task<IActionResult> UpdateState(int Id)
        {
            StateMaster state = new StateMaster();
            if (!String.IsNullOrEmpty(Id.ToString()))
            {
                state = await superAdmin.GetState(Id);
            }
            return View(state);
            //StateMaster stateMaster = new StateMaster();
            //stateMaster = await superAdmin.GetState(Id);
            //stateMaster.Countries = superAdmin.CountryList();
            //return View(stateMaster);

        }

        #endregion ManageState State END.


        #region Add City START.
        [HttpGet]
        public IActionResult AddCity()
        {
            ViewBag.stateList = _context.StateMasters.ToList();
            ViewBag.CountryList = _context.CountryMasters.ToList();
            //CityMaster model = new CityMaster();
            //model.States = superAdmin.StateList();
            return View();
        }
        [HttpPost]
        public async Task<RequestResponse> AddCity(CityMaster cityMaster)
        {
            return await superAdmin.ManageCity(cityMaster);
        }
        [HttpGet]
        public async Task<IActionResult> UpdateCity(int Id)
        {
            CityMaster cityMaster = new CityMaster();
            cityMaster = await superAdmin.GetCity(Id);
            cityMaster.States = superAdmin.StateList();
            return View(cityMaster);
        }
        [HttpPost]
        public IActionResult CityList()
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
            IEnumerable<CityStateModel> stateList = superAdmin.CityList();
            long TotalRecordsCount = stateList.Count();

            #region filters   
            if (!string.IsNullOrEmpty(searchTerm) && !string.IsNullOrWhiteSpace(searchTerm))
            {
                stateList = stateList.Where(x =>
                    x.CityName != null && x.CityName.ToLower().Contains(searchTerm.ToLower()));
            }
            if (!string.IsNullOrEmpty(featurename) && !string.IsNullOrWhiteSpace(featurename))
            {
                stateList = stateList.Where(x => x.CityName != null && x.CityName.ToLower().Contains(featurename.ToLower()));
            }
            #endregion


            //count of record after filter   
            long FilteredRecordCount = stateList.Count();

            #region Sorting  

            // Sorting     
            switch (order)
            {
                case "0":
                    stateList = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? stateList.OrderByDescending(p => p.CityName) : stateList.OrderBy(p => p.CityName);
                    break;
                default:
                    stateList = stateList.OrderByDescending(p => p.Id);
                    break;
            }
            #endregion
            /* Apply pagination to employee iqueryable, startRec will hold the record number from which we need to display and pageSize will hold the number of records to display. Then assign the values to EmployeeDetails model.  */
            var listfeatures = stateList.Skip(startRec).Take(pageSize).ToList()
                .Select(d => new CityStateModel()
                {
                    Id = d.Id,
                    CityName = d.CityName,
                    StateName = d.StateName,
                    StateId = d.StateId,
                }).ToList();
            return Json(new
            {
                draw = Convert.ToInt32(draw),
                recordsTotal = TotalRecordsCount,
                recordsFiltered = FilteredRecordCount,
                data = listfeatures
            });
        }
        #endregion Add City END.



        #region Create Hospital  START
        [HttpGet]
        public IActionResult CreateHospital()
        {
            HospitalModel model = new HospitalModel();
            model.Cities = superAdmin.CityList();
            model.States = superAdmin.StateList();
            return View(model);
        }
        [HttpPost]
        public async Task<RequestResponse> CreateHospital(HospitalModel model)
        {
            RequestResponse response = new RequestResponse();
            response = await superAdmin.CreateHospital(model);
            return response;
        }
        [HttpGet]
        public async Task<IActionResult> EditHospital(string Id)
        {
            HospitalModel model = new HospitalModel();
            if (!String.IsNullOrEmpty(Id))
            {
                model = await superAdmin.GetHospitalbyId(Id);
                model.Cities = superAdmin.CityList();
                model.States = superAdmin.StateList();
            }

            return View(model);
        }


        [HttpPost]
        public async Task<RequestResponse> EditHospital(HospitalModel model)
        {
            RequestResponse response = new RequestResponse();
            response = await superAdmin.UpdateHospital(model);
            return response;
        }



        [HttpGet]
        public IActionResult ManageHospital()
        {
            return View();
        }



        [HttpPost]
        public IEnumerable<CityStateModel> GetCityByState(int StateId)
        {
            return superAdmin.CityListByStateId(StateId);
        }


        #endregion Create Hospital  END
        [HttpPost]
        public async Task<IActionResult> GetHospitalsList()
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
            IEnumerable<HospitalModel> stateList = superAdmin.GetHospitalsListAsync();
            long TotalRecordsCount = stateList.Count();

            #region filters   
            if (!string.IsNullOrEmpty(searchTerm) && !string.IsNullOrWhiteSpace(searchTerm))
            {
                stateList = stateList.Where(x =>
                    x.HospitalName != null && x.HospitalName.ToLower().Contains(searchTerm.ToLower()));
            }
            if (!string.IsNullOrEmpty(featurename) && !string.IsNullOrWhiteSpace(featurename))
            {
                stateList = stateList.Where(x => x.HospitalName != null && x.HospitalName.ToLower().Contains(featurename.ToLower()));
            }
            #endregion 
            long FilteredRecordCount = stateList.Count();

            #region Sorting  


            switch (order)
            {
                case "0":
                    stateList = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? stateList.OrderByDescending(p => p.HospitalName) : stateList.OrderBy(p => p.HospitalName);
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

        [HttpGet]
        public IActionResult CreateRole()
        {
            return View();
        }

        [HttpPost]
        public async Task<RequestResponse> CreateRole(RoleMaster roles)
        {
            RequestResponse result = await superAdmin.CreateRole(roles);
            return result;
        }
        [HttpPost]
        public async Task<IActionResult> RoleList()
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
            IEnumerable<RoleMaster> roleList = await superAdmin.RoleList();
            long TotalRecordsCount = roleList.Count();

            #region filters   
            if (!string.IsNullOrEmpty(searchTerm) && !string.IsNullOrWhiteSpace(searchTerm))
            {
                roleList = roleList.Where(x =>
                    x.Role != null && x.Role.ToLower().Contains(searchTerm.ToLower()));
            }
            if (!string.IsNullOrEmpty(featurename) && !string.IsNullOrWhiteSpace(featurename))
            {
                roleList = roleList.Where(x => x.Role != null && x.Role.ToLower().Contains(featurename.ToLower()));
            }
            #endregion


            //count of record after filter   
            long FilteredRecordCount = roleList.Count();

            #region Sorting  

            // Sorting     
            switch (order)
            {
                case "0":
                    roleList = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? roleList.OrderByDescending(p => p.Role) : roleList.OrderBy(p => p.Role);
                    break;
                default:
                    roleList = roleList.OrderByDescending(p => p.Id);
                    break;
            }
            #endregion
            /* Apply pagination to employee iqueryable, startRec will hold the record number from which we need to display and pageSize will hold the number of records to display. Then assign the values to EmployeeDetails model.  */
            var listfeatures = roleList.Skip(startRec).Take(pageSize).ToList()
                .Select(d => new RoleMaster()
                {
                    Id = d.Id,
                    Role = d.Role,
                }).ToList();
            return Json(new
            {
                draw = Convert.ToInt32(draw),
                recordsTotal = TotalRecordsCount,
                recordsFiltered = FilteredRecordCount,
                data = listfeatures
            });
        }
        [HttpGet]
        public async Task<IActionResult> UpdateRole(string Id)
        {
            RoleMaster role = new RoleMaster();
            if (!String.IsNullOrEmpty(Id.ToString()))
            {
                role = await superAdmin.GetRole(Id);
            }
            return View(role);
        }
        public async Task<IActionResult> SubscribedUser()
        {
            return View();
        }
        //[HttpPost]
        //public async Task<IActionResult> SubscribedUser()
        //{
        //    return View();
        //}
    }
}