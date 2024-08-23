using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace RecyclingApp.Models
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<RecyclableItem> RecyclableItems { get; set; }
        public DbSet<RecyclableType> RecyclableTypes { get; set; }

        public ApplicationDbContext() : base("DefaultConnection")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
