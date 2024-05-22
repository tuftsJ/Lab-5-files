using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CustomerProductClasses
{
    public class Customer
    {
        private string email;
        private string firstName;
        private int id;
        private string lastName;
        private string phone;

        public Customer() { }

        public Customer(string Email, string FirstName, int Id, string LastName, string Phone)
        {
            email = Email;
            firstName = FirstName;
            id = Id;
            lastName = LastName;
            phone = Phone;
        }

        public string Email
        {
            get
            {
                return email;
            }
            set
            {
                email = value;
            }
        }

        public string FirstName
        {
            get
            {
                return firstName;
            }
            set
            {
                firstName = value;
            }
        }

        public int Id
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
            }
        }

        public string LastName
        {
            get
            {
                return lastName;
            }
            set
            {
                lastName = value;
            }
        }

        public string Phone
        {
            get
            {
                return phone;
            }
            set
            {
                phone = value;
            }
        }

        public override string ToString()
        {
            return String.Format("Email: {0} FirstName: {1} Id: {2} LastName: {3} Phone: {4}", email, firstName, id, lastName, Phone);
        }

        public override bool Equals(object obj)
        {
            if (obj == null || obj.GetType() != this.GetType())
                return false;
            else
            {
                Customer other = (Customer)obj;
                return other.Email == Email &&
                    other.FirstName == FirstName &&
                    other.Id == Id &&
                    other.LastName == LastName &&
                    other.Phone == Phone;
            }
        }

        public override int GetHashCode()
        {
            return 13 + 7 * email.GetHashCode() +
                7 * firstName.GetHashCode() +
                7 * id.GetHashCode() +
                7 * lastName.GetHashCode() +
                7 * phone.GetHashCode();
        }


        public static bool operator ==(Customer c1, Customer c2)
        {
            return c1.Equals(c2);
        }

        public static bool operator !=(Customer c1, Customer c2)
        {
            return !c1.Equals(c2);
        }

    }
}
