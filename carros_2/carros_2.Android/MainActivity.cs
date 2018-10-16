
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Provider;
using Android.Support.V4.Content;
using carros_2.Droid;
using carros_2.media;
using Xamarin.Forms;

[assembly: Xamarin.Forms.Dependency(typeof(MainActivity))]
namespace carros_2.Droid
{
    [Activity(Label = "carros_2", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
                              , ICamera
    {
        static Java.IO.File arquivoImagem;
        internal static MainActivity Instance { get; private set; }

        public void TirarFoto()
        {
            Intent intent = new Intent(MediaStore.ActionImageCapture);

            arquivoImagem = PegarArquivoImagem();

            intent.PutExtra(MediaStore.ExtraOutput, Android.Net.Uri.FromFile(arquivoImagem));

            // A implementação proposta (a seguir) está obsoleta
            //var activity = Forms.Context as Activity;
            //activity.StartActivityForResult(intent, 0);

            // Nova implementação
            var activity = MainActivity.Instance;
            activity.StartActivityForResult(intent, 0);

        }

        private static Java.IO.File PegarArquivoImagem()
        {
            Java.IO.File arquivoImagem;
            Java.IO.File dir = new Java.IO.File(Environment.GetExternalStoragePublicDirectory(Environment.DirectoryPictures), "alura");

            if (!dir.Exists())
                dir.Mkdirs();

            arquivoImagem = new Java.IO.File(dir, "foto_temp.jpg");
            return arquivoImagem;
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            Instance = this;

            // Fix for the issue with android N+ sdk on file:// URI and content:// URI
            StrictMode.VmPolicy.Builder builder = new StrictMode.VmPolicy.Builder();
            StrictMode.SetVmPolicy(builder.Build());

            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            LoadApplication(new App());
        }

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);

            if (resultCode == Result.Ok)
            {
                //Alterado para enviar array de bytes para testes
                //MessagingCenter.Send<Java.IO.File>(arquivoImagem, "Foto");

                byte[] bytes;
                using (var stream = new Java.IO.FileInputStream(arquivoImagem))
                {
                    bytes = new byte[arquivoImagem.Length()];
                    stream.Read(bytes);
                };

                MessagingCenter.Send<byte[]>(bytes, "Foto");

            }

        }
    }
}