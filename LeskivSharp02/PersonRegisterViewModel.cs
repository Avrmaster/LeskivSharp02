using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows;
using LeskivSharp02.Annotations;


namespace LeskivSharp02
{
    // ReSharper disable ArrangeAccessorOwnerBody
    class PersonRegisterViewModel : INotifyPropertyChanged
    {
        private readonly Window _parentWindow;

        private string _name = "Your name";
        private string _surname = "Your surname";
        private string _email = "Your email";
        private DateTime _birthDate = DateTime.Today;
        private RelayCommand _signInCommand;

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }

        public string Surname
        {
            get
            {
                return _surname;
            }
            set
            {
                _surname = value;
                OnPropertyChanged();
            }
        }

        public string Email
        {
            get
            {
                return _email;
            }
            set
            {
                _email = value;
                OnPropertyChanged();
            }
        }

        public DateTime BirthDate
        {
            get
            {
                return _birthDate;
            }
            set
            {
                _birthDate = value;
                OnPropertyChanged();
            }
        }

        public RelayCommand RegisterCommand
        {
            get
            {
                return _signInCommand ?? (_signInCommand = new RelayCommand(RegisterImpl,
                           o => !string.IsNullOrWhiteSpace(_name) &&
                                !string.IsNullOrWhiteSpace(_surname) &&
                                !string.IsNullOrWhiteSpace(_email) &&
                                DateTime.Today.YearsPassedCnt(_birthDate) < 135 &&
                                DateTime.Today.YearsPassedCnt(_birthDate) >= 0
                                ));
            }
        }

        private async void RegisterImpl(object o)
        {
            Person person = null;
            await Task.Run((() =>
            {
                person = new Person(_name, _surname, _email, _birthDate);
                //save to database here :)
            }));
            
            PersonInfoWindow personInfoWindow = new PersonInfoWindow(person);

            _parentWindow.Hide();
            personInfoWindow.Show();
        }

        internal PersonRegisterViewModel(Window parentWindow)
        {
            _parentWindow = parentWindow;
        }

        #region Implementation
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
