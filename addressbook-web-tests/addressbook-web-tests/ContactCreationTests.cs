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
            navigator.OpenHomepage();
            loginHelper.Login(new AccountData ("admin", "secret"));
            navigator.OpenAddNewPage();
            contactHelper.FillNewContactForm(new ContactData("aaa", "hhhh"));
            contactHelper.ConfirmContactCreation();
            //loginHelper.Logout();
        }
    }
}
