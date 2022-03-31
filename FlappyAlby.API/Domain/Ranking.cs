namespace FlappyAlby.API.Domain;

public record Ranking(int PlayerId, Player Player, TimeSpan Total, int? Id = default) : EntityBase(Id);