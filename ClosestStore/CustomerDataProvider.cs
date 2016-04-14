using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ClosestStore
{
    public class CustomerDataProvider : ICustomerData
    {

        List<CustomerLocation> customerList = new List<CustomerLocation>();

        public CustomerDataProvider()
        {
            string path = @"c:\Users\zemj\My Documents\Customers_List.csv";
            string[] readText = File.ReadAllLines(path);

            Console.WriteLine("Number of Records", readText.Count());

            foreach (string s in readText)
            {
                string[] split = s.Split(new Char[] { ',' });

                foreach (string sp in split)
                {             
                    if (sp.Trim() != "")
                    {
                        Console.WriteLine(sp);
                    }
                    else
                    {
                    }          

                }

             CustomerLocation cpoint = new CustomerLocation(split[0], double.Parse(split[1]), double.Parse(split[2]));
             customerList.Add(cpoint);
             Console.WriteLine("I just added customer number {0} from Text File",customerList.Count());
            }
          
        }

        public List<CustomerLocation> GetCustomers()
        {
            return customerList;
        }
        
     }
}


