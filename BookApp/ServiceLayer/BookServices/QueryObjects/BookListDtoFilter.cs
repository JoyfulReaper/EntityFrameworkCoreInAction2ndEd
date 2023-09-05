using System.ComponentModel.DataAnnotations;

namespace ServiceLayer.BookServices.QueryObjects;

public enum BooksFilterBy
{
    [Display(Name = "All")] NoFilter = 0,
    [Display(Name = "By Votes...")] ByVotes,
    [Display(Name = "By Categories...")] ByTags,
    [Display(Name = "By Year published...")] ByPublicationYear
}

public static class BookListDtoFilter
{
    public const string AllBooksNotPublishedString = "Coming Soon";

    public static IQueryable<BookListDto> FilterBooksBy(
        this IQueryable<BookListDto> books,
        BooksFilterBy filterBy, string filterValue)
    {
        if (string.IsNullOrEmpty(filterValue))
        {
            return books;
        }

        switch (filterBy)
        {
            case BooksFilterBy.NoFilter:
                return books;
            case BooksFilterBy.ByVotes:
                var filterVote = int.Parse(filterValue);
                return books.
                    Where(x => x.ReviewsAverageVotes > filterVote);
            case BooksFilterBy.ByTags:
                return books.Where(x => x.TagStrings
                    .Any(y => y == filterValue));
            case BooksFilterBy.ByPublicationYear:
                if (filterValue == AllBooksNotPublishedString)
                {
                    return books.Where(x => x.PublishedOn > DateTime.UtcNow);
                }

                var filterYear = int.Parse(filterValue);
                return books.Where(x => x.PublishedOn.Year == filterYear
                    && x.PublishedOn <= DateTime.UtcNow);
            default:
                throw new ArgumentOutOfRangeException
                    (nameof(filterBy), filterBy, null);
        }
    }
}
