using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace WebAddressbookTests
{
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        private string allPhones;

        private string allData;

        public ContactData()
        {
        }

        public ContactData(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Address { get; set; }

        public string HomePhone { get; set; }

        public string MobilePhone { get; set; }

        public string WorkPhone { get; set; }

        public string AllPhones
        {
            get
            {
                if (allPhones != null)
                {
                    return allPhones;
                }
                return (Cleanup(HomePhone) + Cleanup(MobilePhone) + Cleanup(WorkPhone))
                    .Trim();
            }

            set
            {
                allPhones = value;
            }
        }

        public string AllData
        {
            get
            {
                if (allData != null)
                {
                    return Regex.Replace(allData.Replace("\r\n", ""), "[ --():]", "");
                }
                string result = FirstName + LastName + Address;

                if (HomePhone != null && HomePhone != "")
                {
                    result += "H" + HomePhone;
                }

                if (MobilePhone != null && MobilePhone != "")
                {
                    result += "M" + MobilePhone;
                }

                if (WorkPhone != null && WorkPhone != "")
                {
                    result += "W" + WorkPhone;
                }

                return Cleanup(result).Replace("\r\n", "");
            }

            set
            {
                allData = value;
            }
        }

        public bool Equals(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }
            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }
            return FirstName == other.FirstName && LastName == other.LastName;
        }

        public override int GetHashCode()
        {
            return (FirstName + LastName).GetHashCode();
        }

        public override string ToString()
        {
            return ("Имя=" + FirstName) + (", Фамилия=" + LastName);
        }

        public int CompareTo(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }
            if (other.LastName == LastName)
            {
                return FirstName.CompareTo(other.FirstName);
            }
            return LastName.CompareTo(other.LastName);
        }

        private string Cleanup(string data)
        {
            if (data == null || data == "")
            {
                return "";
            }
            return Regex.Replace(data, "[ --()]", "") + "\r\n";
        }
    }
}
