using carros_2.models;
using carros_2.viewmodel;
using System;
using System.Collections.Generic;
using System.Linq;
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
            MessagingCenter.Subscribe<LoginViewModel>(this, "EntrarCommand", (msg) => 
            {
                Navigation.PushAsync(new CarrosView());
            });
            base.OnAppearing();
        }

        protected override void OnDisappearing()
        {
            MessagingCenter.Unsubscribe<LoginViewModel>(this, "EntrarCommand");
            base.OnDisappearing();
        }
        
    }
}