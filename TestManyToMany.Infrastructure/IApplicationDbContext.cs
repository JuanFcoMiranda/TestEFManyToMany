using Microsoft.EntityFrameworkCore;
using TestManyToMany.Domain;

namespace TestManyToMany.Infrastructure;

public interface IApplicationDbContext
{
    DbSet<TariffBuilder> TariffBuilders { get; set; }
    DbSet<TariffBuilderRate> TariffBuilderRates { get; set; }
    DbSet<TariffBuilderRateConcept> TariffBuilderRateConcepts { get; set; }
}