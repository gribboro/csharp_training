using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;


namespace WebAddressbookTests
{
    public class ContactHelper : HelperBase
    {
        public ContactHelper(ApplicationManager manager)
            : base(manager)
        {
        }

        public void Create(ContactData contact)
        {
            manager.Navigator.OpenAddNewPage();

            FillContactForm(contact);
            ConfirmContactCreation();
        }

        public void Remove(int v)
        {
            manager.Navigator.OpenHomepage();

            SelectContact(v);
            RemoveContact();
        }

        internal void Modify(ContactData newData)
        {
            manager.Navigator.OpenHomepage();

            InitContactModification();
            FillContactForm(newData);
            SubmitContactModification();
            ReturnToAddressList();
        }

        public int GetContactNumber()
        {
            manager.Navigator.OpenHomepage();

            return driver.FindElements(By.ClassName("center")).Count;
        }

        private ContactHelper FillContactForm(ContactData contact)
        {
            Type(By.Name("firstname"), contact.FirstName);
            Type(By.Name("lastname"), contact.LastName);
            return this;
        }

        private ContactHelper ConfirmContactCreation()
        {
            driver.FindElement(By.Name("submit")).Click();
            return this;
        }

        private ContactHelper SelectContact(int index)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + index + "]")).Click();
            return this;
        }

        private ContactHelper RemoveContact()
        {
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            driver.SwitchTo().Alert().Accept();
            return this;
        }

        private ContactHelper InitContactModification()
        {
            driver.FindElement(By.CssSelector("img[alt=\"Edit\"]")).Click();
            return this;
        }

        private ContactHelper SubmitContactModification()
        {
            driver.FindElement(By.XPath("(//input[@name='update'])[2]")).Click();
            return this;
        }

        private ContactHelper ReturnToAddressList()
        {
            driver.FindElement(By.LinkText("home page")).Click();
            return this;
        }
    }
}
