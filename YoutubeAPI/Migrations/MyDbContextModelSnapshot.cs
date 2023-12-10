﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using YoutubeAPI.Data;

#nullable disable

namespace YoutubeAPI.Migrations
{
    [DbContext(typeof(MyDbContext))]
    partial class MyDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.25")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("YoutubeAPI.Data.Category", b =>
                {
                    b.Property<int>("category_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("category_id"), 1L, 1);

                    b.Property<string>("category_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("category_id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("YoutubeAPI.Data.Channel", b =>
                {
                    b.Property<int>("channel_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("channel_id"), 1L, 1);

                    b.Property<string>("avatar")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("background")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("channel_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("creation_date")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GetDate()");

                    b.Property<string>("description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("user_id")
                        .HasColumnType("int");

                    b.HasKey("channel_id");

                    b.HasIndex("user_id")
                        .IsUnique();

                    b.ToTable("Channels");
                });

            modelBuilder.Entity("YoutubeAPI.Data.User", b =>
                {
                    b.Property<int>("user_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("user_id"), 1L, 1);

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("join_date")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GetDate()");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("user_id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("YoutubeAPI.Data.Video", b =>
                {
                    b.Property<int>("video_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("video_id"), 1L, 1);

                    b.Property<int>("category_id")
                        .HasColumnType("int");

                    b.Property<int>("channel_id")
                        .HasColumnType("int");

                    b.Property<string>("description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("thumbnail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("upload_date")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GetDate()");

                    b.Property<string>("url")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("views")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.HasKey("video_id");

                    b.HasIndex("category_id");

                    b.HasIndex("channel_id");

                    b.ToTable("Videos");
                });

            modelBuilder.Entity("YoutubeAPI.Data.Channel", b =>
                {
                    b.HasOne("YoutubeAPI.Data.User", "User")
                        .WithOne("Channel")
                        .HasForeignKey("YoutubeAPI.Data.Channel", "user_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("YoutubeAPI.Data.Video", b =>
                {
                    b.HasOne("YoutubeAPI.Data.Category", "Category")
                        .WithMany("Videos")
                        .HasForeignKey("category_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("YoutubeAPI.Data.Channel", "Channel")
                        .WithMany("Videos")
                        .HasForeignKey("channel_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Channel");
                });

            modelBuilder.Entity("YoutubeAPI.Data.Category", b =>
                {
                    b.Navigation("Videos");
                });

            modelBuilder.Entity("YoutubeAPI.Data.Channel", b =>
                {
                    b.Navigation("Videos");
                });

            modelBuilder.Entity("YoutubeAPI.Data.User", b =>
                {
                    b.Navigation("Channel")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}