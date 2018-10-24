using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemensProjekt.Models
{
    public class ForumDataContext : DbContext
    {
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Post> Posts { get; set; }

        public ForumDataContext(DbContextOptions<ForumDataContext> options) : base(options)
        {
            Database.EnsureCreated();
            
        }

        
     
    }
}
