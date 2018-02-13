using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupCreationTests : TestBase
    {
        [Test]
        public void GroupCreationTest()
        {
            navigator.OpenHomepage();
            loginHelper.Login(new AccountData("admin", "secret"));
            navigator.OpenGroups();
            groupHelper.InitNewGroupCreation();
            GroupData group = new GroupData("aaa");
            group.Footer = "www";
            group.Header = "lll";
            groupHelper.FillGroupForm(group);
            groupHelper.SubmitGroupCreation();
            groupHelper.ReturnToGroupsPage();
            //loginHelper.Logout();
        }
    }
}
