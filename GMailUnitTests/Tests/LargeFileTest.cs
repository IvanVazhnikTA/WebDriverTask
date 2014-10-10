using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium;
using NUnit.Framework;
using System.Threading;


namespace GMailTesting.Tests
{
    class LargeFileTest
    {
        private Steps.Steps steps = new Steps.Steps();
        private const string USERNAME = "tatestuser1@gmail.com";
        private const string PASSWORD = "vms3icqu";
        private const string THEME = "55555";
        private const string TEXT = "SOMETEXT";
        private const string FILEPATH = "G:\\Video\\Xman.mkv";


        [SetUp]
        public void Init()
        {
            steps.InitBrowser();

        }

        [TearDown]
        public void Cleanup()
        {
            steps.CloseBrowser();

        }


        [Test]
        public void TryToAttachLargeFile()
        {
            steps.LoginGMail(USERNAME, PASSWORD);
            steps.SendMsg(USERNAME, THEME, TEXT, FILEPATH);



        }


    }
}
