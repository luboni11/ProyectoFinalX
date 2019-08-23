using System;
using SQLite;
namespace AppBancaEnLinea2C2019.Models
{
    [Table("Servicio")]
    public class Servicio
    {
        [PrimaryKey, AutoIncrement]
        public int SER_CODIGO { get; set; }
        [MaxLength(250)]
        public string SER_DESCRIPCION { get; set; }
        [MaxLength(250)]
        public string SER_ESTADO { get; set; }

        public Servicio()
        {
        }
    }
}
