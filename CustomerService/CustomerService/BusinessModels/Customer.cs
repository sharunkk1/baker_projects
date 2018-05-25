using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using System.Xml.Serialization;

namespace BusinessModels
{
    [DataContract]
    public class Customer
    {
        [DataMember]
        public string Name{get;set;}

        [DataMember]
        public DateTime DateOfBirth { get; set; }

        [DataMember]
        public short Age { get; set; }

        [DataMember]
        public string Address { get; set; }
    }

    public class CustomersCollection
    {
        [XmlArray("Customers")]
        [XmlArrayItem("Customer", typeof(Customer))]
        public Customer[] CustomerArray { get; set; }
    }
}