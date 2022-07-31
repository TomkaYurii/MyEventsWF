﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyEventsEntityFrameworkDb.DbContexts;

#nullable disable

namespace MyEventsEntityFrameworkDb.Migrations
{
    [DbContext(typeof(MyEventsDbContext))]
    [Migration("20220731163036_2022_07_31")]
    partial class _2022_07_31
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
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("CategoryId")
                        .HasColumnType("int")
                        .HasColumnName("category_id");

                    b.Property<int?>("EventId")
                        .HasColumnType("int")
                        .HasColumnName("event_id");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("EventId");

                    b.ToTable("CategoriesEvents");
                });

            modelBuilder.Entity("MyEventsEntityFrameworkDb.Entities.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Name")
                        .HasColumnType("int")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "Name" }, "UQ__Categori__72E12F1B6CA6E7A6")
                        .IsUnique();

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("MyEventsEntityFrameworkDb.Entities.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("MyEventsEntityFrameworkDb.Entities.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("CityId")
                        .HasColumnType("int")
                        .HasColumnName("city_id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.HasIndex(new[] { "Name" }, "UQ__Countrie__72E12F1B0A12FB18")
                        .IsUnique();

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("MyEventsEntityFrameworkDb.Entities.Event", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("AcceptableAge")
                        .HasColumnType("int")
                        .HasColumnName("acceptable_age");

                    b.Property<string>("Address")
                        .HasMaxLength(80)
                        .HasColumnType("nchar(80)")
                        .HasColumnName("address")
                        .IsFixedLength();

                    b.Property<int?>("CityId")
                        .HasColumnType("int")
                        .HasColumnName("city_id");

                    b.Property<double?>("CostOfVisit")
                        .HasColumnType("float")
                        .HasColumnName("cost_of_visit");

                    b.Property<int?>("CountryId")
                        .HasColumnType("int")
                        .HasColumnName("country_id");

                    b.Property<DateTime?>("DateOfEvent")
                        .HasColumnType("date")
                        .HasColumnName("date_of_event");

                    b.Property<int?>("GalleryId")
                        .HasColumnType("int")
                        .HasColumnName("gallery_id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)")
                        .HasColumnName("name");

                    b.Property<TimeSpan?>("TimeOfEvent")
                        .HasColumnType("time")
                        .HasColumnName("time_of_event");

                    b.Property<int?>("UserId")
                        .HasColumnType("int")
                        .HasColumnName("user_id");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.HasIndex("CountryId");

                    b.HasIndex("GalleryId");

                    b.HasIndex("UserId");

                    b.HasIndex(new[] { "Name" }, "UQ__Events__72E12F1BCB86E8B3")
                        .IsUnique();

                    b.ToTable("Events");
                });

            modelBuilder.Entity("MyEventsEntityFrameworkDb.Entities.Gallery", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "Name" }, "UQ__Gallerie__72E12F1B67329A7C")
                        .IsUnique();

                    b.ToTable("Galleries");
                });

            modelBuilder.Entity("MyEventsEntityFrameworkDb.Entities.Image", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("GalleryId")
                        .HasColumnType("int")
                        .HasColumnName("gallery_id");

                    b.Property<byte[]>("ImageBytes")
                        .HasColumnType("image");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)")
                        .HasColumnName("name");

                    b.Property<int?>("UserId")
                        .HasColumnType("int")
                        .HasColumnName("user_id");

                    b.HasKey("Id");

                    b.HasIndex("GalleryId");

                    b.HasIndex("UserId");

                    b.HasIndex(new[] { "Name" }, "UQ__Images__72E12F1B116F28F5")
                        .IsUnique();

                    b.ToTable("Images");
                });

            modelBuilder.Entity("MyEventsEntityFrameworkDb.Entities.Message", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("EventId")
                        .HasColumnType("int")
                        .HasColumnName("event_id");

                    b.Property<string>("Message1")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)")
                        .HasColumnName("message");

                    b.Property<int?>("UserId")
                        .HasColumnType("int")
                        .HasColumnName("user_id");

                    b.HasKey("Id");

                    b.HasIndex("EventId");

                    b.HasIndex("UserId");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("MyEventsEntityFrameworkDb.Entities.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "Name" }, "UQ__Roles__72E12F1B4750934D")
                        .IsUnique();

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("MyEventsEntityFrameworkDb.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("CityId")
                        .HasColumnType("int")
                        .HasColumnName("city_id");

                    b.Property<int?>("CountryId")
                        .HasColumnType("int")
                        .HasColumnName("country_id");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("email");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("first_name");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("password");

                    b.Property<int>("RoleId")
                        .HasColumnType("int")
                        .HasColumnName("role_id");

                    b.Property<string>("SecondName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("second_name");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.HasIndex("CountryId");

                    b.HasIndex(new[] { "RoleId" }, "UQ__Users__760965CD1BC080B4")
                        .IsUnique();

                    b.HasIndex(new[] { "Email" }, "UQ__Users__AB6E6164C19E76E7")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("MyEventsEntityFrameworkDb.Entities.CategoriesEvent", b =>
                {
                    b.HasOne("MyEventsEntityFrameworkDb.Entities.Category", "Category")
                        .WithMany("CategoriesEvents")
                        .HasForeignKey("CategoryId")
                        .HasConstraintName("FK__Categorie__categ__02084FDA");

                    b.HasOne("MyEventsEntityFrameworkDb.Entities.Event", "Event")
                        .WithMany("CategoriesEvents")
                        .HasForeignKey("EventId")
                        .HasConstraintName("FK__Categorie__event__01142BA1");

                    b.Navigation("Category");

                    b.Navigation("Event");
                });

            modelBuilder.Entity("MyEventsEntityFrameworkDb.Entities.Country", b =>
                {
                    b.HasOne("MyEventsEntityFrameworkDb.Entities.City", "City")
                        .WithMany("Countries")
                        .HasForeignKey("CityId")
                        .HasConstraintName("FK__Countries__city___75A278F5");

                    b.Navigation("City");
                });

            modelBuilder.Entity("MyEventsEntityFrameworkDb.Entities.Event", b =>
                {
                    b.HasOne("MyEventsEntityFrameworkDb.Entities.City", "City")
                        .WithMany("Events")
                        .HasForeignKey("CityId")
                        .HasConstraintName("FK__Events__city_id__787EE5A0");

                    b.HasOne("MyEventsEntityFrameworkDb.Entities.Country", "Country")
                        .WithMany("Events")
                        .HasForeignKey("CountryId")
                        .HasConstraintName("FK__Events__country___797309D9");

                    b.HasOne("MyEventsEntityFrameworkDb.Entities.Gallery", "Gallery")
                        .WithMany("Events")
                        .HasForeignKey("GalleryId")
                        .HasConstraintName("FK__Events__gallery___7B5B524B");

                    b.HasOne("MyEventsEntityFrameworkDb.Entities.User", "User")
                        .WithMany("Events")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK__Events__user_id__7A672E12");

                    b.Navigation("City");

                    b.Navigation("Country");

                    b.Navigation("Gallery");

                    b.Navigation("User");
                });

            modelBuilder.Entity("MyEventsEntityFrameworkDb.Entities.Image", b =>
                {
                    b.HasOne("MyEventsEntityFrameworkDb.Entities.Gallery", "Gallery")
                        .WithMany("Images")
                        .HasForeignKey("GalleryId")
                        .HasConstraintName("FK__Images__gallery___7C4F7684");

                    b.HasOne("MyEventsEntityFrameworkDb.Entities.User", "User")
                        .WithMany("Images")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK__Images__user_id__7D439ABD");

                    b.Navigation("Gallery");

                    b.Navigation("User");
                });

            modelBuilder.Entity("MyEventsEntityFrameworkDb.Entities.Message", b =>
                {
                    b.HasOne("MyEventsEntityFrameworkDb.Entities.Event", "Event")
                        .WithMany("Messages")
                        .HasForeignKey("EventId")
                        .HasConstraintName("FK__Messages__enent___7F2BE32F");

                    b.HasOne("MyEventsEntityFrameworkDb.Entities.User", "User")
                        .WithMany("Messages")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK__Messages__user_i__00200768");

                    b.Navigation("Event");

                    b.Navigation("User");
                });

            modelBuilder.Entity("MyEventsEntityFrameworkDb.Entities.User", b =>
                {
                    b.HasOne("MyEventsEntityFrameworkDb.Entities.City", "City")
                        .WithMany("Users")
                        .HasForeignKey("CityId")
                        .HasConstraintName("FK__Users__city_id__778AC167");

                    b.HasOne("MyEventsEntityFrameworkDb.Entities.Country", "Country")
                        .WithMany("Users")
                        .HasForeignKey("CountryId")
                        .HasConstraintName("FK__Users__country_i__76969D2E");

                    b.HasOne("MyEventsEntityFrameworkDb.Entities.Role", "Role")
                        .WithOne("User")
                        .HasForeignKey("MyEventsEntityFrameworkDb.Entities.User", "RoleId")
                        .IsRequired()
                        .HasConstraintName("FK__Users__role_id__7E37BEF6");

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
