using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System.Collections.Generic;
using OpenQA.Selenium.Support.UI;

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
            //driver.Close();
        }

        [TestMethod]
        public void ShowcaseAccessTest()
        {

            IWebElement showroom = driver.FindElement(By.Id("Showroom"));
            showroom.Click();
            string showroomValidate = driver.FindElement(By.TagName("h1")).Text;
            IList<IWebElement> price = driver.FindElements(By.Id("vehiclePrice"));
            Assert.AreEqual("Family Auto SHOWROOM", showroomValidate);
            Assert.IsNotNull(price);
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

        [TestMethod]
        public void StatisticsDisplayTest()
        {
            IWebElement manage = driver.FindElement(By.PartialLinkText("Manage"));
            manage.Click();
            IWebElement bd = driver.FindElement(By.PartialLinkText("Business Data"));
            bd.Click();
            IWebElement statistics = driver.FindElement(By.PartialLinkText("Statistics"));
            statistics.Click();

            IWebElement topCustomersNumbers = driver.FindElement(By.Id("topCustomersNumbers"));
            topCustomersNumbers.Click();
            string topCustomersValidation = driver.FindElement(By.XPath(".//*[@id='C1s']/*[name()='text']")).Text;
            Assert.AreEqual("Vehicles_Sold", topCustomersValidation);

            IWebElement topCustomersSpent = driver.FindElement(By.Id("topCustomersSpent"));
            topCustomersSpent.Click();
            string topCustomersSpentValidation = driver.FindElement(By.XPath(".//*[@id='C1s']/*[name()='text']")).Text;
            Assert.AreEqual("Money_Spent", topCustomersSpentValidation);

            IWebElement salesData = driver.FindElement(By.Id("salesData"));
            salesData.Click();
            string salesDataValidation = driver.FindElement(By.XPath(".//*[@id='C1s']/*[name()='text']")).Text;
            Assert.AreEqual("SoldCount", salesDataValidation);
        }

        [TestMethod]
        public void MakeAndModelFilter()
        {
            IWebElement showroom = driver.FindElement(By.Id("Showroom"));
            showroom.Click();
            SelectElement makeFilter = new SelectElement(driver.FindElement(By.Id("make")));
            makeFilter.SelectByIndex(1);
            string make = makeFilter.SelectedOption.Text;
            SelectElement modelFilter = new SelectElement(driver.FindElement(By.Id("model")));
            modelFilter.SelectByIndex(0);
            string model = modelFilter.SelectedOption.Text;
            IWebElement filterButton = driver.FindElement(By.XPath("html/body/div[2]/div[3]/div/form/input[3]"));
            filterButton.Click();
            string makeResult = driver.FindElement(By.Id(make)).Text;
            string modelResult = driver.FindElement(By.Id(model)).Text;
            Assert.AreEqual(make, makeResult);
            Assert.AreEqual(model, modelResult);
        }

        [TestMethod]
        public void VehicleTypeSelection()
        {
            IWebElement expandTypes = driver.FindElement(By.XPath("html/body/div[2]/div[1]/button"));
            expandTypes.Click();
            IWebElement commercialVehicle = driver.FindElement(By.XPath(".//*[@id='VehicleType']/div[1]/div[2]/a/img"));
            commercialVehicle.Click();
            string url = driver.Url;
            Assert.AreEqual("http://localhost:55356/Vehicle/Showroom?type=Commercial", url);
        }

        [TestMethod]
        public void VehicleDetailsImageListing()
        {
            IWebElement showroom = driver.FindElement(By.Id("Showroom"));
            showroom.Click();
            IWebElement vehicleLink = driver.FindElement(By.PartialLinkText("BMW"));
            vehicleLink.Click();

            bool imgCheck = false;
            IList<IWebElement> img = driver.FindElements(By.TagName("img"));
            foreach (var i in img)
            {
                if (i != null) imgCheck = true;
            }
            Assert.IsTrue(imgCheck);
        }

        [TestMethod]
        public void PriceFromToFilter()
        {
            IWebElement showroom = driver.FindElement(By.Id("Showroom"));
            showroom.Click();
            IWebElement priceFrom = driver.FindElement(By.Id("priceFrom"));
            priceFrom.SendKeys("1000");
            IWebElement priceTo = driver.FindElement(By.Id("priceTo"));
            priceTo.SendKeys("10000");
            IWebElement filterButton = driver.FindElement(By.XPath("html/body/div[2]/div[3]/div/form/input[3]"));
            filterButton.Click();
            IList<IWebElement> priceList = driver.FindElements(By.Id("vehiclePrice"));
            bool validate = true;
            foreach (var i in priceList)
            {
                if (i.Text != "")
                {
                    if (Convert.ToInt32(i.Text) < 1000 || Convert.ToInt32(i.Text) > 10000)
                    {
                        validate = false;
                    }
                }
            }
            Assert.IsTrue(validate);
        }

        [TestMethod]
        public void MileageFilter()
        {
            IWebElement showroom = driver.FindElement(By.Id("Showroom"));
            showroom.Click();
            SelectElement mileageFilter = new SelectElement(driver.FindElement(By.Id("mileage")));
            mileageFilter.SelectByIndex(4);
            string mileage = mileageFilter.SelectedOption.Text;
            IWebElement filterButton = driver.FindElement(By.XPath("html/body/div[2]/div[3]/div/form/input[3]"));
            filterButton.Click();
            IList<IWebElement> mileageCollection = driver.FindElements(By.Id("vehicleMileage"));
            bool validate = true;
            foreach (var i in mileageCollection)
            {
                if (i.Text != "")
                {
                    if (Convert.ToInt32(i.Text) > Convert.ToInt32(mileage))
                    {
                        validate = false;
                    }
                }
            }
            Assert.IsTrue(validate);

        }

        [TestMethod]
        public void RoleManagement()
        {
            IWebElement loginLink = driver.FindElement(By.Id("loginLink"));
            loginLink.Click();
            IWebElement username = driver.FindElement(By.Id("Username"));
            username.SendKeys("Filip");
            IWebElement password = driver.FindElement(By.Id("Password"));
            password.SendKeys("8rPq17_aF");
            IWebElement logInButton = driver.FindElement(By.Id("logInButton"));
            logInButton.Click();
            IWebElement manage = driver.FindElement(By.PartialLinkText("Manage"));
            manage.Click();
            IWebElement bd = driver.FindElement(By.PartialLinkText("Business Data"));
            bd.Click();
            IWebElement manageRoles = driver.FindElement(By.Id("manageRoles"));
            manageRoles.Click();
            IWebElement addRole = driver.FindElement(By.Id("addRole"));
            addRole.Click();
            SelectElement userToAdd = new SelectElement(driver.FindElement(By.Id("UserName")));
            userToAdd.SelectByIndex(0);
            IWebElement AddRoleButton = driver.FindElement(By.XPath("html/body/div[2]/div/div/div[2]/form/input[2]"));
            AddRoleButton.Click();
            IWebElement RemoveRoleButton = driver.FindElement(By.XPath("html/body/div[2]/div/div[2]/div[3]/form/input[2]"));
            string returnMessage = driver.FindElement(By.Id("returnMessage")).Text;
            if (returnMessage.Equals("Username added to the role succesfully !"))
            {
                RemoveRoleButton.Click();
                returnMessage = driver.FindElement(By.Id("returnMessage")).Text;
                Assert.AreEqual("Role removed from this user successfully !", returnMessage);
            }
            else if (returnMessage.Equals("This user already has the role specified !"))
            {
                RemoveRoleButton.Click();
                returnMessage = driver.FindElement(By.Id("returnMessage")).Text;
                Assert.AreEqual("Role removed from this user successfully !", returnMessage);
                returnMessage = driver.FindElement(By.Id("returnMessage")).Text;
                AddRoleButton.Click();
                Assert.AreEqual("Username added to the role succesfully !", returnMessage);
            }
            else
            {
                Assert.IsTrue(false);
            }

        }

        [TestMethod]
        public void VehicleEditWrongAttributeTest()
        {
            IWebElement manage = driver.FindElement(By.PartialLinkText("Manage"));
            manage.Click();
            IWebElement manageVehicle = driver.FindElement(By.PartialLinkText("Vehicles"));
            manageVehicle.Click();
            IList<IWebElement> edit = driver.FindElements(By.PartialLinkText("Edit"));
            foreach (var i in edit)
            {
                i.Click();
                break;
            }
            IWebElement registration = driver.FindElement(By.Id("VehicleHistory_FirstRegistration"));
            registration.SendKeys("ABC");
            IWebElement saveButton = driver.FindElement(By.XPath("html/body/div[2]/form/div/div/div/div[11]/div/input"));
            saveButton.Click();
            string validation = driver.FindElement(By.XPath("html/body/div[2]/form/div/div/div/div[8]/div[6]/div/span/span")).Text;
            Assert.AreEqual("The field First Registration must be a date.", validation);
        }

        [TestMethod]
        public void VehicleDeleteConfirmationTest()
        {
            IWebElement manage = driver.FindElement(By.PartialLinkText("Manage"));
            manage.Click();
            IWebElement manageVehicle = driver.FindElement(By.PartialLinkText("Vehicles"));
            manageVehicle.Click();
            IList<IWebElement> del = driver.FindElements(By.PartialLinkText("Delete"));
            foreach (var i in del)
            {
                i.Click();
                break;
            }

            string title = driver.FindElement(By.Id("delTitle")).Text;
            string confMsg = driver.FindElement(By.Id("confirmDeletion")).Text;

            Assert.AreEqual("Delete", title);
            Assert.AreEqual("Are you sure you want to delete the following vehicle?", confMsg);
        }

        [TestMethod]
        public void ArticleDeleteConfirmationTest()
        {
            IWebElement manage = driver.FindElement(By.PartialLinkText("Manage"));
            manage.Click();
            IWebElement manageArticles = driver.FindElement(By.PartialLinkText("Articles"));
            manageArticles.Click();
            IList<IWebElement> del = driver.FindElements(By.PartialLinkText("Delete"));
            foreach (var i in del)
            {
                i.Click();
                break;
            }

            string title = driver.FindElement(By.Id("delTitle")).Text;
            string confMsg = driver.FindElement(By.Id("confirmDeletion")).Text;

            Assert.AreEqual("Delete", title);
            Assert.AreEqual("Are you sure you want to delete the following article?", confMsg);
        }
    }
}
