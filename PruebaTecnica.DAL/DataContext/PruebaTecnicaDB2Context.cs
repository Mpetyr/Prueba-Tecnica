using Microsoft.EntityFrameworkCore;
using PruebaTecnica.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnica.DAL.DataContext
{
    public partial class PruebaTecnicaDB2Context : DbContext
    {
        public PruebaTecnicaDB2Context()
        {
        }

        public PruebaTecnicaDB2Context(DbContextOptions<PruebaTecnicaDB2Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Producto> Productos { get; set; }
        public virtual DbSet<Proveedor> Proveedores { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-JBKO4GR\\SQLEXPRESS; DataBase=PruebaTecnicaDB2;Integrated Security=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.HasKey(e => e.CodigoProducto);

                entity.ToTable("Producto");

                entity.Property(e => e.CodigoProveedorId).HasColumnName("CodigoProveedorID");

                entity.Property(e => e.DescripcionProducto)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.FechaFabricacion).HasColumnType("date");

                entity.Property(e => e.FechaValidez).HasColumnType("date");

                entity.HasOne(d => d.CodigoProveedor)
                    .WithMany(p => p.Productos)
                    .HasForeignKey(d => d.CodigoProveedorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Producto_Proveedor");
            });

            modelBuilder.Entity<Proveedor>(entity =>
            {
                entity.HasKey(e => e.CodigoProveedor);

                entity.ToTable("Proveedor");

                entity.Property(e => e.DescripcionProveedor)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
