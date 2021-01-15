using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;
using System.Xml;

namespace SeleniumCore
{
    public class Tests
    {
        //hooks for nuint.
        [SetUp]
        public void Setup()
        {
           
        }

        [Test]
        public void Test1()
        {
            IWebDriver webDriver = new ChromeDriver();
           
            webDriver.Navigate().GoToUrl("http://issue2.gmoneytrans.net/admin/remit/");
            //Assert.Pass();

            //put values
            var txtusername = webDriver.FindElement(By.Name("EName"));
            txtusername.SendKeys("admin");
            webDriver.FindElement(By.Id("EPass")).SendKeys("Gmoney@1122");
            webDriver.FindElement(By.Id("eCode")).SendKeys("11");
            Thread.Sleep(1000);
            webDriver.FindElement(By.Id("Login")).Click();

          
            Actions builder = new Actions(webDriver);
            IWebElement menuHoverLink = webDriver.FindElement(By.XPath("//div[@class='mainBodyAndMenu']/div[@class='Menu']/ul[@class='mainMenu']/li[@class='MainMenuList']/span[text()='New Reports']"));
            builder.MoveToElement(menuHoverLink);

            IWebElement subLink = webDriver.FindElement(By.XPath("//div[@class='mainBodyAndMenu']/div[@class='Menu']/ul[@class='mainMenu']/li[@class='MainMenuList']//a[text()='Convenience Store Payment']"));
            builder.MoveToElement(subLink);
            builder.Click();
            builder.Build().Perform();

            webDriver.SwitchTo().Frame("");
            IWebElement element =webDriver.FindElement(By.XPath("//form//input[@name='fromDate']"));
            element.SendKeys("2020-09-14");
            //WebElement dateBox = webDriver.FindElement(By.XPath("//form//input[@name='bdaytime']"));
            //webDriver1.FindElement(By.Name("customer_sno")).SendKeys("528475");
            Thread.Sleep(1000);
            webDriver.FindElement(By.Id("Search")).Click();
            // webDriver.FindElement(By.XPath("//div[@class='mainBodyAndMenu']/div/ul/li/ul/li/a[@title='Define Credit Limit']")).Click();


        }
        [Test]
        public void Test_API()
        {
            IWebDriver webDriver = new ChromeDriver();
            webDriver.Navigate().GoToUrl("http://issue2.gmoneytrans.net/gmoneytransUAT_V10_app/webservice.asmx?op=CIValue_Check");
            //Assert.Pass();

            //put values
            
            webDriver.FindElement(By.Name("AGENT_CODE")).SendKeys("GMAPS");
            webDriver.FindElement(By.Name("USER_ID")).SendKeys("IOSGMT");
            webDriver.FindElement(By.Name("Lang_Code")).SendKeys("en");
            webDriver.FindElement(By.Name("CustomerID")).SendKeys("528142");
            webDriver.FindElement(By.Name("Version")).SendKeys("Version");
            webDriver.FindElement(By.Name("SIGNATURE")).SendKeys("kjashdjkad");
            webDriver.FindElement(By.ClassName("Button")).Click();
            



        }

    }
}