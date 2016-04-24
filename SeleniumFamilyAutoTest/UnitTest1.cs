using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System.Collections.Generic;

namespace SeleniumFamilyAutoTest
{
    [TestClass]
    public class FunctionalUnitTests
    {
        private IWebDriver driver;

        [TestInitialize]
        public void TestInit()
        {
            //If the test and the web app are run locally then IIS has to be manually started first with the followin command line
            //start C:\"Program Files (x86)"\"IIS Express"\iisexpress.exe /path:"C:\Users\Filip\Source\Repos\FamilyAuto\FamilyAuto" /port:55356
            driver = new FirefoxDriver();
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            //current setup is for local execution
            driver.Navigate().GoToUrl("http://localhost:55356/");
        }

        [TestCleanup]
        public void TestCleanUp()
        {
            driver.Close();
        }

        [TestMethod]
        public void ShowcaseAccessTest()
        {

            IWebElement showroom = driver.FindElement(By.Id("Showroom"));
            showroom.Click();
            string showroomValidate = driver.FindElement(By.TagName("h1")).Text;
            Assert.AreEqual("Family Auto SHOWROOM", showroomValidate);
        }

        [TestMethod]
        public void VehicleDetailsAccessTest()
        {
            IWebElement showroom = driver.FindElement(By.Id("Showroom"));
            showroom.Click();
            IWebElement vehicleLink = driver.FindElement(By.PartialLinkText("BMW"));
            vehicleLink.Click();
            string vehicleDetails = driver.FindElement(By.TagName("h2")).Text;
            Assert.AreEqual("Vehicle Details", vehicleDetails);

            bool priceCheck = false;
            IList<IWebElement> dt = driver.FindElements(By.TagName("dt"));
            foreach (var i in dt)
            {
                if (i.Text.Equals("Price")) priceCheck = true;
            }
            Assert.IsTrue(priceCheck);
        }

        [TestMethod]
        public void ContactAccessTest()
        {
            IWebElement contact = driver.FindElement(By.PartialLinkText("Contact"));
            contact.Click();
            string title = driver.FindElement(By.TagName("h2")).Text;
            Assert.AreEqual("Contact.", title);
            IWebElement address = driver.FindElement(By.TagName("address"));
            Assert.IsTrue(address.ToString().Length > 0);
        }
    }
}
