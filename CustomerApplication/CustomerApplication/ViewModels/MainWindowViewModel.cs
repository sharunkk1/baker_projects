using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Windows.Input;
using System.ComponentModel;
using Prism.Commands;
using CustomerApplication.Services;
using CustomerApplication.CustomerServiceReference;

namespace CustomerApplication.ViewModels
{
    public class MainWindowViewModel : ViewModel, IDataErrorInfo
    {
        string
            name = null,
            address = null,
            age = null;
        DateTime dateOfBirth;
        IEnumerable<Customer> customers;

        Dictionary<string, bool> ModelErrors = new Dictionary<string, bool>();
        CustomerServiceManager manager = new CustomerServiceManager();


        public MainWindowViewModel()
        {
            this.DateOfBirth = DateTime.Now;
            SaveCommand = new DelegateCommand(SaveCustomer, IsValidModel);
            SaveCommand.ObservesProperty(() => Name);
            SaveCommand.ObservesProperty(() => Address);
            SaveCommand.ObservesProperty(() => DateOfBirth);
        }

        [Required(ErrorMessage = "Name is required.")]
        public string Name
        {
            get { return this.name; }
            set
            {
                this.name = value;
                this.OnPropertyChanged("Name");
            }
        }

        [Required(ErrorMessage = "Date of Birth is required.")]
        public DateTime DateOfBirth
        {
            get { return this.dateOfBirth; }
            set
            {
                this.dateOfBirth = value;
                this.OnPropertyChanged("DateOfBirth");
                this.OnPropertyChanged("Age");
            }
        }

        [Required(ErrorMessage = "Address is required.")]
        public string Address
        {
            get { return this.address; }
            set
            {
                this.address = value;
                this.OnPropertyChanged("Address");

            }
        }

        public short Age
        {
            get
            {
                return (short)(DateTime.Today.Year - DateOfBirth.Year);
            }
        }

        public IEnumerable<Customer> Customers
        {
            get { return customers; }
            set
            {
                this.customers = value;
                this.OnPropertyChanged("Customers");
            }
        }


        #region IDataErrorInfo Members

        public string Error
        {
            get
            {
                return null;
            }
        }

        public string this[string propertyName]
        {
            get
            {
                var errorMessage = GetErrorMessage(propertyName);
                var hasError = !string.IsNullOrEmpty(errorMessage);
                if (hasError)
                    ModelErrors[propertyName] = true;
                else
                    ModelErrors[propertyName] = false;
                return hasError ? errorMessage : null;
            }
        }

        private string GetErrorMessage(string propertyName)
        {
            var errorMessage = string.Empty;
            if (propertyName == "Name")
            {
                return string.IsNullOrEmpty(Name) ? "Name is Required" : string.Empty;
            }
            else if (propertyName == "Address")
            {
                return string.IsNullOrEmpty(Address) ? "Address is Required" : string.Empty;
            }
            else if (propertyName == "DateOfBirth")
            {
                return DateOfBirth == null ? "DOB is Required" : string.Empty;
            }
            return errorMessage;
        }

        #endregion

        public DelegateCommand SaveCommand
        {
            get;
            set;
        }

        private void SaveCustomer()
        {
            var saved = manager.SaveCustomer(new Customer
            {
                Name = this.Name,
                Age = this.Age,
                Address = this.Address,
                DateOfBirth = this.DateOfBirth
            });
            if (saved)
            {
                Customers = manager.GetCustomers();
            }
        }

        private bool IsValidModel()
        {
            return ModelErrors.Values.All(x => x == false);
        }
    }
}
