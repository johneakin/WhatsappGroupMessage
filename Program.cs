using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace WhatsappGroupMessage
{
    class Program
    {
        static void Main(string[] args)
        {
            Process proc = new Process();
            proc.StartInfo.FileName = @"C:\Program Files (x86)\Google\Chrome\Application\chrome.exe";
            proc.StartInfo.Arguments = "--remote-debugging-port=9333 --user-data-dir=C:\\Temp\\WhatsApp";
            proc.Start();

            System.Threading.Thread.Sleep(2000);

            ChromeOptions options = new ChromeOptions();
            options.DebuggerAddress = "127.0.0.1:9333";
            ChromeDriver driver = new ChromeDriver(options);

            driver.Navigate().GoToUrl("https://web.whatsapp.com/");


            //Wait until the group is visible
            //Note: If Whatsapp isn't linked to phone then you'll see a prompt which you manually need to do first
            IWait<IWebDriver> wait = new OpenQA.Selenium.Support.UI.WebDriverWait(driver, TimeSpan.FromSeconds(3600));
            IWebElement element = wait.Until(ExpectedConditions.ElementExists(By.XPath("//span[@title='test']")));
           


            try
            {
                //Open group (In this example the group is called 'test', Modify the group name as required
                driver.FindElement(By.XPath("//span[@title='test']")).Click();

                //Type message
                driver.FindElement(By.XPath("//div[@title='Type a message']")).SendKeys("This is a test");

                //Press Enter
                driver.FindElement(By.XPath("//div[@title='Type a message']")).SendKeys(Keys.Enter);
            }
            catch (Exception ex)
            { }

        }

       
    }
}
