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
        public AgendamentoViewModel Agendamento { get; set; }
        public AgendamentoView(Veiculo veiculo)
        {
            InitializeComponent();
            this.Agendamento = new AgendamentoViewModel(veiculo);
            this.BindingContext = this.Agendamento;
        }

        protected override void OnAppearing()
        {
            MessagingCenter.Subscribe<AgendamentoViewModel>(this, "AgendarTestDrive", (agendamento) => 
            {
                DisplayAlert("Agendamento Confirmado!", string.Format(@"Veículo: {0}
                                                                        Nome: {1}
                                                                        Telefone: {2}
                                                                        E-Mail: {3}
                                                                        Data: {4}
                                                                        Horario: {5}", 
                                                                        agendamento.Veiculo.NomeCompleto,
                                                                        agendamento.Nome,
                                                                        agendamento.Telefone,
                                                                        agendamento.Email,
                                                                        agendamento.Data,
                                                                        agendamento.Hora)
                                                                        , "Ok");
            });
            base.OnAppearing();
        }

        protected override void OnDisappearing()
        {
            MessagingCenter.Unsubscribe<AgendamentoViewModel>(this, "AgendarTestDrive");
            base.OnDisappearing();
        }
    }
}