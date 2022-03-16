using System;
using System.Collections.Generic;
using System.Text;

namespace WhatsTheMove.Data.Models
{
    public class Activity
    {
        public string Place_Id { get; set; }

        public string Name { get; set; }

        public string Business_Status { get; set; }

        public ActivityGeometry Geometry { get; set; }

        public string Icon { get; set; }

        public IEnumerable<ActivityPhoto> Photos { get; set; }

        public ActivityHours Opening_Hours { get; set; }

        public int Price_Level { get; set; }

        public double Rating { get; set; }

        public int User_Ratings_Total { get; set; }

        public IEnumerable<string> Types { get; set; }

    }
}
