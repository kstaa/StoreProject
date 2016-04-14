using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClosestStore
{
    public class Customer
    {
        public string FirstName { get; set; }

        private readonly string _lastName;

        public string LastName
        {
            get { return _lastName; }
        }

        public Customer(string firstName, string lastName)
        {
            FirstName = firstName;
            _lastName = lastName;
        }
    }
}
