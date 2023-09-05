using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.BookServices.QueryObjects;
public static class BookListDtoSort
{
    public enum OrderByOptions
    {
        [Display(Name = "sort by...")] SimpleOrder = 0,
        [Display(Name = "Votes ↑")] ByVotes,
        [Display(Name = "Publication Date ↑")] ByPublicationDate,
        [Display(Name = "Price ↓")] ByPriceLowestFirst,
        [Display(Name = "Price ↑")] ByPriceHigestFirst
    }

    public static IQueryable<BookListDto> OrderBooksBy (this IQueryable<BookListDto> books,
        OrderByOptions orderByOptions)
    {
        switch (orderByOptions)
        {
            case OrderByOptions.SimpleOrder:
                return books.OrderByDescending(x => x.BookId);
            case OrderByOptions.ByVotes:
                return books.OrderByDescending(x => x.ReviewsAverageVotes);
            case OrderByOptions.ByPublicationDate:
                return books.OrderByDescending(x => x.PublishedOn);
            case OrderByOptions.ByPriceLowestFirst:
                return books.OrderBy(x => x.Price);
            case OrderByOptions.ByPriceHigestFirst:
                return books.OrderByDescending(x => x.Price);
            default:
                throw new ArgumentOutOfRangeException(
                    nameof(orderByOptions), orderByOptions, null);
        }
    }
}
