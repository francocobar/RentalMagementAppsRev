using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentalManagementApps.Models
{
    public class ResponseData
    {
        public bool status { get; set; }
        public string message { get; set; }
        public string next_page { get; set; }
        public bool need_reload { get; set; }
    }
}
