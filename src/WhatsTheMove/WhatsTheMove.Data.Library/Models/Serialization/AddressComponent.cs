using System;
using System.Collections.Generic;
using System.Text;

namespace WhatsTheMove.Data.Models
{
    public class AddressComponent
    {
        public string Long_Name { get; set; }
        public string Short_Name { get; set; }
        public List<string> Types { get; set; }
    }
}
