using System;
using SQLite;
namespace AppBancaEnLinea2C2019.Models
{

    [Table("Cuenta")]
    public class Cuenta
    {
        [PrimaryKey, AutoIncrement]
        public int CUE_CODIGO { get; set; }
        [MaxLength(250)]
        public int USU_CODIGO { get; set; }
        [MaxLength(250)]
        public string CUE_DESCRIPCION { get; set; }
        [MaxLength(3)]
        public string CUE_MONEDA { get; set; }
        [MaxLength(250)]
        public decimal CUE_SALDO { get; set; }
        [MaxLength(1)]
        public string CUE_ESTADO { get; set; }

        public string CUE_DESCRIPCION_label
        {
            get
            {
                return string.Format("Cuenta: {0}-{1} | Saldo: {2} {3:N2}",
                    CUE_CODIGO, CUE_DESCRIPCION,
                    (CUE_MONEDA.Trim().Equals("DOL") ? "$" :
                    (CUE_MONEDA.Trim().Equals("COL") ? "₡" : "€")),
                    CUE_SALDO);
            }                
        }

        public string CUE_SALDO_label
        {
            get
            {
                return string.Format("Saldo: {0} {1:N2}",
                    (CUE_MONEDA.Trim().Equals("DOL") ? "$" :
                    (CUE_MONEDA.Trim().Equals("COL") ? "₡" : "€")), CUE_SALDO);
            }
        }

        public Cuenta()
        {
        }
    }
}
//Modelo Vista Controlador
//el que se conecta con la capa de servicio es el Controlador
