using System;
using System.Collections.Generic;
using Conversation_1._0.LoginBase_And_Repo;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System.Threading;
using Conversation_1._0.Conversation_Repo;

namespace Conversation_1._0
{
    public class Infraweb
    {
        public IWebDriver driver;
        

        public Infraweb(IWebDriver driver)
        {
            this.driver = driver;
        }

        


        public void ClickOn(By selector)
        {
            IWebElement webElement = GetElement(selector);
            try
            {
                webElement.Click();
            }
            catch (Exception e)
            {
                throw new Exception($"Can't click on {selector}", e);
            }
        }
        public IWebElement GetElement(By selector)
        {
            IWebElement element = null;
            try
            {
                element = driver.FindElement(selector);
            }
            catch (Exception e)
            {
                throw new Exception($"Can't find element in {selector}", e);
            }
            return element;
        }

        public void WaitFor(int i)
        {
            Thread.Sleep(i);
        }

        public IList<IWebElement> GetElements(By selector)
        {
            IList<IWebElement> elementList = null;
            try
            {
                elementList = driver.FindElements(selector);

            }

            catch (Exception e)
            {
                throw new Exception($"Can't find elements in {selector}", e);
            }

            return elementList;

        }

        public IWebElement GetElementInnerElement(IWebElement fatherElement, By childSelector)
        {


            IWebElement element;
            try
            {
                element  = fatherElement.FindElement(childSelector);
            }
            catch (Exception e)
            {
                throw new Exception($"Can't find element in {childSelector} in father element {fatherElement}", e);
            }

            return element;
        }

        public void InsertText(By selector, string str)
        {

            IWebElement element = GetElement(selector);
            
            try
            {
                element.SendKeys(str);
            }
            catch (Exception e)
            {
                throw new Exception($"Can't insert text {str} to element {selector}", e);
            }

        }
        public void Hover(By selector)
        {
            Actions actions = new Actions(driver);
            IWebElement target = GetElement(selector);
            try
            {
                actions.MoveToElement(target).Perform();
            }
            catch (Exception e)
            {
                throw new Exception($"Can't hover over element {selector}", e);
            }
        }

    }
}