using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;


namespace GMailTesting.Pages
{
    public class LoginPage : AbstractPage
    {

        private const string BASE_URL = "https://www.gmail.com";

        [FindsBy(How = How.Id, Using = "Email")]
        private IWebElement inputLogin;

        [FindsBy(How = How.Id, Using = "Passwd")]
        private IWebElement inputPassword;

        [FindsBy(How = How.XPath, Using = "//input[@id = 'signIn']")]
        private IWebElement buttonSubmit;

      //  [FindsBy(How = How.XPath, Using = "//a[@title='Аккаунт tatestuser1@gmail.com']")]
      //  private IWebElement linkLoggedInUser;

        [FindsBy(How = How.XPath, Using = "//div[@id='remove-link']")]
        private IWebElement buttonDel;

        private IWebDriver driver;

        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(this.driver, this);
        }

        public override void OpenPage()
        {
            driver.Navigate().GoToUrl(BASE_URL);
            Console.WriteLine("Login Page opened");
        }

        public void Login(string username, string password)
        {
            inputLogin.SendKeys(username);
            inputPassword.SendKeys(password);
            buttonSubmit.Click();
        }

        public void DelUser()
        {
           
            buttonDel.Click();
            //driver.Navigate().Refresh();

        }

       // public string GetLoggedInUserName()
      //  {
       //     return linkLoggedInUser.Text;
       // }
        

    }
}
