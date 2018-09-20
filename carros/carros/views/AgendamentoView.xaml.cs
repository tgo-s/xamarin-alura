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
		public AgendamentoView (Veiculo veiculo)
		{
			InitializeComponent ();
            this.Title = this.Title = veiculo.Fabricante + " - " + veiculo.Nome;
        }
	}
}