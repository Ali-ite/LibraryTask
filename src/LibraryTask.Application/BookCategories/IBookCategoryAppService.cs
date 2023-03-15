
using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using LibraryTask.CrudAppServiceBase;
using LibraryTask.BookCategories.Dto;

namespace LibraryTask.BookCategories
{
    /// <summary>
    /// IBookCategoryAppService
    /// </summary>
    public interface IBookCategoryAppService : ILibraryTaskAsyncCrudAppService<BookCategoryDetailsDto, int, LiteBookCategoryDto, PagedBookCategoryResultRequestDto,
        CreateBookCategoryDto, UpdateBookCategoryDto>
    {
        //Task<PagedResultDto<LiteBookCategoryDto>> GetAll(PagedBookCategoryResultRequestDto input);
    }
}
