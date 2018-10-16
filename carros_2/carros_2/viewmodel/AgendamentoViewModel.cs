using carros_2.data;
using carros_2.models;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace carros_2.viewmodel
{
    public class AgendamentoViewModel : ViewModelBase
    {
        private const string URL_POST_MARCAR_AGENDAMENTO = "http://aluracar.herokuapp.com/salvaragendamento";

        public string TituloPagina
        {
            get
            {
                //return Agendamento.Veiculo.Fabricante + " - " + Agendamento.Veiculo.Nome;
                return Agendamento.Modelo;
            }
        }
        public ICommand AgendarCmd { get; set; }
        
        public AgendamentoViewModel(Veiculo veiculo, Usuario usuario)
        {
            Agendamento = new Agendamento(usuario.Nome, usuario.Telefone, usuario.Email, veiculo.Nome, veiculo.ValorTotal);
            Agendamento.Data = DateTime.Today;
            AgendarCmd = new Command(() => 
            {
                MessagingCenter.Send(this, "AgendarTestDrive");
            });
        }

        public Agendamento Agendamento { get; set; }

        public async Task MarcarAgendamentoAsync()
        {
            HttpClient client = new HttpClient();
            var agendamentoJson = JsonConvert.SerializeObject(this.Agendamento);
            StringContent agendamentoContent = new StringContent(agendamentoJson.ToString());
            var resposta = await client.PostAsync(URL_POST_MARCAR_AGENDAMENTO, agendamentoContent);

            SalvarAgendamentoData();

            if (resposta.IsSuccessStatusCode)
            {
                MessagingCenter.Send<Agendamento>(this.Agendamento, "AgendamentoMarcado");
            }
            else
            {
                MessagingCenter.Send<ArgumentException>(new ArgumentException(), "ProblemaAoAgendar");
            }
        }

        private void SalvarAgendamentoData()
        {
            using (var conn = DependencyService.Get<ISQLite>().PegarConexao())
            {
                AgendamentoDAO dao = new AgendamentoDAO(conn);
                dao.Salvar(this.Agendamento);
            };
        }
    }
}