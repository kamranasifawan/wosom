using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;
using System.Threading;

namespace wosom
{
    [TestClass]
    public class singUpTest : basePage
    {
        signUpPage signUpPageObj = new signUpPage();
        
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", "C:\\Users\\kamran\\source\\repos\\wosom\\wosom\\XMLFile1.xml", "Login", DataAccessMethod.Sequential)]

        [TestMethod]

        public void signUpTest001()
        {
            basePage browser = new basePage();
            IWebDriver driver1 = browser.openBrowser("Chrome");
            driver = driver1;
            OpenUrl("http://wosom.fr/register");
            string userFirestName, userLastName, countryName, userEmail, userPassword, userPhoneNo, 
             monthName, dayOfmonth, yearOfbirth, selection;
            userFirestName = TestContext.DataRow[0].ToString();
            userLastName = TestContext.DataRow[1].ToString();
            countryName = TestContext.DataRow[2].ToString();
            userEmail = TestContext.DataRow[3].ToString();
            userPassword = TestContext.DataRow[4].ToString();
            userPhoneNo = TestContext.DataRow[5].ToString();
            monthName = TestContext.DataRow[6].ToString();
            dayOfmonth = TestContext.DataRow[7].ToString();
            yearOfbirth = TestContext.DataRow[8].ToString();
            selection = TestContext.DataRow[9].ToString();
            signUpPageObj.createUser(userFirestName,userLastName,userEmail,countryName,userPassword,userPhoneNo, monthName, dayOfmonth, yearOfbirth,selection);


                Thread.Sleep(10000);
                basePage.CloseDriver();
        }       
    }
}
