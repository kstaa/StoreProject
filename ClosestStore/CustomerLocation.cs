using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClosestStore
{

    public class CustomerLocation : Point
    {
        public string PostalCode { get; set; }

        public CustomerLocation() 
        { 
        }

        public CustomerLocation(string zip, double lat, double lon) : base(lat, lon)
        {
            this.PostalCode = zip;
        }
    }
}
