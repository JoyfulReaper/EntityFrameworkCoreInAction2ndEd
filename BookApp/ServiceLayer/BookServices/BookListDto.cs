

namespace ServiceLayer.BookServices;
public class BookListDto
{
    public int BookId { get; set; }
    public string? Title { get; set; }
    public DateTime PublishedOn { get; set; }
    public decimal Price { get; set; }
    public decimal AcutalPrice { get; set; }
    public string? PromotionalText { get; set; }
    public string? AuthorsOrdered { get; set; }
    public int ReviewCount { get; set; }
    public double? ReviewsAverageVotes { get; set; }
    public string[] TagStrings { get; set; } = new string[0];
}
