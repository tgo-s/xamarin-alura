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
    public partial class AgendamentoView : ContentPage
    {
        public AgendamentoViewModel View { get; set; }
        public AgendamentoView(Veiculo veiculo)
        {
            InitializeComponent();
            this.View = new AgendamentoViewModel(veiculo);
            this.BindingContext = this.View;
        }

        protected override void OnAppearing()
        {
            MessagingCenter.Subscribe<AgendamentoViewModel>(this, "AgendarTestDrive", async (view) => 
            {

                var confirmacao = await DisplayAlert("Confirmar Agendamento", "Deseja confirmar este agendamento?", "Sim", "Não");

                if (confirmacao)
                {
                    await View.MarcarAgendamentoAsync();
                }
            });

            MessagingCenter.Subscribe<Agendamento>(this, "AgendamentoMarcado", (agendamento) => 
            {
                DisplayAlert("Agendamento", "Agendamento marcado com sucesso!", "Ok");
            });

            MessagingCenter.Subscribe<ArgumentException>(this, "ProblemaAoAgendar", (argEx) =>
            {
                DisplayAlert("Agendamento", "Um erro ocorreu ao tentar agendar o test drive", "Ok");
            });

            base.OnAppearing();
        }

        protected override void OnDisappearing()
        {
            MessagingCenter.Unsubscribe<AgendamentoViewModel>(this, "AgendarTestDrive");
            MessagingCenter.Unsubscribe<Agendamento>(this, "AgendamentoMarcado");
            MessagingCenter.Unsubscribe<ArgumentException>(this, "ProblemaAoAgendar");
            base.OnDisappearing();
        }
    }
}