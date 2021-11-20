using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using CapstoneTesting.pages;
using System.Threading;


namespace JoesPizzaTesting
{
    public class Tests
    {
        IWebDriver driver = new ChromeDriver(@"C:\DoverCorp");
        string url = "http://localhost:4200/";
        
        // IWebDriver driver;
        [SetUp]
        public void Setup()
        {
            driver.Navigate().GoToUrl(url+"home");
            // driver.Close();

        }

        [Test, Order(1)]
        public void userLogin()
        {
            driver.Navigate().GoToUrl(url+"home");

            Home home = new Home(driver);
            home.clickLogin();
            LoginPage loginPage = new LoginPage(driver);

          
            loginPage.Login("appe", "appe");
            Thread.Sleep(2000);
            string expectedUrl = url+"user/1";
            string actualUrl = driver.Url;

            Assert.AreEqual(actualUrl, expectedUrl);
            
        }
        

        [Test, Order(2)]
        public void adminLogin()
        {
            driver.FindElement(By.Id("logout")).Click();
            //driver.Navigate().GoToUrl(url);

            Home home = new Home(driver);
            home.clickLogin();
            LoginPage loginPage = new LoginPage(driver);

            //admin login
            loginPage.Login("admin", "admin");
            Thread.Sleep(2000);

            IWebElement addNew = driver.FindElement(By.Name("addNew"));
            Assert.That(addNew.Displayed, Is.True);
            driver.FindElement(By.Id("logout")).Click();

        }

        [Test, Order(3)]
        public void ProductDetails()
        {
            driver.Navigate().GoToUrl(url+"home");
            Home home = new Home(driver);
            Assert.That(home.PImage.Displayed, Is.True);
            Assert.That(home.PName.Displayed, Is.True);
            Assert.That(home.PPrice.Displayed, Is.True);
            Assert.That(home.PDesc.Displayed, Is.True);

        }
        [Test, Order(4)]
        public void AddToCart()
        {
            userLogin();
            Thread.Sleep(2000);

            Home home = new Home(driver);
            home.addCart();

            Cart cart = new Cart(driver);
            Assert.AreEqual(cart.prodName, "Sugarlite Sugar, 500 gm");

        }

        [Test, Order(5)]
        public void CheckTotal()
        {
            driver.FindElement(By.Id("logout")).Click();
            userLogin();
            Thread.Sleep(5000);

            Home home = new Home(driver);
            
            for(int i=0;i<3;i++)
            {
                home.addCart();
                Thread.Sleep(2000);
                driver.Navigate().GoToUrl(url + "user/1");
                Thread.Sleep(2000);

            }
               
            driver.Navigate().GoToUrl(url + "cart");

            Cart cart = new Cart(driver);
            string expectedTotal = "Pay ₹ 264";
            string actualTotal = cart.payButton;
            Assert.AreEqual(expectedTotal, actualTotal);


        }


    }
}