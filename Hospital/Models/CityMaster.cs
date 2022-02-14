using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital.Models
{
    public class CityMaster
    {
        [Key]
        public int Id { get; set; } 
        [ForeignKey("Id")]
        [Required(ErrorMessage ="Field is required")]
        [Display(Name ="State")]
        public int CountryId { get; set; }
        public int StateId { get; set; }
        public virtual StateMaster StateMaster { get; set; }
        [Required(ErrorMessage ="Field is required")]
        [Display(Name ="City Name")]
        public string CityName { get; set; }
        public bool IsActive { get; set; }
        public IEnumerable<StateMaster> States { get; set; }
        public CityMaster()
        {
            States = new List<StateMaster>();
        }
    }
}
