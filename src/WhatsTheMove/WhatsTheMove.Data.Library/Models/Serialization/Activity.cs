using System;
using System.Collections.Generic;
using System.Text;

namespace WhatsTheMove.Data.Models
{

    public class Activity
    {

        public List<AddressComponent> Address_Components { get; set; }
        public string Adr_Address { get; set; }
        public string Business_Status { get; set; }
        public string Formatted_Address { get; set; }
        public string Formatted_Phone_Number { get; set; }
        public ActivityGeometry Geometry { get; set; }
        public string Icon { get; set; }
        public string Icon_Background_Color { get; set; }
        public string Icon_Mask_Base_Uri { get; set; }
        public string International_Phone_Number { get; set; }
        public string Name { get; set; }
        public OpeningHours Opening_Hours { get; set; }
        public List<ActivityPhoto> Photos { get; set; }
        public string Place_Id { get; set; }
        public ActivityCode Plus_Code { get; set; }
        public int Price_Level { get; set; }
        public double Rating { get; set; }
        public string Reference { get; set; }
        public List<ActivityReview> Reviews { get; set; }
        public List<string> Types { get; set; }
        public string Url { get; set; }
        public int User_Ratings_Total { get; set; }
        public int Utc_Offset { get; set; }
        public string Vicinity { get; set; }
        public string Website { get; set; }
        public string showAddress { get { return string.Empty; }}
        //Address_Components[0].Long_Name + " " + Address_Components[1].Long_Name + ", " + Address_Components[2].Long_Name;
    }

}
