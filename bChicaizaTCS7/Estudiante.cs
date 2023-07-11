using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace bChicaizaTCS7
{
    public class Estudiante
    {
        [PrimaryKey, AutoIncrement]
        public int id {  get; set; }

        [MaxLength(100)]
        public string nombre { get; set; }

        [MaxLength(100)]
        public string usuario { get; set; }

        [MaxLength(100)]
        public string clave { get; set; }
    }
}
