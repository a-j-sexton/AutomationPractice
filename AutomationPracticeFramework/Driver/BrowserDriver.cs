using Coypu;
using Coypu.Drivers;
using Coypu.Drivers.Selenium;
using OpenQA.Selenium;

namespace AudenAutomation.Driver
{
    public static class BrowserDriver
    {
        public static BrowserSession Instance { get; set; }

        public static void Initialise()
        {
            var config = new SessionConfiguration
            {
                Port = 3371,
                Browser = Browser.Chrome,
                Driver = typeof(SeleniumWebDriver)
            };
            Instance = new BrowserSession(config);
        }

        public static void End()
        {
            Instance.Dispose();
        }

        public class Iniitalise
        {
        }
    }

    public static class SeleniumDriver
    {
        public static IWebDriver Instance
        {
            get
            {
                return (OpenQA.Selenium.IWebDriver)BrowserDriver.Instance.Native;
            }

        }

    }
}
