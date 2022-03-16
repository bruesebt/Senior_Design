using System;
using System.Collections.Generic;
using System.Text;

namespace WhatsTheMove.Data.Models
{
    public class SavedActivity
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public int PreferenceId { get; set; }

        public string Place_Id { get; set; }

        public string Name { get; set; }

        public DateTime DateAdded { get; set; }

        public int? Rating { get; set; }

    }
}
