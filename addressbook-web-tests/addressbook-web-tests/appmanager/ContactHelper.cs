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

        private List<ContactData> contactCache = null;

        public  List<ContactData> GetContactList()
        {
            if (contactCache == null)
            {
                contactCache = new List<ContactData>();

                manager.Navigator.OpenHomepage();
                ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("tr[name='entry']"));
                foreach (IWebElement element in elements)
                {
                    string LastName = element.FindElements(By.CssSelector("td"))[1].Text;
                    string FirstName = element.FindElements(By.CssSelector("td"))[2].Text;
                    contactCache.Add(new ContactData(FirstName, LastName));
                }
            }
            return contactCache;
        }

        public void Remove(int v)
        {
            manager.Navigator.OpenHomepage();

            SelectContact(v);
            RemoveContact();
        }

        internal void Modify(int v, ContactData newData)
        {
            manager.Navigator.OpenHomepage();

            SelectContact(v);
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
            contactCache = null;
            return this;
        }

        private ContactHelper SelectContact(int index)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + (index+1) + "]")).Click();
            return this;
        }

        private ContactHelper RemoveContact()
        {
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            driver.SwitchTo().Alert().Accept();
            contactCache = null;
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
            contactCache = null;
            return this;
        }

        private ContactHelper ReturnToAddressList()
        {
            driver.FindElement(By.LinkText("home page")).Click();
            return this;
        }
    }
}
