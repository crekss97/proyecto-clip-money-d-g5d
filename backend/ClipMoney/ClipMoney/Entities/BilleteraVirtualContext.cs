using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace ClipMoney.Entities
{
    public partial class BilleteraVirtualContext : DbContext
    {
        public BilleteraVirtualContext()
        {
        }

        public BilleteraVirtualContext(DbContextOptions<BilleteraVirtualContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Criptomonedum> Criptomoneda { get; set; }
        public virtual DbSet<Cuentum> Cuenta { get; set; }
        public virtual DbSet<Deposito> Depositos { get; set; }
        public virtual DbSet<Extraccion> Extraccions { get; set; }
        public virtual DbSet<Moneda> Monedas { get; set; }
        public virtual DbSet<Movimiento> Movimientos { get; set; }
        public virtual DbSet<PlazoFijo> PlazoFijos { get; set; }
        public virtual DbSet<Servicio> Servicios { get; set; }
        public virtual DbSet<TipoCuentum> TipoCuenta { get; set; }
        public virtual DbSet<Transferencium> Transferencia { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("server=localhost\\SQLEXPRESS;database=billetera_virtual;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Criptomonedum>(entity =>
            {
                entity.HasKey(e => e.IdCriptomoneda);

                entity.Property(e => e.IdCriptomoneda).HasColumnName("id_criptomoneda");

                entity.Property(e => e.Cantidad)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("cantidad");

                entity.Property(e => e.FechaCompra)
                    .HasColumnType("date")
                    .HasColumnName("fechaCompra");

                entity.Property(e => e.HoraCompra).HasColumnName("horaCompra");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.ValorCriptomoneda)
                    .HasColumnType("money")
                    .HasColumnName("valorCriptomoneda");
            });

            modelBuilder.Entity<Cuentum>(entity =>
            {
                entity.HasKey(e => e.IdCuenta);

                entity.Property(e => e.IdCuenta).HasColumnName("id_cuenta");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("date")
                    .HasColumnName("fechaCreacion");

                entity.Property(e => e.HoraCreacion).HasColumnName("horaCreacion");

                entity.Property(e => e.IdCriptomoneda).HasColumnName("id_criptomoneda");

                entity.Property(e => e.IdMoneda).HasColumnName("id_moneda");

                entity.Property(e => e.IdTipoCuenta).HasColumnName("id_tipoCuenta");

                entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");

                entity.Property(e => e.Monto)
                    .HasColumnType("money")
                    .HasColumnName("monto");

                entity.Property(e => e.Movimientos)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("movimientos")
                    .IsFixedLength(true);

                entity.HasOne(d => d.IdCriptomonedaNavigation)
                    .WithMany(p => p.Cuenta)
                    .HasForeignKey(d => d.IdCriptomoneda)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Cuenta_Criptomoneda");

                entity.HasOne(d => d.IdMonedaNavigation)
                    .WithMany(p => p.Cuenta)
                    .HasForeignKey(d => d.IdMoneda)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Cuenta_Monedas");

                entity.HasOne(d => d.IdTipoCuentaNavigation)
                    .WithMany(p => p.Cuenta)
                    .HasForeignKey(d => d.IdTipoCuenta)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Cuenta_tipoCuenta");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Cuenta)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Cuenta_Usuario");
            });

            modelBuilder.Entity<Deposito>(entity =>
            {
                entity.HasKey(e => e.IdDeposito);

                entity.ToTable("Deposito");

                entity.Property(e => e.IdDeposito).HasColumnName("id_deposito");

                entity.Property(e => e.Fecha)
                    .HasColumnType("date")
                    .HasColumnName("fecha");

                entity.Property(e => e.Hora).HasColumnName("hora");

                entity.Property(e => e.IdCuentaEntrante).HasColumnName("id_cuentaEntrante");

                entity.Property(e => e.IdCuentaSaliente).HasColumnName("id_cuentaSaliente");

                entity.Property(e => e.Monto)
                    .HasColumnType("money")
                    .HasColumnName("monto");

                entity.HasOne(d => d.IdCuentaEntranteNavigation)
                    .WithMany(p => p.DepositoIdCuentaEntranteNavigations)
                    .HasForeignKey(d => d.IdCuentaEntrante)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Deposito_Cuenta");

                entity.HasOne(d => d.IdCuentaSalienteNavigation)
                    .WithMany(p => p.DepositoIdCuentaSalienteNavigations)
                    .HasForeignKey(d => d.IdCuentaSaliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Deposito_Cuenta1");
            });

            modelBuilder.Entity<Extraccion>(entity =>
            {
                entity.HasKey(e => e.IdExtraccion);

                entity.ToTable("Extraccion");

                entity.Property(e => e.IdExtraccion).HasColumnName("id_extraccion");

                entity.Property(e => e.Fecha)
                    .HasColumnType("date")
                    .HasColumnName("fecha");

                entity.Property(e => e.Hora).HasColumnName("hora");

                entity.Property(e => e.IdCuentaExtraccion).HasColumnName("id_cuentaExtraccion");

                entity.Property(e => e.Monto)
                    .HasColumnType("money")
                    .HasColumnName("monto");

                entity.HasOne(d => d.IdCuentaExtraccionNavigation)
                    .WithMany(p => p.Extraccions)
                    .HasForeignKey(d => d.IdCuentaExtraccion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Extraccion_Cuenta");
            });

            modelBuilder.Entity<Moneda>(entity =>
            {
                entity.HasKey(e => e.IdMonedas);

                entity.Property(e => e.IdMonedas).HasColumnName("id_monedas");

                entity.Property(e => e.FechaCompra)
                    .HasColumnType("date")
                    .HasColumnName("fechaCompra");

                entity.Property(e => e.HoraCompra).HasColumnName("horaCompra");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.ValorMoneda)
                    .HasColumnType("money")
                    .HasColumnName("valorMoneda");
            });

            modelBuilder.Entity<Movimiento>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.IdDeposito).HasColumnName("id_deposito");

                entity.Property(e => e.IdExtraccion).HasColumnName("id_extraccion");

                entity.Property(e => e.IdMovimiento)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id_movimiento");

                entity.Property(e => e.IdTransferencia).HasColumnName("id_transferencia");
            });

            modelBuilder.Entity<PlazoFijo>(entity =>
            {
                entity.HasKey(e => e.IdPlazoFijo);

                entity.ToTable("plazoFijo");

                entity.Property(e => e.IdPlazoFijo).HasColumnName("id_plazoFijo");

                entity.Property(e => e.FechaFin)
                    .HasColumnType("date")
                    .HasColumnName("fechaFin");

                entity.Property(e => e.FechaInicio)
                    .HasColumnType("date")
                    .HasColumnName("fechaInicio");

                entity.Property(e => e.HoraFin).HasColumnName("horaFin");

                entity.Property(e => e.HoraInicio).HasColumnName("horaInicio");

                entity.Property(e => e.IdCuenta).HasColumnName("id_cuenta");

                entity.Property(e => e.Interes)
                    .HasColumnType("numeric(2, 1)")
                    .HasColumnName("interes");

                entity.Property(e => e.Monto)
                    .HasColumnType("money")
                    .HasColumnName("monto");

                entity.HasOne(d => d.IdCuentaNavigation)
                    .WithMany(p => p.PlazoFijos)
                    .HasForeignKey(d => d.IdCuenta)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_plazoFijo_Cuenta");
            });

            modelBuilder.Entity<Servicio>(entity =>
            {
                entity.HasKey(e => e.IdServicios);

                entity.Property(e => e.IdServicios).HasColumnName("id_servicios");

                entity.Property(e => e.FechaPagado)
                    .HasColumnType("date")
                    .HasColumnName("fechaPagado");

                entity.Property(e => e.FechaVencimiento)
                    .HasColumnType("date")
                    .HasColumnName("fechaVencimiento");

                entity.Property(e => e.HoraPagado).HasColumnName("horaPagado");

                entity.Property(e => e.HoraVencimiento).HasColumnName("horaVencimiento");

                entity.Property(e => e.IdCuenta).HasColumnName("id_cuenta");

                entity.Property(e => e.Monto)
                    .HasColumnType("money")
                    .HasColumnName("monto");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.HasOne(d => d.IdCuentaNavigation)
                    .WithMany(p => p.Servicios)
                    .HasForeignKey(d => d.IdCuenta)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Servicios_Cuenta");
            });

            modelBuilder.Entity<TipoCuentum>(entity =>
            {
                entity.HasKey(e => e.IdTipoCuenta);

                entity.ToTable("tipoCuenta");

                entity.Property(e => e.IdTipoCuenta).HasColumnName("id_tipoCuenta");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<Transferencium>(entity =>
            {
                entity.HasKey(e => e.IdTransferencia);

                entity.Property(e => e.IdTransferencia).HasColumnName("id_transferencia");

                entity.Property(e => e.Fecha)
                    .HasColumnType("date")
                    .HasColumnName("fecha");

                entity.Property(e => e.Hora).HasColumnName("hora");

                entity.Property(e => e.IdCuentaEntrante).HasColumnName("id_cuentaEntrante");

                entity.Property(e => e.IdCuentaSaliente).HasColumnName("id_cuentaSaliente");

                entity.Property(e => e.Monto)
                    .HasColumnType("money")
                    .HasColumnName("monto");

                entity.HasOne(d => d.IdCuentaEntranteNavigation)
                    .WithMany(p => p.TransferenciumIdCuentaEntranteNavigations)
                    .HasForeignKey(d => d.IdCuentaEntrante)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Transferencia_Cuenta1");

                entity.HasOne(d => d.IdCuentaSalienteNavigation)
                    .WithMany(p => p.TransferenciumIdCuentaSalienteNavigations)
                    .HasForeignKey(d => d.IdCuentaSaliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Transferencia_Cuenta");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario);

                entity.ToTable("Usuario");

                entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");

                entity.Property(e => e.Apellido)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("apellido");

                entity.Property(e => e.Cbu)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CBU");

                entity.Property(e => e.Contraseña)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("contraseña");

                entity.Property(e => e.Dnidorsal)
                    .IsRequired()
                    .HasColumnType("image")
                    .HasColumnName("DNIDorsal");

                entity.Property(e => e.Dnifrontal)
                    .IsRequired()
                    .HasColumnType("image")
                    .HasColumnName("DNIFrontal");

                entity.Property(e => e.Mail)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("mail");

                entity.Property(e => e.NombreUsuario)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombreUsuario");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
