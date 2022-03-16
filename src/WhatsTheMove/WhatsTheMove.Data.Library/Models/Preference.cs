using System;
using System.Collections.Generic;
using System.Text;

namespace WhatsTheMove.Data.Models
{
    public class Preference
    {

        public int Id { get; set; }

        public int UserId { get; set; }
        
        public int GroupSize { get; set; }

        public bool IsFoodRequested { get; set; }

        public bool IsDrinksRequested { get; set; }

        public int EnergyLevel { get; set; }

        public int Budget { get; set; }

        public int TimeOfDay { get; set; }

        public int DressCode { get; set; }
       
    }
}
