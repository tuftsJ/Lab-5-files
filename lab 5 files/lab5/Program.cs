using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerProductClasses
{
    public class CustomerList
    {
        private List<Customer> customers;

        public CustomerList()
        {
            customers = new List<customer>();
        }

        public int Count
        {
            get
            {
                return customers.Count;
            }
        }

        public void Fill()
        {
            customers = CustomerDB.GetCustomers();
        }

        public void Save()
        {
            CustomerDB.SaveCustomers(customers);
        }

        public void Add(Customer customer)
        {
            customers.Add(customer);
        }

        public void Add(string Email, string FirstName, int Id, string LastName, string Phone)
        {
            Customer c = new Customer(Email, FirstName, Id, LastName, Phone);
            customers.Add(c);
        }

        public void Remove(Customer customer)
        {
            customers.Remove(customer);
        }

        public override string ToString()
        {
            string output = "";
            foreach (Customer c in customers)
            {
                output += c.ToString() + "\n";
            }
            return output;
        }

        public static CustomerList operator +(CustomerList cl, Customer c)
        {
            cl.Add(c);
            return cl;
        }

        public static CustomerList operator -(CustomerList cl, Customer c)
        {
            cl.Remove(c);
            return cl;
        }
    }
}
