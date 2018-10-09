using carros_2.models;
using carros_2.util;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace carros_2.viewmodel
{
    public class VeiculoView : ViewModelBase
    {
        // Using WebAPI .Net Core - Don't forget to change the launchSettings file start server on 127.0.0.1
        // Usando o .net core WebAPI - Não esqueça de mudar o arquivo launchSettings para iniciar a aplicação em 127.0.0.1
        //private const string URL_WEB_SERVER_FOR_CHROME = "http://10.0.2.2:5000/api/veiculo/get/lista-veiculos";
        private const string URL_WEB_SERVER_FOR_CHROME = "http://aluracar.herokuapp.com/";

        private List<Veiculo> veiculos;
        public List<Veiculo> Veiculos
        {
            get
            {
                return veiculos;
            }
            set
            {
                veiculos = value;
                OnPropertyChanged();
            }
        }

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

        private bool carregandoLista;
        public bool CarregandoLista
        {
            get
            {
                return carregandoLista;
            }
            set
            {
                carregandoLista = value;
                OnPropertyChanged();
            }

        }

        // Construtor
        public VeiculoView()
        {
            this.Veiculos = new List<Veiculo>();
        }

        public async Task GetVeiculos() //Task<List<Veiculo>> //Sem Observable
        {
            CarregandoLista = true;
            try
            {
                HttpClientHandler httpClientHandler = new ProxyConfig().CreateSaneparProxyConfig();
                HttpClient cliente = new HttpClient(httpClientHandler, true);
                string veiculosJson = await cliente.GetStringAsync(URL_WEB_SERVER_FOR_CHROME);
                // OservableCollection pode ser usado, especialmente no caso de popular os itens manualmente com .Add() ou .Remove()
                // neste caso ela irá notificar a view sobre as mudanças automaticamente
                this.Veiculos = JsonConvert.DeserializeObject<List<Veiculo>>(veiculosJson);
            }
            catch (Exception ex)
            {
                MessagingCenter.Send<Exception>(ex, "FalhaGetVeiculos");
            }
            CarregandoLista = false;
        }
    }
}