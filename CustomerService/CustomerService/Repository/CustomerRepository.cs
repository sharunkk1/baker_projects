using BusinessModels;
using CustomerService.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CustomerService.Repository
{
    public class XmlCustomerRepository:ICustomerRepository
    {
        public bool SaveCustomer(Customer customer)
        {
            return XmlHelper.SaveCustomerInXml(customer);
        }
        
        public Customer[] GetCustomers()
        {
            return XmlHelper.GetCustomersFromXml();
        }
    }
}