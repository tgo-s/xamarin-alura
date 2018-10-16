using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using carros_2.data;
using carros_2.Droid;
using SQLite;

[assembly: Xamarin.Forms.Dependency(typeof(SQLiteAndroid))]
namespace carros_2.Droid
{
    public class SQLiteAndroid : ISQLite
    {
        private const string DatabasePath = "agendamento.db3";

        public SQLiteConnection PegarConexao()
        {
            var caminhoData = Path.Combine(Android.OS.Environment.ExternalStorageDirectory.Path, DatabasePath);

            return new SQLiteConnection(caminhoData);
        }
    }
}