using BusinessModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace CustomerService
{
    [ServiceContract]
    public interface ICustomerService
    {

        [OperationContract]
        bool SaveCustomer(Customer customer);

        [OperationContract]
        Customer[] GetCustomers();
    }

}
