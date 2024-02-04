using Microsoft.EntityFrameworkCore;
using TestManyToMany.Domain;

namespace TestManyToMany.Infrastructure;

public class ApplicationDbContext : DbContext, IApplicationDbContext
{
    public DbSet<TariffBuilder> TariffBuilders { get; set; }
    public DbSet<TariffBuilderRate> TariffBuilderRates { get; set; }
    public DbSet<TariffBuilderRateConcept> TariffBuilderRateConcepts { get; set; }
    
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        Database.SetCommandTimeout(TimeSpan.FromMinutes(1));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        // modelBuilder.Entity<TariffBuilderRate>()
        //     .HasOne(x => x.Tariff)
        //     .WithMany(x => x.TariffBuilderRates)
        //     .HasForeignKey(x => x.TariffBuilderId)
        //     .OnDelete(DeleteBehavior.Cascade);
        //
        // modelBuilder.Entity<TariffBuilderRate>()
        //     .HasOne(x => x.TariffRateConcept)
        //     .WithMany(x => x.TariffBuilderRates)
        //     .HasForeignKey(x => x.TariffBuilderRateConceptId)
        //     .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<TariffBuilder>()
            .HasMany(e => e.TariffBuilderRates)
            .WithOne(e => e.Tariff)
            .HasForeignKey(e => e.TariffBuilderId)
            .OnDelete(DeleteBehavior.Cascade);
        
        modelBuilder.Entity<TariffBuilderRateConcept>()
            .HasMany(e => e.TariffBuilderRates)
            .WithOne(e => e.TariffRateConcept)
            .HasForeignKey(e => e.TariffBuilderRateConceptId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}