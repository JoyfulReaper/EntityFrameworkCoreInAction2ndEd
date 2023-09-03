using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.EfClasses;
public class Book
{
    public int BookId { get; set; } // Primary key by EF Core conventions: <ClassName>Id. Since property is of type int, EF core assumes it is an IDENTITY column in the database.
    public string Title { get; set; } = default!; 
    public string Description { get; set; } = default!;
    public DateTime PublishedOn { get; set; }
    public decimal Price { get; set; }
    public string ImageUrl { get; set; } = default!;

    // Relationships
    public PriceOffer Promotion { get; set; }  // Link to optional one-to-one PriceOffer Relationship
    public ICollection<Review> Reviews { get; set; } // There can be zero or many reviews for a book
    public ICollection<Tag> Tags { get; set; } // EF Core automatic many-to-many relationship to Tag entity
    public ICollection<BookAuthor> AuthorsLink { get; set; } // Provides a link to the many-to-many linking table that links authors of this book
}
