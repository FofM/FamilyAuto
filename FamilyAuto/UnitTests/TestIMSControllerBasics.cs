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
    public class TestIMSControllerBasics
    {
        [Test]
        public void TestIMSControllerIndex()
        {
            var controller = new IMSController();

            ViewResult result = controller.Index() as ViewResult;

            Assert.AreEqual("Index", result.ViewName);
        }

        [Test]
        public void TestIMSControllerStatistics()
        {
            var controller = new IMSController();

            ViewResult result = controller.Statistics() as ViewResult;

            Assert.AreEqual("Statistics", result.ViewName);
        }

        [Test]
        public void TestIMSControllerDetails()
        {
            var controller = new IMSController();

            ViewResult result = controller.Details(1002) as ViewResult;

            Assert.AreEqual("Details", result.ViewName);
        }

        [Test]
        public void TestIMSControllerCreate()
        {
            var controller = new IMSController();

            ViewResult result = controller.Create() as ViewResult;

            Assert.AreEqual("Create", result.ViewName);
        }

        [Test]
        public void TestIMSControllerEdit()
        {
            var controller = new IMSController();

            ViewResult result = controller.Edit(1002) as ViewResult;

            Assert.AreEqual("Edit", result.ViewName);
        }

        [Test]
        public void TestIMSControllerDelete()
        {
            var controller = new IMSController();

            ViewResult result = controller.Delete(1002) as ViewResult;

            Assert.AreEqual("Delete", result.ViewName);
        }
    }
}