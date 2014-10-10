using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using GMailTesting.Utils;
using System.Windows.Forms;

namespace GMailTesting.Pages
{
    class InboxPage : AbstractPage
    {
        private const string BASE_URL = "https://mail.google.com/mail/#inbox";
        private const string SPAM_URL = "https://mail.google.com/mail/#spam";

        [FindsBy(How = How.XPath, Using = "//div[@class = 'T-I J-J5-Ji T-I-KE L3']")]
        private IWebElement buttonWrite;

        [FindsBy(How = How.XPath, Using = "//textarea[@class = 'vO']")]
        private IWebElement msgTo;

        [FindsBy(How = How.XPath, Using = "//input[@class = 'aoT']")]
        private IWebElement msgTheme;

        [FindsBy(How = How.XPath, Using = "//div[@class ='Am Al editable']/iframe")]
        private IWebElement msgArea;

        [FindsBy(How = How.XPath, Using = "//div[@class = 'T-I J-J5-Ji aoO T-I-atl L3']")]
        private IWebElement buttonSendMsg;

       // [FindsBy(How = How.XPath, Using = "//div[text() = 'Письмо отправлено.']")]
      //  private IWebElement msgSended;

     
        [FindsBy(How = How.XPath, Using = "//div[@class  = 'a1 aaA aMZ']")]
        private IWebElement buttonAttach;


        [FindsBy(How = How.XPath, Using = "//div[@class  = 'UI']")]
        private IWebElement fieldUI;

        [FindsBy(How = How.XPath, Using = "//span[@email = 'tatestuser1@gmail.com']")]
        private IWebElement buttonMsg;
        [FindsBy(How = How.XPath, Using = "//img[@class='hA T-I-J3'][@role ='menu']")]
        private IWebElement buttonMenu;

      
        [FindsBy(How = How.XPath, Using = "//div[@class='cj'][@act='9']")]
        private IWebElement buttonSpam;

        [FindsBy(How = How.XPath, Using = "//a[@class='J-Ke n0 aBU']")]
        private IWebElement buttonMainSpam;

        [FindsBy(How = How.XPath, Using = "//span[@class= 'CJ']")]
        private IWebElement buttonAll;


        [FindsBy(How = How.XPath, Using = "//span[@email = 'tatestuser1@gmail.com']")]
        private IWebElement spamMsg;


        
        private IWebDriver driver;
       
         public InboxPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(this.driver, this);
        }

         public override void OpenPage()
         {
             driver.Navigate().GoToUrl(BASE_URL);
             Console.WriteLine("Inbox Page opened");
         }

        public void SendMsg(string unametomsg, string theme,string msgtext)
         {
             buttonWrite.Click();
             msgTo.SendKeys(unametomsg);
             msgTheme.SendKeys(theme);
             msgArea.SendKeys(msgtext);
             buttonSendMsg.Click();
            
             
         }

        public void SendMsg(string unametomsg, string theme, string msgtext, string filepath)
        {
            buttonWrite.Click();
            msgTo.SendKeys(unametomsg);
            msgTheme.SendKeys(theme);
            msgArea.SendKeys(msgtext);

            buttonAttach.Click();
           // SendKeys.Send(filepath + "{ENTER}");
            buttonSendMsg.Click();


        }


        public void LogOut(string username)
        {
            IWebElement linkUser = driver.FindElement(By.XPath("//a[text() = '" + username + "']"));
            linkUser.Click();
            IWebElement linkUserExit = driver.FindElement(By.XPath("//a[@class='gb_1b gb_7b gb_V']"));
            linkUserExit.Click();
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(3));

        }

        public void LetterCheck()
        {
            fieldUI.Click();
            buttonMenu.Click();
            buttonSpam.Click();
        }

        public void CheckInSpam()
        {

            driver.Navigate().GoToUrl(SPAM_URL);
            //buttonAll.Click();
           // buttonMainSpam.Click();
            //spamMsg.Enabled;
        }

        public bool CheckMsgInSpam()
        {
            if (spamMsg.Enabled)
            {
                return true;
            }
            else
                return false;


        }

    }
}
