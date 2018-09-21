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
	public partial class AgendamentoView : ContentPage
	{
        public AgendamentoForm Form { get;set; }
		public AgendamentoView (Veiculo veiculo)
		{
			InitializeComponent ();
            this.Title = this.Title = veiculo.Fabricante + " - " + veiculo.Nome;
            this.Form = new AgendamentoForm();
            this.Form.Veiculo = veiculo;
            this.BindingContext = this.Form;
        }
	}

    public class AgendamentoForm
    {
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public DateTime Data { get; set; }
        public TimeSpan Hora { get; set; }
        public Veiculo Veiculo { get; set; }
    }
}