﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using BaseProject.DAO.Models;

namespace BaseProject.DAO.Data
{
    public partial class ApplicationDbContext : IdentityDbContext<AspNetUser>
    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Download> Download { get; set; }
        public virtual DbSet<DownloadArquivo> DownloadArquivo { get; set; }
        public virtual DbSet<Empresa> Empresa { get; set; }
        public virtual DbSet<EmpresaLogo> EmpresaLogo { get; set; }
        public virtual DbSet<Log> Log { get; set; }
        public virtual DbSet<LogAcessoUsuario> LogAcessoUsuario { get; set; }
        public virtual DbSet<LogOpenAI> LogOpenAI { get; set; }
        public virtual DbSet<Upload> Upload { get; set; }
        public virtual DbSet<UploadArquivo> UploadArquivo { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }
        public virtual DbSet<UsuarioFoto> UsuarioFoto { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
				var configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
                optionsBuilder.UseSqlServer(configuration.GetConnectionString(Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Download>(entity =>
            {
                entity.HasOne(d => d.IdEmpresaNavigation)
                    .WithMany(p => p.Download)
                    .HasForeignKey(d => d.IdEmpresa)
                    .HasConstraintName("FK_Download_Empresa");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Download)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK_Download_Usuario");
            });

            modelBuilder.Entity<DownloadArquivo>(entity =>
            {
                entity.Property(e => e.IdDownload).ValueGeneratedNever();

                entity.HasOne(d => d.IdDownloadNavigation)
                    .WithOne(p => p.DownloadArquivo)
                    .HasForeignKey<DownloadArquivo>(d => d.IdDownload)
                    .HasConstraintName("FK_DownloadArquivo_Download");
            });

            modelBuilder.Entity<Empresa>(entity =>
            {
                entity.Property(e => e.CNPJ).IsFixedLength();

                entity.HasOne(d => d.IdRepresentanteNavigation)
                    .WithMany(p => p.Empresa)
                    .HasForeignKey(d => d.IdRepresentante)
                    .HasConstraintName("FK_Empresa_Representante");
            });

            modelBuilder.Entity<EmpresaLogo>(entity =>
            {
                entity.Property(e => e.IdEmpresa).ValueGeneratedNever();

                entity.HasOne(d => d.IdEmpresaNavigation)
                    .WithOne(p => p.EmpresaLogo)
                    .HasForeignKey<EmpresaLogo>(d => d.IdEmpresa)
                    .HasConstraintName("FK_Empresa_Logo");
            });

            modelBuilder.Entity<LogAcessoUsuario>(entity =>
            {
                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.LogAcessoUsuario)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK_Usuario_LogAcessoUsuario");
            });

            modelBuilder.Entity<LogOpenAI>(entity =>
            {
                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.LogOpenAI)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK_LogOpenAI_Usuario");
            });

            modelBuilder.Entity<Upload>(entity =>
            {
                entity.Property(e => e.MD5).IsFixedLength();

                entity.HasOne(d => d.IdEmpresaNavigation)
                    .WithMany(p => p.Upload)
                    .HasForeignKey(d => d.IdEmpresa)
                    .HasConstraintName("FK_Upload_Empresa");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Upload)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK_Upload_Usuario");
            });

            modelBuilder.Entity<UploadArquivo>(entity =>
            {
                entity.Property(e => e.IdUpload).ValueGeneratedNever();

                entity.HasOne(d => d.IdUploadNavigation)
                    .WithOne(p => p.UploadArquivo)
                    .HasForeignKey<UploadArquivo>(d => d.IdUpload)
                    .HasConstraintName("FK_UploadArquivo_Upload");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.Property(e => e.CPF).IsFixedLength();

                entity.HasOne(d => d.IdEmpresaNavigation)
                    .WithMany(p => p.UsuarioIdEmpresaNavigation)
                    .HasForeignKey(d => d.IdEmpresa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Usuario_Empresa");

                entity.HasOne(d => d.IdEmpresaSelecionadaNavigation)
                    .WithMany(p => p.UsuarioIdEmpresaSelecionadaNavigation)
                    .HasForeignKey(d => d.IdEmpresaSelecionada)
                    .HasConstraintName("FK_Usuario_EmpresaSelecionada");
            });

            modelBuilder.Entity<UsuarioFoto>(entity =>
            {
                entity.Property(e => e.IdUsuario).ValueGeneratedNever();

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithOne(p => p.UsuarioFoto)
                    .HasForeignKey<UsuarioFoto>(d => d.IdUsuario)
                    .HasConstraintName("FK_Usuario_Foto");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}