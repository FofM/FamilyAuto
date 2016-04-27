using FamilyAuto.Controllers;
using FamilyAuto.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Moq;
using System.IO;
using System.Configuration;
using System.Web.ApplicationServices;

namespace FamilyAuto.UnitTests
{
    public class TestVehicleCRUD
    {
        [Test]
        public void TestVehicleCreateRedirect()
        {
            var controller = new VehicleController();

            var request = new Mock<HttpRequestBase>();
            var context = new Mock<HttpContextBase>();
            var postedfile = new Mock<HttpPostedFileBase>();
            var postedfilesKeyCollection = new Mock<HttpFileCollectionBase>();
            var fakeFileKeys = new List<string>() { "file" };
            context.Setup(ctx => ctx.Request).Returns(request.Object);
            request.Setup(req => req.Files).Returns(postedfilesKeyCollection.Object);
            postedfilesKeyCollection.Setup(keys => keys.GetEnumerator()).Returns(fakeFileKeys.GetEnumerator());
            postedfilesKeyCollection.Setup(keys => keys["file"]).Returns(postedfile.Object);
            postedfile.Setup(f => f.ContentLength).Returns(8192).Verifiable();
            postedfile.Setup(f => f.FileName).Returns("foo.doc").Verifiable();
            postedfile.Setup(f => f.SaveAs(It.IsAny<string>())).Verifiable();


            //FormCollection form = new FormCollection();
            //form.Add("VehicleHistory.Purpose", "NewPurpose");
            //form.Add("VehicleHistory.NoOfOwners", "");
            //form.Add("VehicleHistory.HUValidUntil", "");
            //form.Add("VehicleHistory.Warranty", "");
            //form.Add("VehicleHistory.Mileage", "");
            //form.Add("VehicleHistory.FirstRegistration", "");

            controller.ControllerContext = new ControllerContext(context.Object, new System.Web.Routing.RouteData(), controller);

            RedirectToRouteResult result = controller.Create(new Vehicle()
            {
                Make = "TestMake",
                Model = "TestModel",
                Variant = "TestVariant",
                Condition = "TestCondition",
                Type = TypeEnum.Commercial,
                Description = "Test Description",
                Price = 1000
            }, null) as RedirectToRouteResult;

            Assert.That(result.RouteValues["action"], Is.EqualTo("Index"));
        }

        [Test]
        public void TestVehicleDetails()
        {
            var controller = new VehicleController();

            FamilyAutoEntities db = new FamilyAutoEntities();

            var expectedVehicle = new Vehicle
            {
                Make = "TestMake",
                Model = "TestModel"
            };

            var editVehicle = db.Vehicles.Where(x => x.Make == "TestMake").FirstOrDefault();

            int vehicleId = editVehicle.Id;

            ViewResult result = controller.Details(vehicleId) as ViewResult;
            var resultData = (Vehicle)result.ViewData.Model;

            Assert.AreEqual(expectedVehicle.Make, resultData.Make);
            Assert.AreEqual(expectedVehicle.Model, resultData.Model);
        }

        [Test]
        public void TestVehicleEditRedirect()
        {
            var controller = new VehicleController();

            FamilyAutoEntities db = new FamilyAutoEntities();

            var editVehicle = db.Vehicles.AsNoTracking().Where(x => x.Make == "TestMake").FirstOrDefault();

            editVehicle.Model = "TestModelEditing";

            RedirectToRouteResult result = controller.Edit(editVehicle) as RedirectToRouteResult;

            Assert.That(result.RouteValues["action"], Is.EqualTo("Index"));
        }

        [Test]
        public void TestVehicleDeleteRedirect()
        {
            var controller = new VehicleController();

            FamilyAutoEntities db = new FamilyAutoEntities();

            var delVehicle = db.Vehicles.Where(x => x.Make == "TestMake").FirstOrDefault();

            int vehicleId = delVehicle.Id;

            RedirectToRouteResult result = controller.DeleteConfirmed(vehicleId) as RedirectToRouteResult;

            Assert.That(result.RouteValues["action"], Is.EqualTo("Index"));

        }

        [Test]
        public void TestVehicleCreateErrorView()
        {
            var controller = new VehicleController();

            var request = new Mock<HttpRequestBase>();
            var context = new Mock<HttpContextBase>();
            var postedfile = new Mock<HttpPostedFileBase>();
            var postedfilesKeyCollection = new Mock<HttpFileCollectionBase>();
            var fakeFileKeys = new List<string>() { "file" };
            context.Setup(ctx => ctx.Request).Returns(request.Object);
            request.Setup(req => req.Files).Returns(postedfilesKeyCollection.Object);
            postedfilesKeyCollection.Setup(keys => keys.GetEnumerator()).Returns(fakeFileKeys.GetEnumerator());
            postedfilesKeyCollection.Setup(keys => keys["file"]).Returns(postedfile.Object);
            postedfile.Setup(f => f.ContentLength).Returns(8192).Verifiable();
            postedfile.Setup(f => f.FileName).Returns("foo.doc").Verifiable();
            postedfile.Setup(f => f.SaveAs(It.IsAny<string>())).Verifiable();

            controller.ControllerContext = new ControllerContext(context.Object, new System.Web.Routing.RouteData(), controller);

            ViewResult result = controller.Create(new Vehicle()
            {
                Make = null,
                Model = "TestModel",
                Variant = "TestVariant",
                Condition = "TestCondition",
                Type = TypeEnum.Commercial,
                Description = "Test Description",
                Price = 1000
            }, null) as ViewResult;

            Assert.That(result.ViewName, Is.EqualTo("Error"));
        }

    }
}