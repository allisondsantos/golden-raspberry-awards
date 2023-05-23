﻿// <auto-generated />
using Golden.Raspberry.Awards.WebAPI.Infra.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Golden.Raspberry.Awards.WebAPI.Infra.Migrations
{
    [DbContext(typeof(SqliteContext))]
    [Migration("20230523013738_CreateTableMovies")]
    partial class CreateTableMovies
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.5");

            modelBuilder.Entity("Texo.Teste.WebAPI.Domain.Entities.Movie", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("id");

                    b.Property<string>("Producer")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("producer");

                    b.Property<string>("Studio")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("studio");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("title");

                    b.Property<bool>("Winner")
                        .HasColumnType("INTEGER")
                        .HasColumnName("winner");

                    b.Property<int>("Year")
                        .HasColumnType("INTEGER")
                        .HasColumnName("year");

                    b.HasKey("Id");

                    b.ToTable("movies", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}
