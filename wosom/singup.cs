using OpenQA.Selenium;


namespace wosom
{
    public class signUpPage : basePage
    {
        By firstName = By.XPath("//input[@name='first_name']");
        By lastName = By.XPath("//input[@name='last_name']");
        By email = By.Id("email");
        By country = By.XPath("//select[@name='country']");
        By password = By.Id("password");
        By button = By.XPath("//input[@name='next']");
        By phone = By.Id("phone1");
        By month = By.XPath("//select[@name='month']");
        By day = By.XPath("//input[@name='day']");
        By year = By.XPath("//input[@name='year']");
        By submitButton = By.XPath("//input[@name='submit']");
        By verifylater = By.XPath("//*[contains(text(),'Verify later') and @type='button']");
        By userSelection = By.XPath("//select[@name='user_selection']");
        By Continue = By.XPath("//*[contains(text(),'Continue') and @type='submit']");


        public void createUser(string userFirestName, string userLastName, string userEmail, 
        string countryName, string userPassword,string userPhoneNo,string monthName,string dayOfmonth,
        string yearOfbirth,string selection)
        {
            
            IsElementTextField(firstName);
            Write(firstName, userFirestName);

            IsElementTextField(lastName);
            Write(lastName, userLastName);

            dropDown(country, countryName);

            IsElementTextField(email);
            Write(email, userEmail);

            IsElementTextField(password);
            Write(password, userPassword);

            ScrollToElement(password);

            Screenshot screenshot = ((ITakesScreenshot)driver).GetScreenshot();
            screenshot.SaveAsFile(@".\\Screenshot4.png", ScreenshotImageFormat.Png);

            IsElementPresent(button);
            Click(button);

            IsElementTextField(phone);
            Write(phone, userPhoneNo);

            dropDown(month, monthName);

            IsElementTextField(day);
            Write(day, dayOfmonth);
            
            IsElementTextField(year);
            Write(year, yearOfbirth);

            IsElementPresent(submitButton);
            Click(submitButton);
            
            IsElementPresent(verifylater);
            Click(verifylater);

            //var parentWindow = driver.WindowHandles[0];
            //var childwindow = driver.WindowHandles[];

            //driver.SwitchTo().w;
            dropDown(userSelection, selection);

            IsElementPresent(Continue);
            Click(Continue);

            //driver.SwitchTo().Frame(parentWindow);

        }
    }
}
