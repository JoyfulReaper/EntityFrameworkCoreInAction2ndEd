using DataLayer.EfClasses;

namespace ServiceLayer.AdminServices;
public interface IChangePriceOfferService
{
    Book? OrgBook { get; }

    Book AddUpdatePriceOffer(PriceOffer promotion);
    PriceOffer GetOriginal(int id);
}