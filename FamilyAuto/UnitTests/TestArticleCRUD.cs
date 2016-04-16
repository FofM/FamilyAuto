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
    public class TestArticleCRUD
    {
        [Test]
        public void TestArticleCreateRedirect()
        {
            var controller = new ArticleController();

            RedirectToRouteResult result = controller.Create(new Articles()
            {
                ArticleTitle = "TestArticle",
                ArticleDescription = "TestDescription",
                ArticleType = 0,
                DateUploaded = DateTime.Now
            }) as RedirectToRouteResult;

            Assert.That(result.RouteValues["action"], Is.EqualTo("Index"));
        }

        [Test]
        public void TestArticleDetails()
        {
            var controller = new ArticleController();

            FamilyAutoEntities db = new FamilyAutoEntities();

            var expectedArticle = new Articles
            {
                ArticleTitle = "TestArticle",
                ArticleDescription = "TestDescription"
            };

            var editArticle = db.Articles.Where(x => x.ArticleTitle == "TestArticle").FirstOrDefault();

            int articleId = editArticle.Id;

            ViewResult result = controller.Details(articleId) as ViewResult;
            var resultData = (Articles)result.ViewData.Model;

            Assert.AreEqual(expectedArticle.ArticleTitle, resultData.ArticleTitle);
            Assert.AreEqual(expectedArticle.ArticleDescription, resultData.ArticleDescription);
        }

        [Test]
        public void TestArticleEditRedirect()
        {
            var controller = new ArticleController();

            FamilyAutoEntities db = new FamilyAutoEntities();

            var editArticle = db.Articles.Where(x => x.ArticleTitle == "TestArticle").FirstOrDefault();

            editArticle.ArticleDescription = "TestDescriptionEdit";

            RedirectToRouteResult result = controller.Edit(editArticle) as RedirectToRouteResult;

            Assert.That(result.RouteValues["action"], Is.EqualTo("Index"));
        }

        [Test]
        public void TestArticleDeleteRedirect()
        {
            var controller = new ArticleController();

            FamilyAutoEntities db = new FamilyAutoEntities();

            var delArticle = db.Articles.Where(x => x.ArticleTitle == "TestArticle").FirstOrDefault();

            int articleId = delArticle.Id;

            RedirectToRouteResult result = controller.DeleteConfirmed(articleId) as RedirectToRouteResult;

            Assert.That(result.RouteValues["action"], Is.EqualTo("Index"));

        }

        [Test]
        public void TestArticleCreateErrorView()
        {
            var controller = new ArticleController();

            ViewResult result = controller.Create(new Articles()
            {
                ArticleTitle = "TestArticle",
                ArticleDescription = null,
                ArticleType = 0,
                DateUploaded = DateTime.Now
            }) as ViewResult;

            Assert.That(result.ViewName, Is.EqualTo("Error"));
        }
    }
}