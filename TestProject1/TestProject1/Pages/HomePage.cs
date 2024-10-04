using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.DevTools.V126.DOM;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject1.Pages
{
    public class HomePage
    {
        private IWebDriver driver;
        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        IWebElement BtnSignIn => driver.FindElement(By.XPath("/html/body/div[2]/header/div[1]/div/ul/li[2]/a"));

        IWebElement BtnCreateAccount => driver.FindElement(By.LinkText("Create an Account"));

        IWebElement BtnWhatsNew => driver.FindElement(By.LinkText("What's New"));

        IWebElement BtnWomen => driver.FindElement(By.Id("ui-id-4")); //(By.LinkText("Women"));

        IWebElement BtnMen => driver.FindElement(By.Id("ui-id-5")); //(By.LinkText("Men"));

        IWebElement BtnGear => driver.FindElement(By.Id("ui-id-6")); //(By.LinkText("Gear"));

        IWebElement BtnTraining => driver.FindElement(By.Id("ui-id-7")); //(By.LinkText("Gear"));

        IWebElement BtnCart => driver.FindElement(By.XPath("/html/body/div[2]/header/div[2]/div[1]/a"));

        IWebElement BtnCheckOut => driver.FindElement(By.Id("top-cart-btn-checkout"));

        IWebElement BtnDeletemItem => driver.FindElement(By.ClassName("action delete")); // fiendElements?

        IWebElement TxtQty => driver.FindElement(By.ClassName("item-qty cart-item-qty")); // fiendElements?

        IWebElement CheckFlat => driver.FindElement(By.XPath("//*[@id=\"checkout-shipping-method-load\"]/table/tbody/tr[1]/td[1]"));

        IWebElement BtnNext => driver.FindElement(By.XPath("//*[@id=\"shipping-method-buttons-container\"]/div"));

        IWebElement BtnPlaceOrder => driver.FindElement(By.XPath("//*[@id=\"checkout-payment-method-load\"]/div/div/div[2]/div[2]/div[4]/div"));

        IWebElement TxtDone => driver.FindElement(By.XPath("//*[@id=\"maincontent\"]/div[1]/h1/span"));

        IList<IWebElement> ListProduct => driver.FindElements(By.ClassName("product-item-info"));

        IList<IWebElement> LblLeftMenuTitle => driver.FindElements(By.ClassName("filter-options-title"));

        IList<IWebElement> BtnMenuOptions => driver.FindElements(By.XPath("//div[@class='filter-options-content' and contains(@style, 'block')]/ol/li"));

        //Top Page
        public void SingInClick()
        {
            BtnSignIn.Click();
        }

        public void CreatAccountClick()
        {
            BtnCreateAccount.Click();
        }
        // Menu Bar
        public void MenuWahtsNewClick()
        {
            BtnWhatsNew.Click();
        }

        public void MenuWomenClick()
        {
            BtnWomen.Click();
        }

        public void MenuMenClick()
        {
            BtnMen.Click();
        }

        public void MenuGearClick()
        {
            BtnGear.Click();
        }

        public void MenuGearTraining()
        {
            BtnTraining.Click();
        }
        // End MenuBar

        //Select Product Page
        public void clickLeftPanel(string element)
        {
            driver.FindElement(By.LinkText(element)).Click();
        }
        
        public void clickManualLeftFilterOption(string element)
        {
            driver.FindElement(By.XPath($"//div[text()='{element}']")).Click();
        }

        public void clickManualLeftFilterOptionMenu(string element)
        {
            driver.FindElement(By.XPath($"//div[@class='filter-options-content' and contains(@style, 'block')]/ol/li/a/span[contains(text(), '{element}')]"));
        } 


        public void selectLeftPanelRandomFilters(string element)
        {
            driver.FindElement(By.LinkText(element)).Click();
            Random random = new Random();
            int count = LblLeftMenuTitle.Count;
            LblLeftMenuTitle[random.Next(0, count - 1)].Click();
            count = BtnMenuOptions.Count;
            BtnMenuOptions[random.Next(0, count - 1)].Click();
        }

        public void selectRandomLeftPanel()
        {
            Random random = new Random();
            int count = LblLeftMenuTitle.Count;
            LblLeftMenuTitle[random.Next(0,count-1)].Click();
            count = BtnMenuOptions.Count;
            BtnMenuOptions[random.Next(0,count-1)].Click();

        }
        public void SelectRandomProduct()
        {
            Random random = new Random();
            int count = ListProduct.Count;
            ListProduct[random.Next(0, count - 1)].Click();
        }

        //End Select Product Page

        public void click(IWebElement element)
        {
            element.Click();
        }

        //Shopping Cart
        public void ClickShoppingCart()
        {
            BtnCart.Click();
        }

        public void FinishShop()
        {
            BtnCart.Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            BtnCheckOut.Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            CheckFlat.Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            BtnNext.Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            BtnPlaceOrder.Submit();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            Assert.That(TxtDone.Enabled, Is.True);

        }

        //End Shopping Cart


        //Login method
        public void Loing()
        {
            LoginPage loginPage = new LoginPage(driver);
            loginPage.Login("jgalvez@aptest.com.mx", "123Test.123$");
        }
    }
}
