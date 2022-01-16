using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Threading;
using System.Linq;
using Conversation_1._0.Login;

namespace Conversation_1._0
{
    public class SeleniumBase 

    {

        private IWebDriver driver = null;
        //public IWebDriver driver = new ChromeDriver("C:/dev");
        public Infraweb _Infra;

        [SetUp]
        public void CreateDriver()
        {
            driver = new ChromeDriver(@"C:/dev");
            driver.Manage().Window.Maximize();
            this._Infra = new Infraweb(this.driver);
        }


        [TearDown]
        public void TearDown()
        {
            driver.Close();
        }

    }
}
