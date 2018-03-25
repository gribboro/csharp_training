using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinqToDB;

namespace WebAddressbookTests
{
    class AddressbookDB : LinqToDB.Data.DataConnection
    {
        public AddressbookDB() : base("AddressBook") { }

        public ITable<GroupData> Groups
        {
            get
            {
                return GetTable<GroupData>();
            }
        }

        public ITable<ContactData> Contacts
        {
            get
            {
                return GetTable<ContactData>();
            }
        }

        public ITable<GroupContactRelation> GCR
        {
            get
            {
                return GetTable<GroupContactRelation>();
            }
        }
    }
}
