using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace carros.views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DetalheView : ContentPage
	{
        private Veiculo Veiculo { get; set; }

		public DetalheView (Veiculo veiculo)
		{
            this.Veiculo = veiculo;
            this.Veiculo.Acessorios = this.InicializaAcessorios();
            this.Title = veiculo.Fabricante + " - " + veiculo.Nome;
            this.BindingContext = this.Veiculo;
            InitializeComponent();
        }

        private List<Acessorio> InicializaAcessorios()
        {
            return new List<Acessorio>()
            {
                new Acessorio(){ Nome = "Turbo", Valor = 15000, Ativo=false },
                new Acessorio(){ Nome = "ECU", Valor = 10000, Ativo=false },
                new Acessorio(){ Nome = "Freios ABS", Valor = 7000, Ativo=false },
                new Acessorio(){ Nome = "Conjunto de Rodas 19\"", Valor = 12000, Ativo=false },
            };
        }

        private void btnProsseguir_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AgendamentoView(this.Veiculo));
        }
    }
}