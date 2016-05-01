using FamilyAuto.Controllers;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FamilyAuto.UnitTests
{
    [TestFixture]
    public class TestVatRateCalculation
    {
        [Test]
        public void TestVatRate()
        {
            var controller = new SoldVehiclesController();

            int result = controller.AddVAT(100);

            Assert.AreEqual(120, result);
        }

        [Test]
        public void TestVatRateNegative()
        {
            var controller = new SoldVehiclesController();

            var ex = Assert.Throws<ArgumentOutOfRangeException>(() => controller.AddVAT(-100));

            Assert.IsTrue(ex.Message.Contains("Must supply a positive integer"));
        }
    }
}