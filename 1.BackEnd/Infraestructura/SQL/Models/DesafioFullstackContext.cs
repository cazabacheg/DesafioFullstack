using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace DesafioFullstack.Infraestructura.SQL.Models
{
    public partial class DesafioFullstackContext : DbContext
    {
        public DesafioFullstackContext()
        {
        }

        public DesafioFullstackContext(DbContextOptions<DesafioFullstackContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TbCategoria> TbCategorias { get; set; }
        public virtual DbSet<TbProducto> TbProductos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<TbCategoria>(entity =>
            {
                entity.HasKey(e => e.IdCategoria)
                    .HasName("PK__tb_categ__A3C02A1005ABC73B");

                entity.ToTable("tb_categorias");

                entity.Property(e => e.IdCategoria).ValueGeneratedNever();

                entity.Property(e => e.Descripcion).HasColumnType("text");

                entity.Property(e => e.NombreCategoria)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TbProducto>(entity =>
            {
                entity.HasKey(e => e.IdProducto)
                    .HasName("PK__tb_produ__09889210058514F1");

                entity.ToTable("tb_productos");

                entity.Property(e => e.IdProducto)
                    .HasMaxLength(7)
                    .IsUnicode(false);

                entity.Property(e => e.NombreProducto)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.PrecioUnidad).HasColumnType("decimal(10, 2)");

                entity.HasOne(d => d.IdCategoriaNavigation)
                    .WithMany(p => p.TbProductos)
                    .HasForeignKey(d => d.IdCategoria)
                    .HasConstraintName("FK__tb_produc__IdCat__49C3F6B7");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
