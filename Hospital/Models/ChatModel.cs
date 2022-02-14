using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital.Models
{
    public class ChatMessages
    {
        [Key]
        public int Id { get; set; }
        public string SenderID { get; set; }
        public string RecieverID { get; set; }
        public string Message { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public string Day { get; set; }
    }
}
