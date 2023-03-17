﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;

namespace UnitTestWebDriver1
{
    [TestClass]
    public class UnitTest1
    {
        IWebDriver driver = new EdgeDriver(@"C:\WebDrivers\edgedriver_win64");

        [TestInitialize] 
        public void Setup() 
        {
            driver.Navigate().GoToUrl("https://localhost:44306/");
            System.Threading.Thread.Sleep(1000);
            IWebElement element = driver.FindElement(By.LinkText("Log in"));
            element.Click();
            element = driver.FindElement(By.Id("MainContent_Email"));
            element.SendKeys("user1@wp.pl");
            element = driver.FindElement(By.Id("MainContent_Password"));
            element.SendKeys("Pa$$w0rd!");
            element = driver.FindElement(By.Name("ctl00$MainContent$ctl05"));
            element.Click();
        }

        [TestMethod]
        public void TestMethod1()
        {
        }
    }
}