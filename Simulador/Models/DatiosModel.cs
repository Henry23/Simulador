namespace Simulador.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DatiosModel : DbContext
    {
        public DatiosModel()
            : base("name=DatiosModel")
        {
        }

        public virtual DbSet<Dato> Datos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Dato>()
                .Property(e => e.material_tanque)
                .IsFixedLength();

            modelBuilder.Entity<Dato>()
                .Property(e => e.cant_ml_s)
                .IsFixedLength();

            modelBuilder.Entity<Dato>()
                .Property(e => e.cant_ml_incial)
                .IsFixedLength();
        }
    }
}
