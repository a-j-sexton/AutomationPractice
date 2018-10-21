using AudenAutomation.Helpers.TestData;
using AudenAutomation.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;

namespace AudenAutomationTests.StepDefinitions
{
    [Binding]
    public sealed class PageSteps
    {
        private GeneratedCustomer customer;
        public BasePage page;
        private bool customerRegistered = false;

        [Then(@"I am logged in")]
        public void ThenIAmLoggedIn()
        {
            Assert.IsTrue(page.IsLoggedIn(), "FAIL: BasePage was not logged in");
        }

        [Given(@"I go to the '(.*)' tab"),
            When(@"I go to the '(.*)' tab")]
        public void IGoToTheTab(string itsALinkName)
        {
            page.ClickLink(itsALinkName);
        }

        [When(@"I order results by 'Price: Highest first""")]
        public void IOrderResultsByPriceHighestFirst()
        {
            page.SelectOptionFromDropDown("Price: Highest first", "Sort by");
        }

        [Given(@"I have registered an account")]
        public void GivenIHaveRegisteredAnAccount()
        {
            if (!customerRegistered)
            {
                GivenIRegisterANewAccount();
            }
        }


        [Given(@"I have navigated to ""(.*)""")]
        public void GivenIHaveNavigatedTo(string url)
        {
            if (page == null) {
                page = new BasePage();
                ScenarioContext.Current.Set<BasePage>(page, "page");
            }
            page.Goto(url);
        }

        [Given(@"I have registered a new account")]
        [When(@"I register a new account")]
        public void GivenIRegisterANewAccount()
        {
            customer = ScenarioContext.Current.Get<GeneratedCustomer>("customer") ;
            GivenLoginStatus(false);
            page.ClickLink("Sign in");
            page.Form("Create an account").FillInEditBoxWithContent("Email address", customer.email);
            page.Form("Create an account").ClickButton("Create an account");
            page.WaitForContent("Your personal information");
            page.ChooseRadioButtonFromOptions("Mr.", "Title");
            page.FillInEditBoxWithContent("First name", customer.firstname);
            page.FillInEditBoxWithContent("Last name", customer.surname);
            page.FillInEditBoxWithContent("Email", customer.email);
            page.FillInEditBoxWithContent("Password", customer.password);
            page.SetDatePicker("Date of Birth", customer.dob);
            page.ClickCheckBox("Sign up for our newsletter!");
            page.ClickCheckBox("Receive special offers from our partners!");
            page.FillInEditBoxWithContent("Company", "skdfnsdoklf");
            page.FillInEditBoxWithContent("Address", "skdfnsdoklf");
            page.FillInEditBoxWithContent("Address (Line 2)", "skdfnsdoklf");
            page.FillInEditBoxWithContent("City", "skdfnsdoklf");
            page.SelectOptionFromDropDown("Colorado", "State");
            page.FillInEditBoxWithContent("Zip/Postal Code", "12345");
            page.SelectOptionFromDropDown("United States", "Country");
            page.FillInEditBoxWithContent("Additional information", "skdfnsdoklf");
            page.FillInEditBoxWithContent("Home phone", "0123456789");
            page.FillInEditBoxWithContent("Mobile phone", "07987456321");
            page.ClickButton("Register");
            customerRegistered = true;
        }

        [Given(@"I am logged (.*)"), When(@"I am logged (.*)")]
        [Given(@"I log(.*)"), When(@"I log(.*)")]
        public void GivenLoginStatus(bool Truthiness)
        {
            bool _loggedIn = page.IsLoggedIn();
            if (Truthiness)
            {
                if (!_loggedIn)
                {
                    page.ClickLink("Sign in");
                    page.Form("Already registered?")
                        .FillInEditBoxWithContent("Email address", customer.email);
                    page.Form("Already registered?")
                        .FillInEditBoxWithContent("Password", customer.password);
                    page.Form("Already registered?").ClickButton("Sign in");

                }
                return;
            }

            else
            {
                if (_loggedIn) { page.LogOut(); }
            }
        }

        [StepArgumentTransformation("(in|out)")]
        public bool Truthiness(string truth)
        {
            switch (truth)
            {
                case "in": return true;
                default: return false;
            }

        }
    }
}
