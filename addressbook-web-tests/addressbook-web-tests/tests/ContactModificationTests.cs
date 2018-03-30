using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactModificationTests : AuthTestBase
    {
        [Test]
        public void ContactModificationTest()
        {
            if (app.Contacts.GetContactCount() == 0)
            {
                app.Contacts.Create(new ContactData("fff", "gggg"));
            }

            ContactData newData = new ContactData("fef", "urur");

            List<ContactData> oldContacts = ContactData.GetAll();
            ContactData toBeModified = oldContacts[0];

            app.Contacts.Modify(toBeModified, newData);

            List<ContactData> newContacts = ContactData.GetAll();
            oldContacts[0].FirstName = newData.FirstName;
            oldContacts[0].LastName = newData.LastName;
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
        }
    }
}
