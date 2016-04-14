using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClosestStore
{
    public class DistanceCalculator
    {
       

        //Has the store provider interface
        public IStoreData StoreProv { get; set; }

        
        //Constructor
        public DistanceCalculator()
        {
        }

        
        //Get the distance calculation here
        public ClosestStoreResult GetClosestStoreDistance(Point customerLocation)
        {

           double? minDistance = null;
           // string closestStoreNum = "";
           int? closestStoreNum = null;

            foreach (StoreLocation store in StoreProv.GetStores())
            {
                double storeDist = RadiansCalculator(customerLocation.Latitude, customerLocation.Longitude, store.Latitude, store.Longitude );

                if (storeDist < minDistance || minDistance == null )
                {
                    minDistance = storeDist;
                    closestStoreNum = store.StoreNumber;
                }
            }

            if (minDistance == null)
            {
                throw new Exception("There is no store data");
            }

         
            return new ClosestStoreResult((int) closestStoreNum, (double) minDistance);
            
        }

        /// <summary>
        /// Calculates the distance between two lat-long points in miles
        /// </summary>
        /// <param name="lat1"></param>
        /// <param name="long1"></param>
        /// <param name="lat2"></param>
        /// <param name="long2"></param>
        /// <returns>Distance in Miles</returns>
        public double RadiansCalculator(double lat1, double long1, double lat2, double long2)
        {

            double RadiansLat1 = (lat1) * (Math.PI / 180.0);
            double RadiansLong1 = (long1) * (Math.PI / 180.0);
            double RadiansLat2 = (lat2) * (Math.PI / 180.0);
            double RadiansLong2 = (long2) * (Math.PI / 180.0);

            double dlon = RadiansLong2 - RadiansLong1;
            double dlat = RadiansLat2 - RadiansLat1;

            double a = Math.Pow(Math.Sin(dlat / 2.0), 2.0) + Math.Cos(RadiansLat1) * Math.Cos(RadiansLat2) * Math.Pow(Math.Sin(dlon / 2.0), 2.0);
            double c = 2.0 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1.0 - a));
            double d = 6367 * c;
            double distance = d / 1.609;

            return distance;
        }

        
    }
}
