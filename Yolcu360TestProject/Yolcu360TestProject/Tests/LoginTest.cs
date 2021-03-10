using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using Yolcu360TestProject.Base;

namespace Yolcu360TestProject.Tests
{
    [Binding]
   public class LoginTest 
    {
        public IWebDriver Driver { get; set; }
        public BasePage basePage;
        public Actions action;
        private readonly ScenarioContext context;

        public LoginTest(ScenarioContext contx)
        {
            this.context = contx;
        }

        [BeforeScenario]
        public void Setup()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("start-maximized");
            options.AddArgument("disable-popup-blocking");
            options.AddArgument("disable-notifications");
            options.AddArgument("test-type");
            Driver = new ChromeDriver(options);
            action = new Actions(Driver);
            Driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(30);
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);
            Driver.Navigate().GoToUrl("https://yolcu360.com");
            basePage = new BasePage(Driver);
        }

        [StepDefinition(@"Giris butonuna tiklanir")]
        public void ClickSingButton()
        {
            basePage.ClickElement(By.ClassName("menu-title"));
            basePage.ClickElement(By.XPath("//*[@class='dropdown-menu show']/a"));
        }

        [StepDefinition(@"E-posta alanina '(.*)' yazilir")]
        public void SetUserName(string eMail)
        {
            basePage.SendKeys(By.XPath("//*[@id='ajax-login-form2']/div[1]/input"), eMail);
        }

        [StepDefinition(@"Şifre alanina '(.*)' yazilir")]
        public void SetPassword(string password)
        {
            basePage.SendKeys(By.XPath("//*[@id='ajax-login-form2']/div[2]/input"), password);
        }

        [StepDefinition(@"Giris Yap butonuna tiklanir")]
        public void ClickSignInButton()
        {
            basePage.ClickElement(By.XPath("//button[@class='btn login-btn form-control']"));
        }

        [StepDefinition(@"Basarili giris yapildigi gorulur")]
        public void CheckSuccessLogin()
        {
           string value= basePage.GetText(By.XPath("//*[@id='logged_in_username']/a[1]/span"));
            Assert.IsTrue(value.Contains("Mustafa YARDIMCI"));
        }

        [StepDefinition(@"Basarili giris yapilamadigi gorulur")]
        public void CheckUnSuccessLogin()
        {
            string value = basePage.GetText(By.XPath("//*[@id='ajax-login-form2']/div[2]/span[2]"));
            Assert.IsTrue(value.Contains("Bilinmeyen kullanıcı veya eşleşmeyen şifre."));
        }

        [StepDefinition(@"Bu alanin doldurulmasi zorunludur mesaji gorulur")]
        public void CheckUnSuccessLoginMessage()
        {
            string value = basePage.GetText(By.XPath("//*[@id='ajax-login-form2']/div[2]/span[2]"));
            Assert.IsTrue(value.Contains("Bu alanın doldurulması zorunludur."));
        }

        [AfterScenario]
        public void TearDown()
        {
            Driver.Quit();
        }
    }
}
