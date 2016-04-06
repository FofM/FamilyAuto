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
    public class TestHomeControllerBasics
    {
        [Test]
        public void TestHomeControllerIndex()
        {
            var controller = new HomeController();

            ViewResult result = controller.Index() as ViewResult;

            Assert.AreEqual("Index", result.ViewName);
        }

        [Test]
        public void TestHomeControllerContact()
        {
            var controller = new HomeController();

            ViewResult result = controller.Contact() as ViewResult;

            Assert.AreEqual("Contact", result.ViewName);
        }

        [Test]
        public void TestHomeControllerNews()
        {
            var controller = new HomeController();

            ViewResult result = controller.News() as ViewResult;

            Assert.AreEqual("News", result.ViewName);
        }

        [Test]
        public void TestHomeControllerServices()
        {
            var controller = new HomeController();

            ViewResult result = controller.Services() as ViewResult;

            Assert.AreEqual("Services", result.ViewName);
        }
    }
}