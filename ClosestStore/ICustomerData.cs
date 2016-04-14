using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClosestStore
{
    public interface ICustomerData
    {
        List<CustomerLocation> GetCustomers();
    }
}
