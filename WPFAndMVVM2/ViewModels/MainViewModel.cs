using System;
using System.Collections.Generic;
using System.Text;
using WPFAndMVVM2.Models;

namespace WPFAndMVVM2.ViewModels
{
    public class MainViewModel
    {
        private PersonRepository personRepo = new PersonRepository();

        // Implement the rest of this MainViewModel class below to 
        // establish the foundation for data binding !

        public PersonViewModel currentPerson { get; set; }
        public List<PersonViewModel> PersonsVM { get; set; }
        public MainViewModel()
        { 
            PersonsVM = new List<PersonViewModel>();
            foreach (Person person in personRepo.GetAll())
            {
                PersonViewModel personViewModel= new PersonViewModel(person);
                PersonsVM.Add(personViewModel);
            }
        }
       

    }
}
