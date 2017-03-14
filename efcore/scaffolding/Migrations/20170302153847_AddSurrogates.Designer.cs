using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using scaffolding;

namespace scaffolding.Migrations
{
    [DbContext(typeof(BlogDbContext))]
    [Migration("20170302153847_AddSurrogates")]
    partial class AddSurrogates
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.0-rtm-22752")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("scaffolding.Blog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("BackingField", "Id");

                    b.Property<string>("BlogNumber")
                        .IsRequired()
                        .HasAnnotation("BackingField", "BlogNumber");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasAnnotation("BackingField", "Title");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasAnnotation("BackingField", "Url");

                    b.HasKey("Id");

                    b.ToTable("Blogs");
                });

            modelBuilder.Entity("scaffolding.Post", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("BlogNumber");

                    b.Property<string>("Content");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.HasIndex("BlogNumber");

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("scaffolding.Post", b =>
                {
                    b.HasOne("scaffolding.Blog")
                        .WithMany("Posts")
                        .HasForeignKey("BlogNumber")
                        .HasPrincipalKey("BlogNumber");
                });
        }
    }
}
