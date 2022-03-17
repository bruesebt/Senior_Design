using System;
using System.Collections.Generic;
using System.Text;

namespace WhatsTheMove.Data.Models
{

    public class Activity
    {
        public string Business_Status { get; set; }
        public ActivityGeometry Geometry { get; set; }
        public string Icon { get; set; }
        public string Icon_Background_Color { get; set; }
        public string Icon_Mask_Base_Uri { get; set; }
        public string Name { get; set; }
        public OpeningHours Opening_Hours { get; set; }
        public List<ActivityPhoto> Photos { get; set; }
        public string Place_Id { get; set; }
        public ActivityCode Plus_Code { get; set; }
        public int Price_Level { get; set; }
        public double Rating { get; set; }
        public string Reference { get; set; }
        public string Scope { get; set; }
        public List<string> Types { get; set; }
        public int User_Ratings_Total { get; set; }
        public string Vicinity { get; set; }
    }

}
