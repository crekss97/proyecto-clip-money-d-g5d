using System;
using System.Collections.Generic;

#nullable disable

namespace ClipMoney.Entities
{
    public partial class Usuario
    {
        public Usuario()
        {
            Cuenta = new HashSet<Cuentum>();
        }

        public int IdUsuario { get; set; }
        public string NombreUsuario { get; set; }
        public string Contraseña { get; set; }
        public string Apellido { get; set; }
        public byte[] Dnidorsal { get; set; }
        public string Mail { get; set; }
        public byte[] Dnifrontal { get; set; }
        public string Cbu { get; set; }

        public virtual ICollection<Cuentum> Cuenta { get; set; }
    }
}
