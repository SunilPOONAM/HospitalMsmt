using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hospital.Models;
using Hospital.Services;
using Hospital.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.APIController
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AppAPIController : Controller
    {
        private readonly HMSContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IEmailSender _emailSender;
        public AppAPIController(
                             HMSContext context,
                             UserManager<ApplicationUser> userManager,
                             SignInManager<ApplicationUser> signInManager,
                             IEmailSender emailSender
                               )
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
            _emailSender = emailSender;
        }

        [HttpPost]
        [Route("~/api/appapi/Login")]
        public async Task<ResponseViewModel> LoginAsync(LoginViewModel model)
        {

            ResponseViewModel responseModel = new ResponseViewModel();
            IList<string> RolesList = new List<string>();

            var user = await _userManager.FindByNameAsync(model.Email);

            if (user != null)
            {
                RolesList = await _userManager.GetRolesAsync(user);
                if (!RolesList.Contains("Admin") && !RolesList.Contains("HospitalAdmin") && !RolesList.Contains("Doctor") && !RolesList.Contains("Nurse"))
                {
                    ModelState.AddModelError(string.Empty, "You are not authorized to login. Please contact your Manager.");
                    responseModel.Message = "You are not authorized to login. Please contact your Manager."; 
                }
            }

            var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, lockoutOnFailure: false);
            if (result.Succeeded)
            {
                responseModel.Data = user;
                responseModel.Status = 1; 
            }
            else
            {
                responseModel.Status = 0;  
            }
            return responseModel;
        }

        [HttpPost]
        [Route("~/api/appapi/Register")]
        public async Task<ResponseViewModel> Register(RegisterViewModel model)
        {
            ResponseViewModel responseModel = new ResponseViewModel();
            var user = new ApplicationUser { UserName = model.Email, Email = model.Email, FirstName = model.FirstName, LastName = model.LastName, Role = "HospitalAdmin" };
            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                
                TempData["msg"] = "<script>alert('Your new account has been created successfully..');</script>";
                // Add a user to the default role, or any role you prefer here
                await _userManager.AddToRoleAsync(user, "HospitalAdmin");
                //await _userManager.AddToRoleAsync(user, model.UserRole.ToString());

                var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                var callbackUrl = Url.EmailConfirmationLink(user.Id, code, Request.Scheme);
                await _emailSender.SendEmailConfirmationAsync(model.Email, callbackUrl);

                await _signInManager.SignInAsync(user, isPersistent: false);
                
                responseModel.Status = 1;
                responseModel.Message = "User created a new account with password.";
            }
            else
            {
              
                responseModel.Status = 0;
                responseModel.Message = "This email already existed, please try another email..";
            }
            return responseModel;
        }



    }
}