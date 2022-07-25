using Microsoft.EntityFrameworkCore;
using MyEventsEntityFrameworkDb.Entities;

namespace MyEventsEntityFrameworkDb.DbContexts
{
    public partial class MyEventsDbContext : DbContext
    {
        public MyEventsDbContext()
        {
        }

        public MyEventsDbContext(DbContextOptions<MyEventsDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CategoriesEvent> CategoriesEvents { get; set; } = null!;
        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<City> Cities { get; set; } = null!;
        public virtual DbSet<Country> Countries { get; set; } = null!;
        public virtual DbSet<Event> Events { get; set; } = null!;
        public virtual DbSet<Gallery> Galleries { get; set; } = null!;
        public virtual DbSet<Image> Images { get; set; } = null!;
        public virtual DbSet<Message> Messages { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.;Initial Catalog=MyEventsDb;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CategoriesEvent>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CategoryId).HasColumnName("category_id");

                entity.Property(e => e.EventId).HasColumnName("event_id");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.CategoriesEvents)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK__Categorie__categ__02084FDA");

                entity.HasOne(d => d.Event)
                    .WithMany(p => p.CategoriesEvents)
                    .HasForeignKey(d => d.EventId)
                    .HasConstraintName("FK__Categorie__event__01142BA1");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasIndex(e => e.Name, "UQ__Categori__72E12F1B6CA6E7A6")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name).HasColumnName("name");
            });

            modelBuilder.Entity<City>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.HasIndex(e => e.Name, "UQ__Countrie__72E12F1B0A12FB18")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CityId).HasColumnName("city_id");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name");

                entity.HasOne(d => d.City)
                    .WithMany(p => p.Countries)
                    .HasForeignKey(d => d.CityId)
                    .HasConstraintName("FK__Countries__city___75A278F5");
            });

            modelBuilder.Entity<Event>(entity =>
            {
                entity.HasIndex(e => e.Name, "UQ__Events__72E12F1BCB86E8B3")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AcceptableAge).HasColumnName("acceptable_age");

                entity.Property(e => e.Address)
                    .HasMaxLength(80)
                    .HasColumnName("address")
                    .IsFixedLength();

                entity.Property(e => e.CityId).HasColumnName("city_id");

                entity.Property(e => e.CostOfVisit).HasColumnName("cost_of_visit");

                entity.Property(e => e.CountryId).HasColumnName("country_id");

                entity.Property(e => e.DateOfEvent)
                    .HasColumnType("date")
                    .HasColumnName("date_of_event");

                entity.Property(e => e.GalleryId).HasColumnName("gallery_id");

                entity.Property(e => e.Name)
                    .HasMaxLength(250)
                    .HasColumnName("name");

                entity.Property(e => e.TimeOfEvent).HasColumnName("time_of_event");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.City)
                    .WithMany(p => p.Events)
                    .HasForeignKey(d => d.CityId)
                    .HasConstraintName("FK__Events__city_id__787EE5A0");

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.Events)
                    .HasForeignKey(d => d.CountryId)
                    .HasConstraintName("FK__Events__country___797309D9");

                entity.HasOne(d => d.Gallery)
                    .WithMany(p => p.Events)
                    .HasForeignKey(d => d.GalleryId)
                    .HasConstraintName("FK__Events__gallery___7B5B524B");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Events)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Events__user_id__7A672E12");
            });

            modelBuilder.Entity<Gallery>(entity =>
            {
                entity.HasIndex(e => e.Name, "UQ__Gallerie__72E12F1B67329A7C")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Image>(entity =>
            {
                entity.HasIndex(e => e.Name, "UQ__Images__72E12F1B116F28F5")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.GalleryId).HasColumnName("gallery_id");

                entity.Property(e => e.Name)
                    .HasMaxLength(300)
                    .HasColumnName("name");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.Gallery)
                    .WithMany(p => p.Images)
                    .HasForeignKey(d => d.GalleryId)
                    .HasConstraintName("FK__Images__gallery___7C4F7684");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Images)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Images__user_id__7D439ABD");
            });

            modelBuilder.Entity<Message>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.EventId).HasColumnName("event_id");

                entity.Property(e => e.Message1)
                    .HasMaxLength(500)
                    .HasColumnName("message");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.Event)
                    .WithMany(p => p.Messages)
                    .HasForeignKey(d => d.EventId)
                    .HasConstraintName("FK__Messages__enent___7F2BE32F");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Messages)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Messages__user_i__00200768");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasIndex(e => e.Name, "UQ__Roles__72E12F1B4750934D")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(e => e.RoleId, "UQ__Users__760965CD1BC080B4")
                    .IsUnique();

                entity.HasIndex(e => e.Email, "UQ__Users__AB6E6164C19E76E7")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CityId).HasColumnName("city_id");

                entity.Property(e => e.CountryId).HasColumnName("country_id");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .HasColumnName("email");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .HasColumnName("first_name");

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .HasColumnName("password");

                entity.Property(e => e.RoleId).HasColumnName("role_id");

                entity.Property(e => e.SecondName)
                    .HasMaxLength(50)
                    .HasColumnName("second_name");

                entity.HasOne(d => d.City)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.CityId)
                    .HasConstraintName("FK__Users__city_id__778AC167");

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.CountryId)
                    .HasConstraintName("FK__Users__country_i__76969D2E");

                entity.HasOne(d => d.Role)
                    .WithOne(p => p.User)
                    .HasForeignKey<User>(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Users__role_id__7E37BEF6");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
