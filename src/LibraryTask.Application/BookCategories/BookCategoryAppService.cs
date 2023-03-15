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

using LibraryTask.BookCategories.Dto;
using LibraryTask.Domain.BookCategories;

using static LibraryTask.Enums.Enum;
using LibraryTask.Domain.Attachments;


namespace LibraryTask.BookCategories
{
    /// <summary>
    ///  Blog Category App Service
    /// </summary>
    public class BookCategoryAppService : LibraryTaskAsyncCrudAppService<BookCategory, BookCategoryDetailsDto, int, LiteBookCategoryDto,
        PagedBookCategoryResultRequestDto, CreateBookCategoryDto, UpdateBookCategoryDto>,
        IBookCategoryAppService
    {
     
        private readonly IBookCategoryManager _BookCategoryManager;
        private readonly IAttachmentManager _attachmentManager;

        /// <summary>
        /// Blog Category AppService
        /// </summary>
        /// <param name="repository"></param>
        /// <param name="BookCategoryManager"></param>
        public BookCategoryAppService(IRepository<BookCategory> repository, IBookCategoryManager BookCategoryManager,
             IAttachmentManager attachmentManager) 
            : base(repository)
        {


            _BookCategoryManager = BookCategoryManager;
            _attachmentManager=attachmentManager;
        }
        /// <summary>
        /// Get BookCategory Details ById
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public override async Task<BookCategoryDetailsDto> GetAsync(EntityDto<int> input)
        {
            var BookCategory = await _BookCategoryManager.GetBookCategory(input.Id);
            if (BookCategory is null)
            {
                throw new UserFriendlyException(L("not found"));
            }
          

            var BookCategoryDto=   MapToEntityDto(BookCategory);
          
            
            return BookCategoryDto;
        }
        /// <summary>
        /// Get All Blog Categories Details
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
         //[ApiExplorerSettings(IgnoreApi = true)]
        public override async Task<PagedResultDto<LiteBookCategoryDto>> GetAllAsync(PagedBookCategoryResultRequestDto input)
        {
            return await base.GetAllAsync(input);
          
               
          
        }
      
    
        public override async Task<BookCategoryDetailsDto> CreateAsync(CreateBookCategoryDto input)
        {
            CheckCreatePermission();

            var BookCategory = ObjectMapper.Map<BookCategory>(input);
            BookCategory.IsActive = true;
            await Repository.InsertAsync(BookCategory);
            UnitOfWorkManager.Current.SaveChanges();
           
            return MapToEntityDto(BookCategory);

        }
        /// <summary>
        /// Update Blog Category Details
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
      //  [AbpAuthorize]
        public override async Task<BookCategoryDetailsDto> UpdateAsync(UpdateBookCategoryDto input)
        {
            CheckUpdatePermission();
            var BookCategory = await _BookCategoryManager.GetBookCategory(input.Id);
            BookCategory.Translations.Clear();
            if (BookCategory is null)
            {
                throw new UserFriendlyException(L("not found"));

            }
        
            MapToEntity(input, BookCategory);
            BookCategory.LastModificationTime = DateTime.Now;
            await Repository.UpdateAsync(BookCategory);
            var BookCategoryDto = MapToEntityDto(BookCategory);
            return BookCategoryDto;
        }

        /// <summary>
        /// Delete Blog Category Details
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public override async Task DeleteAsync(EntityDto<int> input)
        {
            CheckDeletePermission();
            var BookCategory = await Repository.GetAsync(input.Id);
            if (BookCategory is null)
            {
                throw new UserFriendlyException(L("not found"));
            }
        
            BookCategory.DeletionTime = DateTime.Now;
            BookCategory.IsActive = false;
            BookCategory.IsDeleted = true;
            await Repository.UpdateAsync(BookCategory);
        }

        /// <summary>
        /// Filter For A Group Of BlogCategories
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        protected override IQueryable<BookCategory> CreateFilteredQuery(PagedBookCategoryResultRequestDto input)
        {
            var data = base.CreateFilteredQuery(input);
         
            data = data.Include(x => x.Translations);
            if (!input.Keyword.IsNullOrEmpty())
                data = data.Where(x => x.Translations.Where(x => x.Name.Contains(input.Keyword )).Any());
            if (input.IsActive.HasValue)
            {
                data = data.Where(x => x.IsActive == input.IsActive);
            }
            if (input.IsParent.HasValue)
            {
                data = data.Where(x => x.IsParent == input.IsParent);
            }  
            if (input.ParentCaregoryId.HasValue)
            {
                data = data.Where(x => x.ParentCaregoryId == input.ParentCaregoryId);
            }
            return data;

        }
        /// <summary>
        /// Sorting Filtered Blog Categories
        /// </summary>
        /// <param name="query"></param>
        /// <param name="input"></param>
        /// <returns></returns>
        protected override IQueryable<BookCategory> ApplySorting(IQueryable<BookCategory> query, PagedBookCategoryResultRequestDto input)
        {
            return query.OrderByDescending(r => r.CreationTime);
        }
        /// <summary>
        /// Switch Activation Of A Blog Category
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>

        [HttpPut]
        public async Task<BookCategoryDetailsDto> SwitchActivationAsync(BookCategorySwitchActivationDto input)
        {
            CheckUpdatePermission();
            var BookCategory = await Repository.GetAsync(input.Id);
            if (BookCategory is null)
            {
                throw new UserFriendlyException(L("not found"));
            }
           
          
            BookCategory.IsActive = input.IsActive;
            BookCategory.LastModificationTime = DateTime.Now;
            await Repository.UpdateAsync(BookCategory);
            var BookCategoryDto = MapToEntityDto(BookCategory);
            return BookCategoryDto;
        }

    }
}
