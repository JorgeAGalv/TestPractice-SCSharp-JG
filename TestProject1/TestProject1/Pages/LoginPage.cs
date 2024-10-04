using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject1.Pages
{
    public class LoginPage
    {
        private readonly IWebDriver driver;

        public LoginPage(IWebDriver driver)
        {
            this.driver=driver;
        }

        IWebElement TxtEmail => driver.FindElement(By.Id("email"));

        IWebElement TxtPassword => driver.FindElement(By.Id("pass"));

        IWebElement BtnSingIn => driver.FindElement(By.Id("send2"));

        public void Login(string username, string password)
        {
            TxtEmail.Clear();
            TxtEmail.SendKeys(username);
            TxtPassword.Clear();
            TxtPassword.SendKeys(password);
            BtnSingIn.Submit();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
        }
    }
}
