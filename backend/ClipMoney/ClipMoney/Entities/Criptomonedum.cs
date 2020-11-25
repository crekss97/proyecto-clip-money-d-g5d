using System;
using System.Collections.Generic;

#nullable disable

namespace ClipMoney.Entities
{
    public partial class Criptomonedum
    {
        public Criptomonedum()
        {
            Cuenta = new HashSet<Cuentum>();
        }

        public int IdCriptomoneda { get; set; }
        public string Nombre { get; set; }
        public decimal ValorCriptomoneda { get; set; }
        public decimal Cantidad { get; set; }
        public DateTime FechaCompra { get; set; }
        public TimeSpan HoraCompra { get; set; }

        public virtual ICollection<Cuentum> Cuenta { get; set; }
    }
}
