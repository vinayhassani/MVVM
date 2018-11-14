using MVVMDemo.Command;
using MVVMDemo.Model;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using System;

namespace MVVMDemo.ViewModel
{
    public class PersonViewModel : INotifyPropertyChanged
    {
        private Person _person;

        public Person Person
        {
            get { return _person; }
            set
            {
                _person = value;
                NotifyPropertyChanged("Person");
            }
        }

        private ObservableCollection<Person> _persons;

        public ObservableCollection<Person> Persons
        {
            get { return _persons; }
            set
            {
                _persons = value;
                NotifyPropertyChanged("Persons");
            }
        }

        private ICommand _SubmitCommand;
        public ICommand SubmitCommand {
            get
            {
                if (_SubmitCommand == null)
                {
                    _SubmitCommand = new RelayCommand(SubmitExecute, CanSubmitExecute, false);
                }
                  return _SubmitCommand;
                
            }
        }

        public PersonViewModel()
        {
            Person = new Person();
            Persons = new ObservableCollection<Person>();
        }

        
        private void SubmitExecute(object parameter)
        {
            Persons.Add(Person);
        }
        private bool CanSubmitExecute(object parameter)
        {
            if (string.IsNullOrEmpty(Person.Fname) || string.IsNullOrEmpty(Person.Lname))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private ICommand _DeleteCommand;

        public ICommand DeleteCommand
        {
            get
            {
                _DeleteCommand = new RelayCommand(DeleteExecute, CanDeleteExecute, false);
                return _DeleteCommand;
            }
        }

        private bool CanDeleteExecute(object arg)
        {
            if (string.IsNullOrEmpty(Person.Fname) || string.IsNullOrEmpty(Person.Lname))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void DeleteExecute(object obj)
        {
            Persons.Remove(Person);
        }

       

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
