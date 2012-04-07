using Coypu;
using TechTalk.SpecFlow;

namespace Tests.Acceptance.Steps
{
    [Binding]
    public class BrowserConfig
    {
        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            Configuration.AppHost = "localhost";
            Configuration.Port = 56785;
            Configuration.SSL = false;
            Configuration.Browser = Coypu.Drivers.Browser.Chrome;
        }

        [AfterTestRun]
        public static void AfterTestRun()
        {
            Browser.EndSession();
        }
    }
}
