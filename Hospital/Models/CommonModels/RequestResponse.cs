using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital.Models.CommonModels
{
    public class RequestResponse
    {
        public bool Status { get; set; }
        public string Message { get; set; }
        public dynamic  Data { get; set; }
    }
}
