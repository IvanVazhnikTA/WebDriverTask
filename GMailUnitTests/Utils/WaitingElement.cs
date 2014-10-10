using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace GMailTesting.Utils
{
    class WaitingElement
    {


        public void WaitElement(IWebDriver driver,IWebElement webelement)
        {
            try
            {
                if (webelement.Displayed)
                {
                    webelement.Click();
                }

            }
            catch (Exception e)
            {
                if (e is ElementNotVisibleException || e is NoSuchElementException)
                {
                    driver.Navigate().Refresh();
                    driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(20));
                    WaitElement(driver,webelement);
                }
            }


        }


    }
}
