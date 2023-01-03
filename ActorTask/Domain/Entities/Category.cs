namespace Domain.Entities;

public class Category
{
    public int CategoryId { get; set; }
    public string Title { get; set; }

    //----------Navigation props--------
    public virtual List<Movie> Movie { get; set; }
}
