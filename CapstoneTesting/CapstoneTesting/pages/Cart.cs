using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace CapstoneTesting.pages
{
    class Cart
    {
        private IWebDriver driver { get; }

        public string prodName => driver.FindElement(By.Name("PName")).Text;
        public string payButton=> driver.FindElement(By.Id("payButton")).Text;
        public Cart(IWebDriver Webdriver)
        {
            driver = Webdriver;
        }

    }
}
