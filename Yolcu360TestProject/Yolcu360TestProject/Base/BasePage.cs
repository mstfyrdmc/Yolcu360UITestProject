using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yolcu360TestProject.Base
{
   public class BasePage
    {
        IWebDriver driver;
        public BasePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public IWebElement FindElement(By by)
        {
            return driver.FindElement(by);
        }

        public void ClickElement(By by)
        {
            FindElement(by).Click();
        }

        public void SendKeys(By by,string value)
        {
            FindElement(by).SendKeys(value);
        }

        public string GetText(By by)
        {
           return FindElement(by).Text;

        }
    }
    
}
