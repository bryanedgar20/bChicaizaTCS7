using Foundation;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using UIKit;

[assembly: Xamarin.Forms.Dependency(typeof(bChicaizaTCS7.iOS.SqliteClient))]
namespace bChicaizaTCS7.iOS
{
    public class SqliteClient: DataBase
    {
        public SQLiteAsyncConnection GetConnection()
        {
            var documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);

            var path = Path.Combine(documentsPath, "uisrael.db3");

            return new SQLiteAsyncConnection(path);
        }
    }
}