namespace TestManyToMany.Domain;

public class TariffBuilderRate
{
    public int Id { get; set; } = 0;
    public Guid UiId { get; set; } = Guid.NewGuid();
    public Guid TariffBuilderUiId { get; set; } = Guid.NewGuid();
    public decimal Rate { get; set; }
    public int TariffBuilderId { get; set; }
    public int TariffBuilderRateConceptId { get; set; }
    public Guid TariffBuilderRateConceptUiId { get; set; } = Guid.NewGuid();
    public virtual TariffBuilder Tariff { get; set; }
    public virtual TariffBuilderRateConcept TariffRateConcept { get; set; }
}