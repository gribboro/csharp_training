using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactCreationTests : TestBase
    {
        [Test]
        public void ContactCreationTest()
        {
            app.Navigator.OpenHomepage();
            app.Auth.Login(new AccountData ("admin", "secret"));
            app.Navigator.OpenAddNewPage();
            app.Contacts.FillNewContactForm(new ContactData("aaa", "hhhh"));
            app.Contacts.ConfirmContactCreation();
            //loginHelper.Logout();
        }
    }
}
