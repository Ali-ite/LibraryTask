using AutoMapper;

using System;
using System.Collections.Generic;
using System.Text;
using LibraryTask.Domain.Books;
using LibraryTask.Books.Dto;

namespace LibraryTask.Books.Mapper
{
    /// <summary>
    /// Book Map Profile
    /// </summary>
    public class BookMapProfile : Profile
    {
        /// <summary>
        /// BookMapProfile
        /// </summary>
        public BookMapProfile()
        {
            CreateMap<CreateBookDto, Book>();
            CreateMap<CreateBookDto, BookDto>();
        }



    }
}
