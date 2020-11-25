using System;
using System.Collections.Generic;

#nullable disable

namespace ClipMoney.Entities
{
    public partial class Moneda
    {
        public Moneda()
        {
            Cuenta = new HashSet<Cuentum>();
        }

        public int IdMonedas { get; set; }
        public string Nombre { get; set; }
        public decimal ValorMoneda { get; set; }
        public DateTime FechaCompra { get; set; }
        public TimeSpan HoraCompra { get; set; }

        public virtual ICollection<Cuentum> Cuenta { get; set; }
    }
}
