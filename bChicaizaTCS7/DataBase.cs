using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace bChicaizaTCS7
{
    public interface DataBase
    {
        SQLiteAsyncConnection GetConnection();
    }
}
