using BusinessModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CustomerService.Repository
{
    public interface ICustomerRepository
    {
        bool SaveCustomer(Customer customer);
        Customer[] GetCustomers();
    }
}