namespace FlappyAlby.API.Domain;

public record Player(string Name, int? Id = default) : EntityBase(Id)
{
    public IReadOnlyCollection<Ranking> Rankings { get; } = new HashSet<Ranking>();
}