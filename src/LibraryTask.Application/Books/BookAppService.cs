using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Collections.Extensions;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Abp.UI;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryTask.Authorization;
using LibraryTask.CrudAppServiceBase;
using LibraryTask.Books.Dto;
using LibraryTask.Domain.Books;

using static LibraryTask.Enums.Enum;
using LibraryTask.Domain.Attachments;

namespace LibraryTask.Books
{
    /// <summary>
    ///  Blog Category App Service
    /// </summary>
    public class BookAppService : LibraryTaskAsyncCrudAppService<Book, BookDetailsDto, int, LiteBookDto,
        PagedBookResultRequestDto, CreateBookDto, UpdateBookDto>,
        IBookAppService
    {
     
        private readonly IBookManager _BookManager;
        private readonly IAttachmentManager _attachmentManager;

        /// <summary>
        /// Blog Category AppService
        /// </summary>
        /// <param name="repository"></param>
        /// <param name="BookManager"></param>
        public BookAppService(IRepository<Book> repository, IBookManager BookManager,
             IAttachmentManager attachmentManager) 
            : base(repository)
        {


            _BookManager = BookManager;
            _attachmentManager=attachmentManager;
        }
        /// <summary>
        /// Get Book Details ById
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public override async Task<BookDetailsDto> GetAsync(EntityDto<int> input)
        {
            var Book = await _BookManager.GetEntityAsync(input.Id);
            if (Book is null)
            {
                throw new UserFriendlyException(L("not found"));
            }
          

            var BookDto=   MapToEntityDto(Book);
            var attachment = await _attachmentManager.GetElementByRefAsync(BookDto.Id, AttachmentRefType.Book);
            if (attachment is not null)
            {
                BookDto.Attachment = new LiteAttachmentDto
                {
                    Id = attachment.Id,
                    Url = _attachmentManager.GetUrl(attachment)
                };

            }
            return BookDto;
        }
        /// <summary>
        /// Get All Blog Categories Details
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
         //[ApiExplorerSettings(IgnoreApi = true)]
        public override async Task<PagedResultDto<LiteBookDto>> GetAllAsync(PagedBookResultRequestDto input)
        {
            var result= await base.GetAllAsync(input);
            foreach(var  item in result.Items)
            {
                var attachment =await _attachmentManager.GetElementByRefAsync(item.Id, AttachmentRefType.Book);
                if (attachment is not null)
                {
                    item.Attachment = new LiteAttachmentDto
                    {
                        Id = attachment.Id,
                        Url = _attachmentManager.GetUrl(attachment)
                    };
                }
               
            }
            return result;
        }
        //[HttpGet]
        //public async Task<PagedResultDto<LiteBookDto>> GetAllBook(PagedBookResultRequestDto input)
        //{
        //    var data = CreateFilteredQuery(input);
        //    var totalCount = await AsyncQueryableExecuter.CountAsync(data);
        //    data = ApplySorting(data, input);
        //    data = ApplyPaging(data, input);
        //    var list = await AsyncQueryableExecuter.ToListAsync(data);
        //    var Blogcattranslation = new List<BookTranslation>();
        //    var listDto = ObjectMapper.Map<List<LiteBookDto>>(list);
        //    if (input.Language == null)
        //    {
        //        input.Language = "en";
        //    }
        //    foreach (var li in list)
        //    {
        //        foreach (var liD in listDto)
        //        {
        //            liD.Name = li.Translations.Where(x => x.Language == input.Language).FirstOrDefault().Name;
        //        }
        //    }

        //    return new PagedResultDto<LiteBookDto>(totalCount, listDto);
        //}
        /// <summary>
        /// Add New Blog Category Details
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
    //    [AbpAuthorize]
        public override async Task<BookDetailsDto> CreateAsync(CreateBookDto input)
        {
            CheckCreatePermission();

            var Book = ObjectMapper.Map<Book>(input);
           
            await Repository.InsertAsync(Book);
            UnitOfWorkManager.Current.SaveChanges();
           
            await _attachmentManager.CheckAndUpdateRefIdAsync(
                    input.AttachmentId, AttachmentRefType.Book, Book.Id);
            return MapToEntityDto(Book);

        }
        /// <summary>
        /// Update Blog Category Details
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
      //  [AbpAuthorize]
        public override async Task<BookDetailsDto> UpdateAsync(UpdateBookDto input)
        {
            CheckUpdatePermission();
            var Book = await _BookManager.GetEntityAsync(input.Id);
            Book.Translations.Clear();
            if (Book is null)
            {
                throw new UserFriendlyException(L("not found"));

            }
            var attachment = await _attachmentManager.GetElementByRefAsync(Book.Id, AttachmentRefType.Book);
            if (attachment.Id != input.AttachmentId)
            {
                attachment.IsDeleted = true;
                await _attachmentManager.CheckAndUpdateRefIdAsync(
               input.AttachmentId, AttachmentRefType.Book, Book.Id);

            }
            MapToEntity(input, Book);
            Book.LastModificationTime = DateTime.Now;
            await Repository.UpdateAsync(Book);
            var BookDto = MapToEntityDto(Book);
            return BookDto;
        }

        /// <summary>
        /// Delete Blog Category Details
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public override async Task DeleteAsync(EntityDto<int> input)
        {
            CheckDeletePermission();
            var Book = await Repository.GetAsync(input.Id);
            if (Book is null)
            {
                throw new UserFriendlyException(L("not found"));
            }
            var attachment = await _attachmentManager.GetElementByRefAsync(Book.Id, AttachmentRefType.Book);
            if (attachment is not null)
            {
                attachment.IsDeleted = true;
              

            }

            Book.DeletionTime = DateTime.Now;
         
            Book.IsDeleted = true;
            await Repository.UpdateAsync(Book);
        }

        /// <summary>
        /// Filter For A Group Of BlogCategories
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        protected override IQueryable<Book> CreateFilteredQuery(PagedBookResultRequestDto input)
        {
            var data = base.CreateFilteredQuery(input);
         
            data = data.Include(x => x.Translations);
            data = data.Include(x => x.BookCategory.Translations);
            data = data.Include(x => x.Author);
            if (!input.Keyword.IsNullOrEmpty())
                data = data.Where(x => x.Translations.Where(x => x.Name.Contains(input.Keyword )).Any());
            if (input.CategoryId.HasValue)
            {
                data = data.Where(x => x.BookCategoryCaregoryId == input.CategoryId);
            }
            return data;

        }
        /// <summary>
        /// Sorting Filtered Blog Categories
        /// </summary>
        /// <param name="query"></param>
        /// <param name="input"></param>
        /// <returns></returns>
        protected override IQueryable<Book> ApplySorting(IQueryable<Book> query, PagedBookResultRequestDto input)
        {
            return query.OrderByDescending(r => r.CreationTime);
        }
        /// <summary>
        /// Switch Activation Of A Blog Category
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>

      
    }
}
