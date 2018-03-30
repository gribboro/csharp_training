using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactInformationTests : AuthTestBase
    {
        [Test]
        public void GeneralInformationTest()
        {
            ContactData fromTable = app.Contacts.GetContactInformationFromTable(0);
            ContactData fromForm = app.Contacts.GetContactInformationFromForm(0, 7);

            Assert.AreEqual(fromTable.FirstName, fromForm.FirstName);
            Assert.AreEqual(fromTable.LastName, fromForm.LastName);
            Assert.AreEqual(fromTable.Address, fromForm.Address);
            Assert.AreEqual(fromTable.AllPhones, fromForm.AllPhones);
        }

        [Test]
        public void DetailedInformationTest()
        {
            while (app.Contacts.GetContactCount() != 0)
            {
                app.Contacts.Remove(0);
            }

            app.Contacts.Create(new ContactData("Имя", "Фамилия") {
                Address = "Адрес 123123",
                HomePhone = "(903) 321-321-321",
                MobilePhone = "(903) 123-123-123",
                WorkPhone = "(903) 987-987-987"});

            ContactData fromDetails = app.Contacts.GetContactInformationFromDetails(0, 6);
            ContactData fromForm = app.Contacts.GetContactInformationFromForm(0, 7);

            Assert.AreEqual(fromDetails.AllData, fromForm.AllData);
        }
    }
}
