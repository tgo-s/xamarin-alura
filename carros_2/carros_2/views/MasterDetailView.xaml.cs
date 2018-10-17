using carros_2.models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace carros_2.views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MasterDetailView : MasterDetailPage
    {
        private readonly Usuario usuario;
        public MasterDetailView(Usuario usuario)
        {
            InitializeComponent();
            this.usuario = usuario;
            this.Master = new MasterView(this.usuario);
            this.Detail = new NavigationPage(new CarrosView(this.usuario));

        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            AssinarMensagens();
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            CancelarAssinaturas();
        }

        private void CancelarAssinaturas()
        {
            MessagingCenter.Unsubscribe<Usuario>(this, "MeusAgendamentos");
        }

        private void AssinarMensagens()
        {
            MessagingCenter.Subscribe<Usuario>(this, "MeusAgendamentos",
                            (usuario) =>
                            {
                                this.Detail = new NavigationPage(new AgendamentosUsuarioView());
                                // Esconde a página master
                                this.IsPresented = false;
                            });
        }
    }
}