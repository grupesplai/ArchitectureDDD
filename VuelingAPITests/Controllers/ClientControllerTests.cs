using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;
using System.Collections.Generic;
using Vueling.Common.Entity;

namespace VuelingAPI.Controllers.Tests
{
    [TestClass()]
    public class ClientControllerTests
    {
        public IWebDriver driver;
        string url = "http://localhost:33329/api/client";
        [TestInitialize()]
        public void ClientsControllerTest()
        {
            //chrome = new ChromeDriver();
            driver = new FirefoxDriver();
            driver.Manage().Window.Maximize();
        }

        [TestMethod()]
        public void GetTest()
        {
            List<Clients> list = new List<Clients>();

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            driver.Navigate().GoToUrl(url);

            var responseElement = driver.FindElements(By.TagName("Clients"));

            foreach (var n in responseElement)
            {
                var nombre = n.FindElement(By.TagName("nombre"));
                var email = n.FindElement(By.TagName("email"));
                var id = n.FindElement(By.TagName("id"));
                var role = n.FindElement(By.TagName("role"));

                list.Add(new Clients
                {
                    id = id.ToString(),
                    name = nombre.ToString(),
                    email = email.ToString(),
                    role = role.ToString()
                });
            }

            Assert.IsTrue(list != null);
        }

        [TestMethod()]
        public void PostTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetTest1()
        {
            string idtest = "a3b8d425-2b60-4ad7-becc-bedf2ef860bd";
            Clients clientTest = new Clients {
                id = idtest, name = "Barnett",
                email = "barnettblankenship@quotezart.com", role = "user"
            };

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            url = string.Concat(url, string.Concat("/", idtest));
            driver.Navigate().GoToUrl(url);

            var responseElement = driver.FindElements(By.TagName("Clients"));
            Clients clientSelected = null;
            foreach (var n in responseElement)
            {
                clientSelected = new Clients
                {
                    id = n.FindElement(By.TagName("id")).ToString(),
                    name = n.FindElement(By.TagName("nombre")).ToString(),
                    email = n.FindElement(By.TagName("email")).ToString(),
                    role = n.FindElement(By.TagName("role")).ToString()
                };
            }
            Assert.IsTrue(clientSelected.Equals(clientTest));
        }

        [TestMethod()]
        public void DeleteTest()
        {
            Assert.Fail();
        }
    }
}