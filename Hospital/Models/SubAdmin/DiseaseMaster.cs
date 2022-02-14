using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital.Models.SubAdmin
{
    public class DiseaseMaster
    {
        [Key]
        public int Id { get; set; }
        public string Disease { get; set; }
        public DateTime CreateDate { get; set; }
        public bool isDeleted { get; set; }
    }
}
