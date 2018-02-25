using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupRemovalTests : AuthTestBase
    {
        [Test]
        public void GroupRemovalTest()
        {
            if (app.Groups.GetGroupNumber() == 0)
            {
                GroupData group = new GroupData("aaa");
                group.Footer = "www";
                group.Header = "lll";

                app.Groups.Create(group);
            }

            app.Groups.Remove(1);
        }
    }
}
