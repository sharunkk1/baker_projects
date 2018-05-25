using BusinessModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Xml;
using System.Xml.Serialization;
namespace CustomerService.Helper
{
    public class XmlHelper
    {
        private static readonly string xmlFilePath = HttpContext.Current.Server.MapPath("Customers.xml");

        public static bool SaveCustomerInXml(Customer customer)
        {
            try
            {
                XmlDocument XmlDocObj = new XmlDocument();
                XmlDocObj.Load(xmlFilePath);
                XmlNode RootNode = XmlDocObj.SelectSingleNode("CustomersCollection/Customers");
                XmlNode customerNode = RootNode.AppendChild(XmlDocObj.CreateNode(XmlNodeType.Element, "Customer", ""));

                customerNode.AppendChild(XmlDocObj.CreateNode(XmlNodeType.Element, "Name", "")).InnerText = customer.Name;
                customerNode.AppendChild(XmlDocObj.CreateNode(XmlNodeType.Element, "DateOfBirth", "")).InnerText = XmlConvert.ToString(customer.DateOfBirth,"yyyy-MM-dd");
                customerNode.AppendChild(XmlDocObj.CreateNode(XmlNodeType.Element, "Age", "")).InnerText = customer.Age.ToString();
                customerNode.AppendChild(XmlDocObj.CreateNode(XmlNodeType.Element, "Address", "")).InnerText = customer.Address;

                XmlDocObj.Save(xmlFilePath);
                return true;
            }
            catch (Exception ex)
            {
                //Log exception if needed
                return false;
            }
        }
        public static Customer[] GetCustomersFromXml()
        {
            try
            {
                CustomersCollection customersCollection = null;
                XmlSerializer serializer = new XmlSerializer(typeof(CustomersCollection));
                StreamReader reader = new StreamReader(xmlFilePath);
                customersCollection = (CustomersCollection)serializer.Deserialize(reader);
                reader.Close();
                return customersCollection.CustomerArray;
            }
            catch (Exception ex)
            {
                //Log exception if needed.
                return null;
            }
        }
    }
}