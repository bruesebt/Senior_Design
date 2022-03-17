using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WhatsTheMove.Data.Models;

namespace WhatsTheMove.Web.API
{
    public class PlacesApiResultsRoot
    {
        public List<object> Html_Attributions { get; set; }
        public List<Activity> Results { get; set; }
        public string Status { get; set; }
    }
}
