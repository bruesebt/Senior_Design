using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhatsTheMove.Data.Library.Models
{
    public class User
    {
        public int ID { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }

        public string PasswordHashed { get; set; }

        public string Salt { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime Birthdate { get; set; }

        public string Gender { get; set; }

    }
}
