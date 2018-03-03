using System;
using System.Windows;

namespace LeskivSharp02
{
    /// <summary>
    /// Interaction logic for PersonInfoWindow.xaml
    /// </summary>
    public partial class PersonInfoWindow : Window
    {
        public PersonInfoWindow(Person person)
        {
            InitializeComponent();
            DataContext = new PersonInfoViewModel(person);
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            Application.Current.Shutdown();
        }

    }
}
