using Coypu;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace Tests.Acceptance.Steps
{
    [Binding]
    public class NavigationSteps
    {
        [Given(@"I am logged in")]
        public void GivenIAmLoggedIn()
        {
            var browser = Browser.Session;
            browser.Visit("/Membership/Logon");
            browser.FillIn("UserName").With("user1");
            browser.FillIn("Password").With("password");
            browser.ClickButton("Log On");
            Assert.IsTrue(browser.Has(() => browser.FindLink("Log off user1")), "Can't find log off link");
        }

        [When(@"I navigate to (.*)")]
        public void WhenINavigateToTheMoviePage(string relativeUrl)
        {
            var browser = Browser.Session;
            browser.Visit(relativeUrl);
            VerifyPageLoadedWithoutError();
        }

        [When(@"I click the ""(.*)"" link")]
        public void WhenIClickTheLink(string linkText)
        {
            var browser = Browser.Session;
            browser.ClickLink(linkText);
            VerifyPageLoadedWithoutError();
        }

        [Then(@"the list of movies should appear on the screen")]
        public void ThenTheListOfMoviesShouldAppearOnTheScreen()
        {
            ScenarioContext.Current.Pending();
        }

        private void VerifyPageLoadedWithoutError()
        {
            var browser = Browser.Session;
            Assert.IsTrue(browser.HasNoContent("404 Not Found"), "Page not found");
            Assert.IsTrue(browser.HasNoContent("Server Error"), "View not found");
        }
    }
}
