using Abp.Domain.Repositories;
using Abp.Domain.Services;
using LibraryTask.Domain.BookCategories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryTask.Domain.Books
{
    public class BookManager : DomainService, IBookManager
    {
        private readonly IRepository<Book> _bookRepository;
        public BookManager(IRepository<Book> bookRepository)
        {
            _bookRepository = bookRepository;

        }
        public async Task<Book> GetLiteEntityAsync(int bookId)
        {
            return await _bookRepository.GetAll().Include(x => x.Translations).FirstOrDefaultAsync(x => x.Id == bookId);
        }
        public async Task<Book> GetEntityAsync(int bookId)
        {
            return await _bookRepository.GetAll().Include(x => x.Translations).Include(x => x.Author).FirstOrDefaultAsync(x => x.Id == bookId);
        }
    }
}
