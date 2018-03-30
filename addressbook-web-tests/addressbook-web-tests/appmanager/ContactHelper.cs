using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
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
        private List<ContactData> contactCache = null;

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

        public void Remove(ContactData contact)
        {
            manager.Navigator.OpenHomepage();

            SelectContact(contact.Id);
            RemoveContact();
        }

        internal void Modify(int v, ContactData newData)
        {
            manager.Navigator.OpenHomepage();

            SelectContact(v);
            ClickContactButton(0, 7);
            FillContactForm(newData);
            SubmitContactModification();
            ReturnToAddressList();
        }

        internal void Modify(ContactData contact, ContactData newData)
        {
            manager.Navigator.OpenHomepage();

            SelectContact(contact.Id);
            ClickContactButton(0, 7);
            FillContactForm(newData);
            SubmitContactModification();
            ReturnToAddressList();
        }

        public void AddContactToGroup(ContactData contact, GroupData group)
        {
            manager.Navigator.OpenHomepage();

            ClearGroupFilter();
            SelectContact(contact.Id);
            SelectGroupToAdd(group.Name);
            CommitAddingContactToGroup();
            new WebDriverWait(driver, TimeSpan.FromSeconds(10))
                .Until(d => d.FindElements(By.CssSelector("div.msgbox")).Count > 0);
        }

        public void RemoveContactFromGroup(ContactData contact, GroupData group)
        {
            throw new NotImplementedException();
        }

        public List<ContactData> GetContactList()
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

        public int GetContactCount()
        {
            manager.Navigator.OpenHomepage();
            return driver.FindElements(By.Name("selected[]")).Count;
        }

        private ContactHelper FillContactForm(ContactData contact)
        {
            Type(By.Name("firstname"), contact.FirstName);
            Type(By.Name("lastname"), contact.LastName);
            Type(By.Name("address"), contact.Address);

            Type(By.Name("home"), contact.HomePhone);
            Type(By.Name("mobile"), contact.MobilePhone);
            Type(By.Name("work"), contact.WorkPhone);

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

        private ContactHelper ClickContactButton(int rowIndex, int column)
        {
            driver.FindElements(By.Name("entry"))[rowIndex]
                .FindElements(By.TagName("td"))[column]
                .FindElement(By.TagName("a"))
                .Click();
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

        public ContactData GetContactInformationFromTable(int index)
        {
            manager.Navigator.OpenHomepage();
            IList<IWebElement> cells = driver.FindElements(By.Name("entry"))[index]
                .FindElements(By.TagName("td"));

            string lastName = cells[1].Text;
            string firstName = cells[2].Text;
            string address = cells[3].Text;
            string allPhones = cells[5].Text;

            return new ContactData(firstName, lastName)
            {
                Address = address,
                AllPhones = allPhones,
            };
        }

        public ContactData GetContactInformationFromForm(int index, int cell)
        {
            manager.Navigator.OpenHomepage();
            ClickContactButton(index, cell);

            string firstName = driver.FindElement(By.Name("firstname")).GetAttribute("value");
            string lastName = driver.FindElement(By.Name("lastname")).GetAttribute("value");
            string address = driver.FindElement(By.Name("address")).GetAttribute("value");

            string homePhone = driver.FindElement(By.Name("home")).GetAttribute("value");
            string mobilePhone = driver.FindElement(By.Name("mobile")).GetAttribute("value");
            string workPhone = driver.FindElement(By.Name("work")).GetAttribute("value");

            return new ContactData(firstName, lastName)
            {
                Address = address,
                HomePhone = homePhone,
                MobilePhone = mobilePhone,
                WorkPhone = workPhone
            };
        }

        internal ContactData GetContactInformationFromDetails(int index, int cell)
        {
            manager.Navigator.OpenHomepage();
            ClickContactButton(index, cell);

            string allData = driver.FindElement(By.Id("content")).Text;
            return new ContactData("", "")
            {
                AllData = allData
            };
        }

        public int GetNumberOfSearchResults()
        {
            manager.Navigator.OpenHomepage();
            string text = driver.FindElement(By.TagName("label")).Text;
            Match m = new Regex(@"\d+").Match(text);
            return Int32.Parse(m.Value);
        }

        private void ClearGroupFilter()
        {
            new SelectElement(driver.FindElement(By.Name("group"))).SelectByText("[all]");
        }

        private void SelectContact(string contactId)
        {
            driver.FindElement(By.XPath("//*[@id=" + contactId + "]")).Click();

            //*[@id="60"]
        }

        private void SelectGroupToAdd(string name)
        {
            new SelectElement(driver.FindElement(By.Name("to_group"))).SelectByText(name);
        }

        private void CommitAddingContactToGroup()
        {
            driver.FindElement(By.Name("add")).Click();
        }
    }
}
