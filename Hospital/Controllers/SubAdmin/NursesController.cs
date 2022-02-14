using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Hospital.Models;
using Hospital.Models.SubAdmin;
using Hospital.CollectionViewModel;
using Microsoft.AspNetCore.Authorization;
using Hospital.Models.CommonModels;
using static Hospital.Models.CommonModels.ChatViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using Hospital.ViewModels;
using Hospital.Models.AccountViewModels;

namespace Hospital.Controllers.SubAdmin
{
    [Authorize(Roles = "Nurse")]
    public class NursesController : Controller
    {
        private readonly HMSContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public NursesController(HMSContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IActionResult Index()
        {

            var nurs = _context.Users.Where(c => c.Id == _userManager.GetUserId(HttpContext.User)).FirstOrDefault();
            ViewBag.nursLists = _context.Users.Where(c => c.HospitalID == nurs.HospitalID && c.Role == "Nurse").ToList();
            ViewBag.docLists = _context.Users.Where(c => c.HospitalID == nurs.HospitalID && c.Role == "Doctor").ToList();
            var date = DateTime.Now.Date;
            var model = new CollectionOfAll
            {
                //Departments = _context.Departments.Where(c => c.HospitalID == nurs.HospitalID).ToList(),
                //Doctors = _context.Users.ToList(),
                Patients = _context.Patients.Where(c => c.HospitalID == nurs.HospitalID).ToList(),
                Appointments = _context.Appointments.Where(c => c.HospitalID == nurs.HospitalID).ToList(),
                Department = _context.Departments.Where(c => c.HospitalID == nurs.HospitalID).ToList(),
                Schedules = _context.Schedules.Where(c => c.HospitalID == nurs.HospitalID).ToList(),
                Allotments = _context.Allotments.ToList(),
                //Nurses=_context.Users.ToList()

               
            };
            return View(model);
        }


        // GET: Nurses
        public async Task<IActionResult> NurseList()
        {
            var nurs = _context.Users.Where(c => c.Id == _userManager.GetUserId(HttpContext.User)).FirstOrDefault();
            ViewBag.ListOfNurses = _context.Users.Where(c => c.HospitalID == nurs.HospitalID && c.Role == "Nurse").ToList();
            //var hMSContext = _context.Nurses.Include(n => n.ApplicationUser);
            //return View(await hMSContext.ToListAsync());
            return View();
        }

        // GET: Nurses/Details/5
        public async Task<IActionResult> NurseDetails(string id)
        {
            
            if (id == null)
            {
                return NotFound();
            }

            var data = await _context.Users.FirstOrDefaultAsync(m => m.Id == id);
            if (data == null)
            {
                return NotFound();
            }

            ViewBag.nurseDetail = data;

            return View();
        }

        // GET: Nurses/Create
        //public IActionResult AddNurse()
        //{
        //    ViewData["ApplicationUserId"] = new SelectList(_context.Users, "Id", "Id");
        //    return View();
        //}

        // POST: Nurses/Create
        
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> AddNurse([Bind("Id,ApplicationUserId,FullName,EmailAddress,Address,MobileNo,Gender,BloodGroup,DateOfBirth,Status")] Nurse nurse)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(nurse);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(NurseList));
        //    }
        //    ViewData["ApplicationUserId"] = new SelectList(_context.Users, "Id", "Id", nurse.ApplicationUserId);
        //    return View(nurse);
        //}

        // GET: Nurses/Edit/5
        //public async Task<IActionResult> EditNurse(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var nurse = await _context.Nurses.FindAsync(id);
        //    if (nurse == null)
        //    {
        //        return NotFound();
        //    }
        //    ViewData["ApplicationUserId"] = new SelectList(_context.Users, "Id", "Id", nurse.ApplicationUserId);
        //    return View(nurse);
        //}

        // POST: Nurses/Edit/5
        
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> EditNurse(int id, [Bind("Id,ApplicationUserId,FullName,EmailAddress,Address,MobileNo,Gender,BloodGroup,DateOfBirth,Status")] Nurse nurse)
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

        //Nurse Delete 
        public async Task<IActionResult> NurseDelete(string id)
        {
            var data = await _context.Users.FindAsync(id);
            if (data == null)
            {
                return NotFound();

            }
            _context.Users.Remove(data);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(NurseList));
        }

        private bool NurseExists(int id)
        {
            return _context.Nurses.Any(e => e.Id == id);
        }

        //Patient List
        // GET: Patients
        public async Task<IActionResult> PatientList()
        {
            var nurs = _context.Users.Where(c => c.Id == _userManager.GetUserId(HttpContext.User)).FirstOrDefault();
            return View(await _context.Patients.Where(c => c.HospitalID == nurs.HospitalID).ToListAsync());
        }
        // GET: Patients/Details/5

        public async Task<IActionResult> PatientDetails(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patients = await _context.Patients
                .FirstOrDefaultAsync(m => m.PatientID == id);
            if (patients == null)
            {
                return NotFound();
            }

            return View(patients);
        }

        public async Task<IActionResult> PatientDelete(int id)
        {
            var book = await _context.Patients.FindAsync(id);
            if (book == null)
            {
                return NotFound();

            }
            _context.Patients.Remove(book);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(PatientList));
        }


        private bool PatientsExists(int id)
        {
            return _context.Patients.Any(e => e.PatientID == id);
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

        // GET: Allotments/Create
        public IActionResult AddAllotment()
        {
            return View();
        }

        // POST: Allotments/Create
    
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddAllotment([Bind("AllotmentId,Room,RoomType,PatientName,AllotmentDate,DischargeDate,DoctorName,Status")] Allotment allotment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(allotment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(AllotmentList));
            }
            return View(allotment);
        }

        // GET: Allotments/Edit/5
        public async Task<IActionResult> EditAllotment(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var allotment = await _context.Allotments.FindAsync(id);
            if (allotment == null)
            {
                return NotFound();
            }
            return View(allotment);
        }

        

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
        //Department
        // GET: Departments
        public async Task<IActionResult> DepartmentList()
        {
            return View(await _context.Departments.ToListAsync());
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
        //public async Task<IActionResult> Chat()
        //{
        //    // ViewBag.AllMembers = _context.ApplicationUser.Where(a => a.Id == HttpContext.Session.GetString("CurrentHospitalId")).ToList();
        //    ViewBag.AllMembers = (from c in _context.ApplicationUser
        //                          join r in _context.UserRoles on c.Id equals r.UserId
        //                          where c.HospitalID == HttpContext.Session.GetString("CurrentHospitalId") || c.Id == HttpContext.Session.GetString("CurrentHospitalId")
        //                          join R in _context.Roles on r.RoleId equals R.Id
        //                          where R.Name != "StaffMember" && R.Name != "Nurse"
        //                          select c).ToList();
        //    return View();
        //}

        public IActionResult Chat()
        {
            var data = _context.Users.Where(c => c.Id == _userManager.GetUserId(HttpContext.User)).FirstOrDefault();
            ViewBag.AllChatMembers = _context.Users.Where(c => c.HospitalID == data.HospitalID || c.Id == data.HospitalID).ToList();
            ViewBag.loginId = _userManager.GetUserId(HttpContext.User);
            return View();
        }

        public JsonResult SelectedUserChat(string Id)
        {
            ResponseViewModel responsemodel = new ResponseViewModel();
            var logusr = _userManager.GetUserId(HttpContext.User);
            var result = _context.Users.Where(c => c.Id == Id).FirstOrDefault();
            var chats = _context.ChatMessages.Where(c => (c.SenderID == logusr && c.RecieverID == Id) || (c.SenderID == Id && c.RecieverID == logusr)).ToList();
            responsemodel.Data = result;
            responsemodel.Chat = chats;
            responsemodel.loginId = _userManager.GetUserId(HttpContext.User);

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
            return PartialView("_NurseChatPartial", chatViewModels);
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

        public async Task<IActionResult> AddPrescriptions(int? id)
        {
            var data = _context.Patients.Where(c => c.Id == id).FirstOrDefault();
            ViewBag.PatientDetail = data;
            
            ViewBag.appointmentID = "AP" + data.PatientID;
            ViewBag.Date = DateTime.Now.ToString("dd-MM-yyyy");
            ViewBag.HospitalName = _context.Users.Where(c => c.Id == data.HospitalID).FirstOrDefault();

            return View();

        }


        [HttpPost]
        public IActionResult AddPrescriptions(PrescriptionViewModel model)
        {
            PatientPrescription prescription = new PatientPrescription();

            prescription.patientId = model.patientId;
            prescription.doctorId = _userManager.GetUserId(HttpContext.User);
            prescription.HospitalId = model.HospitalId;
            prescription.ChiefComplain = model.ChiefComplain;
            prescription.VisitingFees = model.VisitingFees;
            prescription.PatientNotes = model.PatientNotes;
            prescription.Reference = model.Reference;
            prescription.createdDate = DateTime.Now.ToString("dd-MM-yyyy");
            _context.PatientPrescriptions.Add(prescription);
          
            PrescribedMedicin medicin;
            for (int i = 0; i < model.Day.Length; i++)
            {
                medicin = new PrescribedMedicin();
                medicin.patientId = model.patientId;
                medicin.CreatedDate = DateTime.Now.ToString("dd-MM-yyyy");
                medicin.DoctorId_Or_NurseId = _userManager.GetUserId(HttpContext.User);
                medicin.HospitalId = model.HospitalId;
                medicin.Day = model.Day[i].ToString();
                medicin.MedicineName = model.MedicineName[i].ToString();
                medicin.MedicineType = model.MedicineType[i].ToString();
                medicin.Instruction = model.MedicinInstruction[i].ToString();
                _context.PrescribedMedicin.Add(medicin);
            }

            PrescribedDiagnosis predignosis;
            for (int j = 0; j < model.Diagnosis.Length; j++)
            {
                predignosis = new PrescribedDiagnosis();
                predignosis.HospitalId = model.HospitalId;
                predignosis.patientId = model.patientId;
                predignosis.DoctorId_Or_NurseId = _userManager.GetUserId(HttpContext.User);
                predignosis.Diagnosis = model.Diagnosis[j].ToString();
                predignosis.Instruction = model.DignosisInstruction[j].ToString();
                _context.PrescribedDiagnosis.Add(predignosis);
            }

             _context.SaveChanges();
            //ViewBag.isSuccess = true;
            return RedirectToAction("PrescriptionList","Nurses");
            //return View();
        }

        [HttpGet]
        public async Task<IActionResult> PrescriptionListAsync()
        {
            return View(await _context.PatientPrescriptions.Where(c => c.doctorId == _userManager.GetUserId(HttpContext.User)).ToListAsync());
        }

        public async Task<IActionResult> PatientCaseStudyList()
        {
            var data = await _context.PatientCaseStudy.Where(c => c.DoctorId_Or_NurseId == _userManager.GetUserId(HttpContext.User)).ToListAsync();
           return View(data);
        }


        public IActionResult AddDocument(int Id)
        {
            var data = _context.Patients.Where(c => c.Id == Id).FirstOrDefault();
            ViewBag.patientId = data.PatientID;
            return View();
        }

        public JsonResult uploadDocument(string Description)
        {
            ResponseViewModel response = new ResponseViewModel();
            response.Status = 1;
            return Json(response);
        }

        [HttpPost]
        public IActionResult AddDocument(PatientDocuments model)
        {

            //if (model.AttachFile != null)
            //{
            //    //string path = Path.Combine(HostString.MapPath("~/UploadedFiles"), Path.GetFileName(model.UploadFile));
            //    //model.SaveAs(path);

            //    var path = Path.Combine(Server.("~/UploadedFiles"), model.UploadFile);
            //    model.UploadFile = path;
            //    model.SaveAs(path)
            //    _context.Add(model);
            //    _context.SaveChanges();
            //    file.SaveAs(path);
            //}

            model.Id = 0;
            var data = _context.Users.Where(c => c.Id == _userManager.GetUserId(HttpContext.User)).FirstOrDefault();
            model.HospitalID = data.HospitalID;
            model.CreatedDate = DateTime.Now.ToString("dd-MM-yyyy");
            model.DoctorID = _userManager.GetUserId(HttpContext.User);
            _context.Add(model);
            _context.SaveChanges();
            return View();
        }



        public IActionResult PatientPrescriptionList(int? id)
        {
            PrescriptionViewModel model = new PrescriptionViewModel();

            model.prescription = _context.PatientPrescriptions.Where(p => p.Id == id && p.doctorId == _userManager.GetUserId(HttpContext.User)).ToList();
            model.medicin = _context.PrescribedMedicin.ToList();
            model.diagnosis = _context.PrescribedDiagnosis.ToList();

            return View(model);
        }

        public IActionResult PatientCaseStudy(int? patientId)
        {
            var data = _context.Patients.Where(c => c.PatientID == patientId).FirstOrDefault();
            ViewBag.PatientID = patientId;
            ViewBag.HospitalID = data.HospitalID;
            return View();
        }

        [HttpPost]
        public IActionResult AddPatientCaseStudy(PatientCaseStudy CaseStudy)
        {
            CaseStudy.CreatedDate = DateTime.Now.ToString("dd-MM-yyyy");
            CaseStudy.DoctorId_Or_NurseId = _userManager.GetUserId(HttpContext.User);
            _context.Add(CaseStudy);
            _context.SaveChanges();
            return RedirectToAction(nameof(PatientCaseStudyList));
        }

        
        public async Task<IActionResult> EditPatientCaseStudy(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var CaseStudy = await _context.PatientCaseStudy.FindAsync(id);
            if (CaseStudy == null)
            {
                return NotFound();
            }
            // ViewData["Id"] = new SelectList(_context.PatientCaseStudy, "Id", "Id", CaseStudy.Id);
            return View(CaseStudy);
        }
        //EditPatientsCaseStudy Post Method
        [HttpPost]
        public IActionResult EditPatientCaseStudy(PatientCaseStudy patientCaseStudy)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    patientCaseStudy.DoctorId_Or_NurseId = _userManager.GetUserId(HttpContext.User);
                    _context.Update(patientCaseStudy);
                    _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    
                }

            }
            return RedirectToAction("PatientCaseStudyList", "Nurses");
        }


        public async  Task<IActionResult> PatientCaseStudyListDetails(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var CaseStudy = await _context.PatientCaseStudy.FindAsync(id);
            var hospitalName = _context.Users.Where(c => c.Id == CaseStudy.HospitalId).FirstOrDefault();

            CaseStudy.Hospital_Name = hospitalName.FirstName +" "+ hospitalName.LastName;

            var doc_nurse_name = _context.Users.Where(c => c.Id == _userManager.GetUserId(HttpContext.User)).FirstOrDefault();
            CaseStudy.Doctor_Nurse_Name = doc_nurse_name.FirstName + " " + doc_nurse_name.LastName;
            
            if (CaseStudy == null)
            {
                return NotFound();
            }
            // ViewData["Id"] = new SelectList(_context.PatientCaseStudy, "Id", "Id", CaseStudy.Id);
            return View(CaseStudy);
        }

        public async Task<IActionResult> DeletePatientCaseStudyAsync(int? id)
        {
            var data = await _context.PatientCaseStudy.FindAsync(id);
            if(data != null)
            {
                _context.Remove(data);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(PatientCaseStudyList));
        }


      
    }
}
