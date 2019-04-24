using ClairG.ChatApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClairG.ChatApp.Domain.Concrete
{
    public class EFDbContext : DbContext
    {
        public EFDbContext() : base("connStr")
        {
            Database.SetInitializer<EFDbContext>(null);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Reply> Replies { get; set; }
    }
}
