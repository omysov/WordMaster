﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WordMaster.Services.LanguageAPI.Data;

#nullable disable

namespace WordMaster.Services.LanguageAPI.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230927122112_AddDbLanguage")]
    partial class AddDbLanguage
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.11");

            modelBuilder.Entity("WordMaster.Services.LanguageAPI.Models.Language", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Languages");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "English"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Russian"
                        },
                        new
                        {
                            Id = 3,
                            Name = "France"
                        },
                        new
                        {
                            Id = 4,
                            Name = "German"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
