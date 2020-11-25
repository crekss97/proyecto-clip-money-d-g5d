using System;
using System.Collections.Generic;

#nullable disable

namespace ClipMoney.Entities
{
    public partial class TipoCuentum
    {
        public TipoCuentum()
        {
            Cuenta = new HashSet<Cuentum>();
        }

        public int IdTipoCuenta { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<Cuentum> Cuenta { get; set; }
    }
}
