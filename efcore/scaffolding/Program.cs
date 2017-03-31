﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Logging;

namespace scaffolding
{
    class Program
    {
        static void Main(string[] args)
        {
            using(var context = new BlogDbContext())
            {
                //var blog = new Blog("Luru Blog","http://geeks.ms/blogs/lruiz");
                //blog.Posts.Add(new Post(){Title = "My first post", Content = "asdasdasdasdasdas"});
                //context.Blogs.Add(blog);
                //context.Blogs.Add(new Blog("Unai Blog", "http://geeks.ms/blogs/unai"));

                //context.SaveChanges();

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
                options.UseSqlServer(@"Server=.\SQLEXPRESS;Database=BloggingWorld;Trusted_Connection=True");
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
            //    rsb.IncrementsBy(1);
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
            //    .HasAnnotation("BackingField", "Id");

            //modelBuilder
            //    .Entity<Blog>()
            //    .Property(b => b.Url)
            //    .IsRequired()
            //    .HasAnnotation("BackingField", "Url");

            //modelBuilder
            //    .Entity<Blog>()
            //    .Property(b => b.Title)
            //    .IsRequired()
            //    .HasAnnotation("BackingField", "Title");

            //modelBuilder
            //    .Entity<Blog>()
            //    .Property(b => b.BlogNumber)
            //    .IsRequired()
            //    .HasAnnotation("BackingField", "BlogNumber");

            //============ SURROGATE KEYS ==========

            //modelBuilder.Entity<Blog>().HasMany(b => b.Posts).WithOne().HasForeignKey(p => p.BlogNumber).HasPrincipalKey(b => b.BlogNumber);
        }
    }

    public class Blog
    {
        public int Id { get;  set; }
        public string BlogNumber { get;  set; }
        public string Url { get;  set; }
        public string Title { get;  set; }
        public List<Post> Posts { get;  set; }

        protected Blog() { }

        //public Blog(string title, string url)
        //{
        //    Title = title;
        //    Url = url;
        //    BlogNumber = Guid.NewGuid().ToString();
        //    Posts = new List<Post>();
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