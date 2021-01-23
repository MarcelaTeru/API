namespace API.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<Banco> Banco { get; set; }
        public virtual DbSet<Promocion> Promocion { get; set; }
        public virtual DbSet<ReporteVenta> ReporteVenta { get; set; }
        public virtual DbSet<Banquete> Banquete { get; set; }
        public virtual DbSet<hotel> hotel { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Banco>()
                .Property(e => e.AccountCompanyId)
                .IsUnicode(false);

            modelBuilder.Entity<Promocion>()
                .Property(e => e.id_producto)
                .IsUnicode(false);

            modelBuilder.Entity<Promocion>()
                .Property(e => e.nombreProm)
                .IsUnicode(false);

            modelBuilder.Entity<Promocion>()
                .Property(e => e.infoPromocion)
                .IsUnicode(false);

            modelBuilder.Entity<Promocion>()
                .Property(e => e.codigoPromo)
                .IsUnicode(false);

            modelBuilder.Entity<Promocion>()
                .Property(e => e.area)
                .IsUnicode(false);

            modelBuilder.Entity<ReporteVenta>()
                .Property(e => e.id_producto)
                .IsUnicode(false);

            modelBuilder.Entity<ReporteVenta>()
                .Property(e => e.nombre_prod)
                .IsUnicode(false);

            modelBuilder.Entity<Banquete>()
                .Property(e => e.descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<Banquete>()
                .Property(e => e.precio)
                .HasPrecision(10, 0);

            modelBuilder.Entity<hotel>()
                .Property(e => e.nombreServicio)
                .IsUnicode(false);

            modelBuilder.Entity<hotel>()
                .Property(e => e.detalles)
                .IsUnicode(false);
        }
    }
}
