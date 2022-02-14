using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital.Models
{
    public class StateMaster
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Id")]
        [Required(ErrorMessage = "Field is required")]
        [Display(Name = "Country")]
        public int CountryId { get; set; }
        public virtual CountryMaster CountryMaster { get; set; }
        [Required(ErrorMessage = "Field is required")]
        [Display(Name = "State Name")]
        public string StateName { get; set; }
        public bool IsActive { get; set; }
        public IEnumerable<CountryMaster> Countries { get; set; }
        //public string Countries { get; set; }

        public StateMaster()
        {
            Countries = new List<CountryMaster>();
        }
    }
}
