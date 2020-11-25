using System;
using System.Collections.Generic;

#nullable disable

namespace ClipMoney.Entities
{
    public partial class Extraccion
    {
        public int IdExtraccion { get; set; }
        public DateTime Fecha { get; set; }
        public TimeSpan Hora { get; set; }
        public decimal Monto { get; set; }
        public int IdCuentaExtraccion { get; set; }

        public virtual Cuentum IdCuentaExtraccionNavigation { get; set; }
    }
}
