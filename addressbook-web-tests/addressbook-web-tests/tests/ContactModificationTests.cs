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
            if (app.Contacts.GetContactNumber() == 0)
            {
                app.Contacts.Create(new ContactData("fff", "gggg"));
            }

            app.Contacts.Modify(new ContactData ("fef", "urur"));
        }
    }
}
