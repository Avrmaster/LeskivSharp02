using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using LeskivSharp02.Annotations;


namespace LeskivSharp02
{
    class PersonRegisterViewModel: INotifyPropertyChanged
    {

        public string WestZodiac
        {
            get
            {
                return $"Western zodiac:{Environment.NewLine}";
            }
        }

        public string ChineseZodiac
        {
            get
            {
                return $"Chinise zodiac:{Environment.NewLine}";
            }
        }

        internal PersonRegisterViewModel()
        {

        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
