using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.ComponentModel.DataAnnotations;

namespace AutoGenStoredProcs
{
    /// <summary>
    /// sample from msdn - http://msdn.microsoft.com/en-us/data/dn468673
    /// </summary>
    public class Blog
    {
        [Key]
        public Guid BlogId { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }

        public List<Post> Posts { get; set; }

        [Timestamp]
        public byte[] Timestamp { get; set; } 
    }

    public class Post
    {
        [Key]
        public Guid PostId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        public Blog Blog { get; set; }

        [Timestamp]
        public byte[] Timestamp { get; set; } 
    }

    public class BlogDBContext : DbContext
    {
        public BlogDBContext()
            : base("BlogDBConnectionString")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Configure domain classes using Fluent API here 
            modelBuilder.Entity<Blog>().MapToStoredProcedures();

            //// This example renames all three stored procedures.
            //modelBuilder.Entity<Blog>().MapToStoredProcedures(s =>
            //    s.Update(u => u.HasName("modify_blog"))
            //     .Delete(d => d.HasName("delete_blog"))
            //     .Insert(i => i.HasName("insert_blog")));


            //// These calls are all chainable and composable. Here is an example that renames all three stored procedures and their parameters.
            //modelBuilder.Entity<Blog>().MapToStoredProcedures(s =>
            //    s.Update(u => u.HasName("modify_blog")
            //                   .Parameter(b => b.BlogId, "blog_id")
            //                   .Parameter(b => b.Name, "blog_name")
            //                   .Parameter(b => b.Url, "blog_url"))
            //     .Delete(d => d.HasName("delete_blog")
            //                   .Parameter(b => b.BlogId, "blog_id"))
            //     .Insert(i => i.HasName("insert_blog")
            //                   .Parameter(b => b.Name, "blog_name")
            //                   .Parameter(b => b.Url, "blog_url")));


        }

        public DbSet<Blog> Blog_Detail { get; set; }



    }


}
