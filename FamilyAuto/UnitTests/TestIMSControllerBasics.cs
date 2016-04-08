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
    }
}