using AudenAutomation.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;

namespace AudenAutomationTests.StepDefinitions
{
    [Binding]
    public sealed class ProductSteps
    {
        public ProductsListing products;
        private BasePage page = ScenarioContext.Current.Get<BasePage>("page");

        // For additional details on SpecFlow step definitions see http://go.specflow.org/doc-stepdef
        [Given(@"I add the item priced ""(.*)"" to the cart")]
        [When(@"I add the item priced ""(.*)"" to the cart")]
        public void IAddTheItemPriceToTheCart(string price)
        {
            if (products == null) { products = new ProductsListing(); }
            products.ProductByPrice(price).ClickButton("Add to cart");
            page.ClickButton("Proceed to checkout");
        }

        [Then(@"the first product is priced ""(.*)""")]
        public void ThenTheFirstProductIsPriced(string expectedPrice)
        {
            if (products == null) { products = new ProductsListing(); }
            string actualPrice = products.ProductByIndex(0).Price;
            Assert.AreEqual(expectedPrice, actualPrice, "FAIL: Expecting the first item to " +
                "have a price of {0}, actual {1}", expectedPrice, actualPrice);
        }
    }
}
