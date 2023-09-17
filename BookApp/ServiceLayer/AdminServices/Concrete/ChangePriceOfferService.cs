using DataLayer.EfClasses;
using DataLayer.EfCode;
using Microsoft.EntityFrameworkCore;

namespace ServiceLayer.AdminServices.Concrete;
public class ChangePriceOfferService : IChangePriceOfferService
{
    public Book? OrgBook { get; private set; }

    private readonly EfCoreContext _context;

    public ChangePriceOfferService(EfCoreContext context)
    {
        _context = context;
    }

    public PriceOffer GetOriginal(int id)
    {
        OrgBook = _context.Books
            .Include(r => r.Promotion)
            .Single(k => k.BookId == id);

        return OrgBook.Promotion
            ?? new PriceOffer {
                BookId = id,
                NewPrice = OrgBook.Price,
            };
    }

    public Book AddUpdatePriceOffer(PriceOffer promotion)
    {
        var book = _context.Books
            .Include(r => r.Promotion)
            .Single(k => k.BookId == promotion.BookId);

        if (book.Promotion is null)
        {
            book.Promotion = promotion;
        }
        else
        {
            book.Promotion.NewPrice = promotion.NewPrice;
            book.Promotion.PromotionalText = promotion.PromotionalText;
        }

        _context.SaveChanges();
        return book;
    }
}
