
using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using LibraryTask.CrudAppServiceBase;
using LibraryTask.Books.Dto;

namespace LibraryTask.Books
{
    /// <summary>
    /// IBookAppService
    /// </summary>
    public interface IBookAppService : ILibraryTaskAsyncCrudAppService<BookDetailsDto, int, LiteBookDto, PagedBookResultRequestDto,
        CreateBookDto, UpdateBookDto>
    {
        //Task<PagedResultDto<LiteBookDto>> GetAll(PagedBookResultRequestDto input);
    }
}
