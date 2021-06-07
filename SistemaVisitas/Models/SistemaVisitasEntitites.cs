namespace SistemaVisitas.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class SistemaVisitasEntitites : DbContext
    {
        public SistemaVisitasEntitites()
            : base("name=SistemaVisitasEntities")
        {
        }

        public virtual DbSet<EntranceRoomViewModel> ENTRANCEROOMs { get; set; }
        public virtual DbSet<GeneratorRoomViewModel> GENERATORROOMs { get; set; }
        public virtual DbSet<OdcOfficeViewModel> ODCOFFICEs { get; set; }
        public virtual DbSet<RegistroVisitasViewModel> REGISTROVISITAS { get; set; }
        public virtual DbSet<ServerRoomViewModel> SERVERROOMs { get; set; }
        public virtual DbSet<UPSAViewModel> UPSAs { get; set; }
        public virtual DbSet<UPSBViewModel> UPSBs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EntranceRoomViewModel>()
                .HasMany(e => e.REGISTROVISITAS)
                .WithRequired(e => e.ENTRANCEROOM)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<GeneratorRoomViewModel>()
                .HasMany(e => e.REGISTROVISITAS)
                .WithRequired(e => e.GENERATORROOM)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<OdcOfficeViewModel>()
                .HasMany(e => e.REGISTROVISITAS)
                .WithRequired(e => e.ODCOFFICE)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ServerRoomViewModel>()
                .HasMany(e => e.REGISTROVISITAS)
                .WithRequired(e => e.SERVERROOM)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<UPSAViewModel>()
                .HasMany(e => e.REGISTROVISITAS)
                .WithRequired(e => e.UPSA)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<UPSBViewModel>()
                .HasMany(e => e.REGISTROVISITAS)
                .WithRequired(e => e.UPSB)
                .WillCascadeOnDelete(false);
        }
    }
}
