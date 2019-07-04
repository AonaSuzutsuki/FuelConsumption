using System;
using FuelConsumption2.Models;
using NUnit.Framework;

namespace FuelConsumption2UnitTest.Models
{
    [TestFixture]
    public class FuelConsumptionInfoTest
    {
        [Test]
        public void FuelConsumptionTest()
        {
            var value1 = new FuelConsumptionInfo
            {
                Odo = 6327,
                Date = new DateTime(2019, 6, 9),
                Litter = 5.17,
                PricePerLitter = 153
            };
            var value2 = new FuelConsumptionInfo
            {
                Odo = 6512,
                Date = new DateTime(2019, 7, 1),
                Litter = 5.54,
                PricePerLitter = 148
            };

            var exp = 33.393501805054152d.ToString("F2"); 
            var act = value2.FuelConsumption(value1).ToString("F2");

            Assert.AreEqual(exp, act);
        }
    }
}
