using System;
using System.Collections.Generic;

#nullable disable

namespace ClipMoney.Entities
{
    public partial class Movimiento
    {
        public int IdMovimiento { get; set; }
        public int? IdExtraccion { get; set; }
        public int? IdTransferencia { get; set; }
        public int? IdDeposito { get; set; }
    }
}
