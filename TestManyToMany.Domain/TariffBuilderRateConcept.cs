namespace TestManyToMany.Domain;

public class TariffBuilderRateConcept : Entity
{
    public string Name { get; set; }
    public int TariffBuilderRateSectionId { get; set; }
    public int Index { get; set; }
    public List<TariffBuilderRate> TariffBuilderRates { get; set; }
}