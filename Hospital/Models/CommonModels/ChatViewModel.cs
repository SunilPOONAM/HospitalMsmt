using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital.Models.CommonModels
{
    public class ChatViewModel
    {
        public partial class ReciverMessage
        {
            public string FirstName { get; set; }
            public string Message { get; set; }
            public DateTime MessageDate { get; set; }
            public string SelectedId { get; set; }
        }
        public partial class SenderMessage
        {
            public string FirstName { get; set; }
            public string Message { get; set; }
            public DateTime MessageDate { get; set; }
            public string SelectedId { get; set; }
        }
        public IEnumerable<ReciverMessage> ReciverMessages { get; set; }
        public IEnumerable<SenderMessage> SenderMessages { get; set; }
    }
}
