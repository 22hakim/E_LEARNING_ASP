﻿// <auto-generated />
using System;
using E_Learning_API.Data;
using E_Learning_API.Models.Enum;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace E_Learning_API.Migrations
{
    [DbContext(typeof(ElearningDataContext))]
    [Migration("20220913085416_CreateDB")]
    partial class CreateDB
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.HasPostgresEnum(modelBuilder, "category_message", new[] { "help", "issue" });
            NpgsqlModelBuilderExtensions.HasPostgresEnum(modelBuilder, "level_course", new[] { "easy", "intermediate", "hard" });
            NpgsqlModelBuilderExtensions.HasPostgresEnum(modelBuilder, "published", new[] { "not_published", "published" });
            NpgsqlModelBuilderExtensions.HasPostgresEnum(modelBuilder, "rate_course", new[] { "bad", "almost_bad", "average", "good", "perfect" });
            NpgsqlModelBuilderExtensions.HasPostgresEnum(modelBuilder, "state_course", new[] { "never_read", "opened", "validated" });
            NpgsqlModelBuilderExtensions.UseSerialColumns(modelBuilder);

            modelBuilder.Entity("CourseTag", b =>
                {
                    b.Property<int>("CoursesId")
                        .HasColumnType("integer");

                    b.Property<int>("TagsId")
                        .HasColumnType("integer");

                    b.HasKey("CoursesId", "TagsId");

                    b.HasIndex("TagsId");

                    b.ToTable("CourseTag");
                });

            modelBuilder.Entity("E_Learning_API.Models.Assignement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseSerialColumn(b.Property<int>("Id"));

                    b.Property<int>("CourseId")
                        .HasColumnType("integer");

                    b.Property<string[]>("ListText")
                        .HasColumnType("text[]");

                    b.Property<string[]>("ListVideosUrl")
                        .HasColumnType("text[]");

                    b.HasKey("Id");

                    b.HasIndex("CourseId")
                        .IsUnique();

                    b.ToTable("Assignements");
                });

            modelBuilder.Entity("E_Learning_API.Models.Course", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseSerialColumn(b.Property<int>("Id"));

                    b.Property<string>("Content")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("LastUpdate")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("timestamp with time zone");

                    b.Property<LevelCourse>("Level")
                        .HasColumnType("level_course");

                    b.Property<Published>("Published")
                        .HasColumnType("published");

                    b.Property<string>("Title")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("E_Learning_API.Models.Tag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseSerialColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("CourseTag", b =>
                {
                    b.HasOne("E_Learning_API.Models.Course", null)
                        .WithMany()
                        .HasForeignKey("CoursesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("E_Learning_API.Models.Tag", null)
                        .WithMany()
                        .HasForeignKey("TagsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("E_Learning_API.Models.Assignement", b =>
                {
                    b.HasOne("E_Learning_API.Models.Course", "Course")
                        .WithOne("Assignement")
                        .HasForeignKey("E_Learning_API.Models.Assignement", "CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");
                });

            modelBuilder.Entity("E_Learning_API.Models.Course", b =>
                {
                    b.Navigation("Assignement");
                });
#pragma warning restore 612, 618
        }
    }
}