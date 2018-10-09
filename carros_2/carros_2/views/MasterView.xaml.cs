using carros_2.models;
using carros_2.viewmodel;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace carros_2.views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MasterView : TabbedPage
    {

        public MasterView(Usuario usuario)
        {
            InitializeComponent();
            this.BindingContext = new MasterViewModel(usuario);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            this.AssinarMensagens();
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
        }

        private void AssinarMensagens()
        {
            MessagingCenter.Subscribe<Usuario>(this, "EditarPerfil",
                (usuario) =>
                {
                    ((MasterViewModel)this.BindingContext).Editando = true;
                    this.CurrentPage = this.Children[1];

                });
            MessagingCenter.Subscribe<Usuario>(this, "SalvarPerfil",
                (usuario) =>
                {
                    ((MasterViewModel)this.BindingContext).Editando = false;
                    this.CurrentPage = this.Children[0];

                });
        }

        private void CanccelarMensagens()
        {
            MessagingCenter.Unsubscribe<Usuario>(this, "EditarPerfil");
            MessagingCenter.Unsubscribe<Usuario>(this, "SalvarPerfil");
        }

        private void TabbedPage_CurrentPageChanged(object sender, System.EventArgs e)
        {
            var i = this.Children.IndexOf(this.CurrentPage);

            if (this.BindingContext != null && i == 0)
                ((MasterViewModel)this.BindingContext).Editando = false;
        }
    }
}