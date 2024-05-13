using EX.Core.Domain;
using Microsoft.EntityFrameworkCore;

namespace EX.Data
{
    public class EXContext : DbContext
    {
        public DbSet<Activite> activites { get; set; }
        public DbSet<Pack> packs { get; set; }
        public DbSet<Reservation> reservations { get; set; }
        public DbSet<CLient> Clients { get; set; }
        public DbSet<Conseiller> Conseillers { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\mssqllocaldb;
                                        Initial Catalog = MyDBweb1; 
                                        Integrated Security = true");
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CLient>()
                .HasOne(c => c.Conseiller) // Client a un seul Conseiller
                .WithMany(c => c.clients) // Conseiller peut avoir plusieurs clients
                .HasForeignKey(c => c.ConseillerFK) // Clé étrangère
                                                    //   .IsRequired(false) // Client peut être associé à aucun Conseiller
                .OnDelete(DeleteBehavior.Cascade); // Activation de la Cascade On Delete

            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                foreach (var property in entityType.GetProperties())
                {
                    if (property.ClrType == typeof(string) && !property.GetMaxLength().HasValue)
                    {
                        property.SetMaxLength(15);
                    }
                }
            }
            modelBuilder.Entity<Reservation>()
                .HasOne(r => r.cLient)
                .WithMany()
                .HasForeignKey(r => r.CLientId)
                .IsRequired();
            //tttttttttttttttttttttt
            modelBuilder.Entity<Activite>().OwnsOne(a => a.zone);
            base.OnModelCreating(modelBuilder);
        }

    }
}