using DataLayer.EfCode;
using ServiceLayer.BookServices.QueryObjects;

namespace ServiceLayer.BookServices.Concrete;

public class BookFilterDropdownService
{
    private readonly EfCoreContext _db;

    public BookFilterDropdownService(EfCoreContext db)
    {
        _db = db;
    }

    public IEnumerable<DropdownTuple> GetFilterDropDownValues(BooksFilterBy filterBy)
    {
        switch (filterBy)
        {
            case BooksFilterBy.NoFilter:
                return new List<DropdownTuple>();
            case BooksFilterBy.ByVotes:
                return FromVotesDropDown();
            case BooksFilterBy.ByTags:
                return _db.Tags.Select(x => new DropdownTuple {
                    Value = x.TagId,
                    Text = x.TagId
                }).ToList();
            case BooksFilterBy.ByPublicationYear:
                var today = DateTime.UtcNow.Date;
                var result = _db.Books
                    .Where(x => x.PublishedOn <= today)
                    .Select(x => x.PublishedOn.Year)
                    .Distinct()
                    .OrderByDescending(x => x)
                    .Select(x => new DropdownTuple {
                        Value = x.ToString(),
                        Text = x.ToString()
                    }).ToList();
                var comingSoon = _db.Books
                    .Any(x => x.PublishedOn > today);
                if (comingSoon)
                {
                    result.Insert(0, new DropdownTuple {
                        Value = BookListDtoFilter.AllBooksNotPublishedString,
                        Text = BookListDtoFilter.AllBooksNotPublishedString
                    });
                }

                return result;
            default:
                throw new ArgumentOutOfRangeException(nameof(filterBy), filterBy, null);
        }
    }

    private static IEnumerable<DropdownTuple> FromVotesDropDown()
    {
        return new[]
        {
            new DropdownTuple {Value = "4", Text = "4 stars and up"},
            new DropdownTuple {Value = "3", Text = "3 stars and up"},
            new DropdownTuple {Value = "2", Text = "2 stars and up"},
            new DropdownTuple {Value = "1", Text = "1 star and up"},
        };
    }
}
