using System;
using System.Collections.Generic;

#nullable disable

namespace ClipMoney.Entities
{
    public partial class Cuentum
    {
        public Cuentum()
        {
            DepositoIdCuentaEntranteNavigations = new HashSet<Deposito>();
            DepositoIdCuentaSalienteNavigations = new HashSet<Deposito>();
            Extraccions = new HashSet<Extraccion>();
            PlazoFijos = new HashSet<PlazoFijo>();
            Servicios = new HashSet<Servicio>();
            TransferenciumIdCuentaEntranteNavigations = new HashSet<Transferencium>();
            TransferenciumIdCuentaSalienteNavigations = new HashSet<Transferencium>();
        }

        public int IdCuenta { get; set; }
        public int IdUsuario { get; set; }
        public DateTime FechaCreacion { get; set; }
        public TimeSpan HoraCreacion { get; set; }
        public decimal Monto { get; set; }
        public int IdTipoCuenta { get; set; }
        public string Movimientos { get; set; }
        public int IdMoneda { get; set; }
        public int IdCriptomoneda { get; set; }

        public virtual Criptomonedum IdCriptomonedaNavigation { get; set; }
        public virtual Moneda IdMonedaNavigation { get; set; }
        public virtual TipoCuentum IdTipoCuentaNavigation { get; set; }
        public virtual Usuario IdUsuarioNavigation { get; set; }
        public virtual ICollection<Deposito> DepositoIdCuentaEntranteNavigations { get; set; }
        public virtual ICollection<Deposito> DepositoIdCuentaSalienteNavigations { get; set; }
        public virtual ICollection<Extraccion> Extraccions { get; set; }
        public virtual ICollection<PlazoFijo> PlazoFijos { get; set; }
        public virtual ICollection<Servicio> Servicios { get; set; }
        public virtual ICollection<Transferencium> TransferenciumIdCuentaEntranteNavigations { get; set; }
        public virtual ICollection<Transferencium> TransferenciumIdCuentaSalienteNavigations { get; set; }
    }
}
