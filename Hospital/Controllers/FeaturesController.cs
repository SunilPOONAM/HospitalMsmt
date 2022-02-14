using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hospital.Data;
using Hospital.DBServices.Features;
using Microsoft.AspNetCore.Mvc;
using Hospital.Helper;
using Hospital.Models;
using Microsoft.AspNetCore.Authorization;

namespace Hospital.Controllers
{
    //[Authorize(Roles = "Admin")]
    public class FeaturesController : Controller
    {
        readonly IFeatureService _featureService;
        public FeaturesController(IFeatureService featureService)
        {
            _featureService = featureService;

        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AddFeature()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> NewFeature(AppFeatureViewModel appFeatures)
        {
            if (!ModelState.IsValid)
            {
                return View("AddFeature", appFeatures);
            }
            appFeatures.CreatedDate = DateTime.Now;
            var model = appFeatures.ConvertToAppFeatures(appFeatures);
            
            await _featureService.AddNewfeature(model);
            return RedirectToAction("FeaturesList", "Admin");
        }
        public JsonResult FeatureActivateDecativate(long Id, bool status)
        {
            var result = _featureService.FeatureActivateDecativate(Id, status);
            if (result != null)
            {
                return Json(result);
            }
            else
            {
                return Json(null);
            }
        }

        public IActionResult EditFeature(string id)
        {
            int featurId = Convert.ToInt32(EncryptDecrypt.Decode(id));
            AppFeatureViewModel appFeatures = new AppFeatureViewModel();
            var model = _featureService.GetFeatureDeatilByID(featurId).FirstOrDefault();
            if (model != null)
            {
                appFeatures.FeatureName = model.FeatureName;
                appFeatures.Description = model.Description;
                appFeatures.CreatedDate = model.CreatedDate;
                appFeatures.Id = model.Id;
                appFeatures.IsActive = model.IsActive;
            }
            return View(appFeatures);
        }

        [HttpPost]
        public async Task<IActionResult> EditFeature(AppFeatureViewModel appFeatures)
        {
            if (!ModelState.IsValid)
            {
                return View(appFeatures);
            }
            var ConvertModel = appFeatures.ConvertToAppFeatures(appFeatures);
            ConvertModel.ModifiedDate = DateTime.UtcNow;
            var model =  await _featureService.GetFeatureDeatilByID(ConvertModel);

            if (appFeatures == null)
            {
                return RedirectToAction("EditFeature", "Features", new { id = EncryptDecrypt.Encode(model.Id.ToString()) });
            }
            return RedirectToAction("FeaturesList", "Admin");
        }
        public async Task<IActionResult> DeleteFeature(string id)
        {
            int featurId = Convert.ToInt32(EncryptDecrypt.Decode(id));
            AppFeatures appFeatures = new AppFeatures();
            appFeatures = await _featureService.DeleteFeatureByID(featurId);
            return RedirectToAction("FeaturesList", "Admin");
        }
    }
}