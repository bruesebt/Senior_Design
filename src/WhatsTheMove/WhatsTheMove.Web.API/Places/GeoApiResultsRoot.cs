using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WhatsTheMove.Data.Models;

namespace WhatsTheMove.Web.API
{
    public class GeoApiResultsRoot
    {
        public List<AddressInfo> Results { get; set; }
        public string Status { get; set; }
    }
}
