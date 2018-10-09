using carros_2.models;
using carros_2.util;
using Javax.Security.Auth.Login;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using Xamarin.Forms;

namespace carros_2.services
{
    public class LoginService
    {
        public async System.Threading.Tasks.Task FazerLogin(Login login)
        {
            HttpClientHandler httpClientHandler = new ProxyConfig().CreateSaneparProxyConfig();

            using (HttpClient client = new HttpClient(handler: httpClientHandler, disposeHandler: true))
            {
                FormUrlEncodedContent camposForm = new FormUrlEncodedContent(new[]
                {
                        new KeyValuePair<string,string>("email", login.Usuario),
                        new KeyValuePair<string,string>("senha", login.Senha)
                    });

                
                try
                {
                    //client.BaseAddress = new System.Uri("http://127.0.0.1:5000/api");
                    //var result = await client.PostAsync("http://127.0.0.1:5000/api/login/auth/", camposForm);
                    
                    var result = await client.PostAsync("http://aluracar.herokuapp.com/login", camposForm);
                    if (result.IsSuccessStatusCode)
                    {
                        var conteudo = await result.Content.ReadAsStringAsync();
                        var jsonObject = JsonConvert.DeserializeObject<ResultadoLogin>(conteudo);
                        MessagingCenter.Send<Usuario>(jsonObject.Usuario, "SucessoLogin");
                    }
                    else
                        MessagingCenter.Send<LoginException>(new LoginException("Usuario ou senha inválidos"), "FalhaLogin");
                }
                catch (Exception ex)
                {
                    MessagingCenter.Send<HttpRequestException>(new HttpRequestException("Erro ao tentar se conectar com o servidor de login"), "FalhaConexao");
                }
            }
        }
    }
}
