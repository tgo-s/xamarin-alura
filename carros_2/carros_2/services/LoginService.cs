using carros_2.models;
using Javax.Security.Auth.Login;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Xamarin.Forms;

namespace carros_2.services
{
    public class LoginService
    {
        public async System.Threading.Tasks.Task FazerLogin(Login login)
        {
            using (HttpClient client = new HttpClient())
            {
                FormUrlEncodedContent camposForm = new FormUrlEncodedContent(new[]
                {
                        new KeyValuePair<string,string>("email", login.Usuario),
                        new KeyValuePair<string,string>("senha", login.Senha)
                    });

                
                try
                {
                    //client.BaseAddress = new System.Uri("http://127.0.0.1:5000/api");
                     var result = await client.PostAsync("http://127.0.0.1:5000/api/login/auth/", camposForm);
                    if (result.IsSuccessStatusCode)
                        MessagingCenter.Send<Usuario>(new Usuario(), "SucessoLogin");
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
