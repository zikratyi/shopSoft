using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shopSoft
{
    [Serializable]
    class Person
    {
        public string lastName { set; get; }
        public string firstName { set; get; }
        public string phone { set; get; }
        public string email { set; get; }
        public Person(string lastName, string firstName, string phone, string email)
        {
            this.lastName = lastName;
            this.firstName = firstName;
            this.phone = phone;
            this.email = email;
        }
    }
}
