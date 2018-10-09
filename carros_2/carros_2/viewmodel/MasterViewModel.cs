using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using carros_2.models;
using Xamarin.Forms;

namespace carros_2.viewmodel
{
    public class MasterViewModel : ViewModelBase
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
            DefinirComandos(usuario);
        }

        private void DefinirComandos(Usuario usuario)
        {
            EditarPerfilCommand = new Command(() =>
            {
                MessagingCenter.Send<Usuario>(usuario, "EditarPerfil");
                
            });

            SalvarPerfilCommand = new Command(() =>
            {
                MessagingCenter.Send<Usuario>(usuario, "SalvarPerfil");
            });
        }

        public string Email
        {
            get { return this.usuario.Email; }
            set { this.usuario.Email = value; }
        }

        public string DataNascimento
        {
            get { return usuario.DataNascimento; }
            set { usuario.DataNascimento = value; }
        }

        public string Telefone
        {
            get { return usuario.Telefone; }
            set { usuario.Telefone = value; }
        }

        private bool editando = false;
        public bool Editando
        {
            get { return editando; }
            set
            {
                editando = value;
                OnPropertyChanged(nameof(Editando));
            }
        }

        public ICommand EditarPerfilCommand { get; private set; }
        public ICommand SalvarPerfilCommand { get; private set; }

    }
}
