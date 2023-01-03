namespace Domain.Entities;

public class GetMovieDto
{
    public int MovieId { get; set; }
    public string Title { get; set; }
    public int MovieYear { get; set; }

    //--------Navigation props--------
    public int CategoryId { get; set; }
    public string CategoryTitle { get; set; }
}

public class AddMovieDto
{
    public int MovieId { get; set; }
    public string Title { get; set; }
    public int MovieYear { get; set; }

    //--------Navigation props--------
    public int CategoryId { get; set; }
}
