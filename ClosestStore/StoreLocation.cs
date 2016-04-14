using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClosestStore
{

    //Creating StoreLocation Object that has 3 fields: Store #, Latitude and Longitude

    public class StoreLocation : Point
    {
        public int StoreNumber { get; set; }
       

        public StoreLocation(int storenum, double lat, double lon) : base (lat, lon)
        {
            this.StoreNumber = storenum;
        }

        public StoreLocation(decimal storenum, decimal latitude, decimal longitude) :
            this(Convert.ToInt32(storenum), (double)latitude, (double)longitude)
        { }

    }
}
    