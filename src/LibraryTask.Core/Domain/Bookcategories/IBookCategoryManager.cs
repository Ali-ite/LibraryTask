using Abp.Domain.Services;
using System.Threading.Tasks;

namespace LibraryTask.Domain.BookCategories
{
    public interface IBookCategoryManager:IDomainService
    {
        Task<BookCategory> CheckBookCategory(int BookCategoryId);
        Task<BookCategory> GetBookCategory(int BookCategoryId);
    }
}