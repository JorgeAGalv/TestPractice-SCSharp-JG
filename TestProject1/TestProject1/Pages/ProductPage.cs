using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject1.Pages
{
    public class ProductPage
    {
        private readonly IWebDriver driver;

        public ProductPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        IWebElement LblName => driver.FindElement(By.ClassName("base"));

        IWebElement LblPrice => driver.FindElement(By.ClassName("price"));

        IWebElement TxtQty => driver.FindElement(By.Id("qty"));

        IWebElement BtnAddCart => driver.FindElement(By.Id("product-addtocart-button"));

        IList<IWebElement> BtnSize => driver.FindElements(By.XPath("//div[contains(@class, 'swatch-option') and contains(@class, 'text')]"));

        IList<IWebElement> BtnColor => driver.FindElements(By.XPath("//div[contains(@class, 'swatch-option') and contains(@class, 'color')]"));

        IWebElement MsgConfirmation => driver.FindElement(By.XPath("//*[@id=\"maincontent\"]/div[1]/div[2]/div/div/div"));


        public string getProductName()
        {
            return LblName.Text;
        }

        public string getPrice()
        {
            string price = LblPrice.Text;
            price = price.Replace("$", "");
            price = price.Replace(".00", "");
            return price.Trim();
        }

        public void SelectRandomSize()
        {   
            Random random = new Random();
            int count = BtnSize.Count();
            BtnSize[random.Next(0, count - 1)].Click();
        }

        public void SelectRandomColor()
        {
            Random random = new Random();
            int count = BtnColor.Count();
            BtnColor[random.Next(0, count - 1)].Click();
        }

        public void setQty(string qty)
        {
            TxtQty.Clear();
            TxtQty.SendKeys(qty);
        }

        public void AddToCart()
        {
            BtnAddCart.Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            Assert.That(MsgConfirmation.Enabled, Is.True);
        }

    }
}
