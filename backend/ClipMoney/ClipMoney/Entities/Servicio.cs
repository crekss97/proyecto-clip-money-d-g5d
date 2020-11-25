using System;
using System.Collections.Generic;

#nullable disable

namespace ClipMoney.Entities
{
    public partial class Servicio
    {
        public int IdServicios { get; set; }
        public string Nombre { get; set; }
        public decimal Monto { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public TimeSpan HoraVencimiento { get; set; }
        public int IdCuenta { get; set; }
        public DateTime FechaPagado { get; set; }
        public TimeSpan HoraPagado { get; set; }

        public virtual Cuentum IdCuentaNavigation { get; set; }
    }
}
