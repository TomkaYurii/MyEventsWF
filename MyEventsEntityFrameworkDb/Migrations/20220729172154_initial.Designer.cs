﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyEventsEntityFrameworkDb.Context;

#nullable disable

namespace MyEventsEntityFrameworkDb.Migrations
{
    [DbContext(typeof(MyEventsContext))]
    [Migration("20220729172154_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("MyEventsEntityFrameworkDb.Entities.CategoriesEvent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("CategoryId")
                        .HasColumnType("int");

                    b.Property<int?>("EventId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("EventId");

                    b.ToTable("CategoriesEvents");
                });

            modelBuilder.Entity("MyEventsEntityFrameworkDb.Entities.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Name")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("MyEventsEntityFrameworkDb.Entities.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("MyEventsEntityFrameworkDb.Entities.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("CityId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("MyEventsEntityFrameworkDb.Entities.Event", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("AcceptableAge")
                        .HasColumnType("int");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("CityId")
                        .HasColumnType("int");

                    b.Property<double?>("CostOfVisit")
                        .HasColumnType("float");

                    b.Property<int?>("CountryId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DateOfEvent")
                        .HasColumnType("datetime2");

                    b.Property<int?>("GalleryId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<TimeSpan?>("TimeOfEvent")
                        .HasColumnType("time");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.HasIndex("CountryId");

                    b.HasIndex("GalleryId");

                    b.HasIndex("UserId");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("MyEventsEntityFrameworkDb.Entities.Gallery", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Galleries");
                });

            modelBuilder.Entity("MyEventsEntityFrameworkDb.Entities.Image", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("GalleryId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("GalleryId");

                    b.HasIndex("UserId");

                    b.ToTable("Images");
                });

            modelBuilder.Entity("MyEventsEntityFrameworkDb.Entities.Message", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("EventId")
                        .HasColumnType("int");

                    b.Property<string>("Message1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EventId");

                    b.HasIndex("UserId");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("MyEventsEntityFrameworkDb.Entities.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("MyEventsEntityFrameworkDb.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("CityId")
                        .HasColumnType("int");

                    b.Property<int?>("CountryId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<string>("SecondName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.HasIndex("CountryId");

                    b.HasIndex("RoleId")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("MyEventsEntityFrameworkDb.Entities.CategoriesEvent", b =>
                {
                    b.HasOne("MyEventsEntityFrameworkDb.Entities.Category", "Category")
                        .WithMany("CategoriesEvents")
                        .HasForeignKey("CategoryId");

                    b.HasOne("MyEventsEntityFrameworkDb.Entities.Event", "Event")
                        .WithMany("CategoriesEvents")
                        .HasForeignKey("EventId");

                    b.Navigation("Category");

                    b.Navigation("Event");
                });

            modelBuilder.Entity("MyEventsEntityFrameworkDb.Entities.Country", b =>
                {
                    b.HasOne("MyEventsEntityFrameworkDb.Entities.City", "City")
                        .WithMany("Countries")
                        .HasForeignKey("CityId");

                    b.Navigation("City");
                });

            modelBuilder.Entity("MyEventsEntityFrameworkDb.Entities.Event", b =>
                {
                    b.HasOne("MyEventsEntityFrameworkDb.Entities.City", "City")
                        .WithMany("Events")
                        .HasForeignKey("CityId");

                    b.HasOne("MyEventsEntityFrameworkDb.Entities.Country", "Country")
                        .WithMany("Events")
                        .HasForeignKey("CountryId");

                    b.HasOne("MyEventsEntityFrameworkDb.Entities.Gallery", "Gallery")
                        .WithMany("Events")
                        .HasForeignKey("GalleryId");

                    b.HasOne("MyEventsEntityFrameworkDb.Entities.User", "User")
                        .WithMany("Events")
                        .HasForeignKey("UserId");

                    b.Navigation("City");

                    b.Navigation("Country");

                    b.Navigation("Gallery");

                    b.Navigation("User");
                });

            modelBuilder.Entity("MyEventsEntityFrameworkDb.Entities.Image", b =>
                {
                    b.HasOne("MyEventsEntityFrameworkDb.Entities.Gallery", "Gallery")
                        .WithMany("Images")
                        .HasForeignKey("GalleryId");

                    b.HasOne("MyEventsEntityFrameworkDb.Entities.User", "User")
                        .WithMany("Images")
                        .HasForeignKey("UserId");

                    b.Navigation("Gallery");

                    b.Navigation("User");
                });

            modelBuilder.Entity("MyEventsEntityFrameworkDb.Entities.Message", b =>
                {
                    b.HasOne("MyEventsEntityFrameworkDb.Entities.Event", "Event")
                        .WithMany("Messages")
                        .HasForeignKey("EventId");

                    b.HasOne("MyEventsEntityFrameworkDb.Entities.User", "User")
                        .WithMany("Messages")
                        .HasForeignKey("UserId");

                    b.Navigation("Event");

                    b.Navigation("User");
                });

            modelBuilder.Entity("MyEventsEntityFrameworkDb.Entities.User", b =>
                {
                    b.HasOne("MyEventsEntityFrameworkDb.Entities.City", "City")
                        .WithMany("Users")
                        .HasForeignKey("CityId");

                    b.HasOne("MyEventsEntityFrameworkDb.Entities.Country", "Country")
                        .WithMany("Users")
                        .HasForeignKey("CountryId");

                    b.HasOne("MyEventsEntityFrameworkDb.Entities.Role", "Role")
                        .WithOne("User")
                        .HasForeignKey("MyEventsEntityFrameworkDb.Entities.User", "RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("City");

                    b.Navigation("Country");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("MyEventsEntityFrameworkDb.Entities.Category", b =>
                {
                    b.Navigation("CategoriesEvents");
                });

            modelBuilder.Entity("MyEventsEntityFrameworkDb.Entities.City", b =>
                {
                    b.Navigation("Countries");

                    b.Navigation("Events");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("MyEventsEntityFrameworkDb.Entities.Country", b =>
                {
                    b.Navigation("Events");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("MyEventsEntityFrameworkDb.Entities.Event", b =>
                {
                    b.Navigation("CategoriesEvents");

                    b.Navigation("Messages");
                });

            modelBuilder.Entity("MyEventsEntityFrameworkDb.Entities.Gallery", b =>
                {
                    b.Navigation("Events");

                    b.Navigation("Images");
                });

            modelBuilder.Entity("MyEventsEntityFrameworkDb.Entities.Role", b =>
                {
                    b.Navigation("User")
                        .IsRequired();
                });

            modelBuilder.Entity("MyEventsEntityFrameworkDb.Entities.User", b =>
                {
                    b.Navigation("Events");

                    b.Navigation("Images");

                    b.Navigation("Messages");
                });
#pragma warning restore 612, 618
        }
    }
}
