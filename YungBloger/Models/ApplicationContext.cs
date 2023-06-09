using ClassLibrary.Data.Article;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace YungBloger.Models
{
    public class ApplicationContext : IdentityDbContext<ArticleUser>
    {
        public DbSet<Articls> Articls { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<ArticlsTag> ArticleTags { get; set; }
        public DbSet<Coment> Comments { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options)
    : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ArticlsTag>().HasKey(i => new { i.articlsID, i.tagID });
        }

    }
}
