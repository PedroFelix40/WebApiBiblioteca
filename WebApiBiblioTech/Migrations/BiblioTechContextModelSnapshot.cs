﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using webapibibliotech.Contexts;

#nullable disable

namespace WebApiBiblioTech.Migrations
{
    [DbContext(typeof(BiblioTechContext))]
    partial class BiblioTechContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("webapibibliotech.Domains.EmprestimosLivro", b =>
                {
                    b.Property<Guid>("IDEmprestimoLivro")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DataDevolucao")
                        .HasColumnType("DATE");

                    b.Property<Guid>("IDLivro")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IDUsuario")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Situacao")
                        .IsRequired()
                        .HasColumnType("VARCHAR(60)");

                    b.HasKey("IDEmprestimoLivro");

                    b.HasIndex("IDLivro");

                    b.HasIndex("IDUsuario");

                    b.ToTable("EmprestimosLivro");
                });

            modelBuilder.Entity("webapibibliotech.Domains.Generos", b =>
                {
                    b.Property<Guid>("IDGenero")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("TituloGenero")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)");

                    b.HasKey("IDGenero");

                    b.ToTable("Generos");
                });

            modelBuilder.Entity("webapibibliotech.Domains.Livros", b =>
                {
                    b.Property<Guid>("IDLivro")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Ano")
                        .IsRequired()
                        .HasColumnType("VARCHAR(60)");

                    b.Property<string>("Autor")
                        .IsRequired()
                        .HasColumnType("VARCHAR(60)");

                    b.Property<string>("Capa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Editora")
                        .IsRequired()
                        .HasColumnType("VARCHAR(60)");

                    b.Property<Guid>("IDGenero")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ISBN")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("VARCHAR(60)");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("VARCHAR(60)");

                    b.HasKey("IDLivro");

                    b.HasIndex("IDGenero");

                    b.ToTable("Livros");
                });

            modelBuilder.Entity("webapibibliotech.Domains.Resenhas", b =>
                {
                    b.Property<Guid>("IDResenha")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("VARCHAR(200)");

                    b.Property<bool>("Exibe")
                        .HasColumnType("BIT");

                    b.Property<Guid>("IDLivro")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IDUsuario")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("IDResenha");

                    b.HasIndex("IDLivro");

                    b.HasIndex("IDUsuario");

                    b.ToTable("Resenhas");
                });

            modelBuilder.Entity("webapibibliotech.Domains.TiposUsuario", b =>
                {
                    b.Property<Guid>("IDTipoUsuario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("TituloTipoUsuario")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)");

                    b.HasKey("IDTipoUsuario");

                    b.ToTable("TiposUsuario");
                });

            modelBuilder.Entity("webapibibliotech.Domains.Usuarios", b =>
                {
                    b.Property<Guid>("IdUsuario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CodRecupSenha")
                        .HasColumnType("VARCHAR(60)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)");

                    b.Property<string>("Foto")
                        .HasColumnType("VARCHAR(60)");

                    b.Property<Guid>("IDTipoUsuario")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("VARCHAR(60)");

                    b.HasKey("IdUsuario");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("IDTipoUsuario");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("webapibibliotech.Domains.EmprestimosLivro", b =>
                {
                    b.HasOne("webapibibliotech.Domains.Livros", "Livro")
                        .WithMany()
                        .HasForeignKey("IDLivro")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("webapibibliotech.Domains.Usuarios", "Usuario")
                        .WithMany()
                        .HasForeignKey("IDUsuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Livro");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("webapibibliotech.Domains.Livros", b =>
                {
                    b.HasOne("webapibibliotech.Domains.Generos", "Genero")
                        .WithMany()
                        .HasForeignKey("IDGenero")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Genero");
                });

            modelBuilder.Entity("webapibibliotech.Domains.Resenhas", b =>
                {
                    b.HasOne("webapibibliotech.Domains.Livros", "Livro")
                        .WithMany()
                        .HasForeignKey("IDLivro")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("webapibibliotech.Domains.Usuarios", "Usuario")
                        .WithMany()
                        .HasForeignKey("IDUsuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Livro");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("webapibibliotech.Domains.Usuarios", b =>
                {
                    b.HasOne("webapibibliotech.Domains.TiposUsuario", "TipoUsuario")
                        .WithMany()
                        .HasForeignKey("IDTipoUsuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TipoUsuario");
                });
#pragma warning restore 612, 618
        }
    }
}
