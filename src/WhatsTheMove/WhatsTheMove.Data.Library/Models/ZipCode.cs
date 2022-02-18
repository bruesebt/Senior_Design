using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhatsTheMove.Data.Models
{
    public class ZipCode
    {
        public int Id { get; set; }

        public string Code { get; set; }

        public bool IsDefault { get; set; }

    }
}
