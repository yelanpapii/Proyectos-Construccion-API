using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using ProyectosConstruccion.Persistencia.Models;

#nullable disable

namespace ProyectosConstruccion.Persistencia.DataContext
{
    public partial class proyectoconstruccionContext : DbContext
    {
        public proyectoconstruccionContext()
        {
        }

        public proyectoconstruccionContext(DbContextOptions<proyectoconstruccionContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Compra> Compras { get; set; }
        public virtual DbSet<Lider> Liders { get; set; }
        public virtual DbSet<Materialconstruccion> Materialconstruccions { get; set; }
        public virtual DbSet<Proyecto> Proyectos { get; set; }
        public virtual DbSet<Tipo> Tipos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySQL("server=localhost;database=proyectoconstruccion;uid=root;pwd=rochyrd");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Compra>(entity =>
            {
                entity.HasKey(e => e.IdCompra)
                    .HasName("PRIMARY");

                entity.ToTable("compra");

                entity.HasIndex(e => e.IdMaterialConstruccion, "compra_materialconstruccion_fk");

                entity.HasIndex(e => e.IdProyecto, "compra_proyecto_fk");

                entity.Property(e => e.IdCompra)
                    .HasColumnType("smallint(6)")
                    .HasColumnName("ID_Compra");

                entity.Property(e => e.Cantidad).HasColumnType("tinyint(4)");

                entity.Property(e => e.Fecha).HasMaxLength(0);

                entity.Property(e => e.IdMaterialConstruccion)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("ID_MaterialConstruccion");

                entity.Property(e => e.IdProyecto)
                    .HasColumnType("smallint(6)")
                    .HasColumnName("ID_Proyecto");

                entity.Property(e => e.Pagado).HasMaxLength(12);

                entity.Property(e => e.Proveedor).HasMaxLength(21);

                entity.HasOne(d => d.IdMaterialConstruccionNavigation)
                    .WithMany(p => p.Compras)
                    .HasForeignKey(d => d.IdMaterialConstruccion)
                    .HasConstraintName("compra_materialconstruccion_fk");

                entity.HasOne(d => d.IdProyectoNavigation)
                    .WithMany(p => p.Compras)
                    .HasForeignKey(d => d.IdProyecto)
                    .HasConstraintName("compra_proyecto_fk");
            });

            modelBuilder.Entity<Lider>(entity =>
            {
                entity.HasKey(e => e.IdLider)
                    .HasName("PRIMARY");

                entity.ToTable("lider");

                entity.Property(e => e.IdLider)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("ID_Lider");

                entity.Property(e => e.Cargo).HasMaxLength(11);

                entity.Property(e => e.CiudadResidencia)
                    .HasMaxLength(12)
                    .HasColumnName("Ciudad_Residencia");

                entity.Property(e => e.Clasificacion).HasColumnType("decimal(2,1)");

                entity.Property(e => e.DocumentoIdentidad)
                    .HasMaxLength(7)
                    .HasColumnName("Documento_Identidad");

                entity.Property(e => e.FechaNacimiento)
                    .HasMaxLength(0)
                    .HasColumnName("Fecha_Nacimiento");

                entity.Property(e => e.Nombre).HasMaxLength(9);

                entity.Property(e => e.PrimerApellido)
                    .HasMaxLength(9)
                    .HasColumnName("Primer_Apellido");

                entity.Property(e => e.Salario).HasColumnType("mediumint(9)");

                entity.Property(e => e.SegundoApellido)
                    .HasMaxLength(9)
                    .HasColumnName("Segundo_Apellido");
            });

            modelBuilder.Entity<Materialconstruccion>(entity =>
            {
                entity.HasKey(e => e.IdMaterialConstruccion)
                    .HasName("PRIMARY");

                entity.ToTable("materialconstruccion");

                entity.Property(e => e.IdMaterialConstruccion)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("ID_MaterialConstruccion");

                entity.Property(e => e.Importado).HasMaxLength(2);

                entity.Property(e => e.NombreMaterial)
                    .HasMaxLength(13)
                    .HasColumnName("Nombre_Material");

                entity.Property(e => e.PrecioUnidad)
                    .HasColumnType("smallint(6)")
                    .HasColumnName("Precio_Unidad");
            });

            modelBuilder.Entity<Proyecto>(entity =>
            {
                entity.HasKey(e => e.IdProyecto)
                    .HasName("PRIMARY");

                entity.ToTable("proyecto");

                entity.HasIndex(e => e.IdLider, "proyecto_lider_fk");

                entity.HasIndex(e => e.IdTipo, "proyecto_tipo_fk");

                entity.Property(e => e.IdProyecto)
                    .HasColumnType("smallint(6)")
                    .HasColumnName("ID_Proyecto");

                entity.Property(e => e.Acabados).HasMaxLength(2);

                entity.Property(e => e.BancoVinculado)
                    .HasMaxLength(18)
                    .HasColumnName("Banco_Vinculado");

                entity.Property(e => e.Ciudad).HasMaxLength(18);

                entity.Property(e => e.Clasificacion).HasMaxLength(14);

                entity.Property(e => e.Constructora).HasMaxLength(21);

                entity.Property(e => e.FechaInicio)
                    .HasMaxLength(0)
                    .HasColumnName("Fecha_Inicio");

                entity.Property(e => e.IdLider)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("ID_Lider");

                entity.Property(e => e.IdTipo)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("ID_Tipo");

                entity.Property(e => e.NumeroBanos)
                    .HasColumnType("decimal(2,1)")
                    .HasColumnName("Numero_Banos");

                entity.Property(e => e.NumeroHabitaciones)
                    .HasColumnType("decimal(2,1)")
                    .HasColumnName("Numero_Habitaciones");

                entity.Property(e => e.PorcentajeCuotaInicial)
                    .HasColumnType("decimal(2,1)")
                    .HasColumnName("Porcentaje_Cuota_Inicial");

                entity.Property(e => e.Serial).HasMaxLength(9);

                entity.HasOne(d => d.IdLiderNavigation)
                    .WithMany(p => p.Proyectos)
                    .HasForeignKey(d => d.IdLider)
                    .HasConstraintName("proyecto_lider_fk");

                entity.HasOne(d => d.IdTipoNavigation)
                    .WithMany(p => p.Proyectos)
                    .HasForeignKey(d => d.IdTipo)
                    .HasConstraintName("proyecto_tipo_fk");
            });

            modelBuilder.Entity<Tipo>(entity =>
            {
                entity.HasKey(e => e.IdTipo)
                    .HasName("PRIMARY");

                entity.ToTable("tipo");

                entity.Property(e => e.IdTipo)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("ID_Tipo");

                entity.Property(e => e.AreaMax)
                    .HasColumnType("smallint(6)")
                    .HasColumnName("Area_Max");

                entity.Property(e => e.CodigoTipo)
                    .HasColumnType("smallint(6)")
                    .HasColumnName("Codigo_Tipo");

                entity.Property(e => e.Estrato).HasColumnType("tinyint(4)");

                entity.Property(e => e.Financiable).HasColumnType("tinyint(4)");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
