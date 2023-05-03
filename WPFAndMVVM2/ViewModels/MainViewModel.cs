using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using WPFAndMVVM2.Models;

namespace WPFAndMVVM2.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if (propertyChanged != null) propertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        private PersonRepository personRepo = new PersonRepository();


        public PersonViewModel currentPerson { get; set; }
        public ObservableCollection<PersonViewModel> PersonsVM { get; set; }
        public MainViewModel()
        { 
            PersonsVM = new ObservableCollection<PersonViewModel>();
            foreach (Person person in personRepo.GetAll())
            {
                PersonViewModel personViewModel = new PersonViewModel(person);
                PersonsVM.Add(personViewModel);
            }
        }

        public void UpdateCurrentPerson()
        {
            OnPropertyChanged("currentPerson");
        }

        public void DeleteSelectedPerson()
        {
            Debug.WriteLine(personRepo.GetAll().Count);
            currentPerson.DeletePerson(personRepo);
            PersonsVM.Remove(currentPerson);
            Debug.WriteLine(personRepo.GetAll().Count);
        }

        public void AddDefaultPerson()
        {
            Person person = personRepo.Add("Specify First Name", "Specify Last Name", 0, "Specify Phone");
            PersonViewModel personViewModel = new PersonViewModel(person);
            PersonsVM.Add(personViewModel);
            currentPerson = personViewModel;
            OnPropertyChanged("currentPerson");
        }

    }
}
