using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace GMailTesting.Pages
{
   public abstract class AbstractPage
    
   {
       public abstract void OpenPage();

       public bool IsElementPresent(By locator)
       {
           return Driver.DriverInstance.GetInstance().FindElements(locator).Count > 0;
       }


   }
}
