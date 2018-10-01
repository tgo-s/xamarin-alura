using carros_2.models;
using carros_2.services;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Windows.Input;
using Xamarin.Forms;

namespace carros_2.viewmodel
{
    public class LoginViewModel : ViewModelBase
    {
        public ICommand EntrarCommand { get; private set; }

        public Login Login { get; set; }
        public LoginViewModel()
        {
            this.Login = new Login();
            EntrarCommand = new Command(async () =>
            {
                if (this.Login != null)
                    await new LoginService().FazerLogin(this.Login);
                else
                    MessagingCenter.Send<Exception>(new Exception("Erro ao capturar informações de login"), "ErroFormLoginView");
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
