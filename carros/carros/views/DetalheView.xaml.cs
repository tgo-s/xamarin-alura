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
        public Veiculo Veiculo { get; set; }

		public DetalheView (Veiculo veiculo)
		{
            InitializeComponent();
            this.Veiculo = veiculo;
            this.Veiculo.Acessorios = this.InicializaAcessorios();
            this.Title = veiculo.Fabricante + " - " + veiculo.Nome;
            this.Veiculo.ValorTotal = this.Veiculo.Preco;
            this.txtValorTotal.Text = "Total " + this.Veiculo.ValorTotal.ToString("C2");
            this.BindingContext = this.Veiculo;
            
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

        private void SwitchCell_OnChanged(object sender, ToggledEventArgs e)
        {
            this.Veiculo.ValorTotal = this.Veiculo.Preco + this.Veiculo.Acessorios.Where(a => a.Ativo).Sum(v => v.Valor);
            this.txtValorTotal.Text = "Total " + this.Veiculo.ValorTotal.ToString("C2");
        }

    }
}