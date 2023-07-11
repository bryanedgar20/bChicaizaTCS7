using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace bChicaizaTCS7
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page1 : ContentPage
    {
        private SQLiteAsyncConnection _conn;
        public Page1()
        {
            InitializeComponent();
            _conn = DependencyService.Get<DataBase>().GetConnection();
        }

        private void btnLogin_Clicked(object sender, EventArgs e)
        {


            try
            {
                var dataBasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "uisrael.db3");

                var db = new SQLiteConnection(dataBasePath);

                db.CreateTable<Estudiante>();

                IEnumerable<Estudiante> result = SELECT_WHERE(db, txtUsuario.Text, txtClave.Text);

                if (result.Count() > 0)
                {
                    Navigation.PushAsync(new ConsultaRegistro());
                }
                else
                {
                    DisplayAlert("Alerta", "Credenciales incorrectas", "Aceptar");
                }
            }
            catch (Exception ex)
            {

                DisplayAlert("ERROR!", ex.Message, "Ok");
            }
        }

        private async void btnRegistrar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Registro());
        }

        public static IEnumerable<Estudiante> SELECT_WHERE(SQLiteConnection db,string usuario, string clave)
        {
            return db.Query<Estudiante>("Select * from Estudiante where Usuario = ? and Clave = ?", usuario, clave);
        }
    }
}