using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using GMailTesting.Configuration;
using log4net;


namespace GMailTesting.Steps
{
    public class Steps
    {
        IWebDriver driver;
        private static readonly ILog logger = LogManager.GetLogger(typeof(Steps));

        public void InitBrowser()
        {
            driver = Driver.DriverInstance.GetInstance();
        }

        public void CloseBrowser()
        {
            Driver.DriverInstance.CloseBrowser();
        }

        public void LoginGMail(string username, string password)
        {
            logger.Info("Log in to Gmail");
            Pages.LoginPage loginPage = new Pages.LoginPage(driver);
            loginPage.OpenPage();
            loginPage.Login(username, password);
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(3));
        }

        // public bool IsLoggedIn(string username)
        //  {
        //     Pages.LoginPage loginPage = new Pages.LoginPage(driver);
        //     return (loginPage.GetLoggedInUserName().Trim().ToLower().Equals(username));
        // }

        //public string IsLoggedIn(string username)
        // {

        //     Pages.LoginPage loginPage = new Pages.LoginPage(driver);
        //      return (loginPage.GetLoggedInUserName().Trim().ToLower());
        //  }

        public void SendMsg(string unametomsg, string theme, string msgtext)
        {


            Pages.InboxPage inboxPage = new Pages.InboxPage(driver);
            inboxPage.SendMsg(unametomsg, theme, msgtext);
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(3));

        }

        public void LogOut(string username)
        {
            Pages.InboxPage inboxPage = new Pages.InboxPage(driver);
            Pages.LoginPage loginPage = new Pages.LoginPage(driver);
            inboxPage.LogOut(username);
          
            loginPage.DelUser();
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(3));

            
        }

        public void SendMsg(string unametomsg, string theme, string msgtext, string filepath)
        {
            
            Pages.InboxPage inboxPage = new Pages.InboxPage(driver);
            inboxPage.SendMsg(unametomsg, theme, msgtext,filepath);
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(3));

        }

        public void MsgCheck()
        {

            Pages.InboxPage inboxpage = new Pages.InboxPage(driver);
            inboxpage.LetterCheck();

        }

       

        public bool IsMsgInSpam()
        {

            Pages.InboxPage inboxpage = new Pages.InboxPage(driver);
            inboxpage.CheckInSpam();
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(3));
            return inboxpage.CheckMsgInSpam();

        }




    }
}
