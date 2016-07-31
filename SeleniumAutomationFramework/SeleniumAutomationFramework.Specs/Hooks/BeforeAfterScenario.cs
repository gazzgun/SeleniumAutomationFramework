using SeleniumAutomationFramework.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace SeleniumAutomationFramework.Specs.Hooks
{
    [Binding]
    public class BeforeAfterScenario
    {
        [BeforeScenario]
        public void BeforeScenario()
        {
            TestBase.TestSetup();
        }
        [AfterScenario]
        public void AfterScenario()
        {
            TestBase.TearDown();
        }
    }
}
