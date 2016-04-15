using FamilyAuto.Controllers;
using FamilyAuto.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FamilyAuto.UnitTests
{
    [TestFixture]
    public class TestVehicleControllerBasics
    {
        [Test]
        public void TestVehicleControllerIndex()
        {
            var controller = new VehicleController();

            ViewResult result = controller.Index(null, null) as ViewResult;

            Assert.AreEqual("Index", result.ViewName);
        }

        [Test]
        public void TestVehicleControllerShowroomNullQuery()
        {
            var controller = new VehicleController();

            ViewResult result = controller.Showroom(null, null, null, null, null, null) as ViewResult;

            Assert.AreEqual("Showroom", result.ViewName);
        }

        [Test]
        public void TestVehicleControllerShowroomWithQuery()
        {
            var controller = new VehicleController();

            ViewResult result = controller.Showroom("BMW", "Z1", "4WD", 100000, 1000, 5000) as ViewResult;

            Assert.AreEqual("Showroom", result.ViewName);
        }
    }
}