using AMV_Travel_Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AMV_Travel_AccessData.Data
{
    public class AMV_TravelDbContext : IdentityDbContext
    {
        public AMV_TravelDbContext() { }

        public AMV_TravelDbContext(DbContextOptions<AMV_TravelDbContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=localhost;Database=DbAMVTravel;Trusted_Connection=True;MultipleActiveResultSets=true");
            }
        }

        public DbSet<Tour> Tours { get; set; }
        public DbSet<Reserva> Reserva { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Tour>(entity =>
            {
                entity.ToTable("Tour");
                entity.HasKey(t => t.Id);
                entity.Property(t => t.Nombre).IsRequired().HasMaxLength(100);
                entity.Property(t => t.Destino).IsRequired().HasMaxLength(100);
                entity.Property(t => t.FechaInicio).IsRequired();
                entity.Property(t => t.FechaFin).IsRequired();
                entity.Property(t => t.Precio).IsRequired().HasColumnType("decimal(18,2)");
            });

            modelBuilder.Entity<Reserva>(entity =>
            {
                entity.ToTable("Reserva");
                entity.HasKey(r => r.Id);
                entity.Property(t => t.Cliente).IsRequired().HasMaxLength(100);
                entity.Property(t => t.FechaReserva).IsRequired();
                entity.HasOne<Tour>()
                      .WithMany()
                      .HasForeignKey(r => r.TourId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            //INSERTS
            modelBuilder.Entity<Tour>().HasData(
                new Tour
                {
                    Id = 1,
                    Nombre = "Tour del Lago",
                    Destino = "Lago Espejo",
                    FechaInicio = DateTime.Parse("2023-05-01"),
                    FechaFin = DateTime.Parse("2023-05-05"),
                    Precio = 300.00M
                },
                new Tour
                {
                    Id = 2,
                    Nombre = "Tour de Montaña",
                    Destino = "Aconcagua",
                    FechaInicio = DateTime.Parse("2023-06-15"),
                    FechaFin = DateTime.Parse("2023-06-20"),
                    Precio = 450.00M
                },
                new Tour
                {
                    Id = 3,
                    Nombre = "Tour del Mar",
                    Destino = "Playa Varese",
                    FechaInicio = DateTime.Parse("2023-06-15"),
                    FechaFin = DateTime.Parse("2023-06-20"),
                    Precio = 250.00M
                });

            modelBuilder.Entity<Reserva>().HasData(
                new Reserva
                {
                    Id = 1,
                    Cliente = "Juan Pérez",
                    FechaReserva = DateTime.Now,
                    TourId = 1
                },
                new Reserva
                {
                    Id = 2,
                    Cliente = "Ana López",
                    FechaReserva = DateTime.Now,
                    TourId = 2
                },
                 new Reserva
                 {
                     Id = 3,
                     Cliente = "Luis Perez",
                     FechaReserva = DateTime.Now,
                     TourId = 3
                 });
        }
    }
}
