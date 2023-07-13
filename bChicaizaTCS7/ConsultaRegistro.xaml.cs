using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace bChicaizaTCS7
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ConsultaRegistro : ContentPage
    {
        private SQLiteAsyncConnection conn;
        private ObservableCollection<Estudiante> tableStudies;

        public ConsultaRegistro()
        {
            InitializeComponent();
            conn = DependencyService.Get<DataBase>().GetConnection();
            NavigationPage.SetHasBackButton(this, false);
        }

        protected async override void OnAppearing()
        {
            var resultRecord = await conn.Table<Estudiante>().ToListAsync();
            tableStudies = new ObservableCollection<Estudiante>(resultRecord);
            MyListView.ItemsSource = tableStudies;
            base.OnAppearing();
        }

        private void MyListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var obj = (Estudiante)e.SelectedItem;

            try
            {
                Navigation.PushAsync(new Elemento(obj));
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}