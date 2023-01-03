namespace Domain.Entities;

public class GetCategoryDto
{
    public int CategoryId { get; set; }
    public string Title { get; set; }
}

public class AddCategoryDto
{
    public int CategoryId { get; set; }
    public string Title { get; set; }
}