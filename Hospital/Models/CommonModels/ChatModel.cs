using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hospital.Models.CommonModels
{
    public class ChatModel
    {
        [Key]
        public int Id { set; get; }
        public string SenderId { set; get; }
        public string ReciverId { set; get; }
        public string Message { set; get; }
        public DateTime MessageDate { set; get; }
        public bool IsDelete { set; get; }
        public bool IsRead { set; get; }
    }
}
