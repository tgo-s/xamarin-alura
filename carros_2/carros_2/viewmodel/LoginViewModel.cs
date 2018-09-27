using carros_2.models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace carros_2.viewmodel
{
    public class LoginViewModel : ViewModelBase
    {
        public ICommand EntrarCommand { get; private set; }

        public Usuario Usuario { get; set; }
        public LoginViewModel()
        {
            EntrarCommand = new Command(() =>
            {
                MessagingCenter.Send<Usuario>(this.Usuario, "SucessoLogin");
            });
        }
        private bool hidePassword = true;
        public bool HidePassword
        {
            get { return hidePassword; }
            set
            {
                hidePassword = value;
                OnPropertyChanged();
            }
        }
    }
}
