using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhatsTheMove.Data.Library.Models;

namespace WhatsTheMove.Data.Library
{
    public static class DummyData {
        public static IEnumerable<User> TestUsers = new User[] {
                                                new User() {
                                                    ID = 1,
                                                    Username = "cargilch",
                                                    Email="cargilch@mail.uc.edu",
                                                    Birthdate=new DateTime(year:1998, month:11, day:1),
                                                    FirstName = "Caleb",
                                                    LastName = "Cargill",
                                                    Gender="Male",
                                                    PasswordHashed="1234abcd4321dcba",
                                                    Salt="insert-valid-salt"
                                                },
                                                new User() {
                                                    ID = 2,
                                                    Username = "lemonjl",
                                                    Email="lemonjl@mail.uc.edu",
                                                    Birthdate=new DateTime(year:2008, month:7, day:20),
                                                    FirstName = "John",
                                                    LastName = "Lemon",
                                                    Gender="Male",
                                                    PasswordHashed="1234abcd4321dcba",
                                                    Salt="insert-valid-salt"
                                                },
                                                new User() {
                                                    ID = 3,
                                                    Username = "brusewbl",
                                                    Email="bruesebl@mail.uc.edu",
                                                    Birthdate=new DateTime(year:1998, month:4, day:20),
                                                    FirstName = "Brad",
                                                    LastName = "Bruesewitz",
                                                    Gender="Male",
                                                    PasswordHashed="1234abcd4321dcba",
                                                    Salt="insert-valid-salt"
                                                },
                                                new User() {
                                                    ID = 4,
                                                    Username = "dumfornj",
                                                    Email="dumfornj@mail.uc.edu",
                                                    Birthdate=new DateTime(year:1950, month:12, day:1),
                                                    FirstName = "Nate",
                                                    LastName = "Dumford",
                                                    Gender="Male",
                                                    PasswordHashed="1234abcd4321dcba",
                                                    Salt="insert-valid-salt"
                                                }
                                            };
    }

}
