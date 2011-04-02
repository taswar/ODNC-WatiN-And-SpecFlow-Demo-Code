using Microsoft.VisualStudio.TestTools.UnitTesting;
using WatiN.Core;

namespace MvcStoreWatinTest
{
    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    [TestClass]
    public class HomeTests
    {
        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void Home_HasMvcStoreHasTitle_True()
        {
            var browser = new IE("http://localhost:1100/");

            browser.BringToFront();
            Assert.IsTrue(browser.ContainsText("ASP.NET MVC MUSIC STORE"));

            browser.Close();

        }

        [TestMethod]
        public void Home_ClickOnRockContainsRockAlbumText_True()
        {
            using (var browser = new IE("http://localhost:1100/"))
            {

                browser.BringToFront();

                browser.Link(Find.ByText("Rockssss")).Click();
                Assert.IsTrue(browser.ContainsText("Rock Albums"));

            }
        }

        [TestMethod]
        public void Login_UnSuccessful_Should_Have_Error()
        {
            var browser = new IE();
            
            
                browser.GoTo("http://localhost:1100/");

                browser.BringToFront();

                browser.Link(Find.ByText("Admin")).Click();

                browser.TextField(Find.ById("UserName")).TypeText("admin");
                
                browser.TextField(Find.ById("Password")).TypeText("1234");

                browser.Element(Find.BySelector("input.LogOn")).Click();

                Assert.IsTrue(browser.ContainsText("Login was unsuccessful."));
            
        }


        [TestMethod]
        public void Login_WithoutUsernameAndPassword_Should_Have_ErrorMessage()
        {
            using (var browser = new IE())
            {
                browser.GoTo("http://localhost:1100/");

                browser.BringToFront();

                browser.Link(Find.ByText("Admin")).Click();
               
                browser.Element(Find.BySelector("input.LogOn")).Click();

                Assert.IsTrue(browser.ContainsText("The User name field is required"));

                Assert.IsTrue(browser.ContainsText("The Password field is required."));
            }

        }

        [TestMethod]
        public void Login_Successful_Should_Have_LogOut_Link()
        {
            using (var browser = new IE())
            {
                browser.GoTo("http://localhost:1100/");

                browser.BringToFront();

                browser.Link(Find.ByText("Admin")).Click();

                //browser.Element(x => x.)

                browser.TextField(Find.ById("UserName")).TypeText("administrator");

                browser.TextField(Find.ById("Password")).TypeText("password123!");

                browser.Element(Find.BySelector("input.LogOn")).Click();

                Assert.IsTrue(browser.Link(Find.ByText("Log Out")).Exists);

                browser.Link(Find.ByText("Log Out")).Click();

            }
        }
        
    }
}
