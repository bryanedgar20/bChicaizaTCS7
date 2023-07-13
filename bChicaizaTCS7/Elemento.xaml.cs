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
    public partial class Elemento : ContentPage
    {
        public int idSeleccionado;
        private SQLiteAsyncConnection _connection;


        IEnumerable<Estudiante> _resulDelete;
        IEnumerable<Estudiante> _resulUpdate;


        public Elemento(Estudiante estudiante)
        {
            InitializeComponent();
            _connection = DependencyService.Get<DataBase>().GetConnection();
            idSeleccionado = estudiante.id;
            txtNombre.Text = estudiante.nombre;
            txtUsuario.Text = estudiante.usuario;
            txtClave.Text = estudiante.clave;
        }

        private void btnGuardar_Clicked(object sender, EventArgs e)
        {
            try
            {
                var ruta = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "uisrael.db3");
                var db = new SQLiteConnection(ruta);
                _resulUpdate = Update(db,idSeleccionado,txtNombre.Text,txtUsuario.Text,txtClave.Text);
                Navigation.PushAsync(new ConsultaRegistro());
            }
            catch (Exception ex)
            {

                DisplayAlert("Error", ex.Message, "Ok");
            }
        }

        private void btbEliminar_Clicked(object sender, EventArgs e)
        {
            try
            {

                var ruta = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "uisrael.db3");
                var db = new SQLiteConnection(ruta);

                _resulDelete = Delete(db, idSeleccionado);
                Navigation.PushAsync(new ConsultaRegistro());

            }
            catch (Exception ex)
            {

                DisplayAlert("Error",ex.Message,"Ok");
            }
        }

        public static IEnumerable<Estudiante> Delete(SQLiteConnection db, int id) {
            return db.Query<Estudiante>("Delete from Estudiante where Id = ?", id);
        }

        public static IEnumerable<Estudiante> Update(SQLiteConnection db, int id, string nombre, string usuario, string clave)
        {
            return db.Query<Estudiante>("Update Estudiante Set Nombre = ?, Usuario = ?, Clave = ? where Id = ?",nombre,usuario,clave, id);
        }
    }
}