using System.Collections.Generic;
using Xamarin.Forms;

namespace carros.views
{
    public partial class CarrosView : ContentPage
    {
        public CarrosView()
        {
            this.BindingContext = new VeiculoView();
            InitializeComponent();
        }

        private void listaVeiculos_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            Veiculo veiculo = (Veiculo)e.Item;
            //Aula 2
            //DisplayAlert("Veículo selecionado", string.Format("Você selecionou o veículo {0} {1}, cujo preço é {2}", veiculo.Fabricante, veiculo.Nome, veiculo.Preco.ToString("C2")), "Ok");
            //Aula 2

            //Aula 3
            Navigation.PushAsync(new DetalheView(veiculo));
        }
    }

    public class VeiculoView
    {
        public List<Veiculo> Veiculos { get; set; }
        public VeiculoView()
        {
            this.Veiculos = new List<Veiculo>()
            {
                new Veiculo { Fabricante="Ford", Nome="Mustang", Preco=350000 },
                new Veiculo { Fabricante="GM", Nome="Camaro", Preco=340000 },
                new Veiculo { Fabricante="Dodge", Nome="Charger", Preco=370000 },
            };
        }
    }

    public class Veiculo
    {
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public string Fabricante { get; set; }
        public List<Acessorio> Acessorios { get; set; }
    }

    public class Acessorio
    {
        public string Nome { get; set; }
        public decimal Valor { get; set; }
        public bool Ativo { get; set; }
        public string AcessorioValorado
        { get
            {
                return string.Format("{0} - {1}", this.Nome, this.Valor.ToString("C2"));
            }
        }
    }
}
