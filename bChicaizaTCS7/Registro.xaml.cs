using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace bChicaizaTCS7
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Registro : ContentPage
    {
        private SQLiteAsyncConnection _conn;
        public Registro()
        {
            InitializeComponent();
            _conn = DependencyService.Get<DataBase>().GetConnection();
        }

        private void btnRegistrar_Clicked(object sender, EventArgs e)
        {
            var datosRegistro = new Estudiante { nombre = txtNombre.Text, usuario = txtUsuario.Text, clave = txtClave.Text };
            _conn.InsertAsync(datosRegistro);
            cleanForm();
        }

        private void cleanForm()
        {
            txtNombre.Text = "";
            txtUsuario.Text = "";
            txtClave.Text = "";
            DisplayAlert("Exito", "Se agrego correctamente!!", "Aceptar");
        }
    }
}