using AudenAutomation.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;

namespace AudenAutomationTests.StepDefinitions
{
    [Binding]
    public sealed class CartSteps
    {
        private ShoppingCart cart;

        [Then(@"an item priced ""(.*)"" is in the cart")]
        public void ThenAnItemPricedIsInTheCart(string expectedPrice)
        {
            cart = new ShoppingCart();
            string actualPrice = cart.ProductByIndex(0).Price;
            Assert.AreEqual(expectedPrice, actualPrice, "FAIL: Expecting the first item to " +
                 "have a price of {0}, actual {1}", expectedPrice, actualPrice);

        }
    }
}
