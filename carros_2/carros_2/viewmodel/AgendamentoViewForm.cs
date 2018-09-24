using carros_2.models;
using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace carros_2.viewmodel
{
    public class AgendamentoViewModel
    {
        public string TituloPagina
        {
            get
            {
                return Veiculo.Fabricante + " - " + Veiculo.Nome;
            }
        }
        public ICommand AgendarCmd { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public DateTime Data { get; set; }
        public TimeSpan Hora { get; set; }
        public Veiculo Veiculo { get; set; }

        public AgendamentoViewModel(Veiculo veiculo)
        {
            Veiculo = veiculo;
            this.Data = DateTime.Today;
            AgendarCmd = new Command(() => 
            {
                MessagingCenter.Send(this, "AgendarTestDrive");
            });
        }
    }
}