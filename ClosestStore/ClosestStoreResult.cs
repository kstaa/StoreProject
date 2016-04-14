using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClosestStore
{
    public class ClosestStoreResult
    {
        public int StoreNo { get; set; }
        public double ClosestDistance { get; set; }

        public ClosestStoreResult(int storeNum, double closestDistance)
        {
            StoreNo = storeNum;
            ClosestDistance = closestDistance;
        }

    }
}
