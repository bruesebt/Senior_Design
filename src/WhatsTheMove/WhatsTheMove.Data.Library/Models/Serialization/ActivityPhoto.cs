using System;
using System.Collections.Generic;
using System.Text;

namespace WhatsTheMove.Data.Models
{
    public class ActivityPhoto
    {
        public int Height { get; set; }
        public List<string> Html_Attributions { get; set; }
        public string Photo_Reference { get; set; }
        public int Width { get; set; }
    }
}
