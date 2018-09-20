using carros.views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace carros
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //MainPage = new CarrosView();

            //Aula 3 - Como navegar entre páginas.
            //é usado a NavigationPage para usar o recurso de pilha das páginas navegadas
            MainPage = new NavigationPage(new CarrosView());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
