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
    public class TestStaffControllerBasics
    {
        [Test]
        public void TestStaffControllerIndex()
        {
            var controller = new StaffController();

            ViewResult result = controller.Index(null) as ViewResult;

            Assert.AreEqual("Index", result.ViewName);
        }

        [Test]
        public void TestStaffControllerCreate()
        {
            var controller = new StaffController();

            ViewResult result = controller.Create() as ViewResult;

            Assert.AreEqual("Create", result.ViewName);
        }

        [Test]
        public void TestStaffControllerDetails()
        {
            var controller = new StaffController();

            ViewResult result = controller.Details(2) as ViewResult;

            Assert.AreEqual("Details", result.ViewName);
        }

        [Test]
        public void TestStaffControllerEdit()
        {
            var controller = new StaffController();

            ViewResult result = controller.Edit(2) as ViewResult;

            Assert.AreEqual("Edit", result.ViewName);
        }

        [Test]
        public void TestStaffControllerDelete()
        {
            var controller = new StaffController();

            ViewResult result = controller.Delete(2) as ViewResult;

            Assert.AreEqual("Delete", result.ViewName);
        }
    }
}