using System;
using System.Text;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactCreationTests : AuthTestBase
    {
        public static IEnumerable<ContactData> RandomContactDataProvider()
        {
            List<ContactData> contacts = new List<ContactData>();
            for (int i = 0; i < 2; i++)
            {
                contacts.Add(new ContactData(GenerateRandomString(30), GenerateRandomString(30)));
            }
            return contacts;
        }

        //public static IEnumerable<ContactData> ContactDataFromXmlFile()
        //{
        //    return
        //}

        //public static IEnumerable<ContactData> ContactDataFromJsonFile()
        //{

        //}

        [Test, TestCaseSource("ContactDataFromXmlFile")]
        public void ContactCreationTest(ContactData contact)
        {
            List<ContactData> oldContacts = app.Contacts.GetContactList();

            app.Contacts.Create(contact);

            List<ContactData> newContacts = app.Contacts.GetContactList();

            oldContacts.Add(contact);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(newContacts, oldContacts);
        }
    }
}
