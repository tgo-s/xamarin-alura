using carros_2.models;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Xamarin.Forms;

namespace carros_2.viewmodel
{
    // Caso seja necessário implementar na view model o OnPropertyChanged para escutar as alterações entre view e model
    // é necessário que implemente a Interface ao INotifyPropertyChanged e crie seu método OnPropertyChanged
    public class DetalheVeiculoView //: ViewModelBase
    {
        public DetalheVeiculoView(Veiculo veiculo)
        {
            Veiculo = veiculo;
            ProsseguirCmd = new Command(() => 
            {
                try
                {
                    MessagingCenter.Send<Veiculo>(veiculo, "ProsseguirCmd");
                }
                catch (System.Exception ex)
                {
                    throw ex;
                }
            });
        }

        public Veiculo Veiculo { get; set; }
        public ICommand ProsseguirCmd { get; set; }
        public string Titulo
        {
            get
            {
                return this.Veiculo.Fabricante + " - " + this.Veiculo.Nome;
            }
        }
        public string TextoValorTotal { get
            {
                return "Total " + this.Veiculo.ValorTotal.ToString("C2");
            }
        }
    }
}
