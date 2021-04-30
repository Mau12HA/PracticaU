using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace ArSpFi.Models
{
    public partial class ASF_2C_2021Context : DbContext
    {
        public ASF_2C_2021Context()
        {
        }

        public ASF_2C_2021Context(DbContextOptions<ASF_2C_2021Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Mensaje> Mensajes { get; set; }
        public virtual DbSet<Modulo> Modulos { get; set; }
        public virtual DbSet<Operacione> Operaciones { get; set; }
        public virtual DbSet<Reserva> Reservas { get; set; }
        public virtual DbSet<Rol> Rols { get; set; }
        public virtual DbSet<RolOperacion> RolOperacions { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Name=ASF:ConecctionString");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Mensaje>(entity =>
            {
                entity.HasKey(e => e.Idmensaje);

                entity.Property(e => e.Idmensaje).HasColumnName("IDMensaje");

                entity.Property(e => e.Comentario).IsRequired();

                entity.Property(e => e.EmailMensaje)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.FechaMensaje)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.NombreMensaje)
                    .IsRequired()
                    .HasMaxLength(250);
            });

            modelBuilder.Entity<Modulo>(entity =>
            {
                entity.HasKey(e => e.IdModulo);

                entity.Property(e => e.IdModulo).HasColumnName("Id_Modulo");

                entity.Property(e => e.NombModulo)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Operacione>(entity =>
            {
                entity.HasKey(e => e.IdOperacion);

                entity.Property(e => e.IdOperacion).HasColumnName("Id_Operacion");

                entity.Property(e => e.FkModulo).HasColumnName("FK_Modulo");

                entity.Property(e => e.NombOperacion)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.FkModuloNavigation)
                    .WithMany(p => p.Operaciones)
                    .HasForeignKey(d => d.FkModulo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Operaciones_Modulos");
            });

            modelBuilder.Entity<Reserva>(entity =>
            {
                entity.HasKey(e => e.IdReserva);

                entity.Property(e => e.IdReserva).HasColumnName("ID_Reserva");

                entity.Property(e => e.CorreoCliente)
                    .IsRequired()
                    .HasMaxLength(350);

                entity.Property(e => e.Duracion)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Estado)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FechaReservacion).HasColumnType("datetime");

                entity.Property(e => e.FkUsuario).HasColumnName("FK_Usuario");

                entity.Property(e => e.NombCliente)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.TelefonoCliente)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.TipoTour)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Yate)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.FkUsuarioNavigation)
                    .WithMany(p => p.Reservas)
                    .HasForeignKey(d => d.FkUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Reservas_Usuarios");
            });

            modelBuilder.Entity<Rol>(entity =>
            {
                entity.HasKey(e => e.IdRol);

                entity.ToTable("Rol");

                entity.Property(e => e.IdRol).HasColumnName("Id_Rol");

                entity.Property(e => e.NombRol)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<RolOperacion>(entity =>
            {
                entity.ToTable("Rol_Operacion");

                entity.Property(e => e.FkOperacion).HasColumnName("FK_Operacion");

                entity.Property(e => e.FkRol).HasColumnName("FK_Rol");

                entity.HasOne(d => d.FkOperacionNavigation)
                    .WithMany(p => p.RolOperacions)
                    .HasForeignKey(d => d.FkOperacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Rol_Operacion_Operaciones");

                entity.HasOne(d => d.FkRolNavigation)
                    .WithMany(p => p.RolOperacions)
                    .HasForeignKey(d => d.FkRol)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Rol_Operacion_Rol");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario);

                entity.Property(e => e.IdUsuario).HasColumnName("ID_Usuario");

                entity.Property(e => e.Activo)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Correo)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.FechaCreado)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FkRol).HasColumnName("FK_Rol");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(350);

                entity.HasOne(d => d.FkRolNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.FkRol)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Usuarios_Roles");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
