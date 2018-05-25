using BusinessModels;
using CustomerService.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace CustomerService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "CustomerService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select CustomerService.svc or CustomerService.svc.cs at the Solution Explorer and start debugging.
    public class CustomerService : ICustomerService
    {
        ICustomerRepository customerRepository;

        public CustomerService()
        {
            customerRepository = new XmlCustomerRepository();
        }

        public Customer[] GetCustomers()
        {
            return customerRepository.GetCustomers();
        }

        public bool SaveCustomer(Customer customer)
        {
            if (customer is Customer)
                return customerRepository.SaveCustomer((Customer)customer);
            return false;
        }
    }
}
