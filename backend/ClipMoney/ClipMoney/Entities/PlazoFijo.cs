using System;
using System.Collections.Generic;

#nullable disable

namespace ClipMoney.Entities
{
    public partial class PlazoFijo
    {
        public int IdPlazoFijo { get; set; }
        public decimal Monto { get; set; }
        public decimal Interes { get; set; }
        public int IdCuenta { get; set; }
        public DateTime FechaInicio { get; set; }
        public TimeSpan HoraInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public TimeSpan HoraFin { get; set; }

        public virtual Cuentum IdCuentaNavigation { get; set; }
    }
}
