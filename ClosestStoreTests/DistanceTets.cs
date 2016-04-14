using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClosestStore;

namespace ClosestStoreTests
{
    [TestClass]
    public class DistanceCalculatorTest
    {

        CustomerLocation CustomerLocation = new CustomerLocation("80125", 39.485069, -105.052316);

        [TestMethod]
        public void MinDistanceTest()
        {
            double expected = 12.817;

           

            DistanceCalculator calc = new DistanceCalculator();

            calc.StoreProv = new StoreDataProvider(); 

            double actualDistance = calc.GetClosestStoreDistance(CustomerLocation).ClosestDistance;

            Assert.IsTrue(Math.Abs(expected - actualDistance) <= 0.1);
            
        }

        [TestMethod]
        public void ClosestStoreTest()
        {
            String closestStoreNum = "34";

            StoreDataProvider provider = new StoreDataProvider();
            DistanceCalculator calculator = new DistanceCalculator();
            calculator.StoreProv = provider;

            string actualStore = calculator.GetClosestStoreDistance(CustomerLocation).StoreNo.ToString();

            Assert.AreEqual(closestStoreNum, actualStore);
        }
    }


}
