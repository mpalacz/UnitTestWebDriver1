﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;

namespace UnitTestWebDriver1
{
    [TestClass]
    public class UnitTest1
    {
        IWebDriver driver = new EdgeDriver();

        [TestInitialize] 
        public void Setup() 
        {
            driver.Navigate().GoToUrl("https://localhost:44306/");
            IWebElement element = driver.FindElement(By.LinkText("Log in"));
            element.Click();
            element = driver.FindElement(By.Id("MainContent_Email"));
            element.SendKeys("user1@wp.pl");
            element = driver.FindElement(By.Id("MainContent_Password"));
            element.SendKeys("Pa$$w0rd!");
            element = driver.FindElement(By.Name("ctl00$MainContent$ctl05"));
            element.Click();
        }

        [TestCleanup]
        public void Cleanup()
        {
            IWebElement element = driver.FindElement(By.LinkText("Log off"));
            element.Click();
            driver.Manage().Cookies.DeleteAllCookies();
            driver.Quit();
        }

        [TestMethod]
        public void TestMethod1()
        {
            string expectedValue = "Hello, user1@wp.pl !";
            string resultValue = driver.FindElement(By.CssSelector("a[title='Manage your account']")).Text;
            Assert.AreEqual(expectedValue, resultValue);

            expectedValue = "Home Page - My ASP.NET Application";
            resultValue = driver.Title;
            Assert.AreEqual(expectedValue, resultValue);

            expectedValue = "ASP.NET";
            resultValue = driver.FindElement(By.Id("aspnetTitle")).Text;
            Assert.AreEqual(expectedValue, resultValue);

            IWebElement element = driver.FindElement(By.LinkText("About"));
            element.Click();
            expectedValue = "About - My ASP.NET Application";
            resultValue = driver.Title;
            Assert.AreEqual(expectedValue, resultValue);

            element = driver.FindElement(By.LinkText("Contact"));
            element.Click();
            expectedValue = "Contact - My ASP.NET Application";
            resultValue = driver.Title;
            Assert.AreEqual(expectedValue, resultValue);
        }
    }
}
