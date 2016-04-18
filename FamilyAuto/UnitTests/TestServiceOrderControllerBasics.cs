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
    public class TestServiceOrderControllerBasics
    {
        [Test]
        public void TestServiceOrderControllerIndex()
        {
            var controller = new ServiceOrderController();

            ViewResult result = controller.Index() as ViewResult;

            Assert.AreEqual("Index", result.ViewName);
        }

        [Test]
        public void TestServiceOrderControllerCreate()
        {
            var controller = new ServiceOrderController();

            ViewResult result = controller.Create() as ViewResult;

            Assert.AreEqual("Create", result.ViewName);
        }

        [Test]
        public void TestServiceOrderControllerDetails()
        {
            var controller = new ServiceOrderController();

            ViewResult result = controller.Details(1) as ViewResult;

            Assert.AreEqual("Details", result.ViewName);
        }

        [Test]
        public void TestServiceOrderControllerEdit()
        {
            var controller = new ServiceOrderController();

            ViewResult result = controller.Edit(1) as ViewResult;

            Assert.AreEqual("Edit", result.ViewName);
        }

        [Test]
        public void TestServiceOrderControllerDelete()
        {
            var controller = new ServiceOrderController();

            ViewResult result = controller.Delete(1) as ViewResult;

            Assert.AreEqual("Delete", result.ViewName);
        }
    }
}