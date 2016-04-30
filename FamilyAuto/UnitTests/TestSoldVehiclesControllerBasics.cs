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
    public class TestSoldVehiclesControllerBasics
    {
        [Test]
        public void TestSoldVehiclesControllerIndex()
        {
            var controller = new SoldVehiclesController();

            ViewResult result = controller.Index(null) as ViewResult;

            Assert.AreEqual("Index", result.ViewName);
        }

        [Test]
        public void TestSoldVehiclesControllerCreate()
        {
            var controller = new SoldVehiclesController();

            ViewResult result = controller.Create() as ViewResult;

            Assert.AreEqual("Create", result.ViewName);
        }

        [Test]
        public void TestSoldVehiclesControllerDetails()
        {
            var controller = new SoldVehiclesController();

            ViewResult result = controller.Details(1) as ViewResult;

            Assert.AreEqual("Details", result.ViewName);
        }

        [Test]
        public void TestSoldVehiclesControllerEdit()
        {
            var controller = new SoldVehiclesController();

            ViewResult result = controller.Edit(1) as ViewResult;

            Assert.AreEqual("Edit", result.ViewName);
        }

        [Test]
        public void TestSoldVehiclesControllerDelete()
        {
            var controller = new SoldVehiclesController();

            ViewResult result = controller.Delete(1) as ViewResult;

            Assert.AreEqual("Delete", result.ViewName);
        }
    }
}