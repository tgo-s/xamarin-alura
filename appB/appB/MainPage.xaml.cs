using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace appB
{
    public partial class MainPage : ContentPage
    {
        public List<Veiculo> Veiculos { get; set; }
        public MainPage()
        {
            //Fazendo analogia com MVC, no BidingContext vc define sua classe de View
            this.BindingContext = new VeiculoView();

            InitializeComponent();
        }
    }

    public class VeiculoView
    {
        public List<Veiculo> Veiculos { get; set; }
        public VeiculoView()
        {
            this.Veiculos = new List<Veiculo>()
            {
                new Veiculo { Nome="Camaro", Preco=170000},
                new Veiculo {Nome="Golf", Preco=75000},
                new Veiculo {Nome="Lancer EVO X", Preco=120000}
            };
        }
    }

    public class Veiculo
    {
        public string Nome { get; set; }
        public decimal Preco { get; set; }
    }
}
