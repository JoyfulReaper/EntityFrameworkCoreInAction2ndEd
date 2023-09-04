namespace DataLayer.EfClasses;

public class Author
{
    public int AuthorId { get; set; }
    public required string Name { get; set; }

    // Relationships
    public ICollection<BookAuthor> BooksLink { get; set; } = new List<BookAuthor>();
}
