
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ClosestStore
{
    class Program
    {
        public static void Main(string[] args)
        {
            Program app = new Program();
           
            List<CustomerLocation> allCustomers = app.GetCustomerList();
            
            Console.WriteLine("Customers Count after getting customer list inside Main = {0}", allCustomers.Count);
            Console.WriteLine("");

            app.DoStuff(allCustomers);
            Console.ReadKey();         
        }


        public ICustomerData CustomersDataSet { get; set; }


        public List<CustomerLocation> GetCustomerList()
        {
            ICustomerData customersDataSet = new CustomerDataProvider();

            List<CustomerLocation> customersDataList = customersDataSet.GetCustomers();
            Console.WriteLine("Total Customer Count inside GetCustomerList = {0}", customersDataList.Count);

            return customersDataList;
        }


        public void DoStuff(List<CustomerLocation> customerLocations)
        {

            foreach (var customerLocation in customerLocations)
            {
                DistanceCalculator calc = new DistanceCalculator();
                calc.StoreProv = new StoreDataProvider();
                ClosestStoreResult actualResult = calc.GetClosestStoreDistance(customerLocation);

                if (actualResult.ClosestDistance <= 250.00)
                {
                    System.Console.WriteLine("The closest store to zipcode {0} is store number {1} with distance {2:0.##} miles.", 
                        customerLocation.PostalCode, actualResult.StoreNo, actualResult.ClosestDistance);
                }
                else
                {
                    System.Console.WriteLine("There is no store located within 250 miles radius from zipcode {0}.", customerLocation.PostalCode);
                }
            }
        }

    }
}
     

    