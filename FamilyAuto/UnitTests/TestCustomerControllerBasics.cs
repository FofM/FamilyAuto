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
    public class TestCustomerControllerBasics
    {
        [Test]
        public void TestUserControllerIndex()
        {
            var controller = new UserController();

            ViewResult result = controller.Index(null) as ViewResult;

            Assert.AreEqual("Index", result.ViewName);
        }

        [Test]
        public void TestUserControllerCreate()
        {
            var controller = new UserController();

            ViewResult result = controller.Create() as ViewResult;

            Assert.AreEqual("Create", result.ViewName);
        }

        [Test]
        public void TestUserControllerDetails()
        {
            var controller = new UserController();

            ViewResult result = controller.Details(1) as ViewResult;

            Assert.AreEqual("Details", result.ViewName);
        }

        [Test]
        public void TestUserControllerEdit()
        {
            var controller = new UserController();

            ViewResult result = controller.Edit(1) as ViewResult;

            Assert.AreEqual("Edit", result.ViewName);
        }

        [Test]
        public void TestUserControllerDelete()
        {
            var controller = new UserController();

            ViewResult result = controller.Delete(1) as ViewResult;

            Assert.AreEqual("Delete", result.ViewName);
        }
    }
}