using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Hospital.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication;
using Hospital.Services;
using Hospital.Models.AccountViewModels;
using Hospital.Helper;
using Microsoft.AspNetCore.Identity.UI.Services;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;


namespace Hospital.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly HMSContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IEmailSender _emailSender;
        public HomeController(ILogger<HomeController> logger, HMSContext context,
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IEmailSender emailSender)
        {
            _logger = logger;
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
            _emailSender = emailSender;
        }

        public IActionResult Index()
        {
            //var planslist = _context.PricingPacks.Where(c => c.IsActive == true).ToList();
            //ViewBag.AllPlanList = planslist;
            var loginUser = _context.Users.Where(c => c.Id == _userManager.GetUserId(HttpContext.User)).FirstOrDefault();
            ViewBag.loginUserDetail = loginUser;
            return View();
        }

        

        [HttpPost]
        [AllowAnonymous]
        //[ValidateAntiForgeryToken]
        public async Task<ActionResult> Index(LoginViewModel model, string returnUrl)
        {
            ResponseModel response = new ResponseModel();
            
            IList<string> RolesList = new List<string>();
            if (!ModelState.IsValid)
            {
                ViewBag.wrongLoginOpenModel = 0;
                return View();
            }
            var user = await _userManager.FindByNameAsync(model.Email);

            if (user != null)
            {
                RolesList = await _userManager.GetRolesAsync(user);
                if (!RolesList.Contains("Admin") && !RolesList.Contains("StaffMember") && !RolesList.Contains("HospitalAdmin") && !RolesList.Contains("Doctor") && !RolesList.Contains("Nurse"))
                {
                    ModelState.AddModelError(string.Empty, "You are not authorized to login. Please contact your Manager.");
                    return View(model);
                } 
            } 
            var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, lockoutOnFailure: false);
            if (result.Succeeded)
            {
                //---- for chat status Start ---
                if (user.Role == "Nurse" || user.Role == "Doctor")
                {
                    user.Login = true;
                    _context.Users.Update(user);
                    _context.SaveChanges();
                }
                //---- for chat status End ---

                TempData["login"] = "<script>alert('Successfully Login');</script>";
                try
                {
                    if (RolesList.Contains("StaffMember"))
                    {
                        HttpContext.Session.SetString("MenuControl", user.UserRole);
                    }
                    if (!RolesList.Contains("HospitalAdmin"))
                    {
                        HttpContext.Session.SetString("CurrentHospitalId", user.HospitalID);
                    }
                    HttpContext.Session.SetString("CurrentRole", RolesList[0]);
                }
                catch (Exception ex)
                {
                }
                
                return RedirectToLocal(returnUrl, RolesList);
            }
            else
            {
                ViewBag.wrongLoginOpenModel = 0;
                TempData["login"] = "<script>alert('Invalid Login detail..');</script>";
                ModelState.AddModelError("", "Invalid login attempt.");
                return View(model);
            }
        }

        private ActionResult RedirectToLocal(string returnUrl, IList<string> roles)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            if (roles.Contains("Admin"))
            {
                return RedirectToAction("Index", "Admin");
            }
            if (roles.Contains("HospitalAdmin"))
            {
                return RedirectToAction("Index", "HospitalAdmin");
            }
            if (roles.Contains("StaffMember"))
            {
                return RedirectToAction("Index", "HospitalAdmin");
            }
            if (roles.Contains("Doctor"))
            {
                return RedirectToAction("Index", "Doctor");
            }
            if (roles.Contains("Nurse"))
            {
                return RedirectToAction("Index", "Nurses");
            }

            return RedirectToAction("Index", "Account");
        }

        public async Task<IActionResult> DashboardRedirectAsync(string returnUrl)
        {
            
            IList<string> RolesList = new List<string>();
            var user = _context.Users.Where(c => c.Id == _userManager.GetUserId(HttpContext.User)).FirstOrDefault();
            RolesList = await _userManager.GetRolesAsync(user);
            return RedirectToLocal(returnUrl, RolesList);
        }
        public IActionResult PlanSubscription()
        {
            var planslist = _context.PricingPacks.Where(c => c.IsActive == true).ToList();
            ViewBag.AllPlanList = planslist;
            return View();
        }
        public IActionResult AboutUs()
        {
            return View();
        }
        public IActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Contact(Contactus contactus)
        {
            if (!ModelState.IsValid)
            {
                return View();
            } else
            {
                contactus.Date = DateTime.Now.ToString("dd-MM-yyyy");
                _context.Add(contactus);
                _context.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
           
        }
            public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Register(string returnUrl = null)
        {
            var planslist = _context.PricingPacks.Where(c => c.IsActive == true).ToList();

            ViewBag.AllPlanList = planslist;
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            model.Email = model.Email;
            if (!ModelState.IsValid)
            {
                return View();
            }
            var user = new ApplicationUser { UserName = model.Email, Email = model.Email, FirstName = model.FirstName, LastName = model.LastName, Role = "HospitalAdmin" };
            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                //_logger.LogInformation("User created a new account with password.");
                //TempData["msg"] = "<script>alert('Your new account has been created successfully..');</script>";
                // Add a user to the default role, or any role you prefer here
                await _userManager.AddToRoleAsync(user, "HospitalAdmin");
                //await _userManager.AddToRoleAsync(user, model.UserRole.ToString());

                //var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                //var callbackUrl = Url.EmailConfirmationLink(user.Id, code, Request.Scheme);
                //await _emailSender.SendEmailConfirmationAsync(model.Email, callbackUrl);

                await _signInManager.SignInAsync(user, isPersistent: false);
                _logger.LogInformation("User created a new account with password.");
                ViewBag.openMedel = 1;
                return View();
            }
            TempData["msg"] = "<script>alert('This email already existed, please try another email..');</script>";
            return View();
        }

        public JsonResult SubscribePlan(int? id)
         {
            ResponseModel response = new ResponseModel();
            
            var loginUser = _userManager.GetUserId(HttpContext.User);

            if (loginUser != null)
            {
                var data = _context.Users.Where(c => c.Id == loginUser).FirstOrDefault();
                if (data.Role == "HospitalAdmin") {
                    PurchasePlans purchsplan = new PurchasePlans();
                    purchsplan.CustomerID = loginUser;
                    purchsplan.PlanID = Convert.ToString(id);
                    purchsplan.PurchaseDate = DateTime.Now.ToString("dd-MM-yyyy");
                    _context.Add(purchsplan);
                    _context.SaveChanges();
                    response.Message = "Plan Subscribe Successfully";
                    response.Status = 1;
                }
                else
                {
                    response.Message = "You don't need to buy a plan"; 
                    response.Status = 2;
                }
            }
            else
            {
                response.Message = "Login or Register to buy a plan";
                response.Status = 0;
            }
            return Json(response);
        }


    }
}
