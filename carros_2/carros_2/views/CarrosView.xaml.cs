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
    public partial class CarrosView : ContentPage
    {
        public VeiculoView View { get; set; }
        public CarrosView()
        {
            InitializeComponent();
            this.View = new VeiculoView();
            this.BindingContext = this.View;

        }

        // Na implementação do conceito de comandos, remove-se o evento criado diretamente na view e utiliza o SelectedItem
        // fazendo um binding com o objeto que vai passar para frente
        // tendo então que implementar uma forma de redirecionar o fluxo do aplicativo
        // para isso será usado a mensageria


        // Na implementação da mensageria, que utiliza uma propriedade global do Xamarin.Forms
        // a nossa view irá subscrever a um sistema de mensagens e ficar aguardando por notificações da mesma
        // Faremos isso no lancamento da nossa pagina, antes dela tornar-se visivel
        protected async override void OnAppearing()
        {
            MessagingCenter.Subscribe<Veiculo>(this, "VeiculoSelecionado", (veiculo) =>
             {
                 Navigation.PushAsync((new DetalheView(veiculo)));
             });

            MessagingCenter.Subscribe<Exception>(this, "FalhaGetVeiculos", (ex) => 
            {
                DisplayAlert("Erro", "Ocorreu um erro ao tentar obter a lista de veículos. Por favor, tente novamente mais tarde", "OK");
            });
            await this.View.GetVeiculos();
            base.OnAppearing();
        }

        // Remove a inscrição na mensageria ao sair da página
        protected override void OnDisappearing()
        {
            MessagingCenter.Unsubscribe<Veiculo>(this, "VeiculoSelecionado");
            MessagingCenter.Unsubscribe<Exception>(this, "FalhaGetVeiculos");
            base.OnDisappearing();
        }
    }
}