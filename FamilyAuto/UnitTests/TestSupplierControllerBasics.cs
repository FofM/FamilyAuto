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
    public class TestSupplierControllerBasics
    {
        [Test]
        public void TestSupplierControllerIndex()
        {
            var controller = new SupplierController();

            ViewResult result = controller.Index() as ViewResult;

            Assert.AreEqual("Index", result.ViewName);
        }

        [Test]
        public void TestSupplierControllerCreate()
        {
            var controller = new SupplierController();

            ViewResult result = controller.Create() as ViewResult;

            Assert.AreEqual("Create", result.ViewName);
        }

        [Test]
        public void TestSupplierControllerDetails()
        {
            var controller = new SupplierController();

            ViewResult result = controller.Details(1) as ViewResult;

            Assert.AreEqual("Details", result.ViewName);
        }

        [Test]
        public void TestSupplierControllerEdit()
        {
            var controller = new SupplierController();

            ViewResult result = controller.Edit(1) as ViewResult;

            Assert.AreEqual("Edit", result.ViewName);
        }

        [Test]
        public void TestSupplierControllerDelete()
        {
            var controller = new SupplierController();

            ViewResult result = controller.Delete(1) as ViewResult;

            Assert.AreEqual("Delete", result.ViewName);
        }
    }
}