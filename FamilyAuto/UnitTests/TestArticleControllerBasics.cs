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
    public class TestArticleControllerBasics
    {
        [Test]
        public void TestArticleControllerIndex()
        {
            var controller = new ArticleController();

            ViewResult result = controller.Index(null) as ViewResult;

            Assert.AreEqual("Index", result.ViewName);
        }

        [Test]
        public void TestArticleControllerCreate()
        {
            var controller = new ArticleController();

            ViewResult result = controller.Create() as ViewResult;

            Assert.AreEqual("Create", result.ViewName);
        }

        [Test]
        public void TestArticleControllerDetails()
        {
            var controller = new ArticleController();

            ViewResult result = controller.Details(3) as ViewResult;

            Assert.AreEqual("Details", result.ViewName);
        }

        [Test]
        public void TestArticleControllerEdit()
        {
            var controller = new ArticleController();

            ViewResult result = controller.Edit(3) as ViewResult;

            Assert.AreEqual("Edit", result.ViewName);
        }

        [Test]
        public void TestArticleControllerDelete()
        {
            var controller = new ArticleController();

            ViewResult result = controller.Delete(3) as ViewResult;

            Assert.AreEqual("Delete", result.ViewName);
        }
    }
}