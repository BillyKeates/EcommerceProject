﻿using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using uk.co.edgewords.ecommerceprojectfinal.Support;

namespace uk.co.edgewords.ecommerceproject.POMClass
{
    internal class LogInPagePOM
    {

        private IWebDriver _driver;


        public LogInPagePOM(IWebDriver driver)
        {
            this._driver = driver;
        }

        private IWebElement _usernameElement => _driver.FindElement(By.Id("username")); //username input box
        private IWebElement _passwordElement => _driver.FindElement(By.Id("password")); //password input box
        private IWebElement _logInButton => _driver.FindElement(By.CssSelector(".woocommerce-form-login__submit")); //log in button
        

        public void EnterUsername(string username)
        {
            //Give a more readable error if the user forgets to set the USERNAME environment variable
            if (username == null)
            {
                throw new ArgumentNullException("username");
            }
            

            _usernameElement.Clear();
            _usernameElement.SendKeys(username);

        }


        public void EnterPassword(string password)
        {
            //Give a more readable error message if the user forgets to set the PASSWORD environment variable
            if (password == null)
            {
                throw new ArgumentNullException("password");
            }
            
            _passwordElement.Clear();
            _passwordElement.SendKeys(password);
        }

        public void ClickLogIn()
        {
            _logInButton.Click();
        }


        public bool CheckIfLoggedIn()
        {
            try
            {
                _driver.FindElement(By.LinkText("Logout"));
                return true;
            }
            catch
            {
                return false;
            }
        }

    }
}
