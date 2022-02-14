using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
//using System.Web.Mvc;

namespace Hospital.Models.SubAdmin
{
    public class PatientDocuments

    {
        [Key]
        public int Id { get; set; }
        public string HospitalID { get; set; }

        public string DoctorID { get; set; }

        public string PatientID { get; set; }
        [NotMapped]
        public string UploadFile { get; set; }
        [DataType(DataType.Upload)]
        public string AttachFile { get; set; }
        

        public string Description { get; set; }

        public string CreatedDate { get; set; }
    }
         
 }
