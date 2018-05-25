using CustomerApplication.CustomerServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace CustomerApplication.Services
{
    public class CustomerServiceManager
    {
        static CustomerServiceClient customerService = new CustomerServiceClient();

        public bool SaveCustomer(Customer customer)
        {
            return customerService.SaveCustomer(customer);
        }

        public Customer[] GetCustomers()
        {
            return (Customer[])customerService.GetCustomers();
        }
    }
}
