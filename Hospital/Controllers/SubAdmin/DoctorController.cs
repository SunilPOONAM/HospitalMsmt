//using Grpc.Core;
using Hospital.CollectionViewModel;
using Hospital.Models;
using Hospital.Models.AccountViewModels;
using Hospital.Models.CommonModels;
using Hospital.Models.SubAdmin;
using Hospital.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using static Hospital.Models.CommonModels.ChatViewModel;

namespace Hospital.Controllers.SubAdmin
{
    [Authorize(Roles = "Doctor")]
    public class DoctorController : Controller
    {
        private readonly HMSContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        public DoctorController(HMSContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public ActionResult Index()
        {
            var doc = _context.Users.Where(c => c.Id == _userManager.GetUserId(HttpContext.User)).FirstOrDefault();
            ViewBag.doctorLists = _context.Users.Where(c => c.HospitalID == doc.HospitalID && c.Role == "Doctor").ToList();
            ViewBag.nurseLists = _context.Users.Where(c => c.HospitalID == doc.HospitalID && c.Role == "Nurse").ToList();
            var date = DateTime.Now.Date;
            var model = new CollectionOfAll
            {

                //Departments = _context.Departments.ToList(),
                //Doctors = _context.Doctor.ToList(),
                Patients = _context.Patients.Where(c => c.HospitalID == doc.HospitalID).ToList(),
                Appointments = _context.Appointments.Where(c => c.HospitalID == doc.HospitalID).ToList(),
                Schedules = _context.Schedules.Where(c => c.HospitalID == doc.HospitalID).ToList(),
                //Nurses = _context.Nurses.ToList(),
                Allotments = _context.Allotments.ToList(),
                Department = _context.Departments.ToList()

            };
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> PatientList()
        {
            //var data = _context.Appointments.Where(c => c.DoctorID == _userManager.GetUserId(HttpContext.User)).ToListAsync();

            //for (int i = 0; i < data.Result.Count; i++)
            //{
            //    return View(await _context.Patients.Where(c => c.PatientID == data.Id).ToListAsync());
            //    return View(await _context.Patients.Where(c => c.PatientID == data.Id).ToListAsync());
            //}
            //return View();
            var doc = _context.Users.Where(c => c.Id == _userManager.GetUserId(HttpContext.User)).FirstOrDefault();
            return View(await _context.Patients.Where(c => c.HospitalID == doc.HospitalID).ToListAsync());
            //return View(await _context.Appointments.Where(c => c.DoctorID == _userManager.GetUserId(HttpContext.User)).ToListAsync());
        }

        [HttpPost]
        public async Task<IActionResult> PatientLit()
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
            IEnumerable<Patients> stateList = _context.Patients.Where(x => x.HospitalID.Equals(_user.HospitalID) && x.DoctorId.Equals(_user.Id)).ToList();
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

        [HttpGet]
        public async Task<IActionResult> AddPrescription(int patientId)
        {
            PatientPrescriptionModel model = new PatientPrescriptionModel();
            var _user = await _userManager.FindByNameAsync(this.User.Identity.Name);
            if (_user != null)
            {
                model = _context.Patients.Where(x => x.Id == patientId).Select(x => new PatientPrescriptionModel()
                {
                    Id = x.Id,
                    doctorId = x.DoctorId,
                    hospitalId = x.HospitalID,
                    DoctorName = _user.FirstName + " " + _user.LastName,
                    patientId = patientId,
                    PatientName = x.PatientName
                }).FirstOrDefault();
                TempData["patientId"] = patientId;
            }
            return View(model);
        }
        //[HttpPost]
        //public async Task<RequestResponse> AddPrescription(PatientPrescriptionModel model)
        //{
        //    RequestResponse response = new RequestResponse();
        //    if (ModelState.IsValid)
        //    {

        //        PatientPrescription prescription = new PatientPrescription()
        //        {
        //            doctorId = model.doctorId,
        //            patientId = model.patientId,
        //            prescription = model.prescription,
        //            isRead = false,
        //            createdDate = DateTime.UtcNow.ToString(),
        //            HospitalId = model.hospitallId
        //        };
        //        await _context.PatientPrescriptions.AddAsync(prescription);
        //        await _context.SaveChangesAsync();
        //        response.Status = true;
        //    }
        //    return response;
        //}

        //[HttpPost]
        //public async Task<RequestResponse> UpdatePrescription(PatientPrescriptionModel model)
        //{
        //    RequestResponse response = new RequestResponse();
        //    if (ModelState.IsValid)
        //    {
        //        var Obj = _context.PatientPrescriptions.Where(x => x.Id == model.Id).FirstOrDefault();
        //        if (Obj != null)
        //        {
        //            Obj.doctorId = model.doctorId;
        //            Obj.patientId = model.patientId;
        //            Obj.prescription = model.prescription;
        //            Obj.isRead = false;
        //            Obj.hospitallId = model.hospitallId;
        //        }
        //        TempData["patientId"] = model.patientId;
        //        _context.PatientPrescriptions.Update(Obj);
        //        await _context.SaveChangesAsync();
        //        response.Status = true;
        //    }
        //    return response;
        //}
        //[HttpPost]
        //public async Task<IActionResult> PrescriptionList()
        //{
        //    string draw = Request.Form["draw"];
        //    string order = Request.Form["order[0][column]"];
        //    string orderDir = Request.Form["order[0][dir]"];
        //    int startRec = Convert.ToInt32(Request.Form["start"]);
        //    int pageSize = Convert.ToInt32(Request.Form["length"]);
        //    string featurename = Request.Form["columns[0][search][value]"];
        //    string createddate = Request.Form["columns[2][search][value]"];
        //    string modifieddate = Request.Form["columns[3][search][value]"];
        //    string searchTerm = Request.Form["search[value]"];
        //    int patientId = TempData["patientId"] != null ? Convert.ToInt32(TempData["patientId"]) : 0;
        //    var _user = await _userManager.FindByNameAsync(this.User.Identity.Name);
        //    IEnumerable<PatientPrescriptionModel> list = (from pr in _context.PatientPrescriptions
        //                                                  join pt in _context.Patients on pr.patientId equals pt.Id
        //                                                  where (pr.doctorId.Equals(_user.Id) && pr.HospitalId.Equals(_user.HospitalID) && pr.patientId == patientId)
        //                                                  select new PatientPrescriptionModel()
        //                                                  {
        //                                                      Id = pr.Id,
        //                                                      patientId = pr.patientId,
        //                                                      doctorId = pr.doctorId,
        //                                                      createdDate = pr.createdDate,
        //                                                      hospitallId = pr.HospitalId,
        //                                                      isRead = pr.isRead,
        //                                                      PatientName = pt.PatientName,
        //                                                      prescription = pr.ChiefComplain
        //                                                  }).ToList();
        //    long TotalRecordsCount = list.Count();

        //    #region filters   
        //    if (!string.IsNullOrEmpty(searchTerm) && !string.IsNullOrWhiteSpace(searchTerm))
        //    {
        //        list = list.Where(x =>
        //            x.PatientName != null && x.PatientName.ToLower().Contains(searchTerm.ToLower()) || x.prescription != null && x.prescription.ToLower().Contains(searchTerm.ToLower()));
        //    }
        //    #endregion


        //    //count of record after filter   
        //    long FilteredRecordCount = list.Count();

        //    #region Sorting  

        //    // Sorting     
        //    switch (order)
        //    {
        //        case "0":
        //            list = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? list.OrderByDescending(p => p.PatientName) : list.OrderBy(p => p.PatientName);
        //            break;
        //        default:
        //            list = list.OrderByDescending(p => p.Id);
        //            break;
        //    }
        //    #endregion

        //    var listfeatures = list.Skip(startRec).Take(pageSize).ToList();
        //    return Json(new
        //    {
        //        draw = Convert.ToInt32(draw),
        //        recordsTotal = TotalRecordsCount,
        //        recordsFiltered = FilteredRecordCount,
        //        data = listfeatures
        //    });
        //}

        public async Task<IActionResult> PatientDetails(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patients = await _context.Patients
                .FirstOrDefaultAsync(m => m.Id == id);
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


        // GET: Schedules/Create
        public IActionResult AddSchedule()
        {
            return View();
        }

        // POST: Schedules/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddSchedule([Bind("Id,Doctor,DoctorId,AvailableStartDay,AvailableEndDay,AvailableStartTime,AvailableEndTime,TimePerPatient,Status")] Schedule schedule)
        {
            if (ModelState.IsValid)
            {
                _context.Add(schedule);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(ScheduleList));
            }
            return View(schedule);
        }


        //Get :Schedule
        public async Task<IActionResult> ScheduleList()
        {
            return View(await _context.Schedules.ToListAsync());
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
        public async Task<IActionResult> EditSchedule(int id, [Bind("Id,Doctor,DoctorId,AvailableStartDay,AvailableEndDay,AvailableStartTime,AvailableEndTime,TimePerPatient,Status")] Schedule schedule)
        {
            if (id != schedule.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
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
        public async Task<IActionResult> OnPostDelete(int id)
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


        // GET: Appointments
        public async Task<IActionResult> AppointmentList()
        {
            return View(await _context.Appointments.Where(c => c.DoctorID == _userManager.GetUserId(HttpContext.User)).ToListAsync());
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
        public IActionResult AddAppointment()
        {
            return View();
        }

        // POST: Appointments/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddAppointment([Bind("AppointmentId,PatientId,DoctorName,Department,TokenNumber,Problem,AppointmentDate,TimeSlot,AppointmentStatus")] Appointments appointments)
        {
            if (ModelState.IsValid)
            {
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
        public async Task<IActionResult> EditAppointment(int id, [Bind("AppointmentId,PatientId,DoctorName,Department,TokenNumber,Problem,AppointmentDate,TimeSlot,AppointmentStatus")] Appointments appointments)
        {
            if (id != appointments.AppointmentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
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
        [HttpGet]
        public IActionResult UnderContraction()
        {
            return View();
        }

        //public async Task<IActionResult> Chat()
        //{
        //    //ViewBag.AllMembers = _context.ApplicationUser.Where(a => a.Id == HttpContext.Session.GetString("CurrentHospitalId") || a.HospitalID== HttpContext.Session.GetString("CurrentHospitalId")).ToList();
        //    ViewBag.AllMembers = (from c in _context.ApplicationUser
        //                          join r in _context.UserRoles on c.Id equals r.UserId
        //                          where c.HospitalID == HttpContext.Session.GetString("CurrentHospitalId") || c.Id == HttpContext.Session.GetString("CurrentHospitalId")
        //                          join R in _context.Roles on r.RoleId equals R.Id
        //                          where R.Name != "StaffMember" && R.Name != "Doctor"
        //                          select  c ).ToList();
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
            return PartialView("_DoctorChatPartial", chatViewModels);
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

        public IActionResult AddPrescriptions(int id)
        {
            
                var data = _context.Patients.Where(c => c.Id == id).FirstOrDefault();
                ViewBag.PatientDetail = data;

                ViewBag.appointmentID = "AP" + data.PatientID;
                ViewBag.Date = DateTime.Now.ToString("dd-MM-yyyy");
                ViewBag.HospitalName = _context.Users.Where(c => c.Id == data.HospitalID).FirstOrDefault();
                ViewBag.HospitalID = data.HospitalID;
                
           
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
                medicin.DoctorId_Or_NurseId = _userManager.GetUserId(HttpContext.User);
                medicin.CreatedDate = DateTime.Now.ToString("dd-MM-yyyy");
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

            return RedirectToAction(nameof(PatientList));
            //return View("PatientList");
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

            model.prescription = _context.PatientPrescriptions.Where(p=>p.Id== id && p.doctorId == _userManager.GetUserId(HttpContext.User)).ToList();
            model.medicin = _context.PrescribedMedicin.ToList();
            model.diagnosis = _context.PrescribedDiagnosis.ToList();
          
            return View(model);
        }
        public IActionResult Assign_Bed()
        {
            return View();
        }

        public IActionResult Bed_List()
        {
            return View();
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


        public async Task<IActionResult> PatientCaseStudyList()
        {
            var data = await _context.PatientCaseStudy.Where(c => c.DoctorId_Or_NurseId == _userManager.GetUserId(HttpContext.User)).ToListAsync();
            return View(data);
        }

        //public async Task<IActionResult> PatientCaseStudyListAsync()
        //{
        //    return View(await _context.PatientCaseStudy.Where(c => c.DoctorId_Or_NurseId == _userManager.GetUserId(HttpContext.User)).ToListAsync());
        //}

        [HttpGet]
        public async Task<IActionResult> PrescriptionListAsync()
        {
            return View(await _context.PatientPrescriptions.Where(c => c.doctorId == _userManager.GetUserId(HttpContext.User)).ToListAsync());
        }

        // edit

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
            return RedirectToAction("PatientCaseStudyList", "Doctor");
        }


        public async Task<IActionResult> PatientCaseStudyListDetails(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var CaseStudy = await _context.PatientCaseStudy.FindAsync(id);
            var hospitalName = _context.Users.Where(c => c.Id == CaseStudy.HospitalId).FirstOrDefault();

            CaseStudy.Hospital_Name = hospitalName.FirstName + " " + hospitalName.LastName;

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
            if (data != null)
            {
                _context.Remove(data);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(PatientCaseStudyList));
        }

    }

}
