using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Hospital.Models;
using Microsoft.AspNetCore.Authorization;
using Hospital.DBServices.SuperAdmin;
using Hospital.Models.CommonModels;

namespace Hospital.Controllers
{
    [Authorize(Roles = "Admin")]
    public class PricingPacksController : Controller
    {
        private readonly HMSContext _context; 
        private readonly ISuperAdmin superAdmin;

        public PricingPacksController(HMSContext context, ISuperAdmin _superAdmin)
        {
            _context = context;
            superAdmin = _superAdmin;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        #region Get all packages list
        [HttpPost]
        public async Task<IActionResult> GetAllPackagesList()
        {
            try
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
                IEnumerable<PricingPacks> stateList = await superAdmin.GetAllPackagesList();
                long TotalRecordsCount = stateList.Count();

                #region filters   
                if (!string.IsNullOrEmpty(searchTerm) && !string.IsNullOrWhiteSpace(searchTerm))
                {
                    stateList = stateList.Where(x =>
                        x.PlanName != null && x.PlanName.ToLower().Contains(searchTerm.ToLower()));
                }
                if (!string.IsNullOrEmpty(featurename) && !string.IsNullOrWhiteSpace(featurename))
                {
                    stateList = stateList.Where(x => x.PlanName != null && x.PlanName.ToLower().Contains(featurename.ToLower()));
                }
                #endregion
                long FilteredRecordCount = stateList.Count();

                #region Sorting  


                switch (order)
                {
                    case "0":
                        stateList = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? stateList.OrderByDescending(p => p.PlanName) : stateList.OrderBy(p => p.PlanName);
                        break;
                    default:
                        stateList = stateList.OrderByDescending(p => p.id);
                        break;
                }
                #endregion

                var listfeatures = stateList.Skip(startRec).Take(pageSize).ToList()
                    .Select(d => new PricingPacks()
                    {
                        id = d.id,
                        PlanName = d.PlanName,
                        Description = d.Description,
                        BillingPeroid = d.BillingPeroid,
                        Amount = d.Amount,
                        Features = d.Features,
                        PlanType = d.PlanType,
                        IsActive = d.IsActive,
                        CreatedDate = d.CreatedDate ,
                        ModifiedDate = d.ModifiedDate ,
                    }).ToList();
                return Json(new
                {
                    draw = Convert.ToInt32(draw),
                    recordsTotal = TotalRecordsCount,
                    recordsFiltered = FilteredRecordCount,
                    data = listfeatures
                });
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion Get all packages list

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var pricingPack = await superAdmin.GetPricingPackById(id);
            if (pricingPack == null)
            {
                return NotFound();
            }
            return View(pricingPack);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        } 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<RequestResponse> Create(PricingPacks pricingPack)
        {
            RequestResponse response = new RequestResponse();
            if (ModelState.IsValid)
            {
                response = await superAdmin.CreatePackage(pricingPack);

            }
            else
            {
                response.Status = false;
            }
            return response;
        }
        [HttpPost] 
        public async Task<RequestResponse> Update(PricingPacks pricingPack)
        {
            RequestResponse response = new RequestResponse();
            if (ModelState.IsValid)
            {
                response = await superAdmin.UpdatePackage(pricingPack);
            }
            else
            {
                response.Status = false;
            }
            return response;
        }

        [HttpGet]
        public async Task<IActionResult> EditPackage(int Id)
        { 
            var pricingPack =await superAdmin.GetPricingPackById(Id);
            if (pricingPack == null)
            {
                return NotFound();
            }
            return View(pricingPack);
        } 
         
    }
}
