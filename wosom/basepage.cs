
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using System.Threading;

namespace wosom
{
    public class basePage
    {
        public TestContext instance;
        public TestContext TestContext
        {
            set { instance = value; }
            get { return instance; }
        }
        public static IWebDriver driver;
        public IWebDriver openBrowser(string Browser)
        {
            IWebDriver driver = null;
            if (Browser == "Chrome")
            {
                ChromeOptions options = new ChromeOptions();
                options.AddArguments("--start-maximized");
                driver = new ChromeDriver(options);

            }
            else if (Browser == "Firefox")
            {

                driver = new FirefoxDriver();
            }
            else
                if (Browser == "Edge")
            {
                driver = new EdgeDriver();
            }
            return driver;
        }
        public static void ScrollToElement(By by)
        {
            var scrollToElement = driver.FindElement(by);
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", scrollToElement);
        }
        public static void CloseDriver()
        {
            driver.Quit();
        }
        public void Clear(By by)
        {
            driver.FindElement(by).Clear();
        }
        public void OpenUrl(string url)
        {
            driver.Url = url;
        }
        public void dropDown(By by, string value)
        {
            IWebElement drpDown = driver.FindElement(by);
            SelectElement dropDownMenu = new SelectElement(drpDown);
            dropDownMenu.SelectByValue(value);
        }
        public void checkBox(By by)
        {
            IWebElement element = driver.FindElement(by);
            Actions action = new Actions(driver);
            action.Click(element).Build().Perform();
        }
        public void readeoButton(By by)
        {
            IWebElement element = driver.FindElement(by);
            Actions action = new Actions(driver);
            action.Click(element).Build().Perform();
        }
        public string GetElementText(By by)
        {
            string text;
            try
            {
                text = driver.FindElement(by).Text;
            }
            catch
            {
                try
                {
                    text = driver.FindElement(by).GetAttribute("value");
                }
                catch
                {
                    text = driver.FindElement(by).GetAttribute("innerHTML");
                }
            }
            return text;
        }
        public void AssertElement(By by, string expectedText)
        {
            string actualtext = GetElementText(by);
            Assert.AreEqual(expectedText, actualtext);
        }

        public string GetElementState(By by)
        {
            string elementState = driver.FindElement(by).GetAttribute("Disabled");

            if (elementState == null)
            {
                elementState = "enabled";
            }
            else if (elementState == "true")
            {
                elementState = "disabled";
            }
            return elementState;
        }

        public static void PlaybackWait(int miliSeconds)
        {
            Thread.Sleep(miliSeconds);
        }

        public static string ExecuteJavaScriptCode(string javascriptCode)
        {
            string value = null;
            try
            {
                IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                value = (string)js.ExecuteScript(javascriptCode);
            }
            catch (Exception)
            {

            }
            return value;
        }

        public bool IsElementTextField(By by)
        {
            try
            {
                bool resultText = Convert.ToBoolean(driver.FindElement(by).GetAttribute("type").Equals("text"));
                bool resultPass = Convert.ToBoolean(driver.FindElement(by).GetAttribute("type").Equals("password"));
                if (resultText == true || resultPass == true)
                { return true; }
                else
                { return false; }
            }
            catch
            {
                return false;
            }
        }

        private IWebElement WaitforElement(By by, int timeToReadyElement = 0)
        {
            IWebElement element = null;
            try
            {
                if (timeToReadyElement != 0 && timeToReadyElement.ToString() != null)
                {
                    PlaybackWait(timeToReadyElement * 1000);
                }
                element = driver.FindElement(by);
            }
            catch
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
                wait.Until(driver => IsPageReady(driver) == true && IsElementVisible(by) == true && IsClickable(by) == true);
                element = driver.FindElement(by);
            }
            return element;
        }

        private bool IsPageReady(IWebDriver driver)
        {
            return ((IJavaScriptExecutor)driver).ExecuteScript("return document.readyState").Equals("complete");
        }

        private bool IsElementVisible(By by)
        {
            if (driver.FindElement(by).Displayed || driver.FindElement(by).Enabled)
            {
                return true;
            }
            else
            { return false; }
        }

        private bool IsClickable(By by)
        {
            try
            {
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
        public void Write(By by, string value)
        {
            try
            {
                WaitforElement(by).SendKeys(value);
                //TakeScreenshot(Status.Pass, "Enter Text");
            }
            catch (Exception ex)
            {

                ///TakeScreenshot(Status.Fail, "Enter Text: " + ex.ToString());
            }
        }
        public void Click(By by)
        {
            try
            {
                WaitforElement(by).Click();
                //TakeScreenshot("Click Element");
            }
            catch (Exception ex)
            {
                //TakeScreenshot(Status.Fail, "Click Element: " + ex.ToString());
            }
        }
    }
}
