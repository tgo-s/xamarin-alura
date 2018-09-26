using carros_2.models;
using carros_2.viewmodel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace carros_2.views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetalheView : ContentPage
    {
        public DetalheVeiculoView Detalhe { get; set; }

        public DetalheView(Veiculo veiculo)
        {
            InitializeComponent();
            this.Detalhe = new DetalheVeiculoView(veiculo);
            this.BindingContext = this.Detalhe;

        }

        private void SwitchCell_OnChanged(object sender, ToggledEventArgs e)
        {
            this.txtValorTotal.Text = "Total " + this.Detalhe.Veiculo.ValorTotal.ToString("C2");
        }

        protected override void OnAppearing()
        {
            MessagingCenter.Subscribe<Veiculo>(this, "ProsseguirCmd", (veiculo) => 
            {
                try
                {
                    Navigation.PushAsync(new AgendamentoView(veiculo));
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            });

            base.OnAppearing();
        }

        protected override void OnDisappearing()
        {
            MessagingCenter.Unsubscribe<Veiculo>(this, "ProsseguirCmd");
            base.OnDisappearing();
        }

    }
}