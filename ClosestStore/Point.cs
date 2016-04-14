
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClosestStore
{
    public class Point
    {
        public double Latitude { get; private set; }
        public double Longitude { get; private set; }

        public Point()
        {       
        }

        public Point(double lat, double lon)
        {
            Latitude = lat;
            Longitude = lon;
        }

    } 
}