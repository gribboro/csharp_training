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
            OpenHomepage();
            Login(new AccountData ("admin", "secret"));
            GoToAddNewPage();
            FillNewContactForm(new ContactData("aaa", "hhhh"));
            ConfirmContactCreation();
            Logout();
        }
    }
}
