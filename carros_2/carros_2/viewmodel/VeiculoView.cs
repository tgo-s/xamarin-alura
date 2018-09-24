using carros_2.models;
using System.Collections.Generic;
using Xamarin.Forms;

namespace carros_2.viewmodel
{
    public class VeiculoView
    {
        public List<Veiculo> Veiculos { get; set; }
        Veiculo veiculoSelecionado;
        // A nova propriedade VeiculoSelecionado fará binding com a view e ao mudar o valor, irá notificar nosso sistema de mensageria
        // Responsável por redirecionar nosso fluxo ao invés do evento da página
        public Veiculo VeiculoSelecionado
        {
            get { return veiculoSelecionado; }
            set
            {
                veiculoSelecionado = value;
                if(veiculoSelecionado != null)
                    MessagingCenter.Send(veiculoSelecionado, "VeiculoSelecionado");
            }
        }
        public VeiculoView()
        {
            this.Veiculos = new ListagemVeiculos().Veiculos;
        }
    }
}