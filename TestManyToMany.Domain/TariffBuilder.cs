using System.Security.Principal;

namespace TestManyToMany.Domain;

public class TariffBuilder : Entity
{
    public decimal TotalRate { get; set; }
    public string WorkGroup { get; set; }
    public string ActivityName { get; set; }
    public string HierarchyLevelTwo { get; set; }
    public decimal Cost { get; set; }
    public bool IsVariableCost { get; set; }
    public List<TariffBuilderRate> TariffBuilderRates { get; set; }
}