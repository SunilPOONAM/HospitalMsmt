using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hospital.Data;
using Hospital.DBServices.Features;
using Hospital.Helper;
using Hospital.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Controllers
{
   // [Authorize(Roles = "Admin")]
    public class FAQController : Controller
    {
        private HMSContext _context;

        readonly IManageFAQService _manageFAQService;

        public FAQController(IManageFAQService manageFAQService, HMSContext context)
        {
            _manageFAQService = manageFAQService;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddFAQ()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddFAQ(ManageFAQViewModel manageFAQ)
        {
            if (!ModelState.IsValid)
            {
                return View(manageFAQ);
            }
            manageFAQ.CreatedDate = DateTime.Now;
            var ConvertedModel = manageFAQ.ConvertToManageFAQ(manageFAQ);
            await _manageFAQService.AddFAQ(ConvertedModel);
            return RedirectToAction("FAQList", "Admin");
        }

        public IActionResult EditFAQ(string id)
        {
            int FaqId = Convert.ToInt32(EncryptDecrypt.Decode(id));
            ManageFAQViewModel ManageFaq = new ManageFAQViewModel();
            var faq = _manageFAQService.GetFAQDetailByID(FaqId).FirstOrDefault();
            if (faq != null)
            {
                ManageFaq.Question = faq.Question;
                ManageFaq.Answer = faq.Answer;
                ManageFaq.CreatedDate = faq.CreatedDate;
                ManageFaq.Id = faq.Id;
            }
            return View(ManageFaq);
        }

        [HttpPost]
        public async Task<IActionResult> EditFAQ(ManageFAQViewModel manageFAQ)
        {
            if (!ModelState.IsValid)
            {
                return View(manageFAQ);
            }
            var ConvertedModel = manageFAQ.ConvertToManageFAQ(manageFAQ);
            ManageFAQ model = new ManageFAQ();
            model = await _manageFAQService.GetFAQDetailByID(ConvertedModel);
            if (model == null)
            {
                return RedirectToAction("EditFAQ", "FAQ", new { id = EncryptDecrypt.Encode(model.Id.ToString()) });
            }
            return RedirectToAction("FAQList", "Admin");
        }
        public async Task<IActionResult> DeleteFAQ(string id)
        {
            int FaqId = Convert.ToInt32(EncryptDecrypt.Decode(id));
            ManageFAQ faq = new ManageFAQ();
            faq = await _manageFAQService.DeleteFAQByID(FaqId);
            return RedirectToAction("FAQList", "Admin");
        }




    }
}
