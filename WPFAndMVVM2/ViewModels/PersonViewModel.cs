using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFAndMVVM2.Models;

namespace WPFAndMVVM2.ViewModels
{
    public class PersonViewModel : INotifyPropertyChanged
    {
        private Person person;

        private string firstName;
        private string lastName;
        private int age;
        private string phone;
        public string FirstName {
            get { return firstName; } 
            set { 
                firstName = value;
                OnPropertyChanged("FirstName");
            } 
        }

        public string LastName
        {
            get { return lastName; }
            set
            {
                lastName = value;
                OnPropertyChanged("LastName");
            }
        }
        public int Age
        {
            get { return age; }
            set
            {
                age = value;
                OnPropertyChanged("Age");
            }
        }
        public string Phone
        {
            get { return phone; }
            set
            {
                phone = value;
                OnPropertyChanged("Phone");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if (propertyChanged != null) propertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        public PersonViewModel(Person person)
        {
            this.person = person;
            this.FirstName = person.FirstName;
            this.LastName = person.LastName;
            this.Age = person.Age;
            this.Phone = person.Phone;
        }

        public void DeletePerson(PersonRepository personRepository)
        {
            personRepository.Remove(person.Id);
        }

        
    }
}
