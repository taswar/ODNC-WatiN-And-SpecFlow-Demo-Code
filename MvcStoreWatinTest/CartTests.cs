using Microsoft.VisualStudio.TestTools.UnitTesting;
using WatiN.Core;

namespace MvcStoreWatinTest
{
    [TestClass]
    public class CartTests
    {
        [TestMethod]
        public void Adding_Items_ToCart()
        {
            using (var browser = new IE())
            {
                browser.GoTo("http://localhost:1100/");

                browser.BringToFront();

                browser.Link(Find.ByText("Pop")).Click();

                browser.Link(Find.ByText("Frank")).Click();

                browser.Link(Find.ByText("Add to cart")).Click();                

                Assert.IsTrue(browser.ContainsText("8.99"));
            }
        }

        [TestMethod]
        public void RemoveItemsFromCart()
        {
            using (var browser = new IE())
            {
                browser.GoTo("http://localhost:1100/");

                browser.BringToFront();

                browser.Link(Find.ByText("Pop")).Click();

                browser.Link(Find.ByText("Frank")).Click();

                browser.Link(Find.ByText("Add to cart")).Click();

                browser.Link(Find.BySelector("a.RemoveLink")).Click();

                Assert.IsTrue(browser.ContainsText("0"));

            }
        }
    }
}
