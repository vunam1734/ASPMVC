﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Test.Models;

namespace Test.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230907040729_createdb")]
    partial class createdb
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Test.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DisplayOrder")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DisplayOrder = 1,
                            Name = "Điện thoại"
                        },
                        new
                        {
                            Id = 2,
                            DisplayOrder = 2,
                            Name = "Máy tính bảng"
                        },
                        new
                        {
                            Id = 3,
                            DisplayOrder = 3,
                            Name = "Laptop"
                        });
                });

            modelBuilder.Entity("Test.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 1,
                            Name = "Iphone 7",
                            Price = 300.0
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 1,
                            Name = "Iphone 7s",
                            Price = 350.0
                        },
                        new
                        {
                            Id = 3,
                            CategoryId = 1,
                            Name = "Iphone 8",
                            Price = 400.0
                        },
                        new
                        {
                            Id = 4,
                            CategoryId = 1,
                            Name = "Iphone 8s",
                            Price = 420.0
                        },
                        new
                        {
                            Id = 5,
                            CategoryId = 1,
                            Name = "Iphone 11",
                            Price = 600.0
                        },
                        new
                        {
                            Id = 6,
                            CategoryId = 1,
                            Name = "Iphone 11s",
                            Price = 650.0
                        },
                        new
                        {
                            Id = 7,
                            CategoryId = 1,
                            Name = "Iphone 13",
                            Price = 700.0
                        },
                        new
                        {
                            Id = 8,
                            CategoryId = 1,
                            Name = "Iphone 13 Pro",
                            Price = 850.0
                        },
                        new
                        {
                            Id = 9,
                            CategoryId = 1,
                            Name = "Iphone 14",
                            Price = 900.0
                        },
                        new
                        {
                            Id = 10,
                            CategoryId = 1,
                            Name = "Iphone 14 Pro Max ",
                            Price = 1000.0
                        },
                        new
                        {
                            Id = 11,
                            CategoryId = 2,
                            Name = "Ipad Mini",
                            Price = 350.0
                        },
                        new
                        {
                            Id = 12,
                            CategoryId = 2,
                            Name = "Ipad Pro",
                            Price = 550.0
                        });
                });

            modelBuilder.Entity("Test.Models.Product", b =>
                {
                    b.HasOne("Test.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });
#pragma warning restore 612, 618
        }
    }
}
