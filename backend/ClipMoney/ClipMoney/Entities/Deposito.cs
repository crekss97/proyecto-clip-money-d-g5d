using System;
using System.Collections.Generic;

#nullable disable

namespace ClipMoney.Entities
{
    public partial class Deposito
    {
        public int IdDeposito { get; set; }
        public int IdCuentaSaliente { get; set; }
        public DateTime Fecha { get; set; }
        public TimeSpan Hora { get; set; }
        public decimal Monto { get; set; }
        public int IdCuentaEntrante { get; set; }

        public virtual Cuentum IdCuentaEntranteNavigation { get; set; }
        public virtual Cuentum IdCuentaSalienteNavigation { get; set; }
    }
}
