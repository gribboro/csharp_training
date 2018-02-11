﻿using System;
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
            OpenHomepage();
            Login(new AccountData("admin", "secret"));
            OpenGroups();
            InitNewGroupCreation();
            GroupData group = new GroupData("aaa");
            group.Footer = "www";
            group.Header = "lll";
            FillGroupForm(group);
            SubmitGroupCreation();
            ReturnToGroupsPage();
            Logout();
        }
    }
}
