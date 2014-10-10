using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium;
using NUnit.Framework;



namespace GMailTesting.Tests
{
    [TestFixture]
    public class SpamTest
    {

        private Steps.Steps steps = new Steps.Steps();
        private const string USERNAME = "tatestuser1@gmail.com";
        private const string USER2NAME = "tatestuser2@gmail.com";
        private const string PASSWORD = "vms3icqu";

        private const string USERNAMETOSEND = "tatestuser2@gmail.com";
        private const string THEME = "SpamTest";
        private const string MSGTEXT = "spam spam spam";
     

        [SetUp]
        public void Init()
        {
            steps.InitBrowser();
            steps.LoginGMail(USERNAME, PASSWORD);
            steps.SendMsg(USERNAMETOSEND, THEME, MSGTEXT);
            steps.LogOut(USERNAME);
            steps.LoginGMail(USER2NAME, PASSWORD);
            steps.MsgCheck();
            steps.LogOut(USER2NAME);
            steps.LoginGMail(USERNAME, PASSWORD);
            steps.SendMsg(USERNAMETOSEND, THEME, MSGTEXT);
            steps.LogOut(USERNAME);
            steps.LoginGMail(USER2NAME, PASSWORD);
            
            
        }

        [TearDown]
        public void Cleanup()
        {
            steps.CloseBrowser();
            
        }

        [Test]
        public void MsgFromUserInSpam()
        {                          
           Assert.True(steps.IsMsgInSpam());                
                  
        }


    }
}
