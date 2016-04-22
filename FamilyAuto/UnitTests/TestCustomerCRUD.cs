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
    public class TestCustomerCRUD
    {
        [Test]
        public void TestCustomerCreateRedirect()
        {
            var controller = new UserController();

            RedirectToRouteResult result = controller.Create(new Customers()
            {
                FirstName = "TestCustomerFN",
                LastName = "TestCustomerLN",
                Email = "TestCustomer@test.com",
                Address = "TestAddress"
            }) as RedirectToRouteResult;

            Assert.That(result.RouteValues["action"], Is.EqualTo("Index"));
        }

        [Test]
        public void TestCustomerDetails()
        {
            var controller = new UserController();

            FamilyAutoEntities db = new FamilyAutoEntities();

            var expectedCustomer = new Customers
            {
                FirstName = "TestCustomerFN",
                LastName = "TestCustomerLN"
            };

            var editCustomer = db.Customers.Where(x => x.FirstName == "TestCustomerFN").FirstOrDefault();

            int customerId = editCustomer.Id;

            ViewResult result = controller.Details(customerId) as ViewResult;
            var resultData = (Customers)result.ViewData.Model;

            Assert.AreEqual(expectedCustomer.FirstName, resultData.FirstName);
            Assert.AreEqual(expectedCustomer.LastName, resultData.LastName);
        }

        [Test]
        public void TestCustomerEditRedirect()
        {
            var controller = new UserController();

            FamilyAutoEntities db = new FamilyAutoEntities();

            var editCustomer = db.Customers.Where(x => x.FirstName == "TestCustomerFN").FirstOrDefault();

            editCustomer.LastName = "TestCustomerLN_Edit";

            RedirectToRouteResult result = controller.Edit(editCustomer) as RedirectToRouteResult;

            Assert.That(result.RouteValues["action"], Is.EqualTo("Index"));
        }

        [Test]
        public void TestCustomerDeleteRedirect()
        {
            var controller = new UserController();

            FamilyAutoEntities db = new FamilyAutoEntities();

            var delCustomer = db.Customers.Where(x => x.FirstName == "TestCustomerFN").FirstOrDefault();

            int customerId = delCustomer.Id;

            RedirectToRouteResult result = controller.DeleteConfirmed(customerId) as RedirectToRouteResult;

            Assert.That(result.RouteValues["action"], Is.EqualTo("Index"));

        }

        [Test]
        public void TestCustomerCreateErrorView()
        {
            var controller = new UserController();

            ViewResult result = controller.Create(new Customers()
            {
                FirstName = "TestCustomerFN",
                LastName = null,
                Email = "TestCustomer@test.com",
                Address = "TestAddress"
            }) as ViewResult;

            Assert.That(result.ViewName, Is.EqualTo("Error"));
        }
    }
}