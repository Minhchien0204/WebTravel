using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Webtravel.Models
{
    public partial class WebtravelContext : DbContext
    {
        public WebtravelContext()
        {
        }

        public WebtravelContext(DbContextOptions<WebtravelContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<CategoryPost> CategoryPost { get; set; }
        public virtual DbSet<Dattruoc> Dattruoc { get; set; }
        public virtual DbSet<House> House { get; set; }
        public virtual DbSet<HouseTienichs> HouseTienichs { get; set; }
        public virtual DbSet<Post> Post { get; set; }
        public virtual DbSet<Tienich> Tienich { get; set; }
        public virtual DbSet<Toado> Toado { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-FO8QLMB;Initial Catalog=Webtravel;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(e => e.IdCategory)
                    .HasName("PK__Category__AC5CA40E0EBA3371");

                entity.Property(e => e.IdCategory)
                    .HasColumnName("ID_category")
                    .ValueGeneratedNever();

                entity.Property(e => e.CategoryName)
                    .HasColumnName("Category_name")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<CategoryPost>(entity =>
            {
                entity.HasKey(e => new { e.IdPost, e.IdCategory })
                    .HasName("PK__Category__6CD95A9F2902DBE2");

                entity.ToTable("Category_post");

                entity.Property(e => e.IdPost).HasColumnName("ID_post");

                entity.Property(e => e.IdCategory).HasColumnName("ID_category");

                entity.HasOne(d => d.IdCategoryNavigation)
                    .WithMany(p => p.CategoryPost)
                    .HasForeignKey(d => d.IdCategory)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Category___ID_ca__44FF419A");

                entity.HasOne(d => d.IdPostNavigation)
                    .WithMany(p => p.CategoryPost)
                    .HasForeignKey(d => d.IdPost)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Category___ID_po__440B1D61");
            });

            modelBuilder.Entity<Dattruoc>(entity =>
            {
                entity.HasKey(e => e.IdDattruoc)
                    .HasName("PK__Dattruoc__2AABC871E94A018C");

                entity.Property(e => e.IdDattruoc)
                    .HasColumnName("ID_dattruoc")
                    .ValueGeneratedNever();

                entity.Property(e => e.IdUser).HasColumnName("ID_User");

                entity.Property(e => e.Ngaybatdau).HasColumnType("datetime");

                entity.Property(e => e.Ngayketthuc).HasColumnType("datetime");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.Dattruoc)
                    .HasForeignKey(d => d.IdUser)
                    .HasConstraintName("FK__Dattruoc__ID_Use__47DBAE45");
            });

            modelBuilder.Entity<House>(entity =>
            {
                entity.HasKey(e => e.IdHouse)
                    .HasName("PK__House__971841597FA9BA26");

                entity.Property(e => e.IdHouse)
                    .HasColumnName("ID_house")
                    .ValueGeneratedNever();

                entity.Property(e => e.Gia).HasColumnType("money");

                entity.Property(e => e.Giaphong).HasColumnType("money");

                entity.Property(e => e.IdPhong).HasColumnName("ID_phong");
            });

            modelBuilder.Entity<HouseTienichs>(entity =>
            {
                entity.HasKey(e => new { e.IdTienichdetail, e.IdHouse })
                    .HasName("PK__House_ti__D2DA31C708527051");

                entity.ToTable("House_tienichs");

                entity.Property(e => e.IdTienichdetail).HasColumnName("ID_tienichdetail");

                entity.Property(e => e.IdHouse).HasColumnName("ID_House");

                entity.HasOne(d => d.IdHouseNavigation)
                    .WithMany(p => p.HouseTienichs)
                    .HasForeignKey(d => d.IdHouse)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__House_tie__ID_Ho__5EBF139D");
            });

            modelBuilder.Entity<Post>(entity =>
            {
                entity.HasKey(e => e.IdPost)
                    .HasName("PK__Post__961C90DF5BBE333D");

                entity.Property(e => e.IdPost)
                    .HasColumnName("ID_post")
                    .ValueGeneratedNever();

                entity.Property(e => e.Content).HasColumnType("text");

                entity.Property(e => e.Diachi)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.IdHouse).HasColumnName("ID_house");

                entity.Property(e => e.IdToado).HasColumnName("ID_toado");

                entity.Property(e => e.IdUser).HasColumnName("ID_USer");

                entity.HasOne(d => d.IdHouseNavigation)
                    .WithMany(p => p.Post)
                    .HasForeignKey(d => d.IdHouse)
                    .HasConstraintName("FK__Post__ID_house__3F466844");

                entity.HasOne(d => d.IdToadoNavigation)
                    .WithMany(p => p.Post)
                    .HasForeignKey(d => d.IdToado)
                    .HasConstraintName("FK__Post__ID_toado__3E52440B");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.Post)
                    .HasForeignKey(d => d.IdUser)
                    .HasConstraintName("FK__Post__ID_house__3D5E1FD2");
            });

            modelBuilder.Entity<Tienich>(entity =>
            {
                entity.HasKey(e => e.IdTienich)
                    .HasName("PK__Tienich__5A168105D706B1E0");

                entity.Property(e => e.IdTienich)
                    .HasColumnName("ID_tienich")
                    .ValueGeneratedNever();

                entity.Property(e => e.LoaiTienich)
                    .HasColumnName("Loai_tienich")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Toado>(entity =>
            {
                entity.HasKey(e => e.IdToado)
                    .HasName("PK__Toado__0D9B52769C4B9CDF");

                entity.Property(e => e.IdToado)
                    .HasColumnName("ID_toado")
                    .ValueGeneratedNever();
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.IdUser)
                    .HasName("PK__USERS__ED4DE4423BB0CF70");

                entity.ToTable("USERS");

                entity.Property(e => e.IdUser)
                    .HasColumnName("ID_User")
                    .ValueGeneratedNever();

                entity.Property(e => e.Diachi).HasMaxLength(50);

                entity.Property(e => e.Ngaysinh).HasColumnType("date");

                entity.Property(e => e.Passwords)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.UserNames)
                    .HasColumnName("User_names")
                    .HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
