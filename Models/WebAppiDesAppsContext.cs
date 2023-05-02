using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ProyectoDesAppsPT2.Models;

public partial class WebAppiDesAppsContext : DbContext
{
    public WebAppiDesAppsContext()
    {
    }

    public WebAppiDesAppsContext(DbContextOptions<WebAppiDesAppsContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Tipo> Tipos { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    { 
        //To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        //=> optionsBuilder.UseSqlServer("Server=DESKTOP-C4M14GD ;Database=WebAppi_DesAPPS; TrustServerCertificate=True; Trusted_Connection=True;");
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Tipo>(entity =>
        {
            entity.HasKey(e => e.IdTipo).HasName("PK__TIPO__BDD0DFE16F0BAE58");

            entity.ToTable("TIPO");

            entity.Property(e => e.IdTipo).HasColumnName("idTipo");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("descripcion");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PK__USUARIOS__645723A624880436");

            entity.ToTable("USUARIOS");

            entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");
            entity.Property(e => e.ApellidoUsuario)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("apellidoUsuario");
            entity.Property(e => e.DireccionUsuario)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("direccionUsuario");
            entity.Property(e => e.EmailUsuario)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("emailUsuario");
            entity.Property(e => e.IdTipo).HasColumnName("idTipo");
            entity.Property(e => e.NombreUsuario)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombreUsuario");
            entity.Property(e => e.TelefonoUsuario)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("telefonoUsuario");

            entity.HasOne(d => d.IdTipoNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.IdTipo)
                .HasConstraintName("FK_idTipo");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
