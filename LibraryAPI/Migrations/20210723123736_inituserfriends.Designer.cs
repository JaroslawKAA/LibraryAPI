﻿// <auto-generated />
using System;
using LibraryAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LibraryAPI.Migrations
{
    [DbContext(typeof(LibraryContext))]
    [Migration("20210723123736_inituserfriends")]
    partial class inituserfriends
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.8")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("LibraryAPI.Models.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Authors")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("Available")
                        .HasColumnType("bit");

                    b.Property<string>("BarcodeNumber")
                        .HasMaxLength(32)
                        .HasColumnType("nvarchar(32)");

                    b.Property<int>("BookcaseId")
                        .HasColumnType("int");

                    b.Property<int>("Category")
                        .HasColumnType("int");

                    b.Property<string>("OwnerId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("Photo")
                        .HasColumnType("varbinary(max)");

                    b.Property<DateTime>("PublishingYear")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Read")
                        .HasColumnType("bit");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<int>("Votes")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Book");
                });

            modelBuilder.Entity("LibraryAPI.Models.Bookcase", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Bookcase");
                });

            modelBuilder.Entity("LibraryAPI.Models.Borrowing", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BookId")
                        .HasColumnType("int");

                    b.Property<string>("BorrowerId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClientId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ReturnDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Borrowing");
                });

            modelBuilder.Entity("LibraryAPI.Models.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("Localization")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<byte[]>("Photo")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TermsAccepted")
                        .HasColumnType("bit");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("User");
                });

            modelBuilder.Entity("LibraryAPI.Models.User", b =>
                {
                    b.HasOne("LibraryAPI.Models.User", null)
                        .WithMany("Friends")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("LibraryAPI.Models.User", b =>
                {
                    b.Navigation("Friends");
                });
#pragma warning restore 612, 618
        }
    }
}
