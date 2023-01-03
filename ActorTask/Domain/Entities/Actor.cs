namespace Domain.Entities;

public class Actor
{
    public int ActorId { get; set; }
    public string FullName { get; set; }
    public string Gender { get; set; }
    public int BirthYear { get; set; }
    public int DeathYear { get; set; }

    //-------Navigation props----------
    public virtual List<Cast> Cast { get; set; }
}