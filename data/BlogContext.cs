using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using data.tables;

namespace data {
    public class BlogContext : DbContext
    {
        public BlogContext()
        {
            DbPath = System.IO.Path.Join(@"C:\Users\gothm\Documents\GitHub\blogprojectHalicFinal", "blogdb.db");
        }
        public string DbPath { get; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}");
    }
}