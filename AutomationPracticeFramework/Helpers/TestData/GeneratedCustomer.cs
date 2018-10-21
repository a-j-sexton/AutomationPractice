using System;
using System.Collections.Generic;
using System.Linq;

namespace AudenAutomation.Helpers.TestData
{
    public class GeneratedCustomer
    {
        public GeneratedCustomer() { } 

        private readonly List<string> firstNames = new List<String>()
        {
            "Rose",
            "Dandelion",
            "Orchid",
            "Buddleia",
            "Iris",
            "Daffodil",
            "Tulip",
            "Snowdrop",
            "Bluebell",
            "Crocus",
            "Cactus",
            "Oak",
            "Palm",
            "Birch",
            "Ash",
            "Elm",
            "Rowan",
            "Chesnut",
            "Sycamore",
            "Hawthorne",
            "Larch",
            "Azalea",
        };

        private readonly List<string> surnames = new List<String>()
        {
            "Hammer",
            "Spade",
            "Spanner",
            "Rake",
            "Trowel",
            "Chainsaw",
            "Screwdriver",
            "Plain",
            "Blue",
            "Red",
            "Orange",
            "Greeen",
            "White",
            "Black",
            "Red"
        };

        private readonly List<string> domainnames = new List<String>()
        {
            "Vader",
            "Sideous",
            "Tyranus",
            "Maul",
            "Kenobi",
            "Skywalker",
            "Targaryn",
            "Snow",
            "Stark",
            "Oberon",
            "Lannister",
            "Flowers",
            "Wayne",
            "Parker",
            "Brock"
        };

        private string _firstname;
        private string _surname;
        private string _domainname;
        private string _email;
        private string _password;
        private string _dob;

        public string firstname
        {
            get
            {
                if (_firstname == null)
                {
                    Random r = new Random();
                    int index = r.Next(firstNames.Count);
                    _firstname = firstNames[index];
                }
                return _firstname;
            }

            set
            {
                _firstname = value; 
            }
        }
        public string surname
        {
            get
            {
                if (_surname == null)
                {
                    Random r = new Random();
                    int index = r.Next(surnames.Count);
                    _surname = surnames[index];
                }
                return _surname;
            }
            set { _surname = value; }
        }

        public string domainname
        {
            get
            {
                if (_domainname == null)
                {
                    Random r = new Random();
                    int index = r.Next(domainnames.Count);
                    _domainname = domainnames[index];
                }
                return _domainname;
            }

            set { _domainname = value; }
        }

        public string email
        {
            get
            {
                if (_email == null)
                {
                    _email = firstname + surname + RandomString(3) + "@" + domainname + ".com";
                }
                return _email;
            }

            set { _email = value; }
        }

        public string password
        {
            get
            {
                if(_password == null)
                {
                    _password = RandomString(10);
                }
                return _password;

            }

            set { _password = value; }
        }

        public string dob
        {
            get
            {
                if(_dob == null)
                {
                    _dob = RandomDay().ToString("dd/MM/yyyy");
                }

                return _dob;
            }

            set
            {
                _dob = value;
            }
        }


        private static Random random = new Random();
        private static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        private static DateTime RandomDay()
        {
            DateTime start = new DateTime(1950, 1, 1);
            int range = (DateTime.Now.AddYears(-18) - start).Days;
            return start.AddDays(random.Next(range));
        }
    }
}
