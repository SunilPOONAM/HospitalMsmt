using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital.Models.SubAdmin
{
    public class Records
    {
        public int  PatientID { get; set; }
        public string  PatientType { get; set; }
        public string  PatientName { get; set; }
        public string Gender  { get; set; }
        public string DOB { get; set; }
        public string PhoneNo { get; set; }
        public string  Email { get; set; }
        public string Occupation { get; set; }
        public string  Country{ get; set; }
        public string Nationality { get; set; }
        public string Address { get; set; }
        public string Status { get; set; }
        public string PaymentType { get; set; }
        public string PaymentMethod { get; set; }
        public string  InsuranceDetails { get; set; }
        public string InsuranceLimit { get; set; }



    }
}
