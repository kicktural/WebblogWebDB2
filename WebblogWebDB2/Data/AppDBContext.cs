using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebblogWebDB2.Models;

namespace WebblogWebDB2.Data
{
    public class AppDBContext : IdentityDbContext<User>
    {
     public AppDBContext(DbContextOptions options) : base(options) 
        {
        }

        public DbSet<Article> Articles { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<ArticleTag> ArticleTags { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<User>().ToTable("users");
            builder.Entity<IdentityRole>().ToTable("Roles");
            
        }
    }
}
