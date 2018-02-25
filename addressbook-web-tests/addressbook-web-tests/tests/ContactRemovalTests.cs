using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactRemovalTests : AuthTestBase
    {
        [Test]
        public void ContactRemovalTest()
        {
            if (app.Contacts.GetContactNumber() == 0)
            {
                app.Contacts.Create(new ContactData("fff", "gggg"));
            }

            app.Contacts.Remove(1);
        }
    }
}
