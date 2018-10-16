using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Input;
using carros_2.media;
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

            TirarFotoCommand = new Command(() => 
            {
                DependencyService.Get<ICamera>().TirarFoto();
            });

            // Alteração para Bytes para não ter que usara  Java.IO.File

            //MessagingCenter.Subscribe<Java.IO.File>(this, "Foto", (imagem) =>
            //{
            //    this.FotoPerfil = ImageSource.FromFile(imagem.Path);
            //});

            MessagingCenter.Subscribe<byte[]>(this, "Foto", (imagem) =>
            {
                //this.FotoPerfil = ImageSource.FromFile(imagem.Path);
                ImageSource img = ImageSource.FromStream(() => new MemoryStream(imagem));
                this.FotoPerfil = img;
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

        private ImageSource fotoPerfil = "avatar_perfil.png";

        public ImageSource FotoPerfil
        {
            get { return fotoPerfil; }
            private set
            {
                fotoPerfil = value;
                OnPropertyChanged();
            }
        }

        public ICommand EditarPerfilCommand { get; private set; }
        public ICommand SalvarPerfilCommand { get; private set; }
        public ICommand TirarFotoCommand { get; private set; }

    }
}
