using Abp.AutoMapper;
using Abp.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using AutoMapper;
using LibraryTask.Authorization;
using LibraryTask.BookCategories.Dto;
using LibraryTask.Books.Dto;
using LibraryTask.Domain.BookCategories;
using LibraryTask.Domain.Books;

namespace LibraryTask
{
    [DependsOn(
        typeof(LibraryTaskCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class LibraryTaskApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<LibraryTaskAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(LibraryTaskApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );
            Configuration.Modules.AbpAutoMapper().Configurators.Add(configuration =>
            {
                CustomDtoMapper.CreateMappings(configuration, new MultiLingualMapContext(
                    IocManager.Resolve<ISettingManager>()
                ));
            });
        }
        internal static class CustomDtoMapper
        {
            public static void CreateMappings(IMapperConfigurationExpression configuration, MultiLingualMapContext context)
            {
                configuration.CreateMultiLingualMap<BookCategory, BookCategoryTranslation, LiteBookCategoryDto>(context).TranslationMap
               .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));
                configuration.CreateMultiLingualMap<BookCategory, BookCategoryTranslation, BookCategoryDetailsDto>(context).TranslationMap
               .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));
                configuration.CreateMultiLingualMap<Book, BookTranslation, LiteBookDto>(context).TranslationMap
             .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name)).ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description));
                configuration.CreateMultiLingualMap<Book, BookTranslation, BookDetailsDto>(context).TranslationMap
               .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name)).ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description));


            }
        }
    }
}
