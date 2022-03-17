using System;
using System.Collections.Generic;
using System.Text;

namespace WhatsTheMove.Data.Models
{
    public class AddressInfo
    {
        public List<AddressComponent> Address_Components { get; set; }
        public string Formatted_Address { get; set; }
        public ActivityGeometry Geometry { get; set; }
        public string Place_Id { get; set; }
        public List<string> Postcode_Localities { get; set; }
        public List<string> Types { get; set; }
    }
}
