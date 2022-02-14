using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital.Models
{
    public class PurchasePlans
    {
        [Key]
        public int Id { get; set; }
        public string CustomerID { get; set; }
        public string PlanID { get; set; }
        public string PurchaseDate { get; set; }
    }
}
