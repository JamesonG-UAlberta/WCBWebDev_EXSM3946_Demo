using DotNetReact_BackEnd.Models;
using Microsoft.EntityFrameworkCore;

namespace DotNetReact_BackEnd.Data
{
    public partial class DatabaseContext : DbContext
    {
        public DatabaseContext() : base() { }
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

        public virtual DbSet<Strings> Strings { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured) optionsBuilder.UseMySql("server=localhost;user=root;database=react_strings", ServerVersion.Parse("10.4.24-mariadb"));
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.UseCollation("utf8mb4_general_ci").HasCharSet("utf8mb4");

            modelBuilder.Entity<Strings>(entity =>
            {
                entity.HasKey(e => e.String);
                entity.ToTable("strings");
                entity.Property(e => e.String).HasColumnType("varchar(50)").HasColumnName("string");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}