namespace Domain.Entities;

public class AddCastDto
{
    public int CastId { get; set; }

    //-------Navigation props-------
    public int ActorId { get; set; }
    public int MovieId { get; set; }
}


public class GetCastDto
{
    public int CastId { get; set; }

    //-------Navigation props-------
    public int ActorId { get; set; }
    public string ActorFullName { get; set; }
    public int MovieId { get; set; }
    public string MovieTitle { get; set; }
}