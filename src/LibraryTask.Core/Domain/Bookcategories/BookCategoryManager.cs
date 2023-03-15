using Abp.Domain.Repositories;
using Abp.Domain.Services;
using Abp.UI;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace  LibraryTask.Domain.BookCategories
{
    public class BookCategoryManager : DomainService, IBookCategoryManager
    {
        private readonly IRepository<BookCategory> _BookCategoryRepository;
        public BookCategoryManager(IRepository<BookCategory> BookCategoryRepository)
        {
            _BookCategoryRepository = BookCategoryRepository;

        }

        public async Task<BookCategory> CheckBookCategory(int BookCategoryId)
        {
            var BookCategory = await _BookCategoryRepository.GetAsync(BookCategoryId);
            if (BookCategory is null)
            {
                throw new UserFriendlyException(L("CategoryNotFound"));
            }
            return BookCategory;

        }

        public Task<BookCategory> GetBookCategory(int BookCategoryId)
        {

            var BookCategory = _BookCategoryRepository.GetAll().Include(x => x.Translations).FirstOrDefaultAsync(x => x.Id == BookCategoryId);
            if (BookCategory == null)
            {
                throw new UserFriendlyException(L("CategoryNotFound"));
            }
            return BookCategory;



        }
    }
}
