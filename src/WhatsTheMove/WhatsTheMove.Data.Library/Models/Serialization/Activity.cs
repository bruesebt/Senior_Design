using System;
using System.Collections.Generic;
using System.Text;

namespace WhatsTheMove.Data.Models
{

    public class Activity
    {
        //public string Business_Status { get; set; }
        //public ActivityGeometry Geometry { get; set; }
        //public string Icon { get; set; }
        //public string Icon_Background_Color { get; set; }
        //public string Icon_Mask_Base_Uri { get; set; }
        //public string Name { get; set; }
        //public OpeningHours Opening_Hours { get; set; }
        //public List<ActivityPhoto> Photos { get; set; }
        //public string Place_Id { get; set; }
        //public ActivityCode Plus_Code { get; set; }
        //public int Price_Level { get; set; }
        //public double Rating { get; set; }
        //public string Reference { get; set; }
        //public string Scope { get; set; }
        //public List<string> Types { get; set; }
        //public int User_Ratings_Total { get; set; }
        //public string Vicinity { get; set; }

        public List<AddressComponent> address_components { get; set; }
        public string adr_address { get; set; }
        public string business_status { get; set; }
        public string formatted_address { get; set; }
        public string formatted_phone_number { get; set; }
        public ActivityGeometry geometry { get; set; }
        public string icon { get; set; }
        public string icon_background_color { get; set; }
        public string icon_mask_base_uri { get; set; }
        public string international_phone_number { get; set; }
        public string name { get; set; }
        public OpeningHours opening_hours { get; set; }
        public List<ActivityPhoto> Photos { get; set; }
        public string place_id { get; set; }
        public ActivityCode plus_code { get; set; }
        public int Price_Level { get; set; }
        public double rating { get; set; }
        public string reference { get; set; }
        public List<ActivityReview> reviews { get; set; }
        public List<string> types { get; set; }
        public string url { get; set; }
        public int user_ratings_total { get; set; }
        public int utc_offset { get; set; }
        public string vicinity { get; set; }
        public string website { get; set; }
    }

}
