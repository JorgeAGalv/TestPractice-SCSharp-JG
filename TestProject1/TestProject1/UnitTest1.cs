using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Reflection;
using TestProject1.Pages;

namespace TestProject1
{
    public class Tests
    {
        private IWebDriver driver;
        private HomePage homePage;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://magento.softwaretestingboard.com/what-is-new.html");
            driver.Manage().Window.Maximize();
            //homePage = new HomePage(driver);
        }

        [Test]
        public void TestLogin()
        {
            homePage.SingInClick();
            LoginPage loginPage = new LoginPage(driver);
            loginPage.Login("jgalvez@aptest.com.mx", "123Test.123$");   
            
        }

        [Test]
        public void TestBuyExpensiveJacket()
        {
            Women women = new Women(driver);
            women.SingInClick();
            women.Loing();
            women.MenuWomenClick();
            women.BuyExpensiveJacket();
            women.FinishShop();
        }

        [Test]
        public void TestWomenSingleProduct()
        {
            Women women = new Women(driver);
            women.SingInClick();
            women.Loing();
            women.MenuWomenClick();
            women.BuySingleProduct("Pants");
            women.FinishShop();
        }

        [TearDown]
        public void TearDown()
        {
            driver.Close();
        }

    }
}