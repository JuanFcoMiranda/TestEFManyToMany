namespace TestManyToMany.Domain;

public abstract class Entity
{
    public int Id { get; set; } = 0;
    
    public Guid UiId { get; set; } = Guid.NewGuid();
    
    public int ScenarioId { get; set; } = 0;
}