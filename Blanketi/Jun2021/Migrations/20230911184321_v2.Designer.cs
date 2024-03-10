﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Models;

#nullable disable

namespace WebTemplate.Migrations
{
    [DbContext(typeof(IspitContext))]
    [Migration("20230911184321_v2")]
    partial class v2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Models.Meni", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.HasKey("ID");

                    b.ToTable("Menii");
                });

            modelBuilder.Entity("Models.Prodavnica", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Lokacija")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("MeniiID")
                        .HasColumnType("int");

                    b.Property<string>("Naziv")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("ZaliheUProdavniciID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("MeniiID");

                    b.HasIndex("ZaliheUProdavniciID");

                    b.ToTable("Prodavnice");
                });

            modelBuilder.Entity("Models.Proizvod", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Lokacija")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("MeniID")
                        .HasColumnType("int");

                    b.Property<string>("Naziv")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("ZaliheProizvodaID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("MeniID");

                    b.HasIndex("ZaliheProizvodaID");

                    b.ToTable("Proizvodi");
                });

            modelBuilder.Entity("Models.Sastojak", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Naziv")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("ProizvodID")
                        .HasColumnType("int");

                    b.Property<int?>("ZaliheSastojkaID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("ProizvodID");

                    b.HasIndex("ZaliheSastojkaID");

                    b.ToTable("Sastojci");
                });

            modelBuilder.Entity("Models.Zalihe", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("Kolicina")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("Zalihe");
                });

            modelBuilder.Entity("Models.Prodavnica", b =>
                {
                    b.HasOne("Models.Meni", "Menii")
                        .WithMany()
                        .HasForeignKey("MeniiID");

                    b.HasOne("Models.Zalihe", "ZaliheUProdavnici")
                        .WithMany()
                        .HasForeignKey("ZaliheUProdavniciID");

                    b.Navigation("Menii");

                    b.Navigation("ZaliheUProdavnici");
                });

            modelBuilder.Entity("Models.Proizvod", b =>
                {
                    b.HasOne("Models.Meni", null)
                        .WithMany("ListaProizvoda")
                        .HasForeignKey("MeniID");

                    b.HasOne("Models.Zalihe", "ZaliheProizvoda")
                        .WithMany()
                        .HasForeignKey("ZaliheProizvodaID");

                    b.Navigation("ZaliheProizvoda");
                });

            modelBuilder.Entity("Models.Sastojak", b =>
                {
                    b.HasOne("Models.Proizvod", null)
                        .WithMany("ListaSastojaka")
                        .HasForeignKey("ProizvodID");

                    b.HasOne("Models.Zalihe", "ZaliheSastojka")
                        .WithMany()
                        .HasForeignKey("ZaliheSastojkaID");

                    b.Navigation("ZaliheSastojka");
                });

            modelBuilder.Entity("Models.Meni", b =>
                {
                    b.Navigation("ListaProizvoda");
                });

            modelBuilder.Entity("Models.Proizvod", b =>
                {
                    b.Navigation("ListaSastojaka");
                });
#pragma warning restore 612, 618
        }
    }
}
