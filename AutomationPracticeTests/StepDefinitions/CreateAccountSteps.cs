using AudenAutomation.Driver;
using AudenAutomation.Helpers.TestData;
using AudenAutomation.Helpers;
using AudenAutomation.Pages;
using Coypu;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;

namespace AudenAutomationTests.StepDefinitions
{
    [Binding]
    public class CreateAccountSteps : Steps
    {
        
        public ProductsListing products;
        public GeneratedCustomer customer;
        public ShoppingCart cart;
        public BasePage page;

        [Given(@"I am using a browser")]
        public void GivenIAmUsingABrowser()
        {
            if (BrowserDriver.Instance == null)
            {
                BrowserDriver.Initialise();
            }
        }

        [Given(@"I am a new customer")]
        public void GivenIAmANewCustomer()
        {
            customer = new GeneratedCustomer();
            ScenarioContext.Current.Set<GeneratedCustomer>(customer, "customer");
        }
    }
}
