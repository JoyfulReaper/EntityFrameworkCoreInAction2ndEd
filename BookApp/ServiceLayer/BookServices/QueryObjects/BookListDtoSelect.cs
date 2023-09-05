using DataLayer.EfClasses;


namespace ServiceLayer.BookServices.QueryObjects;
public static class BookListDtoSelect
{
    public static IQueryable<BookListDto> MapBookToDto(this IQueryable<Book> books)
    {
        return books.Select(book => new BookListDto {
            BookId = book.BookId,
            Title = book.Title,
            PublishedOn = book.PublishedOn,
            AcutalPrice = book.Promotion == null
                ? book.Price
                : book.Promotion.NewPrice,
            PromotionalText =book.Promotion == null
                ? null
                : book.Promotion.PromotionalText,
            AuthorsOrdered = string.Join(", ", book.AuthorsLink
                .OrderBy(ba => ba.Order)
                .Select(ba => ba.Author.Name)),
            ReviewCount = book.Reviews.Count,
            ReviewsAverageVotes =
                book.Reviews.Select(review => 
                    (double?)review.NumStars).Average(),
            TagStrings = book.Tags
                .Select(x => x.TagId)
                .ToArray()
        });
    }
}
