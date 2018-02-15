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
            app.Navigator.OpenHomepage();
            app.Auth.Login(new AccountData("admin", "secret"));
            app.Navigator.OpenGroups();
            app.Groups.InitNewGroupCreation();
            GroupData group = new GroupData("aaa");
            group.Footer = "www";
            group.Header = "lll";
            app.Groups.FillGroupForm(group);
            app.Groups.SubmitGroupCreation();
            app.Groups.ReturnToGroupsPage();
            //loginHelper.Logout();
        }
    }
}
