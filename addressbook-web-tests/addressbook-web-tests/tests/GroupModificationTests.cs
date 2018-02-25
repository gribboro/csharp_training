using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;


namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupModificationTests : AuthTestBase
    {
        [Test]
        public void GroupModificationTest()
        {
            if (app.Groups.GetGroupNumber() == 0)
            {
                GroupData group = new GroupData("aaa");
                group.Footer = "www";
                group.Header = "lll";

                app.Groups.Create(group);
            }

            GroupData newData = new GroupData("uhu");
            newData.Footer = null;
            newData.Header = null;

            app.Groups.Modify(1, newData);
        }
    }
}
