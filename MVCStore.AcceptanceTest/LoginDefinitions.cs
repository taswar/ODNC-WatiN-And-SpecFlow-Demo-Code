using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;
using WatiN.Core;

namespace MVCStore.AcceptanceTest
{
    [Binding]
    public class LoginDefinitions
    {
        [Given(@"I have filled out all required information")]
        public void GivenIHaveFilledOutAllRequiredInformation()
        {
            WebBrowser.Current.GoTo("http://localhost:1100/");

            WebBrowser.Current.BringToFront();

            WebBrowser.Current.Link(Find.ByText("Admin")).Click();

            WebBrowser.Current.TextField(Find.ById("UserName")).TypeText("administrator");

            WebBrowser.Current.TextField(Find.ById("Password")).TypeText("password123!");
        }

        [Then(@"I should be redirected to the full list of record entries and see a Log Out message")]
        public void ThenIShouldBeRedirectedToTheFullListOfRecordEntriesAndSeeALogOutMessage()
        {
            Assert.IsTrue(WebBrowser.Current.Link(Find.ByText("Log Out")).Exists);
        }

        [When(@"I press Log In")]
        public void WhenIPressLogIn()
        {
            WebBrowser.Current.Element(Find.BySelector("input.LogOn")).Click();
        }

    }
}
