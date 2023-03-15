using Abp.Application.Services;
using LibraryTask.MultiTenancy.Dto;

namespace LibraryTask.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

