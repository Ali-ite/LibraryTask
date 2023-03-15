using AutoMapper;

using System;
using System.Collections.Generic;
using System.Text;
using LibraryTask.Domain.BookCategories;
using LibraryTask.BookCategories.Dto;

namespace LibraryTask.BookCategories.Mapper
{
    /// <summary>
    /// BookCategory Map Profile
    /// </summary>
    public class BookCategoryMapProfile : Profile
    {
        /// <summary>
        /// BookCategoryMapProfile
        /// </summary>
        public BookCategoryMapProfile()
        {
            CreateMap<CreateBookCategoryDto, BookCategory>();
            CreateMap<CreateBookCategoryDto, BookCategoryDto>();
        }



    }
}
