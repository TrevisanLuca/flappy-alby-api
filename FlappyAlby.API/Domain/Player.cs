namespace FlappyAlby.API.Domain;

public record Player(string Name, TimeSpan Total, int Id = 0) : EntityBase(Id);