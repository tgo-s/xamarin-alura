using System;
using System.Collections.Generic;
using System.Text;
using carros_2.models;

namespace carros_2.viewmodel
{
    public class MasterViewModel
    {
        public string Nome
        {
            get { return this.usuario.Nome; }
            set { this.usuario.Nome = value; }
        }

        private Usuario usuario;

        public MasterViewModel(Usuario usuario)
        {
            this.usuario = usuario;
        }

        public string Email
        {
            get { return this.usuario.Email; }
            set { this.usuario.Email = value; }
        }


    }
}
