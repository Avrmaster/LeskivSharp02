using System.ComponentModel;
using System.Runtime.CompilerServices;
using LeskivSharp02.Annotations;

namespace LeskivSharp02
{
    // ReSharper disable ArrangeAccessorOwnerBody
    class PersonInfoViewModel : INotifyPropertyChanged
    {
        private readonly Person _person;

        public string Name => $"Your name:\n{_person.Name}";
        public string Surname => _person.Surname;
        public string Email => _person.Email;
        public string BirthDate => _person.Birthday.ToString();
        public string SunSign => _person.SunSign;
        public string IsAdult => _person.IsAdult.ToString();
        public string ChineseSign => _person.ChineseSign;
        public string IsBirthday => _person.IsBirthday.ToString();

        public PersonInfoViewModel(Person person)
        {
            _person = person;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        

        #region Implementation
        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
