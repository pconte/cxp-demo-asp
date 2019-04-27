﻿// <auto-generated />
using KnowledgeBaseApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace KnowledgeBaseApi2.Migrations
{
    [DbContext(typeof(ApiContext))]
    [Migration("20190427170819_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.8-servicing-32085");

            modelBuilder.Entity("KnowledgeBaseApi.Models.Article", b =>
                {
                    b.Property<long>("ArticleId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Summary");

                    b.Property<string>("Title");

                    b.Property<string>("Url");

                    b.HasKey("ArticleId");

                    b.ToTable("Articles");

                    b.HasData(
                        new { ArticleId = 1L, Summary = "", Title = "Article1", Url = "website.com/path" },
                        new { ArticleId = 2L, Summary = "", Title = "Article2", Url = "website.com/path" }
                    );
                });

            modelBuilder.Entity("KnowledgeBaseApi.Models.ArticleTag", b =>
                {
                    b.Property<long>("ArticleId");

                    b.Property<long>("TagId");

                    b.HasKey("ArticleId", "TagId");

                    b.HasIndex("TagId");

                    b.ToTable("ArticleTag");

                    b.HasData(
                        new { ArticleId = 1L, TagId = 1L },
                        new { ArticleId = 1L, TagId = 3L },
                        new { ArticleId = 1L, TagId = 5L },
                        new { ArticleId = 2L, TagId = 2L },
                        new { ArticleId = 2L, TagId = 4L }
                    );
                });

            modelBuilder.Entity("KnowledgeBaseApi.Models.Suggestion", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Count");

                    b.Property<string>("SearchString");

                    b.HasKey("Id");

                    b.ToTable("Suggestions");
                });

            modelBuilder.Entity("KnowledgeBaseApi.Models.Tag", b =>
                {
                    b.Property<long>("TagId")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("IsInitSelected");

                    b.Property<bool>("IsSelected");

                    b.Property<string>("Name");

                    b.HasKey("TagId");

                    b.ToTable("Tags");

                    b.HasData(
                        new { TagId = 1L, IsInitSelected = false, IsSelected = false, Name = "Tag1" },
                        new { TagId = 2L, IsInitSelected = false, IsSelected = false, Name = "Tag2" },
                        new { TagId = 3L, IsInitSelected = false, IsSelected = false, Name = "Tag3" },
                        new { TagId = 4L, IsInitSelected = false, IsSelected = false, Name = "Tag4" },
                        new { TagId = 5L, IsInitSelected = false, IsSelected = false, Name = "Tag5" }
                    );
                });

            modelBuilder.Entity("KnowledgeBaseApi.Models.ArticleTag", b =>
                {
                    b.HasOne("KnowledgeBaseApi.Models.Article", "Article")
                        .WithMany("Tags")
                        .HasForeignKey("ArticleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("KnowledgeBaseApi.Models.Tag", "Tag")
                        .WithMany("Articles")
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
