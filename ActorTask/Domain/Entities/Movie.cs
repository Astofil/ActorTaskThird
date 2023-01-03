namespace Domain.Entities;

public class Movie
{
    public int MovieId { get; set; }
    public string Title { get; set; }
    public int MovieYear { get; set; }

    //--------Navigation props--------

    public virtual List<Cast> Cast { get; set; }
    public int CategoryId { get; set; }
    public Category Category { get; set; }
}