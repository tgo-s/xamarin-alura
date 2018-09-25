using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace carros_2.models
{
    public class ListagemVeiculos
    {
        private const string URL_WEB_SERVER_FOR_CHROME= "10.0.2.2:8887/GetListaVeiculos.html";

        public List<Veiculo> Veiculos { get; set; }
        public ListagemVeiculos()
        {
            // TODO: converter o string em JSON e consequentemente em objeto Veiculo
            this.Veiculos = new List<Veiculo>();
            Task<List<Veiculo>> t = GetVeiculos();
            this.Veiculos = t.Result;
        }

        public async Task<List<Veiculo>> GetVeiculos()
        {
            HttpClient cliente = new HttpClient();
            string veiculosJson = await cliente.GetStringAsync(URL_WEB_SERVER_FOR_CHROME);
            List<Veiculo> liVeiculos = JsonConvert.DeserializeObject<List<Veiculo>>(veiculosJson);
            return liVeiculos;
        }
    }
}