using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PizzaBox.Data.Entities
{
    public partial class PizzaBoxDB2Context : DbContext
    {
        public PizzaBoxDB2Context()
        {
        }

        public PizzaBoxDB2Context(DbContextOptions<PizzaBoxDB2Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Crust> Crust { get; set; }
        public virtual DbSet<Location> Location { get; set; }
        public virtual DbSet<Login> Login { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<Pizza> Pizza { get; set; }
        public virtual DbSet<PizzaToppingsRel> PizzaToppingsRel { get; set; }
        public virtual DbSet<Size> Size { get; set; }
        public virtual DbSet<ToppingsDb> ToppingsDb { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=tcp:pizza-jarrett.database.windows.net,1433;Initial Catalog=PizzaBoxDB2;Persist Security Info=False;User ID=sqladmin;Password=Password1;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<Crust>(entity =>
            {
                entity.ToTable("Crust", "Pizza");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Price).HasColumnType("numeric(3, 2)");
            });

            modelBuilder.Entity<Location>(entity =>
            {
                entity.ToTable("Location", "Pizza");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Address2)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.State)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ZipCode)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Login>(entity =>
            {
                entity.ToTable("Login", "Pizza");

                entity.HasIndex(e => e.UserName)
                    .HasName("UQ__Login__C9F28456F18BB063")
                    .IsUnique();

                entity.Property(e => e.Password).HasMaxLength(50);

                entity.Property(e => e.UserName).HasMaxLength(50);
            });

            modelBuilder.Entity<Orders>(entity =>
            {
                entity.ToTable("Orders", "Pizza");

                entity.Property(e => e.CustUserName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Price).HasColumnType("numeric(12, 2)");
            });

            modelBuilder.Entity<Pizza>(entity =>
            {
                entity.ToTable("Pizza", "Pizza");

                entity.Property(e => e.Price).HasColumnType("numeric(12, 2)");

                entity.HasOne(d => d.Crust)
                    .WithMany(p => p.Pizza)
                    .HasForeignKey(d => d.CrustId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CrustId");

                entity.HasOne(d => d.Orders)
                    .WithMany(p => p.Pizza)
                    .HasForeignKey(d => d.OrdersId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrdersId");

                entity.HasOne(d => d.Size)
                    .WithMany(p => p.Pizza)
                    .HasForeignKey(d => d.SizeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SizeId");
            });

            modelBuilder.Entity<PizzaToppingsRel>(entity =>
            {
                entity.HasKey(e => e.RelId)
                    .HasName("PK__PizzaTop__2DA9EFAE4778BC2E");

                entity.ToTable("PizzaToppingsRel", "Pizza");

                entity.HasOne(d => d.Pizza)
                    .WithMany(p => p.PizzaToppingsRel)
                    .HasForeignKey(d => d.PizzaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PizzaTopp__Pizza__5FB337D6");

                entity.HasOne(d => d.Toppings)
                    .WithMany(p => p.PizzaToppingsRel)
                    .HasForeignKey(d => d.ToppingsId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PizzaTopp__Toppi__60A75C0F");
            });

            modelBuilder.Entity<Size>(entity =>
            {
                entity.ToTable("Size", "Pizza");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Price).HasColumnType("numeric(3, 2)");
            });

            modelBuilder.Entity<ToppingsDb>(entity =>
            {
                entity.HasKey(e => e.ToppingsId)
                    .HasName("PK_ToppingsDBId");

                entity.ToTable("ToppingsDB", "Pizza");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Price).HasColumnType("numeric(12, 2)");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.ToTable("Users", "Pizza");

                entity.Property(e => e.Address).HasMaxLength(50);

                entity.Property(e => e.Address2).HasMaxLength(50);

                entity.Property(e => e.City).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.State).HasMaxLength(50);

                entity.Property(e => e.ZipCode).HasMaxLength(50);

                entity.HasOne(d => d.Login)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.LoginId)
                    .HasConstraintName("FK_LoginId");
            });
        }
    }
}
