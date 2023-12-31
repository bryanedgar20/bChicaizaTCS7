﻿using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using bChicaizaTCS7.Droid;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

[assembly: Xamarin.Forms.Dependency(typeof(SqliteClient))]
namespace bChicaizaTCS7.Droid
{
    public class SqliteClient : DataBase
    {
        public SQLiteAsyncConnection GetConnection()
        {
            var documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);

            var path = Path.Combine(documentsPath, "uisrael.db3");

            return new SQLiteAsyncConnection(path);
        }
    }
}