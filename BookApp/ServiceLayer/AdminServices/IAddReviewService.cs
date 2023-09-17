using DataLayer.EfClasses;

namespace ServiceLayer.AdminServices;
public interface IAddReviewService
{
    string? BookTitle { get; }

    Book AddReviewToBook(Review review);
    Review GetBlankReview(int id);
}