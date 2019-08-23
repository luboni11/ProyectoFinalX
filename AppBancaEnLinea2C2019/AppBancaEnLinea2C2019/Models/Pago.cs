using System;
using SQLite;
namespace AppBancaEnLinea2C2019.Models
{
    [Table("Pago")]
    public class Pago
    {
        [PrimaryKey, AutoIncrement]
        public int PAG_CODIGO { get; set; }
        public int SER_CODIGO { get; set; }
        public int CUE_CODIGO { get; set; }
        public DateTime PAG_FECHA { get; set; }
        public decimal PAG_MONTO { get; set; }

        public string PAG_DESCRIPCION_label
        {
            get
            {
                return string.Format("Cuenta: {0} | Monto: {1:N2 | Fecha: {2}}", //numero de dos decimales
                    CUE_CODIGO,
                    PAG_MONTO,
                    PAG_FECHA.ToString("dd/MM/yyyy"));
            }
        }

        public Pago()
        {
        }
    }
}
