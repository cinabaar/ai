public enum Team
{
    Player,
    Neutral,
    Enemy
}

public interface IHaveTeam
{ 
    Team Team { get; set; }
}