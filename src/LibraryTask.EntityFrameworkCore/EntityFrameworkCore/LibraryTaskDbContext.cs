using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using LibraryTask.Authorization.Roles;
using LibraryTask.Authorization.Users;
using LibraryTask.MultiTenancy;
using LibraryTask.Domain.Attachments;
using LibraryTask.Domain.Books;
using LibraryTask.Domain.BookCategories;

namespace LibraryTask.EntityFrameworkCore
{
    public class LibraryTaskDbContext : AbpZeroDbContext<Tenant, Role, User, LibraryTaskDbContext>
    {
        /* Define a DbSet for each entity of the application */
        public virtual DbSet<Attachment> Attachments { get; set; }
        public virtual DbSet<BookCategory> BookCategories { get; set; }
        public virtual DbSet<BookCategoryTranslation> BookCategoryTranslations { get; set; }
        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<BookTranslation> BookTranslations { get; set; }
       

        public LibraryTaskDbContext(DbContextOptions<LibraryTaskDbContext> options)
            : base(options)
        {
        }
    }
}
