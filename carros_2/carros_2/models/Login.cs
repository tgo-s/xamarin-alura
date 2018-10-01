using System;
using System.Collections.Generic;
using System.Text;

namespace carros_2.models
{
    public class Login
    {
        public Login()
        {

        }
        public Login(string usuario, string senha)
        {
            this.Usuario = usuario;
            this.Senha = senha;
        }

        public string Usuario { get; set; }
        public string Senha { get; set; }
    }
}

