using Abp.Application.Services.Dto;
using Abp.Domain.Entities;
using Abp.Domain.Repositories;
using Abp.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryTask.CrudAppServiceBase
{
  
 

        public abstract class LibraryTaskAsyncCrudAppService<TEntity, TEntityDto, TPrimaryKey, TLiteEntityDto, TGetAllInput, TCreateInput, TUpdateInput>
          : LibraryTaskCrudAppServiceBase<TEntity, TEntityDto, TPrimaryKey, TLiteEntityDto, TGetAllInput, TCreateInput, TUpdateInput>,
              ILibraryTaskAsyncCrudAppService<TEntityDto, TPrimaryKey, TLiteEntityDto, TGetAllInput, TCreateInput, TUpdateInput>
          where TEntity : class, IEntity<TPrimaryKey>
          where TEntityDto : IEntityDto<TPrimaryKey>
          where TLiteEntityDto : IEntityDto<TPrimaryKey>
          where TUpdateInput : IEntityDto<TPrimaryKey>
        {
            public IAsyncQueryableExecuter AsyncQueryableExecuter { get; set; }

            protected LibraryTaskAsyncCrudAppService(IRepository<TEntity, TPrimaryKey> repository)
                : base(repository)
            {
                AsyncQueryableExecuter = NullAsyncQueryableExecuter.Instance;
                LocalizationSourceName = LibraryTaskConsts.LocalizationSourceName;
            }

            public virtual async Task<TEntityDto> GetAsync(EntityDto<TPrimaryKey> input)
            {
                CheckGetPermission();

                var entity = await GetEntityByIdAsync(input.Id);
                return MapToEntityDto(entity);
            }

            public virtual async Task<PagedResultDto<TLiteEntityDto>> GetAllAsync(TGetAllInput input)
            {
            CheckGetAllPermission();

            var query = CreateFilteredQuery(input);
           

            var totalCount = await AsyncQueryableExecuter.CountAsync(query);

            query = ApplySorting(query, input);
            query = ApplyPaging(query, input);

            var entities = await AsyncQueryableExecuter.ToListAsync(query);

            return new PagedResultDto<TLiteEntityDto>(
                totalCount,
                entities.Select(MapToLiteEntityDto).ToList()
            );
            }

            public virtual async Task<TEntityDto> CreateAsync(TCreateInput input)
            {
                CheckCreatePermission();

                var entity = MapToEntity(input);

                await Repository.InsertAsync(entity);
                await CurrentUnitOfWork.SaveChangesAsync();

                return MapToEntityDto(entity);
            }

            public virtual async Task<TEntityDto> UpdateAsync(TUpdateInput input)
            {
                CheckUpdatePermission();

                var entity = await GetEntityByIdAsync(input.Id);

                MapToEntity(input, entity);
                await CurrentUnitOfWork.SaveChangesAsync();

                return MapToEntityDto(entity);
            }

            public virtual async Task DeleteAsync(EntityDto<TPrimaryKey> input)
            {
                CheckDeletePermission();

                await Repository.DeleteAsync(input.Id);
            }

            protected virtual Task<TEntity> GetEntityByIdAsync(TPrimaryKey id)
            {
                return Repository.GetAsync(id);
            }

            

     

    }

    
}
