namespace DataLayer.EfClasses;

public class Book
{
    public int BookId { get; set; } // Primary key by EF Core conventions: <ClassName>Id. Since property is of type int, EF core assumes it is an IDENTITY column in the database.
    public string? Title { get; set; }
    public string? Description { get; set; }
    public DateTime PublishedOn { get; set; }
    public string? Publisher { get; set; }
    public decimal Price { get; set; }
    public string? ImageUrl { get; set; }
    public bool SoftDeleted { get; set; }

    // Relationships
    public PriceOffer? Promotion { get; set; }  // Link to optional one-to-one PriceOffer Relationship
    public ICollection<Review> Reviews { get; set; } = new List<Review>(); // There can be zero or many reviews for a book
    public ICollection<Tag> Tags { get; set; } = new List<Tag>(); // EF Core automatic many-to-many relationship to Tag entity
    public ICollection<BookAuthor> AuthorsLink { get; set; } = new List<BookAuthor>(); // Provides a link to the many-to-many linking table that links authors of this book
}
