using System.Threading.Tasks;

namespace LibraryTask.Domain.Books
{
    public interface IBookManager
    {
        Task<Book> GetEntityAsync(int bookId);
        Task<Book> GetLiteEntityAsync(int bookId);
    }
}