using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject1.Pages
{
    public class Women : HomePage
    {
        private readonly IWebDriver driver;

        public Women(IWebDriver driver) : base(driver)
        {
            this.driver = driver; 
        }

        //IWebElement btnArticle => driver.FindElement(By.)

        public void BuyExpensiveJacket()
        {
            clickLeftPanel("Jackets");
            clickManualLeftFilterOption("Price");
            clickManualLeftFilterOptionMenu("$80.00");
            SelectRandomProduct();
            ProductPage productPage = new ProductPage(driver);
            Products product = new Products(productPage.getProductName(),productPage.getPrice());
            productPage.SelectRandomSize();
            productPage.SelectRandomColor();
            productPage.setQty("2");
            productPage.AddToCart();
        }

        public void BuySingleProduct(string item)
        {
            selectLeftPanelRandomFilters(item);
            SelectRandomProduct();
            ProductPage productPage = new ProductPage(driver);
            Products product = new Products(productPage.getProductName(), productPage.getPrice());
            productPage.SelectRandomSize();
            productPage.SelectRandomColor();
            productPage.setQty("2");
            productPage.AddToCart();
        }



    }
}
