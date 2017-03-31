using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore.Metadata;

namespace scaffolding
{
    class Program
    {
        static void Main(string[] args)
        {
            using(var context = new BlogDbContext())
            {
                //var blog = new Blog() { Title = "Luru Blog", Url = "http://geeks.ms/blogs/lruiz" };
                //blog.Posts.Add(new Post() { Title = "My first post", Content = "asdasdasdasdasdas" });
                //context.Blogs.Add(blog);
                //context.Blogs.Add(new Blog() { Title = "Unai Blog", Url = "http://geeks.ms/blogs/unai" });

                //var blog = new Blog("Luru Blog", "http://geeks.ms/blogs/lruiz");
                //blog.AddPost(new Post() { Title = "My first post", Content = "asdasdasdasdasdas" });
                //context.Blogs.Add(blog);
                //context.Blogs.Add(new Blog("Unai Blog", "http://geeks.ms/blogs/unai"));

                context.SaveChanges();

                //============ CLIENT EVALUATION ==========

                //var blog = context.Blogs.Where(b => b.Url.IsValidUrl()).ToList();

                //============ RAW SQL ==========

                //var blogs = context.Blogs.FromSql(
                //    "SELECT * FROM [dbo].[Blogs] WHERE Title = @title",
                //    new SqlParameter("@title", "Luru Blog"))
                //    .Where(b => b.Url == "http://geeks.ms/blogs/lruiz")
                //    .ToList();

                //Console.WriteLine(blog[0].Title);
            }

            Console.Read();
        }
    }

    public class BlogDbContext : DbContext
    {
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (!options.IsConfigured)
            {
                options.UseSqlServer(@"Server=.;Database=BloggingWorld;User Id=sa;Password=Plainconcepts01!");
            }

            //============ COMMON SERVICES ==========

            //var loggerFactory = new LoggerFactory()
            //    .AddConsole();

            //options.UseLoggerFactory(loggerFactory);

            //============ CLIENT EVALUATION ==========

            //options.ConfigureWarnings(warnings => warnings.Throw(RelationalEventId.QueryClientEvaluationWarning));
        }

        //============ SHADOW PROPERTIES ==========

        //public override int SaveChanges()
        //{
        //    var entries = ChangeTracker
        //        .Entries<IAuditable>()
        //        .Where(e => e.State == EntityState.Added || e.State == EntityState.Modified)
        //        .ToList();

        //    foreach (var entry in entries)
        //    {
        //        entry.Property("LastUpdate").CurrentValue = DateTime.UtcNow;
        //        entry.Entity.LastUpdate = DateTime.UtcNow;
        //    }

        //    return base.SaveChanges();
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //============ SEQUENCES ==========

            //modelBuilder.HasSequence("BLOG_SEQUENCE", "dbo", rsb =>
            //{
            //    rsb.StartsAt(1);
            //    rsb.IncrementsBy(10);
            //});

            //modelBuilder
            //    .Entity<Blog>()
            //    .Property(x => x.Id)
            //    .HasDefaultValueSql("NEXT VALUE FOR BLOG_SEQUENCE")
            //    .ValueGeneratedOnAdd();

            //============ HILO ==========

            //modelBuilder.Entity<Blog>().Property(b => b.Id).ForSqlServerUseSequenceHiLo("HILO_SEQUENCE");

            //============ SHADOW PROPERTIES ==========

            //modelBuilder.Entity<Blog>().Property<DateTime>("LastUpdate");

            //============ BACKING FIELDS ==========

            //modelBuilder
            //    .Entity<Blog>()
            //    .Property(b => b.Id)
            //    .IsRequired()
            //    .HasField("id");

            //modelBuilder
            //    .Entity<Blog>()
            //    .Property(b => b.Url)
            //    .IsRequired()
            //    .HasField("url");

            //modelBuilder
            //    .Entity<Blog>()
            //    .Property(b => b.Title)
            //    .IsRequired()
            //    .HasField("title");

            //modelBuilder
            //    .Entity<Blog>()
            //    .Property(b => b.BlogNumber)
            //    .IsRequired()
            //    .HasField("blogNumber");

            //var navigation = modelBuilder.Entity<Blog>().Metadata.FindNavigation(nameof(Blog.Posts));

            //navigation.SetPropertyAccessMode(PropertyAccessMode.Field);

            //============ SURROGATE KEYS ==========

            //modelBuilder.Entity<Blog>().HasMany(b => b.Posts).WithOne().HasForeignKey(p => p.BlogNumber).HasPrincipalKey(b => b.BlogNumber);
        }
    }

    public class Blog
    {
        //private int id;
        //private string blogNumber;
        //private string url;
        //private string title;
        //private List<Post> posts;

        //public int Id => id;
        //public string BlogNumber => blogNumber;
        //public string Url => url;
        //public string Title => title;
        //public IEnumerable<Post> Posts => posts.ToList();

        public int Id { get; set; }
        public string BlogNumber { get; set; }
        public string Url { get; set; }
        public string Title { get; set; }
        public List<Post> Posts { get; set; } = new List<Post>();

        //protected Blog() { }

        //public Blog(string title, string url)
        //{
        //    this.title = title;
        //    this.url = url;
        //    blogNumber = Guid.NewGuid().ToString();
        //    posts = new List<Post>();
        //}

        //public void AddPost(Post post)
        //{
        //    posts.Add(post);
        //}
    }
    
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        //public string BlogNumber { get; set; }
    }


    public interface IAuditable
    {
        DateTime LastUpdate { get; set; }
    }

    public static class Extensions
    {
        public static bool IsValidUrl(this string url)
        {
            return true;
        }
    }
}
