using SikuliSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumAutomationFramework.PageObjects.Sikuli
{
   public static class HomePageSikuli
    {
        static   ISikuliSession session;
        static IPattern restartButton = Patterns.FromFile(@"C:\Users\TechTeam\Source\Repos\SeleniumAutomationFramework\SeleniumAutomationFramework\SeleniumAutomationFramework.PageObjects\Sikuli\Images\Restart.png");
        static IPattern signInAgainButton = Patterns.FromFile(@"C:\Users\TechTeam\Source\Repos\SeleniumAutomationFramework\SeleniumAutomationFramework\SeleniumAutomationFramework.PageObjects\Sikuli\Images\SignInAgain.png");
        static IPattern homeButton = Patterns.FromFile(@"C:\Users\TechTeam\Source\Repos\SeleniumAutomationFramework\SeleniumAutomationFramework\SeleniumAutomationFramework.PageObjects\Sikuli\Images\HomeButton.png");

        public static void CreateSession()
        {
            session = SikuliSharp.Sikuli.CreateSession();
        }

        public static void RestartSession()
        {
            if (session.Exists(restartButton, 5))
            {
                session.Click(restartButton);
                session.Click(signInAgainButton);
            }
        }
        public static void ReturnHome()
        {
            if (session.Exists(homeButton, 5))
            {
                session.Click(homeButton);
            }
        }
    }
}
