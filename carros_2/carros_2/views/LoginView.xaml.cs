using carros_2.models;
using carros_2.viewmodel;
using Javax.Security.Auth.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace carros_2.views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginView : ContentPage
    {

        public LoginView()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            MessagingCenter.Subscribe<LoginException>(this, "FalhaLogin", async (ex) => 
            {
                //Navigation.PushAsync(new CarrosView());
                await DisplayAlert("Login Error!", ex.Message, "Ok!");
            });

            MessagingCenter.Subscribe<HttpRequestException>(this, "FalhaConexao", (ex) => 
            {
                DisplayAlert("Erro na conexão", ex.Message, "Ok");
            });

            MessagingCenter.Subscribe<Exception>(this, "ErroFormLoginView", (ex) =>
            {
                DisplayAlert("Erro formulário", ex.Message, "Ok");
            });

            base.OnAppearing();
        }

        protected override void OnDisappearing()
        {
            MessagingCenter.Unsubscribe<LoginException>(this, "FalhaLogin");
            MessagingCenter.Unsubscribe<HttpRequestException>(this, "FalhaConexao");
            MessagingCenter.Unsubscribe<Exception>(this, "ErroFormLoginView");
            base.OnDisappearing();
        }
        
    }
}